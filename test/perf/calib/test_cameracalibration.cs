/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file test_cameracalibration.cs
 * @brief Unit tests for Camera Calibration class
 * @details Unit tests generated using MSTest
 */

using Xunit;
using I3DR.Phase.Calib;

namespace I3DR.PhaseTest
{
    // Tests for CameraCalibration
    [Collection("PhaseSequentialTests")]
    public class CameraCalibrationTests
    {
        [Fact]
        public void test_PerfRectify()
        {
            // Test rectification of image of size 2448x2048
            // using ‘rectify’ function is completed in less than 0.2s
            // TOTEST
        }
    }
}
