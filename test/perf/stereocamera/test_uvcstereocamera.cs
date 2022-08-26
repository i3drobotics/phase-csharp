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
            // TOTEST
        }
    }
}
