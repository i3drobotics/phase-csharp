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
using System;
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

            private static int get2DIndex(int row, int column, int columns){
                return getArrayIndex(row, column, 0, columns, 1);
            }

            private static int getArrayIndex(int row, int column, int layer, int columns, int layers){
                return (row * columns + column) * layers + layer;
            }

            private static int getImageArrayIndex(int row, int column, int channel, int width, int channels){
                return (row * width + column) * channels + channel;
            }

            public static void verify_cal(CameraCalibration cal, CalData cal_data){
                Assert.True(cal.isValid());

                Assert.True(cal.getImageHeight() == cal_data.image_height);
                Assert.True(cal.getImageWidth() == cal_data.image_width);
                
                int precision = 2;

                Assert.Equal(cal.getCameraCX(), cal_data.cx, precision);
                Assert.Equal(cal.getCameraCY(), cal_data.cy, precision);
                Assert.Equal(cal.getCameraFX(), cal_data.fx, precision);
                Assert.Equal(cal.getCameraFY(), cal_data.fy, precision);
                Assert.Equal(cal.getProjectionCX(), cal_data.proj_cx, precision);
                Assert.Equal(cal.getProjectionCY(), cal_data.proj_cy, precision);
                Assert.Equal(cal.getProjectionFX(), cal_data.proj_fx, precision);
                Assert.Equal(cal.getProjectionFY(), cal_data.proj_fy, precision);
                Assert.Equal(cal.getProjectionTX(), cal_data.proj_tx, precision);

                for (int j = 0; j < 3; j++) {
                    for (int i = 0; i < 3; i++) {
                        Assert.Equal(cal.getCameraMatrix()[get2DIndex(j, i, 3)], cal_data.cam_mat[get2DIndex(j, i, 3)], precision);
                    }
                }
                for (int j = 0; j < 1; j++) {
                    for (int i = 0; i < 5; i++) {
                        Assert.Equal(cal.getDistortionCoefficients()[get2DIndex(j, i, 5)], cal_data.dist_coef[get2DIndex(j, i, 5)], precision);
                    }
                }
                for (int j = 0; j < 3; j++) {
                    for (int i = 0; i < 3; i++) {
                        Assert.Equal(cal.getRectificationMatrix()[get2DIndex(j, i, 3)], cal_data.rect_mat[get2DIndex(j, i, 3)], precision);
                    }
                }
                for (int j = 0; j < 3; j++) {
                    for (int i = 0; i < 4; i++) {
                        Assert.Equal(cal.getProjectionMatrix()[get2DIndex(j, i, 4)], cal_data.proj_mat[get2DIndex(j, i, 4)], precision);
                    }
                }
            }

            public static void save_yaml_data(CalData cal_data, CalibrationFileType cal_type, string yaml_file){ 
                Assert.True((cal_type == CalibrationFileType.OPENCV_YAML || cal_type == CalibrationFileType.ROS_YAML));
                string yaml_data = "";
                // TODO fill yaml data strings from StereoCalData
                if (cal_type ==CalibrationFileType.OPENCV_YAML){
                    yaml_data = @"
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
                    yaml_data = @"
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
                File.WriteAllText(yaml_file, yaml_data);
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
            string test_folder = ".phase_test";
            string yaml_file = test_folder + "/left.yaml";

            // Create output folder
            System.IO.Directory.CreateDirectory(test_folder);
            
            CameraCalibrationTestUtils.CalData cal_data = CameraCalibrationTestUtils.gen_cal_data();
            CameraCalibrationTestUtils.save_yaml_data(cal_data, CalibrationFileType.ROS_YAML, yaml_file);

            // Load calibration files
            CameraCalibration cal = new CameraCalibration(yaml_file);
            
            CameraCalibrationTestUtils.verify_cal(cal, cal_data);
            cal.dispose();
        }

        [Fact]
        public void test_ValidLoadOpenCVYAML()
        {
            // Test calibration data is loaded from OpenCV YAML file
            // and values from file match parameters in calibration class 
            string test_folder = ".phase_test";
            string yaml_file = test_folder + "/left.yaml";

            // Create output folder
            System.IO.Directory.CreateDirectory(test_folder);
            
            CameraCalibrationTestUtils.CalData cal_data = CameraCalibrationTestUtils.gen_cal_data();
            CameraCalibrationTestUtils.save_yaml_data(cal_data, CalibrationFileType.OPENCV_YAML, yaml_file);

            // Load calibration files
            CameraCalibration cal = new CameraCalibration(yaml_file);
            
            CameraCalibrationTestUtils.verify_cal(cal, cal_data);
            cal.dispose();
        }

        [Fact]
        public void test_ValidCalibrationFromIdeal()
        {
            // Test Calibration data is loaded from ideal camera parameters
            // using ‘calibrationFromIdeal’ function and loaded parameters match expected values 
            CameraCalibrationTestUtils.CalData cal_data = CameraCalibrationTestUtils.gen_cal_data();
            CameraCalibration cal = CameraCalibration.calibrationFromIdeal(
                cal_data.image_width, cal_data.image_height,
                cal_data.pixel_pitch, cal_data.focal_length,
                cal_data.translation_x, cal_data.translation_y);
            Assert.True(cal.isValid());
            CameraCalibrationTestUtils.verify_cal(cal, cal_data);
            cal.dispose();
        }

        [Fact]
        public void test_SuccessfulRectify()
        {
            // Test image is successfully rectified using ‘rectify’ function 
            int width = 2448;
            int height = 2048;
            byte[] img = new byte[height*width*3];
            for (int i = 0; i < img.Length; i++){img[i] = 1;}
            CameraCalibrationTestUtils.CalData cal_data = CameraCalibrationTestUtils.gen_cal_data();
            CameraCalibration cal = CameraCalibration.calibrationFromIdeal(
                cal_data.image_width, cal_data.image_height,
                cal_data.pixel_pitch, cal_data.focal_length,
                cal_data.translation_x, cal_data.translation_y);
            Assert.True(cal.isValid());
            byte[] rect = cal.rectify(img, width, height);
            Assert.True(rect.Length > 0);
            cal.dispose();
        }
    }
}
