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
        public void test_ValidLoadROSYAML()
        {
            // Test calibration data is loaded from ROS YAML file
            // and values from file match parameters in calibration class 
            // TOTEST
        }

        [Fact]
        public void test_ValidLoadOpenCVYAML()
        {
            // Test calibration data is loaded from OpenCV YAML file
            // and values from file match parameters in calibration class 
            // TOTEST
        }

        [Fact]
        public void test_ValidCalibrationFromIdeal()
        {
            // Test Calibration data is loaded from ideal camera parameters
            // using ‘calibrationFromIdeal’ function and loaded parameters match expected values 
            // TOTEST
        }

        [Fact]
        public void test_SuccessfulRectify()
        {
            // Test image is successfully rectified using ‘rectify’ function 
            // TOTEST
        }

        [Fact]
        public void test_EmptyRectify()
        {
            // Test attempt to rectify empty image using
            // ‘rectify’ function should result in empty result image 
            // TOTEST
        }
    }
}
