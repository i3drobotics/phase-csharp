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
using System.IO;
using I3DR.Phase.Calib;

namespace I3DR.PhaseTest
{
    class CameraCalibrationTestUtils {

            //!  Generated calibration data structure
            /*!
            Struture to store generated calibration data
            */
            public struct CalData{
                public int image_width;
                public int image_height;
                public double focal_length;
                public double pixel_pitch;
                public double translation_x;
                public double translation_y;
                public double fx;
                public double fy;
                public double cx;
                public double cy;
                public double proj_fx;
                public double proj_fy;
                public double proj_cx;
                public double proj_cy;
                public double proj_tx;
                public double[] cam_mat;
                public double[] dist_coef;
                public double[] rect_mat;
                public double[] proj_mat;
            };

            public static CalData gen_cal_data(){
                CalData cal_data = new CalData();
                cal_data.image_width = 2448;
                cal_data.image_height = 2048;
                cal_data.focal_length = 0.012;
                cal_data.pixel_pitch = 0.00000345;
                cal_data.translation_x = 0.1f;
                cal_data.translation_y = 0.0;
                cal_data.fx = 3478.2608695652175;
                cal_data.fy = 3478.2608695652175;
                cal_data.cx = 1224;
                cal_data.cy = 1024;
                cal_data.proj_fx = cal_data.fx;
                cal_data.proj_fy = cal_data.fy;
                cal_data.proj_cx = cal_data.cx;
                cal_data.proj_cy = cal_data.cy;
                cal_data.proj_tx = -347.8260921395;
                cal_data.cam_mat = new double[]{cal_data.fx, 0, cal_data.cx, 0, cal_data.fy, cal_data.cy, 0, 0, 1};
                cal_data.dist_coef = new double[]{0, 0, 0, 0, 0};
                cal_data.rect_mat = new double[]{ 1, 0, 0,
                                                        0, 1, 0,
                                                        0, 0, 1};
                cal_data.proj_mat = new double[]{cal_data.proj_fx, 0, cal_data.proj_cx, cal_data.proj_tx, 0, cal_data.proj_fy, cal_data.proj_cy, 0, 0, 0, 1, 0};
                return cal_data;
            }

            public static void verify_stereo_cal(CameraCalibration cal, CalData cal_data){
                Assert.True(cal.isValid());

                // TODO impliment get methods for calibration parameters

                // REQUIRE(cal.getImageHeight() == cal_data.image_height);
                // REQUIRE(cal.getImageWidth() == cal_data.image_width);
                // REQUIRE(cal.getCameraCX() == cal_data.cx);
                // REQUIRE(cal.getCameraCY() == cal_data.cy);
                // REQUIRE(cal.getCameraFX() == cal_data.fx);
                // REQUIRE(cal.getCameraFY() == cal_data.fy);
                // REQUIRE(cal.getProjectionCX() == cal_data.proj_cx);
                // REQUIRE(cal.getProjectionCY() == cal_data.proj_cy);
                // REQUIRE(cal.getProjectionFX() == cal_data.proj_fx);
                // REQUIRE(cal.getProjectionFY() == cal_data.proj_fy);
                // REQUIRE(fabs(cal.getProjectionTX() - cal_data.proj_tx) < 0.0001 );

                // REQUIRE(cv::sum(cal.getCameraMatrix() != cal_data.cam_mat) == cv::Scalar(0));
                // REQUIRE(cv::sum(cal.getDistortionCoefficients() != cal_data.dist_coef) == cv::Scalar(0));
                // REQUIRE(cv::sum(cal.getRectificationMatrix() != cal_data.rect_mat) == cv::Scalar(0));

                // REQUIRE(cal.getProjectionMatrix().at<double>(0,0) == cal_data.proj_mat.at<double>(0,0));
                // REQUIRE(cal.getProjectionMatrix().at<double>(0,1) == cal_data.proj_mat.at<double>(0,1));
                // REQUIRE(cal.getProjectionMatrix().at<double>(0,2) == cal_data.proj_mat.at<double>(0,2));
                // REQUIRE(fabs(cal.getProjectionMatrix().at<double>(0,3) - cal_data.proj_mat.at<double>(0,3)) < 0.0001 );
                // REQUIRE(cal.getProjectionMatrix().at<double>(1,0) == cal_data.proj_mat.at<double>(1,0));
                // REQUIRE(cal.getProjectionMatrix().at<double>(1,1) == cal_data.proj_mat.at<double>(1,1));
                // REQUIRE(cal.getProjectionMatrix().at<double>(1,2) == cal_data.proj_mat.at<double>(1,2));
                // REQUIRE(cal.getProjectionMatrix().at<double>(1,3) == cal_data.proj_mat.at<double>(1,3));
                // REQUIRE(cal.getProjectionMatrix().at<double>(2,0) == cal_data.proj_mat.at<double>(2,0));
                // REQUIRE(cal.getProjectionMatrix().at<double>(2,1) == cal_data.proj_mat.at<double>(2,1));
                // REQUIRE(cal.getProjectionMatrix().at<double>(2,2) == cal_data.proj_mat.at<double>(2,2));
                // REQUIRE(cal.getProjectionMatrix().at<double>(2,3) == cal_data.proj_mat.at<double>(2,3));
            }

            public static void save_yaml_data(CalData cal_data, CalibrationFileType cal_type, string left_yaml, string right_yaml){ 
                Assert.True((cal_type == CalibrationFileType.OPENCV_YAML || cal_type == CalibrationFileType.ROS_YAML));
                string left_yaml_data = "";
                string right_yaml_data = "";
                // TODO fill yaml data strings from StereoCalData
                if (cal_type ==CalibrationFileType.OPENCV_YAML){
                    left_yaml_data = @"
%YAML:1.0
---
image_width: 2448
image_height: 2048
camera_name: leftCamera
camera_matrix: !!opencv-matrix
   rows: 3
   cols: 3
   dt: d
   data: [ 3.4782608695652175e+03, 0., 1224., 0., 3.4782608695652175e+03, 1024., 0., 0., 1. ]
distortion_model: plumb_bob
distortion_coefficients: !!opencv-matrix
   rows: 1
   cols: 5
   dt: d
   data: [ 0., 0., 0., 0., 0. ]
rectification_matrix: !!opencv-matrix
   rows: 3
   cols: 3
   dt: d
   data: [1., 0., 0., 0., 1., 0., 0., 0., 1.]
projection_matrix: !!opencv-matrix
   rows: 3
   cols: 4
   dt: d
   data: [ 3.4782608695652175e+03, 0., 1224., 0., 0., 3.4782608695652175e+03, 1024., 0., 0., 0., 1., 0. ]
rms_error: ";
                    right_yaml_data = @"
%YAML:1.0
---
image_width: 2448
image_height: 2048
camera_name: leftCamera
camera_matrix: !!opencv-matrix
   rows: 3
   cols: 3
   dt: d
   data: [ 3.4782608695652175e+03, 0., 1224., 0., 3.4782608695652175e+03, 1024., 0., 0., 1. ]
distortion_model: plumb_bob
distortion_coefficients: !!opencv-matrix
   rows: 1
   cols: 5
   dt: d
   data: [ 0., 0., 0., 0., 0. ]
rectification_matrix: !!opencv-matrix
   rows: 3
   cols: 3
   dt: d
   data: [1., 0., 0., 0., 1., 0., 0., 0., 1.]
projection_matrix: !!opencv-matrix
   rows: 3
   cols: 4
   dt: d
   data: [ 3.4782608695652175e+03, 0., 1224., -347.8260921395, 0., 3.4782608695652175e+03, 1024., 0., 0., 0., 1., 0. ]
rms_error: ";
                } else if (cal_type == CalibrationFileType.ROS_YAML){
                    left_yaml_data = @"
image_width: 2448
image_height: 2048
camera_name: leftCamera
camera_matrix:
   rows: 3
   cols: 3
   data: [ 3.4782608695652175e+03, 0., 1224., 0., 3.4782608695652175e+03, 1024., 0., 0., 1. ]
distortion_model: plumb_bob
distortion_coefficients:
   rows: 1
   cols: 5
   data: [ 0., 0., 0., 0., 0. ]
rectification_matrix:
   rows: 3
   cols: 3
   data: [1., 0., 0., 0., 1., 0., 0., 0., 1.]
projection_matrix:
   rows: 3
   cols: 4
   data: [ 3.4782608695652175e+03, 0., 1224., 0., 0., 3.4782608695652175e+03, 1024., 0., 0., 0., 1., 0. ]";
                    right_yaml_data = @"
image_width: 2448
image_height: 2048
camera_name: rightCamera
camera_matrix:
    rows: 3
    cols: 3
    data: [ 3.4782608695652175e+03, 0., 1224., 0., 3.4782608695652175e+03, 1024., 0., 0., 1. ]
distortion_model: plumb_bob
distortion_coefficients:
    rows: 1
    cols: 5
    data: [ 0., 0., 0., 0., 0. ]
rectification_matrix:
    rows: 3
    cols: 3
    data: [1., 0., 0., 0., 1., 0., 0., 0., 1.]
projection_matrix:
    rows: 3
    cols: 4
    data: [ 3.4782608695652175e+03, 0., 1224., -347.8260921395, 0., 3.4782608695652175e+03, 1024., 0., 0., 0., 1., 0. ]";
                }
                File.WriteAllText(left_yaml, left_yaml_data);
                File.WriteAllText(right_yaml, right_yaml_data);
            }
        }


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
