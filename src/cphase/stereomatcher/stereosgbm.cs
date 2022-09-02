/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file stereosgbm.cs
 * @brief Stereo Semi-Global Block Matcher class
 * @details OpenCV's stereo semi-global block matcher.
 */

using System;
using System.Runtime.InteropServices;

namespace I3DR.CPhase.StereoMatcher
{
    //!  Stereo SGBM class
    /*!
    OpenCV's semi-global block matcher for generting disparity from stereo images.
    */
    public class CStereoSGBM
    {
        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoSGBMCreate", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create();

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoSGBMSetWindowSize", CallingConvention = CallingConvention.Cdecl)]
        public static extern void setWindowSize(IntPtr matcher, int value);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoSGBMGetWindowSize", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getWindowSize(IntPtr matcher);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoSGBMSetMinDisparity", CallingConvention = CallingConvention.Cdecl)]
        public static extern void setMinDisparity(IntPtr matcher, int value);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoSGBMGetMinDisparity", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getMinDisparity(IntPtr matcher);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoSGBMSetNumDisparities", CallingConvention = CallingConvention.Cdecl)]
        public static extern void setNumDisparities(IntPtr matcher, int value);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoSGBMGetNumDisparities", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getNumDisparities(IntPtr matcher);
    }
}