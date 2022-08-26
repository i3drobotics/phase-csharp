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
using I3DR.Phase.Calib;

namespace I3DR.CPhase.Calib
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
        public static extern IntPtr calibrationFromYAML(string left_yaml_filepath, string right_yaml_filepath);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoCameraCalibrationCalibrationFromIdeal", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr calibrationFromIdeal(int width, int height, double pixel_pitch, double focal_length, double baseline);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoCameraCalibrationIsValid", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool isValid(IntPtr c);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoCameraCalibrationIsValidSize", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool isValidSize(IntPtr c, int width, int height);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoCameraCalibrationGetLeftCalibration", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr getLeftCalibration(IntPtr c);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoCameraCalibrationGetRightCalibration", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr getRightCalibration(IntPtr c);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoCameraCalibrationGetHFOV", CallingConvention = CallingConvention.Cdecl)]
        public static extern float getHFOV(IntPtr c);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoCameraCalibrationGetBaseline", CallingConvention = CallingConvention.Cdecl)]
        public static extern double getBaseline(IntPtr c);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoCameraCalibrationGetQ", CallingConvention = CallingConvention.Cdecl)]
        public static extern void getQ(IntPtr c, [Out] float[] out_Q);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoCameraCalibrationGetDownsampleFactor", CallingConvention = CallingConvention.Cdecl)]
        public static extern float getDownsampleFactor(IntPtr c);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoCameraCalibrationSetDownsampleFactor", CallingConvention = CallingConvention.Cdecl)]
        public static extern void setDownsampleFactor(IntPtr c, float value);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoCameraCalibrationRectify", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool rectify(IntPtr c, [In] byte[] left_image, [In] byte[] right_image, int width, int height, [Out] byte[] left_rect_image, [Out] byte[] right_rect_image);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoCameraCalibrationSaveToYAML", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool saveToYAML(IntPtr c, string left_calibration_filepath, string right_calibration_filepath, CalibrationFileType cal_file_type);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseStereoCameraCalibrationDispose", CallingConvention = CallingConvention.Cdecl)]
        public static extern void dispose(IntPtr c);
    }
}