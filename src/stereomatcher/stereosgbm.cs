/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file stereosgbm.cs
 * @brief Stereo Semi-Global Block Matcher  class
 * @details C#  class for Stereo Semi-Global Block Matcher class export.
 * DllImports for using C type exports. Pointer to class instance
 * is passed between functions.
 */

using System;
using System.Runtime.InteropServices;

namespace I3DR.Phase
{
    public class StereoSGBM : AbstractStereoMatcher
    {
        // Straight From the c++ Dll (unmanaged)
        [DllImport("phase", EntryPoint = "I3DR_StereoSGBM_create", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr StereoSGBM_create();

        [DllImport("phase", EntryPoint = "I3DR_StereoSGBM_setWindowSize", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StereoSGBM_setWindowSize(IntPtr matcher, int value);

        [DllImport("phase", EntryPoint = "I3DR_StereoSGBM_setMinDisparity", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StereoSGBM_setMinDisparity(IntPtr matcher, int value);

        [DllImport("phase", EntryPoint = "I3DR_StereoSGBM_setNumDisparities", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StereoSGBM_setNumDisparities(IntPtr matcher, int value);

        public StereoSGBM(IntPtr abstractStereoMatcher_instance): base(abstractStereoMatcher_instance){}

        public StereoSGBM(): base(){
            m_AbstractStereoMatcher_instance = StereoSGBM_create();
        }

        public void setWindowSize(int value){
            StereoSGBM_setWindowSize(m_AbstractStereoMatcher_instance, value);
        }

        public void setMinDisparity(int value){
            StereoSGBM_setMinDisparity(m_AbstractStereoMatcher_instance, value);
        }

        public void setNumDisparities(int value){
            StereoSGBM_setNumDisparities(m_AbstractStereoMatcher_instance, value);
        }
    }
}