/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file stereobm.cs
 * @brief I3DR's Semi-Global Stereo Matcher  class
 * @details C#  class for I3DR's Semi-Global Stereo Matcher class export.
 * DllImports for using C type exports. Pointer to class instance
 * is passed between functions.
 */
 
using System;
using System.Runtime.InteropServices;

namespace I3DR.Phase
{
    public class StereoI3DRSGM : AbstractStereoMatcher
    {
        // Straight From the c++ Dll (unmanaged)
        [DllImport("i3dr-phase_core", EntryPoint = "I3DR_StereoI3DRSGM_create", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr StereoI3DRSGM_create();

        [DllImport("i3dr-phase_core", EntryPoint = "I3DR_StereoI3DRSGM_setWindowSize", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StereoI3DRSGM_setWindowSize(IntPtr matcher, int value);

        [DllImport("i3dr-phase_core", EntryPoint = "I3DR_StereoI3DRSGM_setMinDisparity", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StereoI3DRSGM_setMinDisparity(IntPtr matcher, int value);

        [DllImport("i3dr-phase_core", EntryPoint = "I3DR_StereoI3DRSGM_setNumDisparities", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StereoI3DRSGM_setNumDisparities(IntPtr matcher, int value);

        [DllImport("i3dr-phase_core", EntryPoint = "I3DR_StereoI3DRSGM_setSpeckleMaxSize", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StereoI3DRSGM_setSpeckleMaxSize(IntPtr matcher, int value);

        [DllImport("i3dr-phase_core", EntryPoint = "I3DR_StereoI3DRSGM_setSpeckleMaxDiff", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StereoI3DRSGM_setSpeckleMaxDiff(IntPtr matcher, float value);

        [DllImport("i3dr-phase_core", EntryPoint = "I3DR_StereoI3DRSGM_enableSubpixel", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StereoI3DRSGM_enableSubpixel(IntPtr matcher, bool enable);

        [DllImport("i3dr-phase_core", EntryPoint = "I3DR_StereoI3DRSGM_enableInterpolation", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StereoI3DRSGM_enableInterpolation(IntPtr matcher, bool enable);

        [DllImport("i3dr-phase_core", EntryPoint = "I3DR_StereoI3DRSGM_isLicenseValid", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool StereoI3DRSGM_isLicenseValid();

        public StereoI3DRSGM(IntPtr abstractStereoMatcher_instance): base(abstractStereoMatcher_instance){}

        public StereoI3DRSGM(): base(){
            m_AbstractStereoMatcher_instance = StereoI3DRSGM_create();
        }

        public void setWindowSize(int value){
            StereoI3DRSGM_setWindowSize(m_AbstractStereoMatcher_instance, value);
        }

        public void setMinDisparity(int value){
            StereoI3DRSGM_setMinDisparity(m_AbstractStereoMatcher_instance, value);
        }

        public void setNumDisparities(int value){
            StereoI3DRSGM_setNumDisparities(m_AbstractStereoMatcher_instance, value);
        }

        public void setSpeckleMaxSize(int value){
            StereoI3DRSGM_setSpeckleMaxSize(m_AbstractStereoMatcher_instance, value);
        }

        public void setSpeckleMaxDiff(float value){
            StereoI3DRSGM_setSpeckleMaxDiff(m_AbstractStereoMatcher_instance, value);
        }

        public void enableSubpixel(bool enable){
            StereoI3DRSGM_enableSubpixel(m_AbstractStereoMatcher_instance, enable);
        }

        public void enableInterpolation(bool enable){
            StereoI3DRSGM_enableInterpolation(m_AbstractStereoMatcher_instance, enable);
        }

        public static bool isLicenseValid(){
            return StereoI3DRSGM_isLicenseValid();
        }
    }
}