/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2022-09-01
 * @copyright Copyright (c) I3D Robotics Ltd, 2022
 * 
 * @file demo_calib_from_images.cs
 * @brief Example application loading stereo calibration from images
 */

using System;
using System.IO;
using I3DR.Phase;
using I3DR.Phase.Types;
using I3DR.Phase.StereoMatcher;
using I3DR.Phase.StereoCamera;
using I3DR.Phase.Calib;

namespace I3DR.PhaseDemo
{
    //!  Demo load stereo calibration from images
    /*!
    Demo program to generate stereo calibration from a series of images
    */
    class DemoCalibFromImages
    {
        static int Main(string[] args)
        {
            string test_folder = ".phase_test";
            string data_folder = "data";
            string left_yaml = test_folder + "/left.yaml";
            string right_yaml = test_folder + "/right.yaml";
            string left_cal_folder = data_folder + "/checker_sample";
            string right_cal_folder = data_folder + "/checker_sample";
            string left_img_wildcard = "*_l.png";
            string right_img_wildcard = "*_r.png";
            CalibrationBoardType image_type = CalibrationBoardType.CHECKERBOARD;

            // Load calibration
            StereoCameraCalibration cal = StereoCameraCalibration.calibrationFromImages(
                left_cal_folder, right_cal_folder,
                left_img_wildcard, right_img_wildcard,
                image_type, 10, 6, 0.039
            );
            if (!cal.isValid()){
                System.Console.WriteLine("Calibration is invalid");
                return -1;
            }

            // Save calibration to YAML
            bool save_success = cal.saveToYAML(left_yaml, right_yaml, CalibrationFileType.ROS_YAML);
            if (!save_success){
                System.Console.WriteLine("Failed to save calibration to YAML");
                return -1;
            }

            return 0;
        }
    }
}