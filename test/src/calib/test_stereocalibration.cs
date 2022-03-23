/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file test_stereocalibration.cs
 * @brief Unit tests for Stereo Calibration class
 * @details Unit tests generated using MSTest
 */

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using I3DR;

namespace I3DR.Phase.Test
{

    [TestClass]
    public class StereoCalibrationTests
    {
        [TestMethod]
        public void test_LoadCalibration()
        {
            string camera_name = "stereotheatresim";
            string resource_folder = "../../resources";
            string left_ros_yaml = resource_folder + "/test/" + camera_name + "/ros/left.yaml";
            string right_ros_yaml = resource_folder + "/test/" + camera_name + "/ros/right.yaml";
            string left_cv_yaml = resource_folder + "/test/" + camera_name + "/cv/left.yaml";
            string right_cv_yaml = resource_folder + "/test/" + camera_name + "/cv/right.yaml";

            StereoCameraCalibration cal_ros = StereoCameraCalibration.calibrationFromYAML(left_ros_yaml, right_ros_yaml);
            Assert.IsTrue(cal_ros.isValid());

            StereoCameraCalibration cal_cv = StereoCameraCalibration.calibrationFromYAML(left_cv_yaml, right_cv_yaml);
            Assert.IsTrue(cal_cv.isValid());

            Console.WriteLine("calibration load test success");
        }

        [TestMethod]
        public void test_SaveCalibration()
        {
            string camera_name = "stereotheatresim";
            string out_folder = "../../out/csharp";
            string resource_folder = "../../resources";
            string left_yaml = resource_folder + "/test/" + camera_name + "/ros/left.yaml";
            string right_yaml = resource_folder + "/test/" + camera_name + "/ros/right.yaml";

            StereoCameraCalibration cal = StereoCameraCalibration.calibrationFromYAML(left_yaml, right_yaml);
            Assert.IsTrue(cal.isValid());

            cal.saveToYAML(out_folder + "/left_ros.yaml", out_folder + "/right_ros.yaml", CalibrationFileType.ROS_YAML);
            cal.saveToYAML(out_folder + "/left_cv.yaml", out_folder + "/right_cv.yaml", CalibrationFileType.OPENCV_YAML);

            Console.WriteLine("calibration save test success");

            cal.dispose();
        }
    }
}
