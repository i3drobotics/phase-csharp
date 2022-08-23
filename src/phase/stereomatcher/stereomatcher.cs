/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file stereomatcher.cs
 * @brief Stereo Matcher class
 * @details Create stereo matcher of any type using 
 * StereoMatcherType. This allows for the same interface to be
 * used for any stereo matcher. 
 */

using System;
using I3DR.CPhase;

namespace I3DR.Phase
{
    //!  Stereo Matcher class
    /*!
    Create stereo matcher of any type using 
    StereoMatcherType. This allows for the same interface to be
    used for any stereo matcher. 
    */
    public class StereoMatcher
    {
        /*!
        * Create stereo matching from stereo matcher type
        *
        * @param matcher_type stereo matcher type to create
        * @returns stereo matcher object of type specified
        */
        public static AbstractStereoMatcher createStereoMatcher(StereoMatcherType matcher_type){
            if (matcher_type == StereoMatcherType.STEREO_MATCHER_I3DRSGM){
                return new StereoI3DRSGM(CCreateStereoMatcher(matcher_type));
            } else if (matcher_type == StereoMatcherType.STEREO_MATCHER_BM){
                return new StereoBM(CCreateStereoMatcher(matcher_type));
            } else if (matcher_type == StereoMatcherType.STEREO_MATCHER_SGBM){
                return new StereoSGBM(CCreateStereoMatcher(matcher_type));
            } else if (matcher_type == StereoMatcherType.STEREO_MATCHER_HOBM){
                return new StereoHOBM(CCreateStereoMatcher(matcher_type));
            } else {
                throw new ArgumentException(
                    String.Format("Unsupported matcher type: {0}", matcher_type),"matcher_type");
            }
        }
    }
}