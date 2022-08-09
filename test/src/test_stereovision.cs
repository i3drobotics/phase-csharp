/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file test_stereovision.cs
 * @brief Unit tests for Stereo Vision class
 * @details Unit tests generated using MSTest
 */

using Xunit;
using I3DR;

namespace I3DR.Phase.Test
{
    public class StereoVisionTests
    {
        [Fact]
        public void test_StereoVision()
        {
            CameraDeviceInfo device_info = new CameraDeviceInfo(
                "0815-0000", "0815-0001", "virtualpylon",
                CameraDeviceType.DEVICE_TYPE_GENERIC_PYLON,
                CameraInterfaceType.INTERFACE_TYPE_VIRTUAL
            );
            StereoMatcherType matcher_type = StereoMatcherType.STEREO_MATCHER_BM;
            //TODO generate interal calibration from ideal for tests
            StereoVision sv = new StereoVision(device_info, matcher_type, "", "");
            sv.dispose(); //check manual dispose of class works (useful in Unity when used in Editor)
        }
    }
}
