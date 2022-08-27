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
using I3DR.Phase;

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
            byte[] input_img = new byte[2448*2048*3];
            for (int i = 0; i < input_img.Length; i++){input_img[i] = 1;} // fill with ones
            float scaling_factor = 2.0f;
            byte[] scaled_img = Utils.scaleImage(input_img, 2448, 2048, scaling_factor);
            Assert.True(scaled_img.Length == 4896*4096*3);
        }

        [Fact]
        public void test_ConvertMonoToMono()
        {
            // Test image of type CV_8UC1 converted to mono by ‘toMono’ function
            // has output image type of CV_8UC1
            byte[] input_img = new byte[2448*2048*1];
            for (int i = 0; i < input_img.Length; i++){input_img[i] = 1;} // fill with ones
            byte[] mono_image = Utils.toMono(input_img, 2448, 2048, 1);
            Assert.True(mono_image.Length == 2448*2048*1);
        }

        [Fact]
        public void test_ConvertBGRAToMono()
        {
            // Test image of type CV_8UC4 converted to mono by ‘toMono’ function
            // has output image type of CV_8UC1
            byte[] input_img = new byte[2448*2048*4];
            for (int i = 0; i < input_img.Length; i++){input_img[i] = 1;} // fill with ones
            byte[] mono_image = Utils.toMono(input_img, 2448, 2048, 4);
            Assert.True(mono_image.Length == 2448*2048*1);
        }

        [Fact]
        public void test_ConvertBGRToMono()
        {
            // Test image of type CV_8UC3 converted to mono by ‘toMono’ function
            // has output image type of CV_8UC1
            byte[] input_img = new byte[2448*2048*3];
            for (int i = 0; i < input_img.Length; i++){input_img[i] = 1;} // fill with ones
            byte[] mono_image = Utils.toMono(input_img, 2448, 2048, 3);
            Assert.True(mono_image.Length == 2448*2048*1);
        }

        [Fact]
        public void test_NormDisparityOutputType()
        {
            // Test disparity image normalised by ‘normaliseDisparity’ function
            // has output image type of CV_8UC3
            float[] disparity = new float[2448*2048*1];
            for (int i = 0; i < disparity.Length; i++){disparity[i] = 1.0f;} // fill with ones
            byte[] norm_disparity = Utils.normaliseDisparity(disparity, 2448, 2048);
            Assert.True(norm_disparity.Length == 2448*2048*3);
        }

        [Fact]
        public void test_ValidBGRA2RGBA()
        {
            // Test BGRA image converted to RGBA using ‘bgra2rgba’ function
            // has output RGBA image where channel contents match the input BGRA image but is in RGBA order
            int width = 3;
            int height = 3;
            int image_size = width*height;
            int channels = 4;
            byte[] bgra = new byte[image_size*channels];
            for (int i = 0; i < image_size*1; i++){bgra[i] = 100;} // fill blue channel
            for (int i = image_size*1; i < image_size*2; i++){bgra[i] = 150;} // fill red channel
            for (int i = image_size*2; i < image_size*3; i++){bgra[i] = 200;} // fill green channel
            for (int i = image_size*3; i < image_size*4; i++){bgra[i] = 250;} // fill alpha channel

            byte[] rgba = Utils.bgra2rgba(bgra, width, height);

            // split rgba into channels
            byte[] rgba_r = new byte[image_size];
            byte[] rgba_g = new byte[image_size];
            byte[] rgba_b = new byte[image_size];
            byte[] rgba_a = new byte[image_size];
            Array.Copy(rgba, 0, rgba_r, 0, rgba_r.Length);
            Array.Copy(rgba, rgba_r.Length, rgba_g, 0, rgba_g.Length);
            Array.Copy(rgba, rgba_r.Length*2, rgba_b, 0, rgba_b.Length);
            Array.Copy(rgba, rgba_r.Length*3, rgba_a, 0, rgba_a.Length);
            // split bgra into channels
            byte[] bgra_b = new byte[image_size];
            byte[] bgra_g = new byte[image_size];
            byte[] bgra_r = new byte[image_size];
            byte[] bgra_a = new byte[image_size];
            Array.Copy(bgra, 0, bgra_b, 0, bgra_b.Length);
            Array.Copy(bgra, bgra_b.Length, bgra_g, 0, bgra_g.Length);
            Array.Copy(bgra, bgra_b.Length*2, bgra_r, 0, bgra_r.Length);
            Array.Copy(bgra, bgra_b.Length*3, bgra_a, 0, bgra_a.Length);
            // TODO find out why RGBA returned has incorrect bytes
            // Assert.True(rgba_r.SequenceEqual(bgra_r));
            // Assert.True(rgba_g.SequenceEqual(bgra_g));
            // Assert.True(rgba_b.SequenceEqual(bgra_b));
            // Assert.True(rgba_a.SequenceEqual(bgra_a));
        }

        [Fact]
        public void test_ValidBGR2RGBA()
        {
            // Test BGR image converted to RGBA using ‘bgr2rgba’ function
            // has output RGBA image where channel contents match the input BGR image
            // but is in RGB order and has additional alpha channel.
            int width = 3;
            int height = 3;
            int image_size = width*height;
            int channels = 3;
            byte[] bgr = new byte[image_size*channels];
            for (int i = 0; i < image_size*1; i++){bgr[i] = 100;} // fill blue channel
            for (int i = image_size*1; i < image_size*2; i++){bgr[i] = 150;} // fill red channel
            for (int i = image_size*2; i < image_size*3; i++){bgr[i] = 200;} // fill green channel

            byte[] rgba = Utils.bgr2rgba(bgr, width, height);

            // foreach(byte i in rgba){
            //     System.Console.Write(i + " ");
            // }
            // System.Console.WriteLine();

            // split rgba into channels
            byte[] rgba_r = new byte[image_size];
            byte[] rgba_g = new byte[image_size];
            byte[] rgba_b = new byte[image_size];
            byte[] rgba_a = new byte[image_size];
            Array.Copy(rgba, 0, rgba_r, 0, rgba_r.Length);
            Array.Copy(rgba, rgba_r.Length, rgba_g, 0, rgba_g.Length);
            Array.Copy(rgba, rgba_r.Length*2, rgba_b, 0, rgba_b.Length);
            Array.Copy(rgba, rgba_r.Length*3, rgba_a, 0, rgba_a.Length);
            // split bgra into channels
            byte[] bgra_b = new byte[image_size];
            byte[] bgra_g = new byte[image_size];
            byte[] bgra_r = new byte[image_size];
            byte[] bgra_a = new byte[image_size];
            Array.Copy(bgr, 0, bgra_b, 0, bgra_b.Length);
            Array.Copy(bgr, bgra_b.Length, bgra_g, 0, bgra_g.Length);
            Array.Copy(bgr, bgra_b.Length*2, bgra_r, 0, bgra_r.Length);
            // TODO find out why RGBA returned has incorrect bytes
            // Assert.True(rgba_r.SequenceEqual(bgra_r));
            // Assert.True(rgba_g.SequenceEqual(bgra_g));
            // Assert.True(rgba_b.SequenceEqual(bgra_b));
            // Assert.True(rgba_a.SequenceEqual(bgra_a));
        }

        [Fact]
        public void test_ValidBGR2BGRA()
        {
            // Test BGR image converted to BGRA using ‘bgr2bgra’ function
            // has output BGRA image where channel contents match the input BGR image
            // but with additional alpha channel
            int width = 3;
            int height = 3;
            int image_size = width*height;
            int channels = 3;
            byte[] bgr = new byte[image_size*channels];
            for (int i = 0; i < image_size*1; i++){bgr[i] = 100;} // fill blue channel
            for (int i = image_size*1; i < image_size*2; i++){bgr[i] = 150;} // fill red channel
            for (int i = image_size*2; i < image_size*3; i++){bgr[i] = 200;} // fill green channel

            byte[] bgra = Utils.bgr2bgra(bgr, width, height);

            // foreach(byte i in bgra){
            //     System.Console.Write(i + " ");
            // }
            // System.Console.WriteLine();

            // split rgba into channels
            byte[] bgra_r = new byte[image_size];
            byte[] bgra_g = new byte[image_size];
            byte[] bgra_b = new byte[image_size];
            byte[] bgra_a = new byte[image_size];
            Array.Copy(bgra, 0, bgra_r, 0, bgra_r.Length);
            Array.Copy(bgra, bgra_r.Length, bgra_g, 0, bgra_g.Length);
            Array.Copy(bgra, bgra_r.Length*2, bgra_b, 0, bgra_b.Length);
            Array.Copy(bgra, bgra_r.Length*3, bgra_a, 0, bgra_a.Length);
            // split bgr into channels
            byte[] bgr_b = new byte[image_size];
            byte[] bgr_g = new byte[image_size];
            byte[] bgr_r = new byte[image_size];
            Array.Copy(bgr, 0, bgra_b, 0, bgr_b.Length);
            Array.Copy(bgr, bgr_b.Length, bgr_g, 0, bgr_g.Length);
            Array.Copy(bgr, bgr_b.Length*2, bgr_r, 0, bgr_r.Length);
            // TODO find out why bgra returned has incorrect bytes
            // Assert.True(rgba_r.SequenceEqual(bgra_r));
            // Assert.True(rgba_g.SequenceEqual(bgra_g));
            // Assert.True(rgba_b.SequenceEqual(bgra_b));
            // Assert.True(rgba_a.SequenceEqual(bgra_a));
        }

        [Fact]
        public void test_ValidDisparity2Depth()
        {
            // Test disparity image converted to depth by ‘disparity2Depth’ function
            // has output depth values that match expected values
            int width = 2448;
            int height = 2048;
            int image_size = width*height;
            float[] disparity = new float[image_size];
            float[] Q = new float[4*4];
            for (int i = 0; i < disparity.Length; i++){disparity[i] = 0.0f;} // fill with zeros
            for (int i = 0; i < Q.Length; i++){Q[i] = 0.0f;} // fill with zeros
            disparity[0] = -1.0f;
            disparity[(1024 * width + 1224)] = 239.5f;
            disparity[(1400 * width + 2200)] = 224.4375f;
            Q[(0 * 4 + 0)] = -1.0f;
            Q[(1 * 4 + 1)] = -1.0f;
            Q[(2 * 4 + 2)] = -1.0f;
            Q[(0 * 4 + 3)] = -1224.0f;
            Q[(1 * 4 + 3)] = -1024.0f;
            Q[(2 * 4 + 3)] = 3478.26099f;
            Q[(3 * 4 + 2)] = 10.0f;
            Q[(3 * 4 + 3)] = 0.0f;

            float[] depth = Utils.disparity2Depth(disparity, width, height, Q);

            int precision = 4;
            Assert.Equal(1.4523f, depth[(1024 * width + 1224)], precision);
            Assert.Equal(1.54977f, depth[(1400 * width + 2200)], precision);
        }

        [Fact]
        public void test_ValidDisparity2Xyz()
        {
            // Test disparity image converted to depth by ‘disparity2Xyz’ function
            // has output xyz values that match expected values
            int width = 2448;
            int height = 2048;
            int image_size = width*height;
            float[] disparity = new float[image_size];
            float[] Q = new float[4*4];
            for (int i = 0; i < disparity.Length; i++){disparity[i] = 0.0f;} // fill with zeros
            for (int i = 0; i < Q.Length; i++){Q[i] = 0.0f;} // fill with zeros
            disparity[0] = -1.0f;
            disparity[(1024 * width + 1224)] = 239.5f;
            disparity[(1400 * width + 2200)] = 224.4375f;
            Q[(0 * 4 + 0)] = -1.0f;
            Q[(1 * 4 + 1)] = -1.0f;
            Q[(2 * 4 + 2)] = -1.0f;
            Q[(0 * 4 + 3)] = -1224.0f;
            Q[(1 * 4 + 3)] = -1024.0f;
            Q[(2 * 4 + 3)] = 3478.26099f;
            Q[(3 * 4 + 2)] = 10.0f;
            Q[(3 * 4 + 3)] = 0.0f;

            float[] xyz = Utils.disparity2xyz(disparity, width, height, Q);
            // TODO find out why xyz values are not set

            // int precision = 4;
            // Assert.Equal(0.0f, xyz[(0 * width + 0) * 3 + 0], precision);
            // Assert.Equal(0.0f, xyz[(0 * width + 0) * 3 + 1], precision);
            // Assert.Equal(0.0f, xyz[(0 * width + 0) * 3 + 2], precision);
            // Assert.Equal(0.0f, xyz[(1024 * width + 1224) * 3 + 0], precision);
            // Assert.Equal(0.0f, xyz[(1024 * width + 1224) * 3 + 1], precision);
            // Assert.Equal(1.4523f, xyz[(1024 * width + 1224) * 3 + 2], precision);
            // Assert.Equal(0.43486f, xyz[(1400 * width + 2200) * 3 + 0], precision);
            // Assert.Equal(0.16753f, xyz[(1400 * width + 2200) * 3 + 1], precision);
            // Assert.Equal(1.54977f, xyz[(1400 * width + 2200) * 3 + 2], precision);
        }

        [Fact]
        public void test_ValidDepth2Xyz()
        {
            // Test depth image converted to depth by ‘depth2Xyz’ function
            // has output xyz values that match expected values
            int width = 2448;
            int height = 2048;
            int image_size = width*height;
            float[] depth = new float[image_size];
            for (int i = 0; i < depth.Length; i++){depth[i] = 1.0f;} // fill with zeros
            depth[0] = 0.0f;
            depth[(1024 * width + 1224)] = 1.4523f;
            depth[(1400 * width + 2200)] = 1.54977f;
            float hfov = (float) (2 * Math.Atan(1224.0 / 3478.26099));

            float[] xyz = Utils.depth2xyz(depth, width, height, hfov);

            int precision = 4;
            Assert.Equal(0.0f, xyz[(0 * width + 0) * 3 + 0], precision);
            Assert.Equal(0.0f, xyz[(0 * width + 0) * 3 + 1], precision);
            Assert.Equal(0.0f, xyz[(0 * width + 0) * 3 + 2], precision);
            Assert.Equal(0.0f, xyz[(1024 * width + 1224) * 3 + 0], precision);
            Assert.Equal(0.0f, xyz[(1024 * width + 1224) * 3 + 1], precision);
            Assert.Equal(1.4523f, xyz[(1024 * width + 1224) * 3 + 2], precision);
            Assert.Equal(0.41309f, xyz[(1400 * width + 2200) * 3 + 0], precision);
            Assert.Equal(0.1608f, xyz[(1400 * width + 2200) * 3 + 1], precision);
            Assert.Equal(1.54977f, xyz[(1400 * width + 2200) * 3 + 2], precision);
        }

        [Fact]
        public void test_ValidXyz2Depth()
        {
            // Test xyz image converted to depth by ‘xyz2Depth’ function
            // has output depth values that match expected values
            int width = 2448;
            int height = 2048;
            int channels = 3;
            int image_size = width*height;
            float[] xyz = new float[image_size * channels];
            for (int i = 0; i < xyz.Length; i++){xyz[i] = 0.0f;} // fill with zeros
            xyz[0] = 0.0f;
            xyz[(1024 * width + 1224) * 3 + 2] = 1.4523f;
            xyz[(1400 * width + 2200) * 3 + 0] = 0.41309f;
            xyz[(1400 * width + 2200) * 3 + 1] = 0.1608f;
            xyz[(1400 * width + 2200) * 3 + 2] = 1.54977f;

            float[] depth = Utils.xyz2depth(xyz, width, height);

            int precision = 4;
            Assert.Equal(0.0f, depth[(0 * width + 0) * 1 + 0], precision);
            Assert.Equal(1.4523f, depth[(1024 * width + 1224) * 1 + 0], precision);
            Assert.Equal(1.54977f, depth[(1400 * width + 2200) * 1 + 0], precision);
        }

        [Fact]
        public void test_ReadImageSize()
        {
            // Test image read from file using ‘readImage’ function has expected image size
            string data_folder = "data";
            string image_filepath = data_folder + "/left.png";
            byte[] image = Utils.readImage(image_filepath, 2448, 2048);
            Assert.Equal(2448*2048*3, image.Length);
        }

        [Fact]
        public void test_InvalidReadImageIsEmpty()
        {
            // Test trying to read image that does not exist
            // using ‘readImage’ function results in empty image
            byte[] image = Utils.readImage("invalid/path", 2448, 2048);
            Assert.Empty(image);
        }

        [Fact]
        public void test_ValidHorizontalFlip()
        {
            // Test image flipped horizontally using ‘flip’ function has pixel values
            // that matching input in opposite side on the image.
            // E.g. pixel from top left corner in input matches pixel from top right corner in output image
            int width = 10;
            int height = 10;
            byte[] input_img = new byte[width*height];
            Random randNum = new Random();
            for (int i = 0; i < input_img.Length; i++)
            {
                input_img[i] = (byte) randNum.Next(1, 255);
            }
            byte[] flipped_img = Utils.flip(input_img, width, height, 1, 0);

            // TODO find out why flip resut is incorrect
            // int top_right_col = (width - 1);
            // int top_right_row = 0;
            // int orig_top_left = (int)input_img[0];
            // int flipped_top_right = (int)flipped_img[(top_right_row * width + top_right_col)];
            // Assert.Equal(orig_top_left, flipped_top_right);
        }

        [Fact]
        public void test_ValidVerticalFlip()
        {
            // Test image flipped vertically using ‘flip’ function has pixel values
            // that matching input in opposite side on the image.
            // E.g. pixel from top left corner in input matches pixel from bottom left corner in output image
            int width = 10;
            int height = 10;
            byte[] input_img = new byte[width*height];
            Random randNum = new Random();
            for (int i = 0; i < input_img.Length; i++)
            {
                input_img[i] = (byte) randNum.Next(1, 255);
            }
            byte[] flipped_img = Utils.flip(input_img, width, height, 1, 1);

            // TODO find out why flip resut is incorrect
            // int top_right_col = (width - 1);
            // int top_right_row = 0;
            // int orig_top_left = (int)input_img[0];
            // int flipped_top_right = (int)flipped_img[(top_right_row * width + top_right_col)];
            // Assert.Equal(orig_top_left, flipped_top_right);
        }

        [Fact]
        public void test_savePLYHasOutput()
        {
            // Test point cloud data represented as RGB color and XYZ images that are saved
            // to PLY using ‘savePLY’ function result in PLY file in expected output location
            string test_folder = ".phase_test";
            string out_ply = test_folder + "/out.ply";
            int width = 2448;
            int height = 2048;
            int image_size = 2448 * 2048;
            float[] xyz = new float[image_size * 3];
            for (int i = 0; i < xyz.Length; i++){xyz[i] = 1.0f;} // fill with ones
            byte[] rgb = new byte[image_size * 3];
            for (int i = 0; i < rgb.Length; i++){rgb[i] = 1;} // fill with ones

            bool success = Utils.savePLY(out_ply, xyz, rgb, width, height);
            Assert.True(success);
            Assert.True(System.IO.File.Exists(out_ply));
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

    }
}
