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
using I3DR.Phase.StereoMatcher;

namespace I3DR.CPhase.StereoMatcher
{
    //!  Stereo Matcher class
    /*!
    Create stereo matcher of any type using 
    StereoMatcherType. This allows for the same interface to be
    used for any stereo matcher. 
    */
    public class CStereoMatcher
    {
        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseCreateStereoMatcher", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr createStereoMatcher(StereoMatcherType matcher_type);
    }
}