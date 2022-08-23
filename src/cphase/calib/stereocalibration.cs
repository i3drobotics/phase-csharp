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
using System.Runtime.ExceptionServices;

namespace I3DR.CPhase
{
    //!  Stereo Camera Calibration class
    /*!
    Store and manipulate stereo camera calibration data.
    */
    public class StereoCameraCalibration
    {
        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_CStereoCameraCalibration_create", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr CStereoCameraCalibration_create(string left_yaml_filepath, string right_yaml_filepath);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoCameraCalibration_CalibrationFromYAML", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr CCalibrationFromYAML(string left_yaml_filepath, string right_yaml_filepath);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoCameraCalibration_CalibrationFromIdeal", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr CCalibrationFromIdeal(int width, int height, double pixel_pitch, double focal_length, double baseline);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoCameraCalibration_CIsValid", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool CIsValid(IntPtr c);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoCameraCalibration_CIsValidSize", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool CIsValidSize(IntPtr c, int width, int height);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoCameraCalibration_CGetHFOV", CallingConvention = CallingConvention.Cdecl)]
        private static extern float CGetHFOV(IntPtr c);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoCameraCalibration_CGetBaseline", CallingConvention = CallingConvention.Cdecl)]
        private static extern double CGetBaseline(IntPtr c);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoCameraCalibration_CGetQ", CallingConvention = CallingConvention.Cdecl)]
        private static extern void CGetQ(IntPtr c, [Out] float[] out_Q);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoCameraCalibration_CGetDownsampleFactor", CallingConvention = CallingConvention.Cdecl)]
        private static extern float CGetDownsampleFactor(IntPtr c);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoCameraCalibration_CSetDownsampleFactor", CallingConvention = CallingConvention.Cdecl)]
        private static extern void CSetDownsampleFactor(IntPtr c, float value);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoCameraCalibration_CRectify", CallingConvention = CallingConvention.Cdecl)]
        protected static extern bool CRectify(IntPtr c, [In] byte[] left_image, [In] byte[] right_image, int width, int height, [Out] byte[] left_rect_image, [Out] byte[] right_rect_image);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoCameraCalibration_CSaveToYAML", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool CSaveToYAML(IntPtr c, string left_calibration_filepath, string right_calibration_filepath, CalibrationFileType cal_file_type);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoCameraCalibration_dispose", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StereoCameraCalibration_dispose(IntPtr c);
    }
}