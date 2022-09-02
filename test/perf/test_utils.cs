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
        public void test_PerfSmallImageScaling()
        {
            // Test image with size 640x480 scaled by ‘scaleImage’ function
            // with a scaling factor of 2 in less than 0.1s
            int timeout = 100; // ms
            int width = 640;
            int height = 480;
            byte[] input_img = new byte[width*height*3];
            for (int i = 0; i < input_img.Length; i++){input_img[i] = 1;} // fill with ones
            float scaling_factor = 2.0f;

            long start = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
            byte[] scaled_img = Utils.scaleImage(input_img, width, height, scaling_factor);
            long end = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;

            long duration = end - start;
            Assert.True(duration < timeout, "Expected: " + timeout + " Actual: " + duration);
        }

        [Fact]
        public void test_PerfLargeImageScaling()
        {
            // Test image with size 2448x2048 scaled by ‘scaleImage’ function
            // with a scaling factor of 2 in less than 0.2s
            int timeout = 200; // ms
            int width = 2448;
            int height = 2048;
            byte[] input_img = new byte[width*height*3];
            for (int i = 0; i < input_img.Length; i++){input_img[i] = 1;} // fill with ones
            float scaling_factor = 2.0f;

            long start = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
            byte[] scaled_img = Utils.scaleImage(input_img, width, height, scaling_factor);
            long end = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;

            long duration = end - start;
            Assert.True(duration < timeout, "Expected: " + timeout + " Actual: " + duration);
        }

        [Fact]
        public void test_PerfConvertBGR2Mono()
        {
            // Test image of type CV_8UC3 converted to mono
            // by ‘toMono’ function in less than 0.1s
            int timeout = 100; // ms
            int width = 2448;
            int height = 2048;
            byte[] input_img = new byte[width*height*3];
            for (int i = 0; i < input_img.Length; i++){input_img[i] = 1;} // fill with ones
            

            long start = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
            byte[] mono_image = Utils.toMono(input_img, width, height, 3);
            long end = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;

            long duration = end - start;
            Assert.True(duration < timeout, "Expected: " + timeout + " Actual: " + duration);
        }

        [Fact]
        public void test_PerfConvertBGRA2RGBA()
        {
            // Test BGRA image converted to RGBA using ‘bgra2rgba’ function in less than 1.0s
            int timeout = 1000; // ms
            int width = 3;
            int height = 3;
            int image_size = width*height;
            int channels = 4;
            byte[] bgra = new byte[image_size*channels];
            for (int i = 0; i < image_size*1; i++){bgra[i] = 100;} // fill blue channel
            for (int i = image_size*1; i < image_size*2; i++){bgra[i] = 150;} // fill red channel
            for (int i = image_size*2; i < image_size*3; i++){bgra[i] = 200;} // fill green channel
            for (int i = image_size*3; i < image_size*4; i++){bgra[i] = 250;} // fill alpha channel

            long start = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
            byte[] rgba = Utils.bgra2rgba(bgra, width, height);
            long end = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;

            long duration = end - start;
            Assert.True(duration < timeout, "Expected: " + timeout + " Actual: " + duration);
        }

        [Fact]
        public void test_PerfConvertBGR2RGBA()
        {
            // Test BGR image converted to RGBA using ‘bgr2rgba’ function in less than 1.0s
            int timeout = 1000;
            int width = 3;
            int height = 3;
            int image_size = width*height;
            int channels = 3;
            byte[] bgr = new byte[image_size*channels];
            for (int i = 0; i < image_size*1; i++){bgr[i] = 100;} // fill blue channel
            for (int i = image_size*1; i < image_size*2; i++){bgr[i] = 150;} // fill red channel
            for (int i = image_size*2; i < image_size*3; i++){bgr[i] = 200;} // fill green channel

            long start = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
            byte[] rgba = Utils.bgr2rgba(bgr, width, height);
            long end = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;

            long duration = end - start;
            Assert.True(duration < timeout, "Expected: " + timeout + " Actual: " + duration);
        }

        [Fact]
        public void test_PerfConvertBGR2BGRA()
        {
            // Test BGR image converted to BGRA using ‘bgr2bgra’ function in less than 1.0s
            int timeout = 1000;
            int width = 3;
            int height = 3;
            int image_size = width*height;
            int channels = 3;
            byte[] bgr = new byte[image_size*channels];
            for (int i = 0; i < image_size*1; i++){bgr[i] = 100;} // fill blue channel
            for (int i = image_size*1; i < image_size*2; i++){bgr[i] = 150;} // fill red channel
            for (int i = image_size*2; i < image_size*3; i++){bgr[i] = 200;} // fill green channel

            long start = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
            byte[] bgra = Utils.bgr2bgra(bgr, width, height);
            long end = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;

            long duration = end - start;
            Assert.True(duration < timeout, "Expected: " + timeout + " Actual: " + duration);
        }

        [Fact]
        public void test_PerfConvertDisparity2Depth()
        {
            // Test disparity image of size 2448x2048 converted to depth
            // by ‘disparity2Depth’ function in less than 1.0s
            int timeout = 1000;
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

            long start = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
            float[] depth = Utils.disparity2Depth(disparity, width, height, Q);
            long end = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;

            long duration = end - start;
            Assert.True(duration < timeout, "Expected: " + timeout + " Actual: " + duration);
        }

        [Fact]
        public void test_PerfConvertDisparity2Xyz()
        {
            // Test disparity image of size 2448x2048 converted to xyz image
            // by ‘disparity2xyz’ function in less than 2.0s
            int timeout = 2000;
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

            long start = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
            float[] xyz = Utils.disparity2xyz(disparity, width, height, Q);
            long end = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;

            long duration = end - start;
            Assert.True(duration < timeout, "Expected: " + timeout + " Actual: " + duration);
        }

        [Fact]
        public void test_PerfConvertDepth2Xyz()
        {
            // Test depth image of size 2448x2048 converted to xyz image
            // by ‘depth2xyz’ function in less than 1.0s
            int timeout = 1000;
            int width = 2448;
            int height = 2048;
            int image_size = width*height;
            float[] depth = new float[image_size];
            for (int i = 0; i < depth.Length; i++){depth[i] = 1.0f;} // fill with zeros
            depth[0] = 0.0f;
            depth[(1024 * width + 1224)] = 1.4523f;
            depth[(1400 * width + 2200)] = 1.54977f;
            float hfov = (float) (2 * Math.Atan(1224.0 / 3478.26099));

            long start = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
            float[] xyz = Utils.depth2xyz(depth, width, height, hfov);
            long end = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;

            long duration = end - start;
            Assert.True(duration < timeout, "Expected: " + timeout + " Actual: " + duration);
        }

        [Fact]
        public void test_PerfConvertXyz2Depth()
        {
            // Test XYZ image of size 2448x2048 converted to depth image
            // by ‘xyz2depth’ function in less than 0.1s
            int timeout = 100;
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

            long start = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
            float[] depth = Utils.xyz2depth(xyz, width, height);
            long end = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;

            long duration = end - start;
            Assert.True(duration < timeout, "Expected: " + timeout + " Actual: " + duration);
        }

        [Fact]
        public void test_PerfReadImage()
        {
            // Test read image of size 2448x2048 using ‘readImage’ function in less than 0.2s
            int timeout = 200;
            string data_folder = "data";
            string image_filepath = data_folder + "/left.png";
            
            long start = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
            byte[] image = Utils.readImage(image_filepath, 2448, 2048);
            long end = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;

            long duration = end - start;
            Assert.True(duration < timeout, "Expected: " + timeout + " Actual: " + duration);
        }

        [Fact]
        public void test_PerfFlipImageHorizontally()
        {
            // Test flip image of size 2448x2048 horizontally using ‘flip’ function in less than 0.1s
            int timeout = 100;
            int width = 2448;
            int height = 2048;
            byte[] input_img = new byte[width*height];
            Random randNum = new Random();
            for (int i = 0; i < input_img.Length; i++)
            {
                input_img[i] = (byte) randNum.Next(1, 255);
            }

            long start = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
            byte[] flipped_img = Utils.flip(input_img, width, height, 1, 0);
            long end = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;

            long duration = end - start;
            Assert.True(duration < timeout, "Expected: " + timeout + " Actual: " + duration);
        }

        [Fact]
        public void test_PerfSavePLY()
        {
            // Test save RGB and XYZ image of size 2448x2048 as point cloud
            // in PLY format using ‘savePLY’ function in less than 5s
            int timeout = 5000;
            string test_folder = ".phase_test";
            string out_ply = test_folder + "/out.ply";
            int width = 2448;
            int height = 2048;
            int image_size = 2448 * 2048;
            float[] xyz = new float[image_size * 3];
            for (int i = 0; i < xyz.Length; i++){xyz[i] = 1.0f;} // fill with ones
            byte[] rgb = new byte[image_size * 3];
            for (int i = 0; i < rgb.Length; i++){rgb[i] = 1;} // fill with ones

            long start = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
            bool success = Utils.savePLY(out_ply, xyz, rgb, width, height);
            long end = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;

            long duration = end - start;
            Assert.True(duration < timeout, "Expected: " + timeout + " Actual: " + duration);
        }

        [Fact]
        public void test_PerfCheckMatEqual()
        {
            // Test checking equality of two cv::Mat’s using function ‘cvMatIsEqual’ in less than 0.1s
            int timeout = 100;
            int width = 3;
            int height = 3;
            int channels = 1;
            float[] mat_a = new float[width*height*channels];
            float[] mat_b = new float[width*height*channels];
            for (int i = 0; i < width*height*channels; i++){
                mat_a[i] = 1.0f;
                mat_b[i] = 1.0f;
            }

            long start = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
            Utils.cvMatIsEqual(mat_a, mat_b, width, height, channels);
            long end = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;

            long duration = end - start;
            Assert.True(duration < timeout, "Expected: " + timeout + " Actual: " + duration);
        }
    }
}
