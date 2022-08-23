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
using I3DR.CPhase.StereoMatcher;

namespace I3DR.Phase.StereoMatcher
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
                return new StereoI3DRSGM(CStereoMatcher.createStereoMatcher(matcher_type));
            } else if (matcher_type == StereoMatcherType.STEREO_MATCHER_BM){
                return new StereoBM(CStereoMatcher.createStereoMatcher(matcher_type));
            } else if (matcher_type == StereoMatcherType.STEREO_MATCHER_SGBM){
                return new StereoSGBM(CStereoMatcher.createStereoMatcher(matcher_type));
            } else {
                throw new ArgumentException(
                    String.Format("Unsupported matcher type: {0}", matcher_type),"matcher_type");
            }
        }
    }
}