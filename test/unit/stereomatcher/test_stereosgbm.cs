/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file test_stereosgbm.cs
 * @brief Unit tests for StereoSGBM
 * @details Unit tests generated using MSTest
 */

using Xunit;
using I3DR.Phase.StereoMatcher;
using I3DR.Phase;

namespace I3DR.PhaseTest
{
    // Tests for StereoSGBM
    [Collection("PhaseSequentialTests")]
    public class StereoSGBMTests
    {
        [Fact]
        public void test_SettingGettingParams()
        {
            // Test matcher parameters can be set and get functions return expected values
            StereoSGBM matcher = new StereoSGBM();

            int window_size = 11;
            int min_disparity = 0;
            int num_disparities = 25;

            matcher.setWindowSize(window_size);
            matcher.setMinDisparity(min_disparity);
            matcher.setNumDisparities(num_disparities);

            Assert.Equal(window_size, matcher.getWindowSize());
            Assert.Equal(min_disparity, matcher.getMinDisparity());
            Assert.Equal(num_disparities, matcher.getNumDisparities());
            matcher.dispose();
        }

        [Fact]
        public void test_InitParamsValid()
        {
            // Test Matcher parameters defined at initialisation
            // respond with correct values when using get functions 
            int window_size = 11;
            int min_disparity = 0;
            int num_disparities = 25;
            
            StereoParams stereo_params = new StereoParams(
                StereoMatcherType.STEREO_MATCHER_SGBM,
                window_size, min_disparity, num_disparities, true
            );
            StereoSGBM matcher = (StereoSGBM) StereoMatcher.createStereoMatcher(stereo_params);

            Assert.Equal(window_size, matcher.getWindowSize());
            Assert.Equal(min_disparity, matcher.getMinDisparity());
            Assert.Equal(num_disparities, matcher.getNumDisparities());
        }

        [Fact]
        public void test_ValidCompute()
        {
            // Test disparity image computed from ‘compute’ function
            // when given known sample stereo image pair has expected disparity values.
            // Will verify 3 locations in the disparity image.
            string data_folder = "data";
            string left_img_filepath = data_folder + "/left.png";
            string right_img_filepath = data_folder + "/right.png";
            
            StereoParams stereo_params = new StereoParams(
                StereoMatcherType.STEREO_MATCHER_SGBM,
                11, 0, 25, true
            );
            AbstractStereoMatcher matcher = StereoMatcher.createStereoMatcher(stereo_params);
            
            int width = 2448;
            int height = 2048;
            byte[] left_img = Utils.readImage(left_img_filepath, 2448, 2048);
            byte[] right_img = Utils.readImage(right_img_filepath, 2448, 2048);

            StereoMatcherComputeResult match_result = matcher.compute(left_img, right_img, width, height);

            Assert.True(match_result.valid);

            float[] disparity = match_result.disparity;
            int precision = 2;
            Assert.Equal(-1.0f, disparity[0]);
            Assert.Equal(239.44f, disparity[(1024 * width + 1224)], precision);
            Assert.Equal(224.44f, disparity[(1400 * width + 2200)], precision);

            matcher.dispose();
        }

        [Fact]
        public void test_ValidThreadedCompute()
        {
            // Test disparity image computed in thread from ‘startThreadedCompute’ function
            // when given known sample stereo image pair has expected disparity values.
            // Will verify 3 locations in the disparity image. 
            string data_folder = "data";
            string left_img_filepath = data_folder + "/left.png";
            string right_img_filepath = data_folder + "/right.png";
            
            StereoParams stereo_params = new StereoParams(
                StereoMatcherType.STEREO_MATCHER_SGBM,
                11, 0, 25, true
            );
            AbstractStereoMatcher matcher = StereoMatcher.createStereoMatcher(stereo_params);
            
            int width = 2448;
            int height = 2048;
            byte[] left_img = Utils.readImage(left_img_filepath, 2448, 2048);
            byte[] right_img = Utils.readImage(right_img_filepath, 2448, 2048);

            matcher.startComputeThread(left_img, right_img, width, height);

            int timeout = 30000; // seconds
            long start = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
            while(matcher.isComputeThreadRunning()){
                System.Threading.Thread.Sleep(1);
                long end = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
                long duration = end - start;
                if (duration > timeout){
                    Assert.True(duration < timeout);
                    break;
                }
            }

            StereoMatcherComputeResult match_result = matcher.getComputeThreadResult(width, height);

            Assert.True(match_result.valid);

            float[] disparity = match_result.disparity;
            int precision = 2;
            Assert.Equal(-1.0f, disparity[0]);
            Assert.Equal(239.44f, disparity[(1024 * width + 1224)], precision);
            Assert.Equal(224.44f, disparity[(1400 * width + 2200)], precision);

            matcher.dispose();
        }

    }
}
