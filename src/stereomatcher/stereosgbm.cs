/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file stereosgbm.cs
 * @brief Stereo Semi-Global Block Matcher class
 * @details OpenCV's stereo semi-global block matcher.
 */

using System;
using System.Runtime.InteropServices;

namespace I3DR.Phase
{
    //!  Stereo SGBM class
    /*!
    OpenCV's semi-global block matcher for generting disparity from stereo images.
    */
    public class StereoSGBM : AbstractStereoMatcher
    {
        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoSGBM_create", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr StereoSGBM_create();

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoSGBM_setWindowSize", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StereoSGBM_setWindowSize(IntPtr matcher, int value);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoSGBM_setMinDisparity", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StereoSGBM_setMinDisparity(IntPtr matcher, int value);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoSGBM_setNumDisparities", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StereoSGBM_setNumDisparities(IntPtr matcher, int value);

        // TODOC
        public StereoSGBM(IntPtr abstractStereoMatcher_instance): base(abstractStereoMatcher_instance){}

        // TODOC
        public StereoSGBM(): base(){
            m_AbstractStereoMatcher_instance = StereoSGBM_create();
        }

        // TODOC
        public void setWindowSize(int value){
            StereoSGBM_setWindowSize(m_AbstractStereoMatcher_instance, value);
        }

        // TODOC
        public void setMinDisparity(int value){
            StereoSGBM_setMinDisparity(m_AbstractStereoMatcher_instance, value);
        }

        // TODOC
        public void setNumDisparities(int value){
            StereoSGBM_setNumDisparities(m_AbstractStereoMatcher_instance, value);
        }
    }
}