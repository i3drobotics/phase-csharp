/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file demo_cam_read.cs
 * @brief Example application print out the available camera list
 */

using System;
using I3DR.Phase.StereoCamera;

namespace I3DR.PhaseDemo
{
    //!  Demo Camera List class
    /*!
    Demo program to find available camera as a list
    */
    class DemoCameraList
    {
        static int Main(){
            CameraDeviceInfo[] device_infos = StereoCamera.availableDevices();
            if (device_infos.Length == 0 )
            {
                Console.WriteLine("No devices found");
            }
            foreach(CameraDeviceInfo device_info in device_infos){
                Console.WriteLine("Camera Name: " + device_info.unique_serial);
                Console.WriteLine("Left Serial: " + device_info.left_camera_serial);
                Console.WriteLine("Right Serial: " + device_info.right_camera_serial);
            }
            return 0;
        }
    }
}