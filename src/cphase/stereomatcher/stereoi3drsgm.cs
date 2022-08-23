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

namespace I3DR.CPhase.StereoMatcher
{
    //!  Stereo I3DRSGM class
    /*!
    I3DRS's stereo semi-global matcher for generting disparity from stereo images.
    */
    public class CStereoI3DRSGM
    {
        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoI3DRSGMCreate", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create();

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoI3DRSGMSetWindowSize", CallingConvention = CallingConvention.Cdecl)]
        public static extern void setWindowSize(IntPtr matcher, int value);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoI3DRSGMSetMinDisparity", CallingConvention = CallingConvention.Cdecl)]
        public static extern void setMinDisparity(IntPtr matcher, int value);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoI3DRSGMSetNumDisparities", CallingConvention = CallingConvention.Cdecl)]
        public static extern void setNumDisparities(IntPtr matcher, int value);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoI3DRSGMSetSpeckleMaxSize", CallingConvention = CallingConvention.Cdecl)]
        public static extern void setSpeckleMaxSize(IntPtr matcher, int value);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoI3DRSGMSetSpeckleMaxDiff", CallingConvention = CallingConvention.Cdecl)]
        public static extern void setSpeckleMaxDiff(IntPtr matcher, float value);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoI3DRSGMEnableSubpixel", CallingConvention = CallingConvention.Cdecl)]
        public static extern void enableSubpixel(IntPtr matcher, bool enable);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoI3DRSGMEnableInterpolation", CallingConvention = CallingConvention.Cdecl)]
        public static extern void enableInterpolation(IntPtr matcher, bool enable);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoI3DRSGMIsLicenseValid", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool isLicenseValid();
    }
}