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
using I3DR.CPhase;

namespace I3DR.Phase
{
    //!  Stereo HOBM class
    /*!
    High resolution optimised block matcher for generting disparity from stereo images.
    */
    public class StereoHOBM : AbstractStereoMatcher
    {
        /*!
        * Initalise class using C API class instance reference
        * 
        * @IntPtr stereoCameraCalibration_instance
        */
        public StereoHOBM(IntPtr abstractStereoMatcher_instance): base(abstractStereoMatcher_instance){}

        /*!
        * StereoHOBM constructor \n
        * Initalise Stereo matcher and set default matching parameters.
        * 
        */
        public StereoHOBM(): base(){
            m_AbstractStereoMatcher_instance = StereoHOBM_create();
        }

        /*!
        * Set window size for matcher
        * 
        * @param value window size
        */
        public void setWindowSize(int value){
            StereoHOBM_setWindowSize(m_AbstractStereoMatcher_instance, value);
        }

        /*!
        * Set minimum disparity for matcher
        * 
        * @param value minimum disparity
        */
        public void setMinDisparity(int value){
            StereoHOBM_setMinDisparity(m_AbstractStereoMatcher_instance, value);
        }

        /*!
        * Set number of disparities for matcher
        * 
        * @param value number of disparities
        */
        public void setNumDisparities(int value){
            StereoHOBM_setNumDisparities(m_AbstractStereoMatcher_instance, value);
        }
    }
}