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
using I3DR.Phase.StereoCamera;

namespace I3DR.CPhase.StereoCamera
{   
    //!  UVC Stereo Camera class
    /*!
    Capture data from a stereo camera using UVC cameras
    where left and right is transported via green and red channels.
    */
    public class CUVCStereoCamera
    {
        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseUVCStereoCameraCreate", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create(string left_serial, string right_serial, string unique_serial, CameraDeviceType device_type, CameraInterfaceType interface_type);
    }
}