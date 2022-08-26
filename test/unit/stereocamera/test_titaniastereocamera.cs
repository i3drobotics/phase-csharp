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
        public void test_GettingSettingParams()
        {
            // Test stereo camera parameters can be set and get functions return expected values
            CameraDeviceInfo device_info = new CameraDeviceInfo(
                "0815-0000", "0815-0001", "virtual-camera",
                CameraDeviceType.DEVICE_TYPE_TITANIA,
                CameraInterfaceType.INTERFACE_TYPE_VIRTUAL
            );
            TitaniaStereoCamera cam = new TitaniaStereoCamera(device_info);

            // int frame_rate = 5;
            int exposure = 500;
            bool hardware_trigger = false;
            int x_min = 10;
            int x_max = 100;
            int y_min = 10;
            int y_max = 100;
            
            Assert.True(cam.connect());
            cam.setLeftAOI(x_min, y_min, x_max, y_max);
            cam.setRightAOI(x_min, y_min, x_max, y_max);
            cam.setExposure(exposure);
            cam.enableHardwareTrigger(hardware_trigger);

            // TODO add get methods to TitaniaStereoCamera to check values have been set

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
                "0815-0000", "0815-0001", "virtual-camera",
                CameraDeviceType.DEVICE_TYPE_TITANIA,
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
                "0815-0000", "0815-0001", "virtual-camera",
                CameraDeviceType.DEVICE_TYPE_TITANIA,
                CameraInterfaceType.INTERFACE_TYPE_VIRTUAL
            );
            AbstractStereoCamera cam = StereoCamera.createStereoCamera(device_info);
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
                "0815-0000", "0815-0001", "virtual-camera",
                CameraDeviceType.DEVICE_TYPE_TITANIA,
                CameraInterfaceType.INTERFACE_TYPE_VIRTUAL
            );
            AbstractStereoCamera cam = StereoCamera.createStereoCamera(device_info);
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
