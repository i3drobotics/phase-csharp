/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file cameracalibration.cs
 * @brief Camera Calibration Wrapper class
 * @details Camera calibration structures and support functions
 * for generating calibration for mono camera.
 */

using System;
using System.Runtime.InteropServices;
using System.Runtime.ExceptionServices;

namespace I3DR.Phase
{
    //!  Calibration File Type enum
    /*!
    Enum to indicate calibration file type. OpenCV uses different YAML standard from ROS.
    */
    public enum CalibrationFileType { 
        ROS_YAML,
        OPENCV_YAML,
        INVALID
    };
}