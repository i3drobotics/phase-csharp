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
        public void test_PerfVirtualRead()
        {
            // Test reading of frame from virtual camera
            // using ‘read’ function is completed in less than 0.1s
            int timeout = 100;
            CameraDeviceInfo device_info = new CameraDeviceInfo(
                "0", "0", "virtual-camera",
                CameraDeviceType.DEVICE_TYPE_GENERIC_UVC,
                CameraInterfaceType.INTERFACE_TYPE_VIRTUAL
            );
            AbstractStereoCamera cam = StereoCamera.createStereoCamera(device_info);
            string data_folder = "data";
            string left_image_file = data_folder + "/left.png";
            string right_image_file = data_folder + "/right.png";
            cam.setTestImagePaths(left_image_file, right_image_file);
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
