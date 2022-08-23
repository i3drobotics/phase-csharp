/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file stereocamera.cs
 * @brief Stereo Camera class
 * @details Create stereo camera of any type using 
 * CameraDeviceInfo. This allows for the same interface to be
 * used for any stereo camera. 
 */

using System;
using System.Runtime.InteropServices;

namespace I3DR.CPhase
{
    //!  Stereo Camera class
    /*!
    Create stereo camera of any type using 
    CameraDeviceInfo. This allows for the same interface to be
    used for any stereo camera. 
    */
    public class StereoCamera
    {
        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_CCreateStereoCamera", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr CCreateStereoCamera(string left_serial, string right_serial, string unique_serial, CameraDeviceType device_type, CameraInterfaceType interface_type);
    }
}