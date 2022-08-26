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
            // TOTEST
        }

        [Fact]
        public void test_PerfLargeImageScaling()
        {
            // Test image with size 2448x2048 scaled by ‘scaleImage’ function
            // with a scaling factor of 2 in less than 0.1s
            // TOTEST
        }

        [Fact]
        public void test_PerfConvertBGR2Mono()
        {
            // Test image of type CV_8UC3 converted to mono
            // by ‘toMono’ function in less than 0.1s
            // TOTEST
        }

        [Fact]
        public void test_PerfConvertBGRA2RGBA()
        {
            // Test BGRA image converted to RGBA using ‘bgra2rgba’ function in less than 0.8s
            // TOTEST
        }

        [Fact]
        public void test_PerfConvertBGR2RGBA()
        {
            // Test BGR image converted to RGBA using ‘bgr2rgba’ function in less than 0.8s
            // TOTEST
        }

        [Fact]
        public void test_PerfConvertBGR2BGRA()
        {
            // Test BGR image converted to BGRA using ‘bgr2bgra’ function in less than 0.8s
            // TOTEST
        }

        [Fact]
        public void test_PerfConvertDisparity2Depth()
        {
            // Test disparity image of size 2448x2048 converted to depth
            // by ‘disparity2Depth’ function in less than 0.5s
            // TOTEST
        }

        [Fact]
        public void test_PerfConvertDisparity2Xyz()
        {
            // Test disparity image of size 2448x2048 converted to xyz image
            // by ‘disparity2xyz’ function in less than 0.5s
            // TOTEST
        }

        [Fact]
        public void test_PerfConvertDepth2Xyz()
        {
            // Test depth image of size 2448x2048 converted to xyz image
            // by ‘depth2xyz’ function in less than 0.5s
            // TOTEST
        }

        [Fact]
        public void test_PerfConvertXyz2Depth()
        {
            // Test XYZ image of size 2448x2048 converted to depth image
            // by ‘xyz2depth’ function in less than 0.1s
            // TOTEST
        }

        [Fact]
        public void test_PerfReadImage()
        {
            // Test read image of size 2448x2048 using ‘readImage’ function in less than 0.2s
            // TOTEST
        }

        [Fact]
        public void test_PerfFlipImageHorizontally()
        {
            // Test flip image of size 2448x2048 horizontally using ‘flip’ function in less than 0.1s
            // TOTEST
        }

        [Fact]
        public void test_PerfSavePLY()
        {
            // Test save RGB and XYZ image of size 2448x2048 as point cloud
            // in PLY format using ‘savePLY’ function in less than 5s
            // TOTEST
        }

        [Fact]
        public void test_PerfCheckMatEqual()
        {
            // Test checking equality of two cv::Mat’s using function ‘cvMatIsEqual’ in less than 0.1s
            // TOTEST
        }
    }
}
