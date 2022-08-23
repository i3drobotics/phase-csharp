/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file abstractstereomatcher.cs
 * @brief Abstract Stereo Matcher class
 * @details Parent class for building stereo matcher
 * classes. Includes functions/structures common across
 * all stereo matchers. A stereo matcher takes a two images
 * (left and right) and calculates to pixel disparity of features.
 * The produces a disparity value for each pixel which can be
 * used to generate depth. 
 */

using System;
using System.Runtime.InteropServices;
using System.Runtime.ExceptionServices;

namespace I3DR.CPhase
{
    //!  Abstract Stereo Matcher class
    /*!
    Abstract base class for building stereo matcher
    classes. Includes functions/structures common across
    all stereo matchers. A stereo matcher takes a two images
    (left and right) and calculates to pixel disparity of features.
    The produces a disparity value for each pixel which can be
    used to generate depth. 
    */
    public class AbstractStereoMatcher
    {
        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoMatcher_CCompute", CallingConvention = CallingConvention.Cdecl)]
        protected static extern bool AbstractStereoMatcher_CCompute(IntPtr matcher, [In] byte[] left_image, [In] byte[] right_image, int in_width, int in_height, [Out] float[] disparity);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoMatcher_CStartComputeThread", CallingConvention = CallingConvention.Cdecl)]
        protected static extern void AbstractStereoMatcher_CStartComputeThread(IntPtr matcher, [In] byte[] left_image, [In] byte[] right_image, int in_width, int in_height);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoMatcher_CIsComputeThreadRunning", CallingConvention = CallingConvention.Cdecl)]
        protected static extern bool AbstractStereoMatcher_CIsComputeThreadRunning(IntPtr matcher);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoMatcher_CGetComputeThreadResult", CallingConvention = CallingConvention.Cdecl)]
        protected static extern bool AbstractStereoMatcher_CGetComputeThreadResult(IntPtr matcher, int width, int height, [Out] float[] disparity);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoMatcher_dispose", CallingConvention = CallingConvention.Cdecl)]
        protected static extern void AbstractStereoMatcher_dispose(IntPtr matcher);
    }
}