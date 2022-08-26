/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file test_stereocalibration.cs
 * @brief Unit tests for Stereo Calibration class
 * @details Unit tests generated using MSTest
 */

using Xunit;
using System;
using System.IO;
using I3DR.Phase.Calib;

namespace I3DR.PhaseTest
{
    // Tests for Stereo Calibration
    [Collection("PhaseSequentialTests")]
    public class StereoCameraCalibrationTests
    {
        [Fact]
        public void test_PerfRectify()
        {
            // Test rectification of stereo image pair of size 2448x2048
            // using ‘rectify’ function is completed in less than 0.3s
            // TOTEST
        }
    }
}
