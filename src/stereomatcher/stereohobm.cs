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

namespace I3DR.Phase
{
    //!  Stereo HOBM class
    /*!
    High resolution optimised block matcher for generting disparity from stereo images.
    */
    public class StereoHOBM : AbstractStereoMatcher
    {
        // Import Phase functions from C API
        [DllImport("phase", EntryPoint = "I3DR_StereoHOBM_create", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr StereoHOBM_create();

        [DllImport("phase", EntryPoint = "I3DR_StereoHOBM_setWindowSize", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StereoHOBM_setWindowSize(IntPtr matcher, int value);

        [DllImport("phase", EntryPoint = "I3DR_StereoHOBM_setMinDisparity", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StereoHOBM_setMinDisparity(IntPtr matcher, int value);

        [DllImport("phase", EntryPoint = "I3DR_StereoHOBM_setNumDisparities", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StereoHOBM_setNumDisparities(IntPtr matcher, int value);

        // TODOC
        public StereoHOBM(IntPtr abstractStereoMatcher_instance): base(abstractStereoMatcher_instance){}

        // TODOC
        public StereoHOBM(): base(){
            m_AbstractStereoMatcher_instance = StereoHOBM_create();
        }

        // TODOC
        public void setWindowSize(int value){
            StereoHOBM_setWindowSize(m_AbstractStereoMatcher_instance, value);
        }

        // TODOC
        public void setMinDisparity(int value){
            StereoHOBM_setMinDisparity(m_AbstractStereoMatcher_instance, value);
        }

        // TODOC
        public void setNumDisparities(int value){
            StereoHOBM_setNumDisparities(m_AbstractStereoMatcher_instance, value);
        }
    }
}