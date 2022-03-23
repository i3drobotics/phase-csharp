/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file stereomatcher.cs
 * @brief Stereo Matcher  class
 * @details C#  class for Stereo Matcher class export.
 * DllImports for using C type exports. Pointer to class instance
 * is passed between functions.
 */

using System;
using System.Runtime.InteropServices;

namespace I3DR.Phase
{
    public class StereoMatcher
    {
        // Straight From the c++ Dll (unmanaged)
        [DllImport("i3dr-phase_core", EntryPoint = "I3DR_CCreateStereoMatcher", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr CCreateStereoMatcher(StereoMatcherType matcher_type);

        public static AbstractStereoMatcher createStereoMatcher(StereoMatcherType matcher_type){
            if (matcher_type == StereoMatcherType.STEREO_MATCHER_I3DRSGM){
                return new StereoI3DRSGM(CCreateStereoMatcher(matcher_type));
            } else if (matcher_type == StereoMatcherType.STEREO_MATCHER_BM){
                return new StereoBM(CCreateStereoMatcher(matcher_type));
            } else if (matcher_type == StereoMatcherType.STEREO_MATCHER_SGBM){
                return new StereoSGBM(CCreateStereoMatcher(matcher_type));
            } else if (matcher_type == StereoMatcherType.STEREO_MATCHER_HOBM){
                return new StereoHOBM(CCreateStereoMatcher(matcher_type));
            } else {
                throw new ArgumentException(
                    String.Format("Unsupported matcher type: {0}", matcher_type),"matcher_type");
            }
        }
    }
}