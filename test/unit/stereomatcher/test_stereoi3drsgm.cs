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
            // TOTEST
        }

        [Fact]
        public void test_InitParamsValid()
        {
            // Test Matcher parameters defined at initialisation
            // respond with correct values when using get functions 
            // TOTEST
        }

        [Fact]
        public void test_ValidCompute()
        {
            // Test disparity image computed from ‘compute’ function
            // when given known sample stereo image pair has expected disparity values.
            // Will verify 3 locations in the disparity image.
            // TOTEST
        }

        [Fact]
        public void test_ValidThreadedCompute()
        {
            // Test disparity image computed in thread from ‘startThreadedCompute’ function
            // when given known sample stereo image pair has expected disparity values.
            // Will verify 3 locations in the disparity image. 
            // TOTEST
        }
    }
}
