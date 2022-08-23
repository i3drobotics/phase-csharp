/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file stereohobm.cs
 * @brief Stereo High-resolution Optimised Block Matcher class
 * @details High resolution optimised block matcher.
 */

using System;
using System.Runtime.InteropServices;

namespace I3DR.CPhase
{
    //!  Stereo HOBM class
    /*!
    High resolution optimised block matcher for generting disparity from stereo images.
    */
    public class StereoHOBM
    {
        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoHOBM_create", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr StereoHOBM_create();

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoHOBM_setWindowSize", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StereoHOBM_setWindowSize(IntPtr matcher, int value);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoHOBM_setMinDisparity", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StereoHOBM_setMinDisparity(IntPtr matcher, int value);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoHOBM_setNumDisparities", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StereoHOBM_setNumDisparities(IntPtr matcher, int value);
    }
}