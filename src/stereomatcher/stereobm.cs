/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file stereobm.cs
 * @brief Stereo Block Matcher  class
 * @details C#  class for Stereo Block Matcher class export.
 * DllImports for using C type exports. Pointer to class instance
 * is passed between functions.
 */

using System;
using System.Runtime.InteropServices;

namespace I3DR.Phase
{
    public class StereoBM : AbstractStereoMatcher
    {
        // Straight From the c++ Dll (unmanaged)
        [DllImport("i3dr-phase_core", EntryPoint = "I3DR_StereoBM_create", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr StereoBM_create();

        [DllImport("i3dr-phase_core", EntryPoint = "I3DR_StereoBM_setWindowSize", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StereoBM_setWindowSize(IntPtr matcher, int value);

        [DllImport("i3dr-phase_core", EntryPoint = "I3DR_StereoBM_setMinDisparity", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StereoBM_setMinDisparity(IntPtr matcher, int value);

        [DllImport("i3dr-phase_core", EntryPoint = "I3DR_StereoBM_setNumDisparities", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StereoBM_setNumDisparities(IntPtr matcher, int value);

        public StereoBM(IntPtr abstractStereoMatcher_instance): base(abstractStereoMatcher_instance){}

        public StereoBM(): base(){
            m_AbstractStereoMatcher_instance = StereoBM_create();
        }

        public void setWindowSize(int value){
            StereoBM_setWindowSize(m_AbstractStereoMatcher_instance, value);
        }

        public void setMinDisparity(int value){
            StereoBM_setMinDisparity(m_AbstractStereoMatcher_instance, value);
        }

        public void setNumDisparities(int value){
            StereoBM_setNumDisparities(m_AbstractStereoMatcher_instance, value);
        }
    }
}