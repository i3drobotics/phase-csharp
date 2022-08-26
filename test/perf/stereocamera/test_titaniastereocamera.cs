/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file test_titaniastereocamera.cs
 * @brief Unit tests for Titania Stereo Camera class
 * @details Unit tests generated using MSTest
 */

using Xunit;
using I3DR.Phase.StereoCamera;

namespace I3DR.PhaseTest
{
    // Tests for TitaniaStereoCamera
    [Collection("PhaseSequentialTests")]
    public class TitaniaStereoCameraTests
    {
        [Fact]
        public void test_PerfVirtualRead()
        {
            // Test reading of frame from virtual camera
            // using ‘read’ function is completed in less than 0.1s
            int timeout = 100;
            CameraDeviceInfo device_info = new CameraDeviceInfo(
                "0815-0000", "0815-0001", "virtual-camera",
                CameraDeviceType.DEVICE_TYPE_TITANIA,
                CameraInterfaceType.INTERFACE_TYPE_VIRTUAL
            );
            AbstractStereoCamera cam = StereoCamera.createStereoCamera(device_info);
            bool connected = cam.connect();
            Assert.True(connected);
            cam.startCapture();

            long start = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
            CameraReadResult read_result = cam.read();
            long end = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;

            long duration = end - start;
            Assert.True(duration < timeout, "Expected: " + timeout + " Actual: " + duration);
        }
    }
}
