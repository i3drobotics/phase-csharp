/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file stereoi3drsgm.cs
 * @brief I3DR's Semi-Global Stereo Matcher class
 * @details Wrapper for I3DRS's stereo semi-global matcher.
 */
 
using System;
using I3DR.CPhase;

namespace I3DR.Phase
{
    //!  Stereo I3DRSGM class
    /*!
    I3DRS's stereo semi-global matcher for generting disparity from stereo images.
    */
    public class StereoI3DRSGM : AbstractStereoMatcher
    {
        /*!
        * Initalise class using C API class instance reference
        * 
        * @IntPtr stereoCameraCalibration_instance
        */
        public StereoI3DRSGM(IntPtr abstractStereoMatcher_instance): base(abstractStereoMatcher_instance){}

        /*!
        * StereoI3DRSGM constructor \n
        * Initalise Stereo matcher and set default matching parameters.
        * 
        */
        public StereoI3DRSGM(): base(){
            m_AbstractStereoMatcher_instance = StereoI3DRSGM_create();
        }

        /*!
        * Set window size for matcher
        * 
        * @param value window size
        */
        public void setWindowSize(int value){
            StereoI3DRSGM_setWindowSize(m_AbstractStereoMatcher_instance, value);
        }

        /*!
        * Set minimum disparity for matcher
        * 
        * @param value minimum disparity
        */
        public void setMinDisparity(int value){
            StereoI3DRSGM_setMinDisparity(m_AbstractStereoMatcher_instance, value);
        }

        /*!
        * Set number of disparities for matcher
        * 
        * @param value number of disparities
        */
        public void setNumDisparities(int value){
            StereoI3DRSGM_setNumDisparities(m_AbstractStereoMatcher_instance, value);
        }

        /*!
        * Set speckle max size for matcher
        * 
        * @param value speckle max size
        */
        public void setSpeckleMaxSize(int value){
            StereoI3DRSGM_setSpeckleMaxSize(m_AbstractStereoMatcher_instance, value);
        }

        /*!
        * Set speckle max difference for matcher
        * 
        * @param value speckle max difference
        */
        public void setSpeckleMaxDiff(float value){
            StereoI3DRSGM_setSpeckleMaxDiff(m_AbstractStereoMatcher_instance, value);
        }

        /*!
        * Enable/disable subpixel refinement for matcher
        * 
        * @param enable enable/disable subpixel refinement
        */
        public void enableSubpixel(bool enable){
            StereoI3DRSGM_enableSubpixel(m_AbstractStereoMatcher_instance, enable);
        }

        /*!
        * Enable/disable interpolation for matcher
        * 
        * @param enable enable/disable interpolation
        */
        public void enableInterpolation(bool enable){
            StereoI3DRSGM_enableInterpolation(m_AbstractStereoMatcher_instance, enable);
        }

        /*!
        * Check if license is valid \n
        * Looks for license file in the same folder as the application. \n
        * Checks license against hostinfo and returns a valid matcher handle, \n
        * if the license is valid. This matcher handle is checked to see if it \n
        * is null, this is the check returned by the function. \n
        * 
        * @return license validitiy
        */
        public static bool isLicenseValid(){
            return StereoI3DRSGM_isLicenseValid();
        }
    }
}