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
using I3DR.Phase.Types;
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
            float timeout = 300; //ms
            int width = 2448;
            int height = 2048;
            byte[] left = new byte[height*width*3];
            for (int i = 0; i < left.Length; i++){left[i] = 1;}
            byte[] right = new byte[height*width*3];
            for (int i = 0; i < right.Length; i++){right[i] = 1;}
            StereoCameraCalibration cal = StereoCameraCalibration.calibrationFromIdeal(
                2448, 2048, 0.00000345, 0.012, 0.1);
            Assert.True(cal.isValid());

            long start = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
            StereoImagePair rect = cal.rectify(left, right, width, height);
            long end = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;

            long duration = end - start;
            Assert.True(duration < timeout, "Expected: " + timeout + " Actual: " + duration);
        }

        [Fact]
        public void test_PerfCalibFromImages()
        {
            // Test generation of calibration from series 13 images
            // of size 612x512 of a checkerboard completes in less than 5s
            float timeout = 5000; //ms
            string data_folder = "data";
            string left_cal_folder = data_folder + "/checker_sample";
            string right_cal_folder = data_folder + "/checker_sample";
            string left_img_wildcard = "*_l.png";
            string right_img_wildcard = "*_r.png";
            CalibrationBoardType board_type = CalibrationBoardType.CHECKERBOARD;

            long start = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
            StereoCameraCalibration cal = StereoCameraCalibration.calibrationFromImages(
                left_cal_folder, right_cal_folder,
                left_img_wildcard, right_img_wildcard,
                board_type, 10, 6, 0.039);
            long end = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
            
            Assert.True(cal.isValid());            
            long duration = end - start;
            Assert.True(duration < timeout, "Expected: " + timeout + " Actual: " + duration);
        }
    }
}
