/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file stereomatcher.cs
 * @brief Stereo Matcher class
 * @details Create stereo matcher of any type using 
 * StereoMatcherType. This allows for the same interface to be
 * used for any stereo matcher. 
 */

using System;
using System.Runtime.InteropServices;

namespace I3DR.CPhase
{
    //!  Stereo Matcher class
    /*!
    Create stereo matcher of any type using 
    StereoMatcherType. This allows for the same interface to be
    used for any stereo matcher. 
    */
    public class StereoMatcher
    {
        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_CCreateStereoMatcher", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr CCreateStereoMatcher(StereoMatcherType matcher_type);
    }
}