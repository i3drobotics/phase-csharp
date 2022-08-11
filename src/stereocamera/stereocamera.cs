/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file stereocamera.cs
 * @brief Stereo Camera class
 * @details TODOC
 */

using System;
using System.Runtime.InteropServices;

namespace I3DR.Phase
{
    // TODOC: Class definition
    public class StereoCamera
    {
        // Import Phase functions from C API
        [DllImport("phase", EntryPoint = "I3DR_CCreateStereoCamera", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr CCreateStereoCamera(string left_serial, string right_serial, string unique_serial, CameraDeviceType device_type, CameraInterfaceType interface_type);

        // TODOC
        public static AbstractStereoCamera createStereoCamera(CameraDeviceInfo camera_device_info){
            return new AbstractStereoCamera(CCreateStereoCamera(
                camera_device_info.left_camera_serial, camera_device_info.right_camera_serial, 
                camera_device_info.unique_serial, 
                camera_device_info.device_type, camera_device_info.interface_type
            ));
        }
    }
}