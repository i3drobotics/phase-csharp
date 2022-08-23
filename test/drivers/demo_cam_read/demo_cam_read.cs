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

                AbstractStereoCamera camera = StereoCamera.createStereoCamera(device_info);
                StereoCameraCalibration calibration = StereoCameraCalibration.calibrationFromYAML(
                    left_yaml, right_yaml
                );

                AbstractStereoMatcher matcher = StereoMatcher.createStereoMatcher(matcher_type);
                if (matcher is StereoI3DRSGM){
                    Console.WriteLine("Is I3DRSGM");
                    ((StereoI3DRSGM)matcher).setWindowSize(3);
                    ((StereoI3DRSGM)matcher).setNumDisparities(49);
                    ((StereoI3DRSGM)matcher).setSpeckleMaxSize(1000);
                    ((StereoI3DRSGM)matcher).setSpeckleMaxDiff(0.5f);
                }
                
                Console.WriteLine("Connecting to camera...");
                bool ret = camera.connect();
                
                if (ret){
                    Console.WriteLine("Camera connected");
                    camera.startCapture();
                    int disp_width = (int)((float)camera.getWidth() * 0.25f);
                    int disp_height = (int)((float)camera.getHeight() * 0.25f);
                    int disp_stride = disp_width * 4;
                    Console.WriteLine("Running non-threaded camera capture...");
                    for (int i = 0; i < repeat_capture; i++)
                    {
                        Console.WriteLine("Waiting for result...");
                        CameraReadResult read_result = camera.read();
                        if (read_result.valid)
                        {
                            Console.WriteLine("Stereo result received");
                            StereoMatcherComputeResult comp_result = matcher.compute(read_result.left, read_result.right, camera.getWidth(), camera.getHeight());
                            if (comp_result.valid){
                                //float val = read_result.disparity[sv.getWidth()*r+nchannels*c+ch]; //useful to remember how to access array elements
                                byte[] disp_left = Utils.scaleImage(read_result.left, camera.getWidth(), camera.getHeight(), 0.25f);
                                byte[] disp_right = Utils.scaleImage(read_result.right, camera.getWidth(), camera.getHeight(), 0.25f);
                                byte[] norm_disparity = Utils.normaliseDisparity(comp_result.disparity, camera.getWidth(), camera.getHeight());
                                byte[] disp_disparity = Utils.scaleImage(norm_disparity, camera.getWidth(), camera.getHeight(), 0.25f);
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
                                Console.WriteLine("Failed to compute stereo match");
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine("Failed to read stereo camera");
                        }
                    }

                    camera.disconnect();

                    Console.WriteLine("Camera disconnected");
                    ret = camera.connect();
                    if (ret)
                    {
                        camera.startCapture();
                        int width = camera.getWidth();
                        int height = camera.getHeight();
                        Console.WriteLine("Running split threaded camera capture...");
                        for (int i = 0; i < repeat_capture; i++)
                        {
                            camera.startReadThread();
                            Console.WriteLine("Waiting for result...");
                            while (camera.isReadThreadRunning()) { }
                            CameraReadResult cam_result = camera.getReadThreadResult();
                            if (cam_result.valid)
                            {
                                StereoImagePair rect_image_pair = calibration.rectify(
                                    cam_result.left, cam_result.right,
                                    width, height
                                );
                                Console.WriteLine("Starting compute...");
                                matcher.startComputeThread(rect_image_pair.left, rect_image_pair.right, width, height);
                                Console.WriteLine("Stereo result received");
                                Console.WriteLine("Framerate: {0}", camera.getFrameRate());
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
                    }
                    camera.disconnect();
                    Console.WriteLine("Camera disconnected");
                }
                camera.dispose();
                return 0;
            }
        }
    }
}