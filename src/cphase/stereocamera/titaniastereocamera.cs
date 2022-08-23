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

namespace I3DR.CPhase
{
    //!  Titania Stereo Camera class
    /*!
    Capture data from I3DR's Titania stereo camera.
    */
    public class TitaniaStereoCamera
    {
        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_TitaniaStereoCamera_create", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr TitaniaStereoCamera_create(string left_serial, string right_serial, string unique_serial, CameraDeviceType device_type, CameraInterfaceType interface_type);
    }
}