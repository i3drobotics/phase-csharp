/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file test_uvcstereocamera.cs
 * @brief Unit tests for UVC Stereo Camera class
 * @details Unit tests generated using MSTest
 */

using Xunit;
using I3DR.Phase.StereoCamera;

namespace I3DR.PhaseTest
{
    // Tests for UVCStereoCamera
    [Collection("PhaseSequentialTests")]
    public class UVCStereoCameraTests
    {
        [Fact]
        public void test_GettingSettingParams()
        {
            // Test stereo camera parameters can be set and get functions return expected values
            // TOTEST
        }

        [Fact]
        public void test_VirtualCanConnect()
        {
            // Test virtual camera can be connected to using ‘connected’ function
            // TOTEST
        }

        [Fact]
        public void test_ValidVirtualRead()
        {
            // Test read frame from virtual camera using ‘read’ function
            // and valid read result is returned
            // TOTEST
        }

        [Fact]
        public void test_ValidVirtualThreadedRead()
        {
            // Test read frame in threaded process from virtual camera using ‘startReadThread’ function
            // and valid read result is returned
            // TOTEST
        }
    }
}
