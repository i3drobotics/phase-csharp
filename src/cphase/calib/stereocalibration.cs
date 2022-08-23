/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file stereocalibration.cs
 * @brief Stereo Calibration class
 * @details Camera calibration structures and support functions
 * for generating stereo calibration from images.
 */

using System;
using System.Runtime.InteropServices;
using I3DR.Phase;

namespace I3DR.CPhase
{
    //!  Stereo Camera Calibration class
    /*!
    Store and manipulate stereo camera calibration data.
    */
    public class CStereoCameraCalibration
    {
        //! Imported from Phase C API
        // TODO add empty constructor initialisation to C-API
        // [DllImport("phase", EntryPoint = "PhaseStereoCameraCalibrationCreate", CallingConvention = CallingConvention.Cdecl)]
        // public static extern IntPtr PhaseStereoCameraCalibrationCreate(string left_yaml_filepath, string right_yaml_filepath);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoCameraCalibrationCalibrationFromYAML", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr PhaseStereoCameraCalibrationCalibrationFromYAML(string left_yaml_filepath, string right_yaml_filepath);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoCameraCalibrationCalibrationFromIdeal", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr PhaseStereoCameraCalibrationCalibrationFromIdeal(int width, int height, double pixel_pitch, double focal_length, double baseline);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoCameraCalibrationIsValid", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool PhaseStereoCameraCalibrationIsValid(IntPtr c);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoCameraCalibrationIsValidSize", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool PhaseStereoCameraCalibrationIsValidSize(IntPtr c, int width, int height);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "StereoCameraCalibrationGetHFOV", CallingConvention = CallingConvention.Cdecl)]
        public static extern float StereoCameraCalibrationGetHFOV(IntPtr c);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "StereoCameraCalibrationGetBaseline", CallingConvention = CallingConvention.Cdecl)]
        public static extern double StereoCameraCalibrationGetBaseline(IntPtr c);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "StereoCameraCalibrationGetQ", CallingConvention = CallingConvention.Cdecl)]
        public static extern void StereoCameraCalibrationGetQ(IntPtr c, [Out] float[] out_Q);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "StereoCameraCalibrationGetDownsampleFactor", CallingConvention = CallingConvention.Cdecl)]
        public static extern float StereoCameraCalibrationGetDownsampleFactor(IntPtr c);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "StereoCameraCalibrationSetDownsampleFactor", CallingConvention = CallingConvention.Cdecl)]
        public static extern void StereoCameraCalibrationSetDownsampleFactor(IntPtr c, float value);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoCameraCalibrationRectify", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool PhaseStereoCameraCalibrationRectify(IntPtr c, [In] byte[] left_image, [In] byte[] right_image, int width, int height, [Out] byte[] left_rect_image, [Out] byte[] right_rect_image);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "StereoCameraCalibrationSaveToYAML", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool StereoCameraCalibrationSaveToYAML(IntPtr c, string left_calibration_filepath, string right_calibration_filepath, CalibrationFileType cal_file_type);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "StereoCameraCalibrationDispose", CallingConvention = CallingConvention.Cdecl)]
        public static extern void StereoCameraCalibrationDispose(IntPtr c);
    }
}