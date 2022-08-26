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
        public void test_PerfComputeDisparity()
        {
            // Test generation of disparity from stereo image pair
            // with image size of 2448x2048 is computed using ‘compute’ function
            // in 5s
            // TOTEST
        }
    }
}
