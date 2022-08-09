/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file cameracalibration.cs
 * @brief Camera Calibration Wrapper class
 * @details C# wrapper class for Camera Calibration class export.
 * DllImports for using C type exports. Pointer to class instance
 * is passed between functions.
 */

using System;
using System.Runtime.InteropServices;
using System.Runtime.ExceptionServices;

namespace I3DR.Phase
{
    public enum CalibrationFileType { 
        ROS_YAML,
        OPENCV_YAML,
        INVALID
    };
}