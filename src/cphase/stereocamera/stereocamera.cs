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
using I3DR.Phase.StereoCamera;

namespace I3DR.CPhase.StereoCamera
{
    //!  Stereo Camera class
    /*!
    Create stereo camera of any type using 
    CameraDeviceInfo. This allows for the same interface to be
    used for any stereo camera. 
    */
    public class CStereoCamera
    {
        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseCreateStereoCameraFromParams", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr createStereoCameraFromParams(string left_serial, string right_serial, string unique_serial, CameraDeviceType device_type, CameraInterfaceType interface_type);

        [DllImport("phase", EntryPoint = "PhaseCreateStereoCamera", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr createStereoCamera(IntPtr device_info);

        [DllImport("phase", EntryPoint = "PhaseAvailableDevicesCount", CallingConvention = CallingConvention.Cdecl)]
        public static extern int availableDevicesCount();

        [DllImport("phase", EntryPoint = "PhaseAvailableDevices", CallingConvention = CallingConvention.Cdecl)]
        public static extern void availableDevices([Out] IntPtr[] device_info, int length);
    }
}