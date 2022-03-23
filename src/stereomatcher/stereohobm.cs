/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file stereohobm.cs
 * @brief Stereo High-resolution Optimised Block Matcher  class
 * @details C#  class for Stereo Block Matcher class export.
 * DllImports for using C type exports. Pointer to class instance
 * is passed between functions.
 */

using System;
using System.Runtime.InteropServices;

namespace I3DR.Phase
{
    public class StereoHOBM : AbstractStereoMatcher
    {
        // Straight From the c++ Dll (unmanaged)
        [DllImport("i3dr-phase_core", EntryPoint = "I3DR_StereoHOBM_create", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr StereoHOBM_create();

        [DllImport("i3dr-phase_core", EntryPoint = "I3DR_StereoHOBM_setWindowSize", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StereoHOBM_setWindowSize(IntPtr matcher, int value);

        [DllImport("i3dr-phase_core", EntryPoint = "I3DR_StereoHOBM_setMinDisparity", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StereoHOBM_setMinDisparity(IntPtr matcher, int value);

        [DllImport("i3dr-phase_core", EntryPoint = "I3DR_StereoHOBM_setNumDisparities", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StereoHOBM_setNumDisparities(IntPtr matcher, int value);

        public StereoHOBM(IntPtr abstractStereoMatcher_instance): base(abstractStereoMatcher_instance){}

        public StereoHOBM(): base(){
            m_AbstractStereoMatcher_instance = StereoHOBM_create();
        }

        public void setWindowSize(int value){
            StereoHOBM_setWindowSize(m_AbstractStereoMatcher_instance, value);
        }

        public void setMinDisparity(int value){
            StereoHOBM_setMinDisparity(m_AbstractStereoMatcher_instance, value);
        }

        public void setNumDisparities(int value){
            StereoHOBM_setNumDisparities(m_AbstractStereoMatcher_instance, value);
        }
    }
}