/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file demo_cam_read.cs
 * @brief Example application reading from a camera using Phase
 */

using System;
using System.IO;

namespace I3DR
{
    namespace Phase
    {
        //!  Demo Camera Read class
        /*!
        Example application reading from a camera using Phase
        */
        class DemoCameraRead
        {
            static int Main(string[] args)
            {
                bool license_valid = StereoI3DRSGM.isLicenseValid();
                if (license_valid){
                    Console.WriteLine("I3DRSGM license accepted");
                } else {
                    Console.WriteLine("Missing or invalid I3DRSGM license");
                }

                string test_folder = ".phase_test";
                string data_folder = "test/data";
                string left_yaml = data_folder + "/left.yaml";
                string right_yaml = data_folder + "/right.yaml";
                string left_image_file = data_folder + "/left.png";
                string right_image_file = data_folder + "/right.png";
                string out_ply = test_folder + "/out.ply";
                string out_rgb_video = test_folder + "/rgb.mp4";
                string out_depth_video = test_folder + "/depth.avi";

                string left_serial = "0815-0000";
                string right_serial = "0815-0001";

                Directory.CreateDirectory(test_folder);

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

                CameraDeviceInfo device_info = new CameraDeviceInfo(
                    left_serial, right_serial, "virtual-camera",
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
                        left_image_file, right_image_file
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
                                // TODO display images
                                // viewer_left.setImage(disp_left_rgba, disp_width, disp_height, disp_stride);
                                // viewer_right.setImage(disp_right_rgba, disp_width, disp_height, disp_stride);
                                // viewer_disparity.setImage(disp_disparity_rgba, disp_width, disp_height, disp_stride);
                                // viewer_left.show(disp_time);
                                // viewer_right.show(disp_time);
                                // viewer_disparity.show(disp_time);
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
                                    // TODO display images
                                    // viewer_left.setImage(disp_left_rgba, disp_width, disp_height, disp_stride);
                                    // viewer_right.setImage(disp_right_rgba, disp_width, disp_height, disp_stride);
                                    // viewer_left.show(disp_time);
                                    // viewer_right.show(disp_time);
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
                                        // TODO display image
                                        // viewer_disparity.setImage(disp_disparity_rgba, disp_width, disp_height, disp_stride);
                                        // viewer_disparity.show(disp_time);
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
                                    // TODO display images
                                    // viewer_left.setImage(disp_left_rgba, disp_width, disp_height, disp_stride);
                                    // viewer_right.setImage(disp_right_rgba, disp_width, disp_height, disp_stride);
                                    // viewer_disparity.setImage(disp_disparity_rgba, disp_width, disp_height, disp_stride);
                                    // viewer_left.show(disp_time);
                                    // viewer_right.show(disp_time);
                                    // viewer_disparity.show(disp_time);
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