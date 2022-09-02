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
using I3DR.CPhase.StereoMatcher;

namespace I3DR.Phase.StereoMatcher
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
            m_AbstractStereoMatcher_instance = CStereoI3DRSGM.create();
        }

        /*!
        * Set window size for matcher
        * 
        * @param value window size
        */
        public void setWindowSize(int value){
            CStereoI3DRSGM.setWindowSize(m_AbstractStereoMatcher_instance, value);
        }

        /*!
        * Set minimum disparity for matcher
        * 
        * @param value minimum disparity
        */
        public void setMinDisparity(int value){
            CStereoI3DRSGM.setMinDisparity(m_AbstractStereoMatcher_instance, value);
        }

        /*!
        * Set number of disparities for matcher
        * 
        * @param value number of disparities
        */
        public void setNumDisparities(int value){
            CStereoI3DRSGM.setNumDisparities(m_AbstractStereoMatcher_instance, value);
        }

        /*!
        * Set speckle max size for matcher
        * 
        * @param value speckle max size
        */
        public void setSpeckleMaxSize(int value){
            CStereoI3DRSGM.setSpeckleMaxSize(m_AbstractStereoMatcher_instance, value);
        }

        /*!
        * Set speckle max difference for matcher
        * 
        * @param value speckle max difference
        */
        public void setSpeckleMaxDiff(float value){
            CStereoI3DRSGM.setSpeckleMaxDiff(m_AbstractStereoMatcher_instance, value);
        }

        /*!
        * Enable/disable subpixel refinement for matcher
        * 
        * @param enable enable/disable subpixel refinement
        */
        public void enableSubpixel(bool enable){
            CStereoI3DRSGM.enableSubpixel(m_AbstractStereoMatcher_instance, enable);
        }

        /*!
        * Enable/disable interpolation for matcher
        * 
        * @param enable enable/disable interpolation
        */
        public void enableInterpolation(bool enable){
            CStereoI3DRSGM.enableInterpolation(m_AbstractStereoMatcher_instance, enable);
        }

        /*!
        * Enable/disable occlusion detection for matcher
        * 
        * @param enable enable/disable occlusion detection
        */
        public void enableOcclusionDetection(bool enable){
            CStereoI3DRSGM.enableOcclusionDetection(m_AbstractStereoMatcher_instance, enable);
        }

        /*!
        * Enable/disable occlusion interpolation for matcher
        * 
        * @param enable enable/disable occlusion interpolation
        */
        public void enableOcclusionInterpolation(bool enable){
            CStereoI3DRSGM.enableOcclusionInterpolation(m_AbstractStereoMatcher_instance, enable);
        }

        /*!
        * Get window size from matcher
        * 
        * @returns window size
        */
        public int getWindowSize(){
            return CStereoI3DRSGM.getWindowSize(m_AbstractStereoMatcher_instance);
        }

        /*!
        * Get minimum disparity from matcher
        * 
        * @returns minimum disparity
        */
        public int getMinDisparity(){
            return CStereoI3DRSGM.getMinDisparity(m_AbstractStereoMatcher_instance);
        }

        /*!
        * Get number of disparities from matcher
        * 
        * @returns number of disparities
        */
        public int getNumDisparities(){
            return CStereoI3DRSGM.getNumDisparities(m_AbstractStereoMatcher_instance);
        }

        /*!
        * Get speckle max size from matcher
        * 
        * @returns speckle max size
        */
        public int getSpeckleMaxSize(){
            return CStereoI3DRSGM.getSpeckleMaxSize(m_AbstractStereoMatcher_instance);
        }

        /*!
        * Get speckle max difference from matcher
        * 
        * @returns speckle max difference
        */
        public float getSpeckleMaxDiff(){
            return CStereoI3DRSGM.getSpeckleMaxDiff(m_AbstractStereoMatcher_instance);
        }

        /*!
        * Get enable/disable status of subpixel refinement from matcher
        * 
        * @returns enable/disable status of subpixel refinement
        */
        public bool isSubpixelEnabled(){
            return CStereoI3DRSGM.isSubpixelEnabled(m_AbstractStereoMatcher_instance);
        }

        /*!
        * Get enable/disable status of interpolation from matcher
        * 
        * @returns enable/disable status of interpolation
        */
        public bool isInterpolationEnabled(){
            return CStereoI3DRSGM.isSubpixelEnabled(m_AbstractStereoMatcher_instance);
        }

        /*!
        * Get enable/disable status of occlusion detection from matcher
        * 
        * @returns enable/disable status of occlusion detection
        */
        public bool isOcclusionDetectionEnabled(){
            return CStereoI3DRSGM.isOcclusionDetectionEnabled(m_AbstractStereoMatcher_instance);
        }

        /*!
        * Get enable/disable status of occlusion interpolation from matcher
        * 
        * @returns enable/disable status of occlusion interpolation
        */
        public bool isOcclusionInterpolationEnabled(){
            return CStereoI3DRSGM.isOcclusionInterpolationEnabled(m_AbstractStereoMatcher_instance);
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
            return CStereoI3DRSGM.isLicenseValid();
        }
    }
}