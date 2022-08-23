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
using I3DR.Phase.StereoCamera;

namespace I3DR.CPhase.StereoCamera
{
    //!  Titania Stereo Camera class
    /*!
    Capture data from I3DR's Titania stereo camera.
    */
    public class CTitaniaStereoCamera
    {
        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseTitaniaStereoCameraCreate", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create(string left_serial, string right_serial, string unique_serial, CameraDeviceType device_type, CameraInterfaceType interface_type);
    }
}