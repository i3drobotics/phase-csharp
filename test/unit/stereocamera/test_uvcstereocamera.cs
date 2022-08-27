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
            CameraDeviceInfo device_info = new CameraDeviceInfo(
                "0", "0", "virtual-camera",
                CameraDeviceType.DEVICE_TYPE_GENERIC_UVC,
                CameraInterfaceType.INTERFACE_TYPE_VIRTUAL
            );
            UVCStereoCamera cam = new UVCStereoCamera(device_info);

            // int frame_rate = 5;
            // int exposure = 500;
            // bool hardware_trigger = false;
            // int x_min = 10;
            // int x_max = 100;
            // int y_min = 10;
            // int y_max = 100;

            // TODO fix setting exposure for UVC Cameras
            // cam->setExposure(500);
            // TODO fix setting hardware trigger for UVC Cameras
            // cam->enableHardwareTrigger(false);
            // TODO fix setting frame rate for UVC Cameras
            // cam->setFrameRate(frame_rate);
            // TODO fix setting AOI for virutal camera
            // cam->setLeftAOI(x_min, x_max, y_min, y_max);
            // cam->setRightAOI(x_min, x_max, y_min, y_max);

            // TODO add get methods to UVCStereoCamera to check values have been set

            // TODO fix getting frame rate for virtual camera
            // // read a few frames as frame rate is calculated
            // cam->startCapture();
            // cam->read();
            // cam->read();
            // REQUIRE(cam->getFrameRate() == frame_rate);
            cam.dispose();
        }

        [Fact]
        public void test_VirtualCanConnect()
        {
            // Test virtual camera can be connected to using ‘connected’ function
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
            Assert.True(cam.connect());
            cam.dispose();
        }

        [Fact]
        public void test_ValidVirtualRead()
        {
            // Test read frame from virtual camera using ‘read’ function
            // and valid read result is returned
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
            CameraReadResult read_result = cam.read();
            Assert.True(read_result.valid);
            cam.dispose();
        }

        [Fact]
        public void test_ValidVirtualThreadedRead()
        {
            // Test read frame in threaded process from virtual camera using ‘startReadThread’ function
            // and valid read result is returned
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
            cam.startReadThread();

            int timeout = 30000; // seconds
            long start = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
            while(cam.isReadThreadRunning()){
                System.Threading.Thread.Sleep(1);
                long end = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
                long duration = end - start;
                if (duration > timeout){
                    Assert.True(duration < timeout);
                    break;
                }
            }

            CameraReadResult read_result = cam.getReadThreadResult();
            Assert.True(read_result.valid);
            cam.dispose();
        }
    }
}
