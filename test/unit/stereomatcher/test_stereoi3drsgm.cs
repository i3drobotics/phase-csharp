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
        public void test_SettingGettingParams()
        {
            // Test matcher parameters can be set and get functions return expected values
            StereoI3DRSGM matcher = new StereoI3DRSGM();

            int window_size = 11;
            int min_disparity = 0;
            int num_disparities = 25;
            int speckle_max_size = 100;
            float speckle_max_diff = 0.5f;
            bool enable_subpixel = true;
            bool enable_interpolation = true;
            bool enable_occ_detection = true;
            bool enable_occ_interpolation = true;

            matcher.setWindowSize(window_size);
            matcher.setMinDisparity(min_disparity);
            matcher.setNumDisparities(num_disparities);
            matcher.setSpeckleMaxSize(speckle_max_size);
            matcher.setSpeckleMaxDiff(speckle_max_diff);
            matcher.enableSubpixel(enable_subpixel);
            matcher.enableInterpolation(enable_interpolation);
            matcher.enableOcclusionDetection(enable_occ_detection);
            matcher.enableOcclusionInterpolation(enable_occ_interpolation);

            Assert.Equal(window_size, matcher.getWindowSize());
            Assert.Equal(min_disparity, matcher.getMinDisparity());
            Assert.Equal(num_disparities, matcher.getNumDisparities());
            Assert.Equal(speckle_max_size, matcher.getSpeckleMaxSize());
            Assert.Equal(speckle_max_diff, matcher.getSpeckleMaxDiff());
            Assert.Equal(enable_subpixel, matcher.isSubpixelEnabled());
            Assert.Equal(enable_interpolation, matcher.isInterpolationEnabled());
            Assert.Equal(enable_occ_detection, matcher.isOcclusionDetectionEnabled());
            Assert.Equal(enable_occ_interpolation, matcher.isOcclusionInterpolationEnabled());
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
                StereoMatcherType.STEREO_MATCHER_I3DRSGM,
                window_size, min_disparity, num_disparities, true
            );
            StereoI3DRSGM matcher = (StereoI3DRSGM) StereoMatcher.createStereoMatcher(stereo_params);

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
                StereoMatcherType.STEREO_MATCHER_I3DRSGM,
                11, 0, 25, true
            );
            AbstractStereoMatcher matcher = StereoMatcher.createStereoMatcher(stereo_params);
            
            int width = 2448;
            int height = 2048;
            byte[] left_img = Utils.readImage(left_img_filepath, 2448, 2048);
            byte[] right_img = Utils.readImage(right_img_filepath, 2448, 2048);

            StereoMatcherComputeResult match_result = matcher.compute(left_img, right_img, width, height);

            bool license_valid = StereoI3DRSGM.isLicenseValid();
            if (license_valid){
                Assert.True(match_result.valid);
                float[] disparity = match_result.disparity;
                int precision = 2;
                Assert.Equal(-1.0f, disparity[0]);
                Assert.Equal(239.5f, disparity[(1024 * width + 1224)], precision);
                Assert.Equal(224.4375f, disparity[(1400 * width + 2200)], precision);
            } else {
                Assert.False(match_result.valid);
            }

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
                StereoMatcherType.STEREO_MATCHER_I3DRSGM,
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

            bool license_valid = StereoI3DRSGM.isLicenseValid();
            if (license_valid){
                Assert.True(match_result.valid);
                float[] disparity = match_result.disparity;
                int precision = 2;
                Assert.Equal(-1.0f, disparity[0]);
                Assert.Equal(239.5f, disparity[(1024 * width + 1224)], precision);
                Assert.Equal(224.4375f, disparity[(1400 * width + 2200)], precision);
            } else {
                Assert.False(match_result.valid);
            }

            matcher.dispose();
        }
    }
}
