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
using I3DR.Phase;
using I3DR.Phase.Types;
using I3DR.Phase.StereoMatcher;
using I3DR.Phase.StereoCamera;
using I3DR.Phase.Calib;

namespace I3DR.PhaseDemo
{
    //!  Demo Camera Read class
    /*!
    Demo program read and display 20 frames of virtual Pylon camera
    */
    class DemoCameraRead
    {
        static int Main(string[] args)
        {
            string data_folder = "data";
            string left_image_file = data_folder + "/left.png";
            string right_image_file = data_folder + "/right.png";
            // Information of the virtual camera
            string left_serial = "0815-0000";
            string right_serial = "0815-0001";
            CameraDeviceType dev_type = CameraDeviceType.DEVICE_TYPE_GENERIC_PYLON;
            CameraInterfaceType interface_type = CameraInterfaceType.INTERFACE_TYPE_VIRTUAL;
            // Parameters for read and display 20 frames
            int frames = 20;
            float scaling_factor = 0.25f;

            // Create a CameraDeviceInfo for camera connection
            CameraDeviceInfo device_info = new CameraDeviceInfo(
                left_serial, right_serial, "virtual-camera",
                dev_type, interface_type
            );

            // Create camera
            AbstractStereoCamera cam = StereoCamera.createStereoCamera(device_info);
            cam.setTestImagePaths(left_image_file, right_image_file);
            
            // Connect camera and start data capture
            System.Console.WriteLine("Connecting to camera...");
            bool ret = cam.connect();
            System.Console.WriteLine("Camera connected: " + ret);

            int cam_width = cam.getWidth();
            int cam_height = cam.getHeight();
            int scal_width = (int)((float)cam_width * scaling_factor);
            int scal_height = (int)((float)cam_height * scaling_factor);

            // If camera is connected, start data capture
            if (ret) {
                cam.startCapture();
                System.Console.WriteLine("Running camera capture...");
                for (int i = 0; i < frames; i++) {
                    long start_read = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
                    CameraReadResult read_result = cam.read();
                    long end_read = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
                    long read_duration = end_read - start_read;
                    System.Console.WriteLine("Read speed: " + read_duration);
                    // Check if the stereo image pair is valid, display images if valid
                    if (read_result.valid) {
                        long start_proc = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
                        System.Console.WriteLine("Internal framerate: " + cam.getFrameRate());
                        // Display downsampled stereo images
                        byte[] disp_image_left = Utils.scaleImage(
                            read_result.left, cam_width, cam_height, scaling_factor);
                        byte[] disp_image_right = Utils.scaleImage(
                            read_result.right, cam_width, cam_height, scaling_factor);
                        int c_l = Utils.showImage("left", disp_image_left, scal_width, scal_height);
                        int c_r = Utils.showImage("right", disp_image_right, scal_width, scal_height);
                        // If q is pressed, stop camera read
                        if ((char)c_l == 'q' || (char)c_r == 'q') break;
                        long end_proc = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
                        long proc_duration = end_proc - start_proc;
                        System.Console.WriteLine("Process speed: " + proc_duration);
                    } else {
                        System.Console.WriteLine("Failed to read stereo result");
                    }
                }
                cam.disconnect();
            }
            cam.dispose();
            return 0;
        }
    }
}