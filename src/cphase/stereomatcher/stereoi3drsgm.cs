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
        [DllImport("phase", EntryPoint = "PhaseStereoI3DRSGMGetWindowSize", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getWindowSize(IntPtr matcher);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoI3DRSGMSetMinDisparity", CallingConvention = CallingConvention.Cdecl)]
        public static extern void setMinDisparity(IntPtr matcher, int value);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoI3DRSGMGetMinDisparity", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getMinDisparity(IntPtr matcher);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoI3DRSGMSetNumDisparities", CallingConvention = CallingConvention.Cdecl)]
        public static extern void setNumDisparities(IntPtr matcher, int value);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoI3DRSGMGetNumDisparities", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getNumDisparities(IntPtr matcher);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoI3DRSGMSetSpeckleMaxSize", CallingConvention = CallingConvention.Cdecl)]
        public static extern void setSpeckleMaxSize(IntPtr matcher, int value);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoI3DRSGMGetSpeckleMaxSize", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getSpeckleMaxSize(IntPtr matcher);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoI3DRSGMSetSpeckleMaxDiff", CallingConvention = CallingConvention.Cdecl)]
        public static extern void setSpeckleMaxDiff(IntPtr matcher, float value);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoI3DRSGMGetSpeckleMaxDiff", CallingConvention = CallingConvention.Cdecl)]
        public static extern float getSpeckleMaxDiff(IntPtr matcher);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoI3DRSGMEnableSubpixel", CallingConvention = CallingConvention.Cdecl)]
        public static extern void enableSubpixel(IntPtr matcher, bool enable);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoI3DRSGMIsSubpixelEnabled", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool isSubpixelEnabled(IntPtr matcher);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoI3DRSGMEnableInterpolation", CallingConvention = CallingConvention.Cdecl)]
        public static extern void enableInterpolation(IntPtr matcher, bool enable);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoI3DRSGMIsInterpolationEnabled", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool isInterpolationEnabled(IntPtr matcher);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoI3DRSGMEnableOcclusionDetection", CallingConvention = CallingConvention.Cdecl)]
        public static extern void enableOcclusionDetection(IntPtr matcher, bool enable);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoI3DRSGMIsOcclusionDetectionEnabled", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool isOcclusionDetectionEnabled(IntPtr matcher);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoI3DRSGMEnableOcclusionInterpolation", CallingConvention = CallingConvention.Cdecl)]
        public static extern void enableOcclusionInterpolation(IntPtr matcher, bool enable);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoI3DRSGMIsOcclusionInterpolationEnabled", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool isOcclusionInterpolationEnabled(IntPtr matcher);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoI3DRSGMIsLicenseValid", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool isLicenseValid();
    }
}