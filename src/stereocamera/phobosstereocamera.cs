/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file phobosstereocamera.cs
 * @brief Phobos Stereo Camera  class
 * @details C#  class for Phobos Stereo Camera class export.
 * DllImports for using C type exports. Pointer to class instance
 * is passed between functions.
 */

using System;
using System.Runtime.InteropServices;

namespace I3DR.Phase
{
    public class PhobosStereoCamera : AbstractStereoCamera
    {
        // Straight From the c++ Dll (unmanaged)
        [DllImport("i3dr-phase_core", EntryPoint = "I3DR_PhobosStereoCamera_create", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr PhobosStereoCamera_create(string left_serial, string right_serial, string unique_serial, CameraDeviceType device_type, CameraInterfaceType interface_type);
        
        public PhobosStereoCamera(CameraDeviceInfo camera_device_info): base(camera_device_info){}

        protected override void init(CameraDeviceInfo camera_device_info){
            m_AbstractStereoCamera_instance = PhobosStereoCamera_create(
                camera_device_info.left_camera_serial, camera_device_info.right_camera_serial, 
                camera_device_info.unique_serial, 
                camera_device_info.device_type, camera_device_info.interface_type
            );
        }
    }
}