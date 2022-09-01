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
using System.Linq;
using System;
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
                public float[] Q;
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
                stereo_cal_data.Q = new float[]{1, 0, 0, 0, 
                                                 0, 1, 0, 0,
                                                 0, 0, 1, 0,
                                                 0, 0, 0, 1};
                int cols = 4;
                stereo_cal_data.Q[(0 * cols + 3)] = -1224.0f;
                stereo_cal_data.Q[(1 * cols + 3)] = -1024.0f;
                stereo_cal_data.Q[(2 * cols + 2)] = 0.0f;
                stereo_cal_data.Q[(2 * cols + 3)] = (float) 3478.2608695652175;
                stereo_cal_data.Q[(3 * cols + 2)] = 10.0f;
                stereo_cal_data.Q[(3 * cols + 3)] = 0.0f;
                return stereo_cal_data;
            }

            public static StereoCalData gen_checker_sample_data(){
                StereoCalData stereo_cal_data = new StereoCalData();
                stereo_cal_data.image_width = 612;
                stereo_cal_data.image_height = 512;

                CalData left_cal_data;
                left_cal_data.fx = 879.6401059203;
                left_cal_data.fy = 879.8789408574;
                left_cal_data.cx = 304.5127903095;
                left_cal_data.cy = 265.9179405536;
                left_cal_data.proj_fx = 879.2624248102;
                left_cal_data.proj_fy = 879.2624248102;
                left_cal_data.proj_cx = 163.9255523682;
                left_cal_data.proj_cy = 264.7968616486;
                left_cal_data.proj_tx = 0.0;
                left_cal_data.cam_mat = new double[]{left_cal_data.fx, 0, left_cal_data.cx, 0, left_cal_data.fy, left_cal_data.cy, 0, 0, 1};
                left_cal_data.dist_coef = new double[]{ -0.0541917641, 0.3666700783, -0.0010133199, -0.0012571497, -0.50851111 };
                left_cal_data.rect_mat = new double[]{ 0.9900942219983122, 0.0008700163736823347, 0.1404018327411238, -0.0003018064579999549, 0.9999916790189494, -0.004068268148024957, -0.1404042039200354, 0.003985594607062984, 0.9900862460196128 };
                left_cal_data.proj_mat = new double[]{left_cal_data.proj_fx, 0, left_cal_data.proj_cx, left_cal_data.proj_tx, 0, left_cal_data.proj_fy, left_cal_data.proj_cy, 0, 0, 0, 1, 0};

                CalData right_cal_data;
                right_cal_data.fx = 878.4473843097;
                right_cal_data.fy = 878.6459087631;
                right_cal_data.cx = 306.9593300268;
                right_cal_data.cy = 263.9915546904;
                right_cal_data.proj_fx = 879.2624248102;
                right_cal_data.proj_fy = 879.2624248102;
                right_cal_data.proj_cx = 460.0473518372;
                right_cal_data.proj_cy = 264.7968616486;
                right_cal_data.proj_tx = -395.6679851775;
                right_cal_data.cam_mat = new double[]{right_cal_data.fx, 0, right_cal_data.cx, 0, right_cal_data.fy, right_cal_data.cy, 0, 0, 1};
                right_cal_data.dist_coef = new double[]{ -0.0360479725, 0.1531926905, -0.0003590501, 0.0004811706, 0.3374149346 };
                right_cal_data.rect_mat = new double[]{ 0.9882401488216741, 0.0001799830984224486, -0.1529096983941819, 0.0004391286583745972, 0.9999918430758864, 0.004015090000604598, 0.1529091737697147, -0.004035020170438205, 0.9882320087860377 };
                right_cal_data.proj_mat = new double[]{right_cal_data.proj_fx, 0, right_cal_data.proj_cx, right_cal_data.proj_tx, 0, right_cal_data.proj_fy, right_cal_data.proj_cy, 0, 0, 0, 1, 0};

                stereo_cal_data.left_cal_data = left_cal_data;
                stereo_cal_data.right_cal_data = right_cal_data;
                stereo_cal_data.hfov = 0.36864f;
                stereo_cal_data.focal_length = 0.012;
                stereo_cal_data.pixel_pitch = 0.00000345;
                stereo_cal_data.baseline = 0.4499998795f;
                stereo_cal_data.Q = new float[]{1, 0, 0, 0, 
                                                 0, 1, 0, 0,
                                                 0, 0, 1, 0,
                                                 0, 0, 0, 1};
                int cols = 4;
                stereo_cal_data.Q[(0 * cols + 3)] = -163.92555f;
                stereo_cal_data.Q[(1 * cols + 3)] = -264.79688f;
                stereo_cal_data.Q[(2 * cols + 2)] = 0.0f;
                stereo_cal_data.Q[(2 * cols + 3)] = 879.26245f;
                stereo_cal_data.Q[(3 * cols + 2)] = 2.2222228f;
                stereo_cal_data.Q[(3 * cols + 3)] = 658.04865f;
                return stereo_cal_data;
            }

            private static int get2DIndex(int row, int column, int columns){
                return getArrayIndex(row, column, 0, columns, 1);
            }

            private static int getArrayIndex(int row, int column, int layer, int columns, int layers){
                return (row * columns + column) * layers + layer;
            }

            private static int getImageArrayIndex(int row, int column, int channel, int width, int channels){
                return (row * width + column) * channels + channel;
            }

            public static void verify_stereo_cal(StereoCameraCalibration cal, StereoCalData st_cal_data){
                Assert.True(cal.isValid());

                CameraCalibration left_cal;
                cal.getLeftCalibration(out left_cal);
                CameraCalibration right_cal;
                cal.getRightCalibration(out right_cal);

                CalData lcal = st_cal_data.left_cal_data;
                CalData rcal = st_cal_data.right_cal_data;

                Assert.True(left_cal.getImageHeight() == st_cal_data.image_height);
                Assert.True(left_cal.getImageWidth() == st_cal_data.image_width);
                Assert.True(right_cal.getImageHeight() == st_cal_data.image_height);
                Assert.True(right_cal.getImageWidth() == st_cal_data.image_width);

                int precision = 2;

                Assert.Equal(left_cal.getCameraCX(), lcal.cx, precision);
                Assert.Equal(left_cal.getCameraCY(), lcal.cy, precision);
                Assert.Equal(left_cal.getCameraFX(), lcal.fx, precision);
                Assert.Equal(left_cal.getCameraFY(), lcal.fy, precision);
                Assert.Equal(left_cal.getProjectionCX(), lcal.proj_cx, precision);
                Assert.Equal(left_cal.getProjectionCY(), lcal.proj_cy, precision);
                Assert.Equal(left_cal.getProjectionFX(), lcal.proj_fx, precision);
                Assert.Equal(left_cal.getProjectionFY(), lcal.proj_fy, precision);
                Assert.Equal(left_cal.getProjectionTX(), lcal.proj_tx, precision);
                Assert.Equal(right_cal.getCameraCX(), rcal.cx, precision);
                Assert.Equal(right_cal.getCameraCY(), rcal.cy, precision);
                Assert.Equal(right_cal.getCameraFX(), rcal.fx, precision);
                Assert.Equal(right_cal.getCameraFY(), rcal.fy, precision);
                Assert.Equal(right_cal.getProjectionCX(), rcal.proj_cx, precision);
                Assert.Equal(right_cal.getProjectionCY(), rcal.proj_cy, precision);
                Assert.Equal(right_cal.getProjectionFX(), rcal.proj_fx, precision);
                Assert.Equal(right_cal.getProjectionFY(), rcal.proj_fy, precision);
                Assert.Equal(right_cal.getProjectionTX(), rcal.proj_tx, precision);

                for (int j = 0; j < 3; j++) {
                    for (int i = 0; i < 3; i++) {
                        Assert.Equal(left_cal.getCameraMatrix()[get2DIndex(j, i, 3)], lcal.cam_mat[get2DIndex(j, i, 3)], precision);
                    }
                }
                for (int j = 0; j < 3; j++) {
                    for (int i = 0; i < 3; i++) {
                        Assert.Equal(right_cal.getCameraMatrix()[get2DIndex(j, i, 3)], rcal.cam_mat[get2DIndex(j, i, 3)], precision);
                    }
                }
                for (int j = 0; j < 1; j++) {
                    for (int i = 0; i < 5; i++) {
                        Assert.Equal(left_cal.getDistortionCoefficients()[get2DIndex(j, i, 5)], lcal.dist_coef[get2DIndex(j, i, 5)], precision);
                    }
                }
                for (int j = 0; j < 1; j++) {
                    for (int i = 0; i < 5; i++) {
                        Assert.Equal(right_cal.getDistortionCoefficients()[get2DIndex(j, i, 5)], rcal.dist_coef[get2DIndex(j, i, 5)], precision);
                    }
                }
                for (int j = 0; j < 3; j++) {
                    for (int i = 0; i < 3; i++) {
                        Assert.Equal(left_cal.getRectificationMatrix()[get2DIndex(j, i, 3)], lcal.rect_mat[get2DIndex(j, i, 3)], precision);
                    }
                }
                for (int j = 0; j < 3; j++) {
                    for (int i = 0; i < 3; i++) {
                        Assert.Equal(right_cal.getRectificationMatrix()[get2DIndex(j, i, 3)], rcal.rect_mat[get2DIndex(j, i, 3)], precision);
                    }
                }
                for (int j = 0; j < 3; j++) {
                    for (int i = 0; i < 4; i++) {
                        Assert.Equal(left_cal.getProjectionMatrix()[get2DIndex(j, i, 4)], lcal.proj_mat[get2DIndex(j, i, 4)], precision);
                    }
                }
                for (int j = 0; j < 3; j++) {
                    for (int i = 0; i < 4; i++) {
                        Assert.Equal(right_cal.getProjectionMatrix()[get2DIndex(j, i, 4)], rcal.proj_mat[get2DIndex(j, i, 4)], precision);
                    }
                }

                Assert.Equal(cal.getHFOV(), st_cal_data.hfov, precision);
                Assert.Equal(cal.getBaseline(), st_cal_data.baseline, precision);
                for (int j = 0; j < 4; j++) {
                    for (int i = 0; i < 4; i++) {
                        Assert.Equal(cal.getQ()[get2DIndex(j, i, 4)], st_cal_data.Q[get2DIndex(j, i, 4)], precision);
                    }
                }
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
        public void test_ValidLoadFromImages()
        {
            // Test generation of calibration from series 13 images
            // of size 2448x2048 of a checkerboard and verify values
            // match expected in stereo calibration class
            string data_folder = "data";
            string left_cal_folder = data_folder + "/checker_sample";
            string right_cal_folder = data_folder + "/checker_sample";
            string left_img_wildcard = "*_l.png";
            string right_img_wildcard = "*_r.png";
            CalibrationBoardType board_type = CalibrationBoardType.CHECKERBOARD;
            
            StereoCameraCalibrationTestUtils.StereoCalData st_cal_data = StereoCameraCalibrationTestUtils.gen_checker_sample_data();

            // Load calibration from series of checkerboard images
            StereoCameraCalibration cal = StereoCameraCalibration.calibrationFromImages(
                left_cal_folder, right_cal_folder,
                left_img_wildcard, right_img_wildcard,
                board_type, 10, 6, 0.039
            );
            
            StereoCameraCalibrationTestUtils.verify_stereo_cal(cal, st_cal_data);
        }

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
