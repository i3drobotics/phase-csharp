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
using System.IO;
using I3DR.Phase.Types;
using I3DR.Phase.Calib;

namespace I3DR.PhaseTest
{
    class StereoCameraCalibrationTestUtils {

            //!  Generated calibration data structure
            /*!
            Struture to store generated calibration data
            */
            public struct CalData{
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

            //!  Generated stereo calibration data structure
            /*!
            Struture to store generated calibration data
            */
            public struct StereoCalData{
                public int image_width;
                public int image_height;
                public double hfov;
                public double baseline;
                public double focal_length;
                public double pixel_pitch;
                public double[] Q;
                public CalData left_cal_data;
                public CalData right_cal_data;
            };

            public static StereoCalData gen_cal_data(){
                StereoCalData stereo_cal_data = new StereoCalData();
                stereo_cal_data.image_width = 2448;
                stereo_cal_data.image_height = 2048;

                CalData left_cal_data;
                left_cal_data.fx = 3478.2608695652175;
                left_cal_data.fy = 3478.2608695652175;
                left_cal_data.cx = 1224;
                left_cal_data.cy = 1024;
                left_cal_data.proj_fx = left_cal_data.fx;
                left_cal_data.proj_fy = left_cal_data.fy;
                left_cal_data.proj_cx = left_cal_data.cx;
                left_cal_data.proj_cy = left_cal_data.cy;
                left_cal_data.proj_tx = 0.0;
                left_cal_data.cam_mat = new double[]{left_cal_data.fx, 0, left_cal_data.cx, 0, left_cal_data.fy, left_cal_data.cy, 0, 0, 1};
                left_cal_data.dist_coef = new double[]{0, 0, 0, 0, 0};
                left_cal_data.rect_mat = new double[]{ 1, 0, 0,
                                                        0, 1, 0,
                                                        0, 0, 1};
                left_cal_data.proj_mat = new double[]{left_cal_data.proj_fx, 0, left_cal_data.proj_cx, left_cal_data.proj_tx, 0, left_cal_data.proj_fy, left_cal_data.proj_cy, 0, 0, 0, 1, 0};

                CalData right_cal_data;
                right_cal_data.fx = 3478.2608695652175;
                right_cal_data.fy = 3478.2608695652175;
                right_cal_data.cx = 1224;
                right_cal_data.cy = 1024;
                right_cal_data.proj_fx = right_cal_data.fx;
                right_cal_data.proj_fy = right_cal_data.fy;
                right_cal_data.proj_cx = right_cal_data.cx;
                right_cal_data.proj_cy = right_cal_data.cy;
                right_cal_data.proj_tx = -347.8260921395;
                right_cal_data.cam_mat = new double[]{right_cal_data.fx, 0, right_cal_data.cx, 0, right_cal_data.fy, right_cal_data.cy, 0, 0, 1};
                right_cal_data.dist_coef = new double[]{0, 0, 0, 0, 0};
                right_cal_data.rect_mat = new double[]{ 1, 0, 0,
                                                        0, 1, 0,
                                                        0, 0, 1};
                right_cal_data.proj_mat = new double[]{right_cal_data.proj_fx, 0, right_cal_data.proj_cx, right_cal_data.proj_tx, 0, right_cal_data.proj_fy, right_cal_data.proj_cy, 0, 0, 0, 1, 0};

                stereo_cal_data.left_cal_data = left_cal_data;
                stereo_cal_data.right_cal_data = right_cal_data;
                stereo_cal_data.hfov = 0.67673f;
                stereo_cal_data.focal_length = 0.012;
                stereo_cal_data.pixel_pitch = 0.00000345;
                stereo_cal_data.baseline = 0.1f;
                stereo_cal_data.Q = new double[]{1, 0, 0, 0, 
                                                 0, 1, 0, 0,
                                                 0, 0, 1, 0,
                                                 0, 0, 0, 1};
                int cols = 4;
                stereo_cal_data.Q[(0 * cols + 3)] = -1224.0;
                stereo_cal_data.Q[(1 * cols + 3)] = -1024.0;
                stereo_cal_data.Q[(2 * cols + 2)] = 0.0;
                stereo_cal_data.Q[(2 * cols + 3)] = (float) 3478.2608695652175;
                stereo_cal_data.Q[(3 * cols + 2)] = 10.0;
                stereo_cal_data.Q[(3 * cols + 3)] = 0.0;
                return stereo_cal_data;
            }

            public static void verify_stereo_cal(StereoCameraCalibration cal, StereoCalData st_cal_data){
                Assert.True(cal.isValid());

                // TODO impliment get method for left and right calibration in StereoCameraCalibration
                // CameraCalibration left_cal = cal.left_calibration;
                // CameraCalibration right_cal = cal.right_calibration;

                CalData lcal = st_cal_data.left_cal_data;
                CalData rcal = st_cal_data.right_cal_data;

                // TODO impliment get methods for calibration parameters

                // REQUIRE(left_cal.getImageHeight() == st_cal_data.image_height);
                // REQUIRE(left_cal.getImageWidth() == st_cal_data.image_width);
                // REQUIRE(left_cal.getCameraCX() == lcal.cx);
                // REQUIRE(left_cal.getCameraCY() == lcal.cy);
                // REQUIRE(left_cal.getCameraFX() == lcal.fx);
                // REQUIRE(left_cal.getCameraFY() == lcal.fy);
                // REQUIRE(left_cal.getProjectionCX() == lcal.proj_cx);
                // REQUIRE(left_cal.getProjectionCY() == lcal.proj_cy);
                // REQUIRE(left_cal.getProjectionFX() == lcal.proj_fx);
                // REQUIRE(left_cal.getProjectionFY() == lcal.proj_fy);
                // REQUIRE(left_cal.getProjectionTX() == lcal.proj_tx);
                // REQUIRE(right_cal.getImageHeight() == st_cal_data.image_height);
                // REQUIRE(right_cal.getImageWidth() == st_cal_data.image_width);
                // REQUIRE(right_cal.getCameraCX() == rcal.cx);
                // REQUIRE(right_cal.getCameraCY() == rcal.cy);
                // REQUIRE(right_cal.getCameraFX() == rcal.fx);
                // REQUIRE(right_cal.getCameraFY() == rcal.fy);
                // REQUIRE(right_cal.getProjectionCX() == rcal.proj_cx);
                // REQUIRE(right_cal.getProjectionCY() == rcal.proj_cy);
                // REQUIRE(right_cal.getProjectionFX() == rcal.proj_fx);
                // REQUIRE(right_cal.getProjectionFY() == rcal.proj_fy);
                // REQUIRE(fabs(right_cal.getProjectionTX() - rcal.proj_tx) < 0.0001 );

                // REQUIRE(cv::sum(left_cal.getCameraMatrix() != lcal.cam_mat) == cv::Scalar(0));
                // REQUIRE(cv::sum(right_cal.getCameraMatrix() != rcal.cam_mat) == cv::Scalar(0));
                // REQUIRE(cv::sum(left_cal.getDistortionCoefficients() != lcal.dist_coef) == cv::Scalar(0));
                // REQUIRE(cv::sum(right_cal.getDistortionCoefficients() != rcal.dist_coef) == cv::Scalar(0));
                // REQUIRE(cv::sum(left_cal.getRectificationMatrix() != lcal.rect_mat) == cv::Scalar(0));
                // REQUIRE(cv::sum(right_cal.getRectificationMatrix() != rcal.rect_mat) == cv::Scalar(0));

                // REQUIRE(cv::sum(left_cal.getProjectionMatrix() != lcal.proj_mat) == cv::Scalar(0));
                // // REQUIRE(cv::sum(right_cal.getProjectionMatrix() != rcal.proj_mat) == cv::Scalar(0));
                // REQUIRE(right_cal.getProjectionMatrix().at<double>(0,0) == rcal.proj_mat.at<double>(0,0));
                // REQUIRE(right_cal.getProjectionMatrix().at<double>(0,1) == rcal.proj_mat.at<double>(0,1));
                // REQUIRE(right_cal.getProjectionMatrix().at<double>(0,2) == rcal.proj_mat.at<double>(0,2));
                // REQUIRE(fabs(right_cal.getProjectionMatrix().at<double>(0,3) - rcal.proj_mat.at<double>(0,3)) < 0.0001 );
                // REQUIRE(right_cal.getProjectionMatrix().at<double>(1,0) == rcal.proj_mat.at<double>(1,0));
                // REQUIRE(right_cal.getProjectionMatrix().at<double>(1,1) == rcal.proj_mat.at<double>(1,1));
                // REQUIRE(right_cal.getProjectionMatrix().at<double>(1,2) == rcal.proj_mat.at<double>(1,2));
                // REQUIRE(right_cal.getProjectionMatrix().at<double>(1,3) == rcal.proj_mat.at<double>(1,3));
                // REQUIRE(right_cal.getProjectionMatrix().at<double>(2,0) == rcal.proj_mat.at<double>(2,0));
                // REQUIRE(right_cal.getProjectionMatrix().at<double>(2,1) == rcal.proj_mat.at<double>(2,1));
                // REQUIRE(right_cal.getProjectionMatrix().at<double>(2,2) == rcal.proj_mat.at<double>(2,2));
                // REQUIRE(right_cal.getProjectionMatrix().at<double>(2,3) == rcal.proj_mat.at<double>(2,3));

                // REQUIRE(fabs(cal.getHFOV() - st_cal_data.hfov) < 0.001 );
                // REQUIRE(fabs(cal.getBaseline() - st_cal_data.baseline) < 0.001 );
                // cv::Mat Q = cal.getQ();
                // // check Q matrix is equal to known valid q matrix
                // REQUIRE(cv::sum(st_cal_data.Q != Q) == cv::Scalar(0));
            }

            public static void save_yaml_data(StereoCalData st_cal_data, CalibrationFileType cal_type, string left_yaml, string right_yaml){ 
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




    // Tests for Stereo Calibration
    [Collection("PhaseSequentialTests")]
    public class StereoCameraCalibrationTests
    {
        [Fact]
        public void test_ValidLoadROSYAMLs()
        {
            // Test calibration data is loaded from ROS YAML file
            // and values from file match parameters in stereo calibration class
            string test_folder = ".phase_test";
            string left_yaml = test_folder + "/left.yaml";
            string right_yaml = test_folder + "/right.yaml";

            // Create output folder
            System.IO.Directory.CreateDirectory(test_folder);
            
            StereoCameraCalibrationTestUtils.StereoCalData st_cal_data = StereoCameraCalibrationTestUtils.gen_cal_data();
            StereoCameraCalibrationTestUtils.save_yaml_data(st_cal_data, CalibrationFileType.ROS_YAML, left_yaml, right_yaml);

            // Load calibration files
            StereoCameraCalibration cal = StereoCameraCalibration.calibrationFromYAML(left_yaml, right_yaml);
            
            StereoCameraCalibrationTestUtils.verify_stereo_cal(cal, st_cal_data);
            cal.dispose();
        }

        [Fact]
        public void test_ValidLoadOpenCVYAMLs()
        {
            // Test calibration data is loaded from OpenCV YAML file
            // and values from file match parameters in stereo calibration class 
            string test_folder = ".phase_test";
            string left_yaml = test_folder + "/left.yaml";
            string right_yaml = test_folder + "/right.yaml";

            // Create output folder
            System.IO.Directory.CreateDirectory(test_folder);
            
            StereoCameraCalibrationTestUtils.StereoCalData st_cal_data = StereoCameraCalibrationTestUtils.gen_cal_data();
            StereoCameraCalibrationTestUtils.save_yaml_data(st_cal_data, CalibrationFileType.OPENCV_YAML, left_yaml, right_yaml);

            // Load calibration files
            StereoCameraCalibration cal = StereoCameraCalibration.calibrationFromYAML(left_yaml, right_yaml);
            
            StereoCameraCalibrationTestUtils.verify_stereo_cal(cal, st_cal_data);
            cal.dispose();
        }

        [Fact]
        public void test_SaveROSYAMLIsValid()
        {
            // Test calibration data is saved to ROS YAML file
            // and values in file match parameters in calibration class 
            string test_folder = ".phase_test";
            string left_yaml = test_folder + "/left.yaml";
            string right_yaml = test_folder + "/right.yaml";
            CalibrationFileType cal_type = CalibrationFileType.ROS_YAML;

            // Create output folder
            System.IO.Directory.CreateDirectory(test_folder);
            
            StereoCameraCalibrationTestUtils.StereoCalData st_cal_data = StereoCameraCalibrationTestUtils.gen_cal_data();
            StereoCameraCalibration cal = StereoCameraCalibration.calibrationFromIdeal(
                st_cal_data.image_width, st_cal_data.image_height,
                st_cal_data.pixel_pitch, st_cal_data.focal_length, st_cal_data.baseline);
            Assert.True(cal.isValid());

            bool save_success = cal.saveToYAML(
                left_yaml,
                right_yaml, 
                cal_type);

            Assert.True(save_success);

            StereoCameraCalibration cal_out = StereoCameraCalibration.calibrationFromYAML(left_yaml, right_yaml);

            StereoCameraCalibrationTestUtils.verify_stereo_cal(cal, st_cal_data);
            cal.dispose();
            cal_out.dispose();
        }

        [Fact]
        public void test_SaveOpenCVYAMLIsValid()
        {
            // Test calibration data is saved to OpenCV YAML file
            // and values in file match parameters in calibration class 
            string test_folder = ".phase_test";
            string left_yaml = test_folder + "/left.yaml";
            string right_yaml = test_folder + "/right.yaml";
            CalibrationFileType cal_type = CalibrationFileType.OPENCV_YAML;

            // Create output folder
            System.IO.Directory.CreateDirectory(test_folder);
            
            StereoCameraCalibrationTestUtils.StereoCalData st_cal_data = StereoCameraCalibrationTestUtils.gen_cal_data();
            StereoCameraCalibration cal = StereoCameraCalibration.calibrationFromIdeal(
                st_cal_data.image_width, st_cal_data.image_height,
                st_cal_data.pixel_pitch, st_cal_data.focal_length, st_cal_data.baseline);
            Assert.True(cal.isValid());

            bool save_success = cal.saveToYAML(
                left_yaml,
                right_yaml, 
                cal_type);

            Assert.True(save_success);

            StereoCameraCalibration cal_out = StereoCameraCalibration.calibrationFromYAML(left_yaml, right_yaml);

            StereoCameraCalibrationTestUtils.verify_stereo_cal(cal, st_cal_data);
            cal.dispose();
            cal_out.dispose();
        }

        [Fact]
        public void test_ValidCalibrationFromIdeal()
        {
            // Test Calibration data is loaded from ideal camera parameters
            // using ‘calibrationFromIdeal’ function and loaded parameters match expected values
            StereoCameraCalibrationTestUtils.StereoCalData st_cal_data = StereoCameraCalibrationTestUtils.gen_cal_data();
            StereoCameraCalibration cal = StereoCameraCalibration.calibrationFromIdeal(
                st_cal_data.image_width, st_cal_data.image_height,
                st_cal_data.pixel_pitch, st_cal_data.focal_length, st_cal_data.baseline);
            Assert.True(cal.isValid());
            StereoCameraCalibrationTestUtils.verify_stereo_cal(cal, st_cal_data);
            cal.dispose();
        }

        [Fact]
        public void test_SuccessfulRectify()
        {
            // Test left and right images are successfully rectified using ‘rectify’ function 
            int width = 2448;
            int height = 2048;
            byte[] left = new byte[height*width*3];
            for (int i = 0; i < left.Length; i++){left[i] = 1;}
            byte[] right = new byte[height*width*3];
            for (int i = 0; i < right.Length; i++){right[i] = 1;}
            StereoCameraCalibrationTestUtils.StereoCalData st_cal_data = StereoCameraCalibrationTestUtils.gen_cal_data();
            StereoCameraCalibration cal = StereoCameraCalibration.calibrationFromIdeal(
                st_cal_data.image_width, st_cal_data.image_height,
                st_cal_data.pixel_pitch, st_cal_data.focal_length, st_cal_data.baseline);
            Assert.True(cal.isValid());
            StereoImagePair rect = cal.rectify(left, right, width, height);
            Assert.True(rect.left.Length > 0);
            Assert.True(rect.right.Length > 0);
            cal.dispose();
        }
    }
}
