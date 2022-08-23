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

namespace I3DR.CPhase.StereoMatcher
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
    public class CAbstractStereoMatcher
    {
        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseAbstractStereoMatcherCompute", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool compute(IntPtr matcher, [In] byte[] left_image, [In] byte[] right_image, int in_width, int in_height, [Out] float[] disparity);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseAbstractStereoMatcherStartComputeThread", CallingConvention = CallingConvention.Cdecl)]
        public static extern void startComputeThread(IntPtr matcher, [In] byte[] left_image, [In] byte[] right_image, int in_width, int in_height);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseAbstractStereoMatcherIsComputeThreadRunning", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool isComputeThreadRunning(IntPtr matcher);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseAbstractStereoMatcherGetComputeThreadResult", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool getComputeThreadResult(IntPtr matcher, int width, int height, [Out] float[] disparity);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseAbstractStereoMatcherDispose", CallingConvention = CallingConvention.Cdecl)]
        public static extern void dispose(IntPtr matcher);
    }
}