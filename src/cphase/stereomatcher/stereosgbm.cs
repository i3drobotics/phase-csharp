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

namespace I3DR.CPhase
{
    //!  Stereo SGBM class
    /*!
    OpenCV's semi-global block matcher for generting disparity from stereo images.
    */
    public class CStereoSGBM
    {
        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoSGBMCreate", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr PhaseStereoSGBMCreate();

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoSGBMSetWindowSize", CallingConvention = CallingConvention.Cdecl)]
        public static extern void PhaseStereoSGBMSetWindowSize(IntPtr matcher, int value);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoSGBMSetMinDisparity", CallingConvention = CallingConvention.Cdecl)]
        public static extern void PhaseStereoSGBMSetMinDisparity(IntPtr matcher, int value);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoSGBMSetNumDisparities", CallingConvention = CallingConvention.Cdecl)]
        public static extern void PhaseStereoSGBMSetNumDisparities(IntPtr matcher, int value);
    }
}