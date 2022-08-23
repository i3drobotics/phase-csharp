/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file pylonstereocamera.cs
 * @brief Pylon Stereo Camera class
 * @details Capture data from a stereo camera using Basler cameras.
 */

using System;
using System.Runtime.InteropServices;

namespace I3DR.CPhase
{
    //!  Pylon Stereo Camera class
    /*!
    Capture data from a stereo camera using Basler cameras via the Pylon API
    */
    public class PylonStereoCamera
    {
        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_PylonStereoCamera_create", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr PylonStereoCamera_create(string left_serial, string right_serial, string unique_serial, CameraDeviceType device_type, CameraInterfaceType interface_type);
    }
}