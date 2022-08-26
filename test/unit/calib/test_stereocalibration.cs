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
        public void test_ValidLoadROSYAMLs()
        {
            // Test calibration data is loaded from ROS YAML file
            // and values from file match parameters in stereo calibration class
            // TOTEST
        }

        [Fact]
        public void test_ValidLoadOpenCVYAMLs()
        {
            // Test calibration data is loaded from OpenCV YAML file
            // and values from file match parameters in stereo calibration class 
            // TOTEST
        }

        [Fact]
        public void test_SaveROSYAMLIsValid()
        {
            // Test calibration data is saved to ROS YAML file
            // and values in file match parameters in calibration class 
            // TOTEST
        }

        [Fact]
        public void test_SaveOpenCVYAMLIsValid()
        {
            // Test calibration data is saved to OpenCV YAML file
            // and values in file match parameters in calibration class 
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
            // Test left and right images are successfully rectified using ‘rectify’ function 
            // TOTEST
        }

        [Fact]
        public void test_EmptyRectify()
        {
            // Test attempt to rectify empty images using
            // ‘rectify’ function should result in empty left and right images
            // TOTEST
        }



        // Test loading of calibration data from ROS and OpenCV type YAML files
        [Fact]
        public void test_LoadCalibration()
        {
            // TOTEST Remove test
            string test_folder = ".phase_test";
            // string data_folder = "../../../../data";
            string left_ros_yaml = test_folder + "/left_ros.yaml";
            string right_ros_yaml = test_folder + "/right_ros.yaml";
            string left_cv_yaml = test_folder + "/left_cv.yaml";
            string right_cv_yaml = test_folder + "/right_cv.yaml";

            Console.WriteLine("Generating test data...");

            Directory.CreateDirectory(test_folder);

            string left_ros_yaml_data = "" +
                "image_width: 2448\n" +
                "image_height: 2048\n" +
                "camera_name: leftCamera\n" +
                "camera_matrix:\n" +
                "   rows: 3\n" +
                "   cols: 3\n" +
                "   data: [ 3.4782608695652175e+03, 0., 1224., 0., 3.4782608695652175e+03, 1024., 0., 0., 1. ]\n" +
                "distortion_model: plumb_bob\n" +
                "distortion_coefficients:\n" +
                "   rows: 1\n" +
                "   cols: 5\n" +
                "   data: [ 0., 0., 0., 0., 0. ]\n" +
                "rectification_matrix:\n" +
                "   rows: 3\n" +
                "   cols: 3\n" +
                "   data: [1., 0., 0., 0., 1., 0., 0., 0., 1.]\n" +
                "projection_matrix:\n" +
                "   rows: 3\n" +
                "   cols: 4\n" +
                "   data: [ 3.4782608695652175e+03, 0., 1224., 0., 0., 3.4782608695652175e+03, 1024., 0., 0., 0., 1., 0. ]\n";
            string right_ros_yaml_data = "" +
                "image_width: 2448\n" +
                "image_height: 2048\n" +
                "camera_name: rightCamera\n" +
                "camera_matrix:\n" +
                "   rows: 3\n" +
                "   cols: 3\n" +
                "   data: [ 3.4782608695652175e+03, 0., 1224., 0., 3.4782608695652175e+03, 1024., 0., 0., 1. ]\n" +
                "distortion_model: plumb_bob\n" +
                "distortion_coefficients:\n" +
                "   rows: 1\n" +
                "   cols: 5\n" +
                "   data: [ 0., 0., 0., 0., 0. ]\n" +
                "rectification_matrix:\n" +
                "   rows: 3\n" +
                "   cols: 3\n" +
                "   data: [1., 0., 0., 0., 1., 0., 0., 0., 1.]\n" +
                "projection_matrix:\n" +
                "   rows: 3\n" +
                "   cols: 4\n" +
                "   data: [ 3.4782608695652175e+03, 0., 1224., -3.4782608695652175e+02, 0., 3.4782608695652175e+03, 1024., 0., 0., 0., 1., 0. ]\n";
            string left_cv_yaml_data = "" +
                "%YAML:1.0\n" +
                "---\n" +
                "image_width: 2448\n" +
                "image_height: 2048\n" +
                "camera_name: leftCamera\n" +
                "camera_matrix: !!opencv-matrix\n" +
                "   rows: 3\n" +
                "   cols: 3\n" +
                "   dt: d\n" +
                "   data: [ 3.4782608695652175e+03, 0., 1224., 0., 3.4782608695652175e+03, 1024., 0., 0., 1. ]\n" +
                "distortion_model: plumb_bob\n" +
                "distortion_coefficients: !!opencv-matrix\n" +
                "   rows: 1\n" +
                "   cols: 5\n" +
                "   dt: d\n" +
                "   data: [ 0., 0., 0., 0., 0. ]\n" +
                "rectification_matrix: !!opencv-matrix\n" +
                "   rows: 3\n" +
                "   cols: 3\n" +
                "   dt: d\n" +
                "   data: [1., 0., 0., 0., 1., 0., 0., 0., 1.]\n" +
                "projection_matrix: !!opencv-matrix\n" +
                "   rows: 3\n" +
                "   cols: 4\n" +
                "   dt: d\n" +
                "   data: [ 3.4782608695652175e+03, 0., 1224., 0., 0., 3.4782608695652175e+03, 1024., 0., 0., 0., 1., 0. ]\n" +
                "rms_error: \"\"\n";
            string right_cv_yaml_data = "" +
                "%YAML:1.0\n" +
                "---\n" +
                "image_width: 2448\n" +
                "image_height: 2048\n" +
                "camera_name: leftCamera\n" +
                "camera_matrix: !!opencv-matrix\n" +
                "   rows: 3\n" +
                "   cols: 3\n" +
                "   dt: d\n" +
                "   data: [ 3.4782608695652175e+03, 0., 1224., 0., 3.4782608695652175e+03, 1024., 0., 0., 1. ]\n" +
                "distortion_model: plumb_bob\n" +
                "distortion_coefficients: !!opencv-matrix\n" +
                "   rows: 1\n" +
                "   cols: 5\n" +
                "   dt: d\n" +
                "   data: [ 0., 0., 0., 0., 0. ]\n" +
                "rectification_matrix: !!opencv-matrix\n" +
                "   rows: 3\n" +
                "   cols: 3\n" +
                "   dt: d\n" +
                "   data: [1., 0., 0., 0., 1., 0., 0., 0., 1.]\n" +
                "projection_matrix: !!opencv-matrix\n" +
                "   rows: 3\n" +
                "   cols: 4\n" +
                "   dt: d\n" +
                "   data: [ 3.4782608695652175e+03, 0., 1224., -3.4782608695652175e+02, 0., 3.4782608695652175e+03, 1024., 0., 0., 0., 1., 0. ]\n" +
                "rms_error: \"\"\n";

            File.WriteAllText(left_ros_yaml, left_ros_yaml_data);
            File.WriteAllText(right_ros_yaml, right_ros_yaml_data);
            File.WriteAllText(left_cv_yaml, left_cv_yaml_data);
            File.WriteAllText(right_cv_yaml, right_cv_yaml_data);

            StereoCameraCalibration cal_ros = StereoCameraCalibration.calibrationFromYAML(left_ros_yaml, right_ros_yaml);
            Assert.True(cal_ros.isValid());

            StereoCameraCalibration cal_cv = StereoCameraCalibration.calibrationFromYAML(left_cv_yaml, right_cv_yaml);
            Assert.True(cal_cv.isValid());

            Console.WriteLine("calibration load test success");
        }

        // Test saving of calibration data as ROS and OpenCV YAML files
        [Fact]
        public void test_SaveCalibration()
        {
            // TOTEST remove test
            string test_folder = ".phase_test";
            // string data_folder = "../../../../data";
            string left_yaml = test_folder + "/left.yaml";
            string right_yaml = test_folder + "/right.yaml";
            string left_ros_yaml = test_folder + "/left_ros.yaml";
            string right_ros_yaml = test_folder + "/right_ros.yaml";
            string left_cv_yaml = test_folder + "/left_cv.yaml";
            string right_cv_yaml = test_folder + "/right_cv.yaml";

            Console.WriteLine("Generating test data...");

            Directory.CreateDirectory(test_folder);

            string left_yaml_data = "" +
                "image_width: 2448\n" +
                "image_height: 2048\n" +
                "camera_name: leftCamera\n" +
                "camera_matrix:\n" +
                "   rows: 3\n" +
                "   cols: 3\n" +
                "   data: [ 3.4782608695652175e+03, 0., 1224., 0., 3.4782608695652175e+03, 1024., 0., 0., 1. ]\n" +
                "distortion_model: plumb_bob\n" +
                "distortion_coefficients:\n" +
                "   rows: 1\n" +
                "   cols: 5\n" +
                "   data: [ 0., 0., 0., 0., 0. ]\n" +
                "rectification_matrix:\n" +
                "   rows: 3\n" +
                "   cols: 3\n" +
                "   data: [1., 0., 0., 0., 1., 0., 0., 0., 1.]\n" +
                "projection_matrix:\n" +
                "   rows: 3\n" +
                "   cols: 4\n" +
                "   data: [ 3.4782608695652175e+03, 0., 1224., 0., 0., 3.4782608695652175e+03, 1024., 0., 0., 0., 1., 0. ]\n";
            string right_yaml_data = "" +
                "image_width: 2448\n" +
                "image_height: 2048\n" +
                "camera_name: rightCamera\n" +
                "camera_matrix:\n" +
                "   rows: 3\n" +
                "   cols: 3\n" +
                "   data: [ 3.4782608695652175e+03, 0., 1224., 0., 3.4782608695652175e+03, 1024., 0., 0., 1. ]\n" +
                "distortion_model: plumb_bob\n" +
                "distortion_coefficients:\n" +
                "   rows: 1\n" +
                "   cols: 5\n" +
                "   data: [ 0., 0., 0., 0., 0. ]\n" +
                "rectification_matrix:\n" +
                "   rows: 3\n" +
                "   cols: 3\n" +
                "   data: [1., 0., 0., 0., 1., 0., 0., 0., 1.]\n" +
                "projection_matrix:\n" +
                "   rows: 3\n" +
                "   cols: 4\n" +
                "   data: [ 3.4782608695652175e+03, 0., 1224., -3.4782608695652175e+02, 0., 3.4782608695652175e+03, 1024., 0., 0., 0., 1., 0. ]\n";

            File.WriteAllText(left_yaml, left_yaml_data);
            File.WriteAllText(right_yaml, right_yaml_data);

            StereoCameraCalibration cal = StereoCameraCalibration.calibrationFromYAML(left_yaml, right_yaml);
            Assert.True(cal.isValid());

            cal.saveToYAML(left_ros_yaml, right_ros_yaml, CalibrationFileType.ROS_YAML);
            cal.saveToYAML(left_cv_yaml, right_cv_yaml, CalibrationFileType.OPENCV_YAML);

            Console.WriteLine("calibration save test success");

            cal.dispose();
        }
    }
}
