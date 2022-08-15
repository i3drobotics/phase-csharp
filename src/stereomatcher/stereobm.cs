/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file stereobm.cs
 * @brief Stereo Block Matcher class
 * @details OpenCV's stereo block matcher.
 */

using System;
using System.Runtime.InteropServices;

namespace I3DR.Phase
{
    //!  Stereo BM class
    /*!
    OpenCV's block matcher for generting disparity from stereo images.
    */
    public class StereoBM : AbstractStereoMatcher
    {
        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoBM_create", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr StereoBM_create();

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoBM_setWindowSize", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StereoBM_setWindowSize(IntPtr matcher, int value);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoBM_setMinDisparity", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StereoBM_setMinDisparity(IntPtr matcher, int value);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoBM_setNumDisparities", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StereoBM_setNumDisparities(IntPtr matcher, int value);

        /*!
        * Initalise class using C API class instance reference
        * 
        * @IntPtr stereoCameraCalibration_instance
        */
        public StereoBM(IntPtr abstractStereoMatcher_instance): base(abstractStereoMatcher_instance){}

        /*!
        * StereoBM constructor \n
        * Initalise Stereo matcher and set default matching parameters.
        * 
        */
        public StereoBM(): base(){
            m_AbstractStereoMatcher_instance = StereoBM_create();
        }

        /*!
        * Set window size for matcher
        * 
        * @param value window size
        */
        public void setWindowSize(int value){
            StereoBM_setWindowSize(m_AbstractStereoMatcher_instance, value);
        }

        /*!
        * Set minimum disparity for matcher
        * 
        * @param value minimum disparity
        */
        public void setMinDisparity(int value){
            StereoBM_setMinDisparity(m_AbstractStereoMatcher_instance, value);
        }

        /*!
        * Set number of disparities for matcher
        * 
        * @param value number of disparities
        */
        public void setNumDisparities(int value){
            StereoBM_setNumDisparities(m_AbstractStereoMatcher_instance, value);
        }
    }
}