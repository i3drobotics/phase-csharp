/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file stereoi3drsgm.cs
 * @brief I3DR's Semi-Global Stereo Matcher class
 * @details Wrapper for I3DRS's stereo semi-global matcher.
 */
 
using System;
using System.Runtime.InteropServices;

namespace I3DR.CPhase
{
    //!  Stereo I3DRSGM class
    /*!
    I3DRS's stereo semi-global matcher for generting disparity from stereo images.
    */
    public class StereoI3DRSGM
    {
        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoI3DRSGM_create", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr StereoI3DRSGM_create();

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoI3DRSGM_setWindowSize", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StereoI3DRSGM_setWindowSize(IntPtr matcher, int value);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoI3DRSGM_setMinDisparity", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StereoI3DRSGM_setMinDisparity(IntPtr matcher, int value);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoI3DRSGM_setNumDisparities", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StereoI3DRSGM_setNumDisparities(IntPtr matcher, int value);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoI3DRSGM_setSpeckleMaxSize", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StereoI3DRSGM_setSpeckleMaxSize(IntPtr matcher, int value);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoI3DRSGM_setSpeckleMaxDiff", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StereoI3DRSGM_setSpeckleMaxDiff(IntPtr matcher, float value);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoI3DRSGM_enableSubpixel", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StereoI3DRSGM_enableSubpixel(IntPtr matcher, bool enable);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoI3DRSGM_enableInterpolation", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StereoI3DRSGM_enableInterpolation(IntPtr matcher, bool enable);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoI3DRSGM_isLicenseValid", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool StereoI3DRSGM_isLicenseValid();
    }
}