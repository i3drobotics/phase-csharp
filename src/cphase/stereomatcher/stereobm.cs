/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file stereobm.cs
 * @brief Stereo Block Matcher class
 * @details OpenCV's stereo block matcher.
 */

using System;
using System.Runtime.InteropServices;

namespace I3DR.CPhase.StereoMatcher
{
    //!  Stereo BM class
    /*!
    OpenCV's block matcher for generting disparity from stereo images.
    */
    public class CStereoBM
    {
        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoBMCreate", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create();

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoBMSetWindowSize", CallingConvention = CallingConvention.Cdecl)]
        public static extern void setWindowSize(IntPtr matcher, int value);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoBMGetWindowSize", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getWindowSize(IntPtr matcher);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoBMSetMinDisparity", CallingConvention = CallingConvention.Cdecl)]
        public static extern void setMinDisparity(IntPtr matcher, int value);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoBMGetMinDisparity", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getMinDisparity(IntPtr matcher);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoBMSetNumDisparities", CallingConvention = CallingConvention.Cdecl)]
        public static extern void setNumDisparities(IntPtr matcher, int value);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoBMGetNumDisparities", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getNumDisparities(IntPtr matcher);
    }
}