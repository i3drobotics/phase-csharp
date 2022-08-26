/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file test_deimosstereocamera.cs
 * @brief Unit tests for Deimos Stereo Camera class
 * @details Unit tests generated using MSTest
 */

using Xunit;
using I3DR.Phase.StereoCamera;

namespace I3DR.PhaseTest
{
    // Tests for DeimosStereoCamera
    [Collection("PhaseSequentialTests")]
    public class DeimosStereoCameraTests
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