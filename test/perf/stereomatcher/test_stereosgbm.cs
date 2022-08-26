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

namespace I3DR.PhaseTest
{
    // Tests for StereoSGBM
    [Collection("PhaseSequentialTests")]
    public class StereoSGBMTests
    {
        [Fact]
        public void test_PerfComputeDisparity()
        {
            // Test generation of disparity from stereo image pair
            // with image size of 2448x2048 is computed using ‘compute’ function
            // in 20s
            // TOTEST
        }
    }
}
