/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file uvcstereocamera.cs
 * @brief UVC Stereo Camera class
 * @details Capture data from a stereo camera using UVC cameras
 * where left and right is transported via green and red channels.
 */

using System;
using System.Runtime.InteropServices;

namespace I3DR.CPhase
{   
    //!  UVC Stereo Camera class
    /*!
    Capture data from a stereo camera using UVC cameras
    where left and right is transported via green and red channels.
    */
    public class UVCStereoCamera : AbstractStereoCamera
    {
        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_UVCStereoCamera_create", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr UVCStereoCamera_create(string left_serial, string right_serial, string unique_serial, CameraDeviceType device_type, CameraInterfaceType interface_type);
        
        /*!
        * UVCStereoCamera constructor \n
        * Initalise UVC Stereo Camera with the given \p device_info.
        * 
        * @param device_info camera device information
        */
        public UVCStereoCamera(CameraDeviceInfo camera_device_info): base(camera_device_info){}

        /*!
        * Initalise UVC Stereo camera
        * 
        * @param camera_device_info camera device information
        */
        protected override void init(CameraDeviceInfo camera_device_info){
            m_AbstractStereoCamera_instance = UVCStereoCamera_create(
                camera_device_info.left_camera_serial, camera_device_info.right_camera_serial, 
                camera_device_info.unique_serial, 
                camera_device_info.device_type, camera_device_info.interface_type
            );
        }
    }
}