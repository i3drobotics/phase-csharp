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
using I3DR.CPhase.StereoMatcher;

namespace I3DR.Phase.StereoMatcher
{
    //!  Stereo SGBM class
    /*!
    OpenCV's semi-global block matcher for generting disparity from stereo images.
    */
    public class StereoSGBM : AbstractStereoMatcher
    {
        /*!
        * Initalise class using C API class instance reference
        * 
        * @IntPtr stereoCameraCalibration_instance
        */
        public StereoSGBM(IntPtr abstractStereoMatcher_instance): base(abstractStereoMatcher_instance){}

        /*!
        * StereoSGBM constructor \n
        * Initalise Stereo matcher and set default matching parameters.
        * 
        */
        public StereoSGBM(): base(){
            m_AbstractStereoMatcher_instance = CStereoSGBM.create();
        }

        /*!
        * Set window size for matcher
        * 
        * @param value window size
        */
        public void setWindowSize(int value){
            CStereoSGBM.setWindowSize(m_AbstractStereoMatcher_instance, value);
        }

        /*!
        * Set minimum disparity for matcher
        * 
        * @param value minimum disparity
        */
        public void setMinDisparity(int value){
            CStereoSGBM.setMinDisparity(m_AbstractStereoMatcher_instance, value);
        }

        /*!
        * Set number of disparities for matcher
        * 
        * @param value number of disparities
        */
        public void setNumDisparities(int value){
            CStereoSGBM.setNumDisparities(m_AbstractStereoMatcher_instance, value);
        }
    }
}