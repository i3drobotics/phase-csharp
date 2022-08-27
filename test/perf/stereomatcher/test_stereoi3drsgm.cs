/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file test_stereoi3drsgm.cs
 * @brief Unit tests for StereoI3DRSGM
 * @details Unit tests generated using MSTest
 */

using Xunit;
using I3DR.Phase;
using I3DR.Phase.StereoMatcher;

namespace I3DR.PhaseTest
{
    // Tests for StereoI3DRSGM
    [Collection("PhaseSequentialTests")]
    public class StereoI3DRSGMTests
    {
        [Fact]
        public void test_PerfComputeDisparity()
        {
            // Test generation of disparity from stereo image pair
            // with image size of 2448x2048 is computed using ‘compute’ function
            // in 5s
            int timeout = 5000;
            string data_folder = "data";
            string left_img_filepath = data_folder + "/left.png";
            string right_img_filepath = data_folder + "/right.png";
            
            StereoParams stereo_params = new StereoParams(
                StereoMatcherType.STEREO_MATCHER_I3DRSGM,
                11, 0, 25, true
            );
            // TODO impliment create stereo matcher from stereo params
            // StereoBM matcher = StereoMatcher.createStereoMatcher(stereo_params);
            StereoI3DRSGM matcher = (StereoI3DRSGM) StereoMatcher.createStereoMatcher(StereoMatcherType.STEREO_MATCHER_I3DRSGM);
            
            int width = 2448;
            int height = 2048;
            byte[] left_img = Utils.readImage(left_img_filepath, 2448, 2048);
            byte[] right_img = Utils.readImage(right_img_filepath, 2448, 2048);

            long start = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
            StereoMatcherComputeResult match_result = matcher.compute(left_img, right_img, width, height);
            long end = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;

            long duration = end - start;
            Assert.True(duration < timeout, "Expected: " + timeout + " Actual: " + duration);
        }
    }
}
