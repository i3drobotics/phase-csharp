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

namespace I3DR.CPhase
{
    //!  Camera Calibration class
    /*!
    Store and manipulate camera calibration data.
    */
    public class CCameraCalibration
    {
        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseCameraCalibrationCreate", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr PhaseCameraCalibrationCreate(string left_yaml_filepath);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseCameraCalibrationCalibrationFromIdeal", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr PhaseCameraCalibrationCalibrationFromIdeal(int width, int height, double pixel_pitch, double focal_length, double translation_x, double translation_y);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseCameraCalibrationRectify", CallingConvention = CallingConvention.Cdecl)]
        public static extern void PhaseCameraCalibrationRectify(IntPtr c, [In] byte[] image, int width, int height, [Out] byte[] rect_image);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseCameraCalibrationIsValid", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool PhaseCameraCalibrationIsValid(IntPtr c);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseCameraCalibrationGetDownsampleFactor", CallingConvention = CallingConvention.Cdecl)]
        public static extern float PhaseCameraCalibrationGetDownsampleFactor(IntPtr c);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseCameraCalibrationSetDownsampleFactor", CallingConvention = CallingConvention.Cdecl)]
        public static extern void PhaseCameraCalibrationSetDownsampleFactor(IntPtr c, float value);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseCameraCalibrationDispose", CallingConvention = CallingConvention.Cdecl)]
        public static extern void PhaseCameraCalibrationDispose(IntPtr c);
    }
}