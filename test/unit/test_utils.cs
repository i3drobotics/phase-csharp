/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file test_utils.cs
 * @brief Unit tests for Stereo Support class
 * @details Unit tests generated using MSTest
 */

using Xunit;
using System;
using System.IO;
using I3DR.Phase;
using I3DR.Phase.Types;
using I3DR.Phase.StereoMatcher;
using I3DR.Phase.Calib;

namespace I3DR.PhaseTest
{
    // Tests for Utils
    [Collection("PhaseSequentialTests")]
    public class UtilsTests
    {   
        [Fact]
        public void test_ScaledImageSize()
        {
            // Test image with size 2448x2048 scaled by ‘scaleImage’ function
            // with a scaling factor of 2 has an output image size of 4896x4096
            // TOTEST
        }

        [Fact]
        public void test_ConvertMonoToMono()
        {
            // Test image of type CV_8UC1 converted to mono by ‘toMono’ function
            // has output image type of CV_8UC1
            // TOTEST
        }

        [Fact]
        public void test_ConvertBGRAToMono()
        {
            // Test image of type CV_8UC4 converted to mono by ‘toMono’ function
            // has output image type of CV_8UC1
            // TOTEST
        }

        [Fact]
        public void test_ConvertBGRToMono()
        {
            // Test image of type CV_8UC3 converted to mono by ‘toMono’ function
            // has output image type of CV_8UC1
            // TOTEST
        }

        [Fact]
        public void test_NormDisparityOutputType()
        {
            // Test disparity image normalised by ‘normaliseDisparity’ function
            // has output image type of CV_8UC3
            // TOTEST
        }

        [Fact]
        public void test_ValidBGRA2RGBA()
        {
            // Test BGRA image converted to RGBA using ‘bgra2rgba’ function
            // has output RGBA image where channel contents match the input BGRA image but is in RGBA order
            // TOTEST
        }

        [Fact]
        public void test_ValidBGR2RGBA()
        {
            // Test BGR image converted to RGBA using ‘bgr2rgba’ function
            // has output RGBA image where channel contents match the input BGR image
            // but is in RGB order and has additional alpha channel.
            // TOTEST
        }

        [Fact]
        public void test_ValidBGR2BGRA()
        {
            // Test BGR image converted to BGRA using ‘bgr2bgra’ function
            // has output BGRA image where channel contents match the input BGR image
            // but with additional alpha channel
            // TOTEST
        }

        [Fact]
        public void test_ValidDisparity2Depth()
        {
            // Test disparity image converted to depth by ‘disparity2Depth’ function
            // has output depth values that match expected values
            // TOTEST
        }

        [Fact]
        public void test_EmptyDisparity2Depth()
        {
            // Test providing empty disparity or q matrix to ‘disparity2Depth’ function
            // will return an empty depth image
            // TOTEST
        }

        [Fact]
        public void test_ValidDisparity2Xyz()
        {
            // Test disparity image converted to depth by ‘disparity2Xyz’ function
            // has output xyz values that match expected values
            // TOTEST
        }

        [Fact]
        public void test_EmptyDisparity2Xyz()
        {
            // Test providing empty disparity or q matrix to ‘disparity2xyz’ function
            // will return an empty xyz image
            // TOTEST
        }

        [Fact]
        public void test_ValidDepth2Xyz()
        {
            // Test depth image converted to depth by ‘depth2Xyz’ function
            // has output xyz values that match expected values
            // TOTEST
        }

        [Fact]
        public void test_EmptyDepth2Xyz()
        {
            // Test providing empty depth or q matrix to ‘depth2Xyz’ function
            // will return an empty xyz image
            // TOTEST
        }

        [Fact]
        public void test_ValidXyz2Depth()
        {
            // Test xyz image converted to depth by ‘xyz2Depth’ function
            // has output depth values that match expected values
            // TOTEST
        }

        [Fact]
        public void test_EmptyXyz2Depth()
        {
            // Test providing empty xyz to ‘xyz2Depth’ function
            // will return an empty depth image
            // TOTEST
        }

        [Fact]
        public void test_ReadImageSize()
        {
            // Test image read from file using ‘readImage’ function has expected image size
            // TOTEST
        }

        [Fact]
        public void test_InvalidReadImageIsEmpty()
        {
            // Test trying to read image that does not exist
            // using ‘readImage’ function results in empty image
            // TOTEST
        }

        [Fact]
        public void test_ValidHorizontalFlip()
        {
            // Test image flipped horizontally using ‘flip’ function has pixel values
            // that matching input in opposite side on the image.
            // E.g. pixel from top left corner in input matches pixel from top right corner in output image
            // TOTEST
        }

        [Fact]
        public void test_ValidVerticalFlip()
        {
            // Test image flipped vertically using ‘flip’ function has pixel values
            // that matching input in opposite side on the image.
            // E.g. pixel from top left corner in input matches pixel from bottom left corner in output image
            // TOTEST
        }

        [Fact]
        public void test_savePLYHasOutput()
        {
            // Test point cloud data represented as RGB color and XYZ images that are saved
            // to PLY using ‘savePLY’ function result in PLY file in expected output location
            // TOTEST
        }

        [Fact]
        public void test_EqualMatIsReportedEqual()
        {
            // Test two cv::Mat’s that are equal are reported as equal by ‘cvMatIsEqual’ function 
            // Create equal mat's
            int width = 3;
            int height = 3;
            int channels = 1;
            float[] mat_a = new float[width*height*channels];
            float[] mat_b = new float[width*height*channels];
            for (int i = 0; i < width*height*channels; i++){
                mat_a[i] = 1.0f;
                mat_b[i] = 1.0f;
            }

            // Check equal is equal check is correct
            Assert.True(Utils.cvMatIsEqual(mat_a, mat_b, width, height, channels));
        }

        [Fact]
        public void test_NotEqualMatIsReportedNotEqual()
        {
            // Test two cv::Mat’s that are not equal are reported as no equal by ‘cvMatIsEqual’ function 
            // Create equal mat's
            int width = 3;
            int height = 3;
            int channels = 1;
            float[] mat_a = new float[width*height*channels];
            float[] mat_b = new float[width*height*channels];
            for (int i = 0; i < width*height*channels; i++){
                mat_a[i] = 1.0f;
                mat_b[i] = 1.0f;
            }

            // Change one element to make it not equal
            mat_a[0] = 0.0f;

            // Check equal is equal check is correct
            Assert.False(Utils.cvMatIsEqual(mat_a, mat_b, width, height, channels));
        }

        // Test saving 3D data to ply file
        [Fact]
        public void test_Utils_savePLY()
        {
            // TOTEST Remove this test
            string test_folder = ".phase_test";
            string data_folder = "../../../../data";
            string left_image_file = data_folder + "/left.png";
            string right_image_file = data_folder + "/right.png";
            string left_yaml = test_folder + "/left.yaml";
            string right_yaml = test_folder + "/right.yaml";
            string out_ply = test_folder + "/out.ply";

            Directory.CreateDirectory(test_folder);

            Console.WriteLine("Generating test data...");

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
            
            //TODO get image size from file
            int image_width = 2448;
            int image_height = 2048;
            byte[] left_image_cv = Utils.readImage(left_image_file, image_width, image_height);
            byte[] right_image_cv = Utils.readImage(right_image_file, image_width, image_height);

            Assert.True(left_image_cv.Length != 0);
            Assert.True(right_image_cv.Length != 0);

            StereoCameraCalibration calibration = StereoCameraCalibration.calibrationFromYAML(left_yaml, right_yaml);

            Assert.True(calibration.isValid());

            StereoImagePair rect_image_pair = calibration.rectify(left_image_cv, right_image_cv, image_width, image_height);

            Console.WriteLine("Processing stereo...");
            StereoMatcherType matcher_type = StereoMatcherType.STEREO_MATCHER_BM;
            StereoParams stereo_params = new StereoParams(
                matcher_type,
                11, 0, 25, false
            );
            
            AbstractStereoMatcher matcher = StereoMatcher.createStereoMatcher(matcher_type);
            StereoMatcherComputeResult result = matcher.compute(rect_image_pair.left, rect_image_pair.right, image_width, image_height);

            Assert.True(result.valid);

            float[] depth = Utils.disparity2Depth(result.disparity, image_width, image_height, calibration.getQ());

            Assert.True(depth.Length != 0);

            float[] xyz = Utils.depth2xyz(depth, image_width, image_height, calibration.getHFOV());

            Utils.savePLY(out_ply, xyz, rect_image_pair.left, image_width, image_height);
        }
    }
}
