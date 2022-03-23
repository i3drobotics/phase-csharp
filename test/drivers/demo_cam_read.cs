/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file main.cs
 * @brief Example application using I3DR Stereo Vision C# API
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace I3DR
{
    namespace Phase
    {
        class ImageViewer
        {
            private Form form;
            private PictureBox pm;
            public ImageViewer(){
                form = new Form(){
                    FormBorderStyle = FormBorderStyle.FixedDialog
                };
                pm = new PictureBox(){
                    Dock = DockStyle.Fill
                };
                form.Controls.Add(pm);
            }

            public void setImage(byte[] byte_image, int width, int height, int stride){
                Bitmap bit_image = new Bitmap(width, height, stride, 
                    PixelFormat.Format32bppArgb,
                    Marshal.UnsafeAddrOfPinnedArrayElement(byte_image, 0));
                form.Size = new Size(width,height+25);
                pm.Image = bit_image;
            }

            public void show(int wait_time=10){
                form.TopMost = true;
                if (wait_time == 0){
                    form.ShowDialog();
                } else {
                    form.Show();
                    form.Refresh();
                    System.Threading.Thread.Sleep(wait_time);
                }
            }
        }

        class DemoCameraRead
        {
            static int Main(string[] args)
            {
                ImageViewer viewer_disparity = new ImageViewer();
                ImageViewer viewer_left = new ImageViewer();
                ImageViewer viewer_right = new ImageViewer();

                bool license_valid = StereoI3DRSGM.isLicenseValid();
                if (license_valid){
                    Console.WriteLine("I3DRSGM license accepted");
                } else {
                    Console.WriteLine("Missing or invalid I3DRSGM license");
                }
                string resource_folder = "resources";
                string camera_name = "stereotheatresim";
                string left_serial = "0815-0000";
                string right_serial = "0815-0001";
                string cal_type = "ros"; // ros / cv
                CameraDeviceType dev_type = CameraDeviceType.DEVICE_TYPE_GENERIC_PYLON; // DEVICE_TYPE_GENERIC_PYLON / DEVICE_TYPE_TITANIA
                bool use_test_images = true;
                int repeat_capture = 1;
                bool show_display = true;
                int disp_time = 1;

                CameraInterfaceType interface_type;
                if (use_test_images){
                    interface_type = CameraInterfaceType.INTERFACE_TYPE_VIRTUAL;
                } else {
                    interface_type = CameraInterfaceType.INTERFACE_TYPE_USB;
                }

                string left_yaml = resource_folder + "/test/" + camera_name + "/" + cal_type + "/left.yaml";
                string right_yaml = resource_folder + "/test/" + camera_name + "/" + cal_type + "/right.yaml";

                CameraDeviceInfo device_info = new CameraDeviceInfo(
                    left_serial, right_serial, camera_name,
                    dev_type, interface_type
                );

                StereoMatcherType matcher_type;
                if (license_valid){
                    matcher_type = StereoMatcherType.STEREO_MATCHER_I3DRSGM;
                } else {
                    matcher_type = StereoMatcherType.STEREO_MATCHER_BM;
                }

                StereoVision sv = new StereoVision(device_info, matcher_type, left_yaml, right_yaml);
                if (!sv.isValidCalibration()) {
                    Console.WriteLine("Failed to load calibration");
                    sv.dispose();
                    return 1;
                }

                Console.WriteLine("StereoVision instance created");
                if (use_test_images)
                {
                    sv.setTestImagePaths(
                        resource_folder + "/test/" + camera_name + "/left.png",
                        resource_folder + "/test/" + camera_name + "/right.png"
                    );
                }

                AbstractStereoMatcher matcher;
                sv.getMatcher(out matcher);
                if (matcher is StereoI3DRSGM){
                    Console.WriteLine("Is I3DRSGM");
                    ((StereoI3DRSGM)matcher).setWindowSize(3);
                    ((StereoI3DRSGM)matcher).setNumDisparities(49);
                    ((StereoI3DRSGM)matcher).setSpeckleMaxSize(1000);
                    ((StereoI3DRSGM)matcher).setSpeckleMaxDiff(0.5f);
                }
                
                Console.WriteLine("Connecting to camera...");
                bool ret = sv.connect();
                
                if (ret){
                    Console.WriteLine("Camera connected");
                    sv.startCapture();
                    int disp_width = (int)((float)sv.getWidth() * 0.25f);
                    int disp_height = (int)((float)sv.getHeight() * 0.25f);
                    int disp_stride = disp_width * 4;
                    Console.WriteLine("Running non-threaded camera capture...");
                    for (int i = 0; i < repeat_capture; i++)
                    {
                        Console.WriteLine("Waiting for result...");
                        StereoVisionReadResult read_result = sv.read();
                        if (read_result.valid)
                        {
                            Console.WriteLine("Stereo result received");
                            //float val = read_result.disparity[sv.getWidth()*r+nchannels*c+ch]; //useful to remember how to access array elements
                            byte[] disp_left = Utils.scaleImage(read_result.left_image, sv.getWidth(), sv.getHeight(), 0.25f);
                            byte[] disp_right = Utils.scaleImage(read_result.right_image, sv.getWidth(), sv.getHeight(), 0.25f);
                            byte[] norm_disparity = Utils.normaliseDisparity(read_result.disparity, sv.getWidth(), sv.getHeight());
                            byte[] disp_disparity = Utils.scaleImage(norm_disparity, sv.getWidth(), sv.getHeight(), 0.25f);
                            if (show_display) {
                                byte[] disp_left_rgba = Utils.bgr2bgra(disp_left, disp_width, disp_height);
                                byte[] disp_right_rgba = Utils.bgr2bgra(disp_right, disp_width, disp_height);
                                byte[] disp_disparity_rgba = Utils.bgr2bgra(disp_disparity, disp_width, disp_height);
                                viewer_left.setImage(disp_left_rgba, disp_width, disp_height, disp_stride);
                                viewer_right.setImage(disp_right_rgba, disp_width, disp_height, disp_stride);
                                viewer_disparity.setImage(disp_disparity_rgba, disp_width, disp_height, disp_stride);
                                viewer_left.show(disp_time);
                                viewer_right.show(disp_time);
                                viewer_disparity.show(disp_time);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Failed to read stereo result");
                        }
                    }

                    sv.disconnect();

                    Console.WriteLine("Camera disconnected");
                    ret = sv.connect();
                    if (ret)
                    {
                        sv.startCapture();
                        AbstractStereoCamera cam;
                        StereoCameraCalibration cal;
                        sv.getCamera(out cam);
                        sv.getCalibration(out cal);
                        int width = sv.getWidth();
                        int height = sv.getHeight();
                        Console.WriteLine("Running split threaded camera capture...");
                        for (int i = 0; i < repeat_capture; i++)
                        {
                            cam.startReadThread();
                            Console.WriteLine("Waiting for result...");
                            while (cam.isReadThreadRunning()) { }
                            CameraReadResult cam_result = cam.getReadThreadResult();
                            if (cam_result.valid)
                            {
                                StereoImagePair rect_image_pair = cal.rectify(
                                    cam_result.left_image, cam_result.right_image,
                                    width, height
                                );
                                Console.WriteLine("Starting compute...");
                                matcher.startComputeThread(rect_image_pair.left, rect_image_pair.right, width, height);
                                Console.WriteLine("Stereo result received");
                                Console.WriteLine("Framerate: {0}", cam.getFrameRate());
                                byte[] disp_left = Utils.scaleImage(rect_image_pair.left, width, height, 0.25f);
                                byte[] disp_right = Utils.scaleImage(rect_image_pair.right, width, height, 0.25f);
                                if (show_display)
                                {
                                    byte[] disp_left_rgba = Utils.bgr2bgra(disp_left, disp_width, disp_height);
                                    byte[] disp_right_rgba = Utils.bgr2bgra(disp_right, disp_width, disp_height);
                                    viewer_left.setImage(disp_left_rgba, disp_width, disp_height, disp_stride);
                                    viewer_right.setImage(disp_right_rgba, disp_width, disp_height, disp_stride);
                                    viewer_left.show(disp_time);
                                    viewer_right.show(disp_time);
                                }
                                Console.WriteLine("Waiting for result...");
                                while (matcher.isComputeThreadRunning()) { }
                                StereoMatcherComputeResult match_result = matcher.getComputeThreadResult(width, height);
                                if (match_result.valid)
                                {
                                    Console.WriteLine("Match result received");
                                    byte[] norm_disparity = Utils.normaliseDisparity(match_result.disparity, width, height);
                                    byte[] disp_disparity = Utils.scaleImage(norm_disparity, width, height, 0.25f);
                                    if (show_display)
                                    {
                                        byte[] disp_disparity_rgba = Utils.bgr2bgra(disp_disparity, disp_width, disp_height);
                                        viewer_disparity.setImage(disp_disparity_rgba, disp_width, disp_height, disp_stride);
                                        viewer_disparity.show(disp_time);
                                    }                                
                                }
                                else
                                {
                                    Console.WriteLine("Failed to compute stereo match");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Failed to read stereo result");
                            }
                        }

                        Console.WriteLine("Running threaded camera capture...");
                        for (int i = 0; i < repeat_capture; i++)
                        {
                            sv.startReadThread();
                            Console.WriteLine("Waiting for result...");
                            while (sv.isReadThreadRunning()) { }
                            StereoVisionReadResult result = sv.getReadThreadResult();
                            if (result.valid)
                            {
                                Console.WriteLine("Stereo result received");
                                Console.WriteLine("Framerate: {0}", cam.getFrameRate());
                                byte[] disp_left = Utils.scaleImage(result.left_image, width, height, 0.25f);
                                byte[] disp_right = Utils.scaleImage(result.right_image, width, height, 0.25f);
                                byte[] norm_disparity = Utils.normaliseDisparity(result.disparity, width, height);
                                byte[] disp_disparity = Utils.scaleImage(norm_disparity, width, height, 0.25f);
                                if (show_display)
                                {
                                    byte[] disp_left_rgba = Utils.bgr2bgra(disp_left, disp_width, disp_height);
                                    byte[] disp_right_rgba = Utils.bgr2bgra(disp_right, disp_width, disp_height);
                                    byte[] disp_disparity_rgba = Utils.bgr2bgra(disp_disparity, disp_width, disp_height);
                                    viewer_left.setImage(disp_left_rgba, disp_width, disp_height, disp_stride);
                                    viewer_right.setImage(disp_right_rgba, disp_width, disp_height, disp_stride);
                                    viewer_disparity.setImage(disp_disparity_rgba, disp_width, disp_height, disp_stride);
                                    viewer_left.show(disp_time);
                                    viewer_right.show(disp_time);
                                    viewer_disparity.show(disp_time);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Failed to read stereo result");
                            }
                        }
                    }
                    sv.disconnect();
                    Console.WriteLine("Camera disconnected");
                }
                sv.dispose();
                return 0;
            }
        }
    }
}