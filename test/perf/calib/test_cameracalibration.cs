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
            float timeout = 300; //ms
            int width = 2448;
            int height = 2048;
            byte[] img = new byte[height*width*3];
            for (int i = 0; i < img.Length; i++){img[i] = 1;}
            CameraCalibration cal = CameraCalibration.calibrationFromIdeal(
                2448, 2048, 0.00000345, 0.012, 0.1, 0.0);
            Assert.True(cal.isValid());

            long start = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
            byte[] rect = cal.rectify(img, width, height);
            long end = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;

            long duration = end - start;
            Assert.True(duration < timeout, "Expected: " + timeout + " Actual: " + duration);
        }
    }
}
