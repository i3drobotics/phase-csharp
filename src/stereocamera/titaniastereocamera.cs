/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file titaniastereocamera.cs
 * @brief Titania Stereo Camera class
 * @details Capture data from I3DR's Titania stereo camera.
 */

using System;
using System.Runtime.InteropServices;

namespace I3DR.Phase
{
    //!  Titania Stereo Camera class
    /*!
    Capture data from I3DR's Titania stereo camera.
    */
    public class TitaniaStereoCamera : AbstractStereoCamera
    {
        // Import Phase functions from C API
        [DllImport("phase", EntryPoint = "I3DR_TitaniaStereoCamera_create", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr TitaniaStereoCamera_create(string left_serial, string right_serial, string unique_serial, CameraDeviceType device_type, CameraInterfaceType interface_type);
        
        // TODOC
        public TitaniaStereoCamera(CameraDeviceInfo camera_device_info): base(camera_device_info){}

        // TODOC
        protected override void init(CameraDeviceInfo camera_device_info){
            m_AbstractStereoCamera_instance = TitaniaStereoCamera_create(
                camera_device_info.left_camera_serial, camera_device_info.right_camera_serial, 
                camera_device_info.unique_serial, 
                camera_device_info.device_type, camera_device_info.interface_type
            );
        }
    }
}