/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file deimosstereocamera.cs
 * @brief Deimos Stereo Camera class
 * @details Capture data from I3DR's Deimos stereo camera
 */

using System;
using System.Runtime.InteropServices;
using I3DR.CPhase;

namespace I3DR.Phase
{
    //!  Deimos Stereo Camera class
    /*!
    Capture data from I3DR's Deimos stereo camera.
    */
    public class DeimosStereoCamera : AbstractStereoCamera
    {
        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_DeimosStereoCamera_create", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr DeimosStereoCamera_create(string left_serial, string right_serial, string unique_serial, CameraDeviceType device_type, CameraInterfaceType interface_type);

        /*!
        * DeimosStereoCamera constructor \n
        * Initalise Deimos Stereo Camera with the given \p device_info.
        * 
        * @param device_info camera device information
        */
        public DeimosStereoCamera(CameraDeviceInfo camera_device_info): base(camera_device_info){}

        /*!
        * Initalise Deimos Stereo camera
        * 
        * @param camera_device_info camera device information
        */
        protected override void init(CameraDeviceInfo camera_device_info){
            m_AbstractStereoCamera_instance = DeimosStereoCamera_create(
                camera_device_info.left_camera_serial, camera_device_info.right_camera_serial, 
                camera_device_info.unique_serial, 
                camera_device_info.device_type, camera_device_info.interface_type
            );
        }
    }
}