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

namespace I3DR.CPhase.Calib
{
    //!  Camera Calibration class
    /*!
    Store and manipulate camera calibration data.
    */
    public class CCameraCalibration
    {
        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseCameraCalibrationCreate", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create(string yaml_filepath);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseCameraCalibrationCalibrationFromIdeal", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr calibrationFromIdeal(int width, int height, double pixel_pitch, double focal_length, double translation_x, double translation_y);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseCameraCalibrationRectify", CallingConvention = CallingConvention.Cdecl)]
        public static extern void rectify(IntPtr c, [In] byte[] image, int width, int height, [Out] byte[] rect_image);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseCameraCalibrationIsValid", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool isValid(IntPtr c);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseCameraCalibrationGetImageWidth", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getImageWidth(IntPtr c);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseCameraCalibrationGetImageHeight", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getImageHeight(IntPtr c);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseCameraCalibrationGetCameraFX", CallingConvention = CallingConvention.Cdecl)]
        public static extern double getCameraFX(IntPtr c);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseCameraCalibrationGetCameraFY", CallingConvention = CallingConvention.Cdecl)]
        public static extern double getCameraFY(IntPtr c);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseCameraCalibrationGetCameraCX", CallingConvention = CallingConvention.Cdecl)]
        public static extern double getCameraCX(IntPtr c);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseCameraCalibrationGetCameraCY", CallingConvention = CallingConvention.Cdecl)]
        public static extern double getCameraCY(IntPtr c);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseCameraCalibrationGetProjectionFX", CallingConvention = CallingConvention.Cdecl)]
        public static extern double getProjectionFX(IntPtr c);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseCameraCalibrationGetProjectionFY", CallingConvention = CallingConvention.Cdecl)]
        public static extern double getProjectionFY(IntPtr c);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseCameraCalibrationGetProjectionCX", CallingConvention = CallingConvention.Cdecl)]
        public static extern double getProjectionCX(IntPtr c);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseCameraCalibrationGetProjectionCY", CallingConvention = CallingConvention.Cdecl)]
        public static extern double getProjectionCY(IntPtr c);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseCameraCalibrationGetProjectionTX", CallingConvention = CallingConvention.Cdecl)]
        public static extern double getProjectionTX(IntPtr c);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseCameraCalibrationGetCameraMatrix", CallingConvention = CallingConvention.Cdecl)]
        public static extern void getCameraMatrix(IntPtr c, [Out] double[] out_mat);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseCameraCalibrationGetDistortionCoefficients", CallingConvention = CallingConvention.Cdecl)]
        public static extern void getDistortionCoefficients(IntPtr c, [Out] double[] out_mat);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseCameraCalibrationGetRectificationMatrix", CallingConvention = CallingConvention.Cdecl)]
        public static extern void getRectificationMatrix(IntPtr c, [Out] double[] out_mat);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseCameraCalibrationGetProjectionMatrix", CallingConvention = CallingConvention.Cdecl)]
        public static extern void getProjectionMatrix(IntPtr c, [Out] double[] out_mat);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseCameraCalibrationGetDownsampleFactor", CallingConvention = CallingConvention.Cdecl)]
        public static extern float getDownsampleFactor(IntPtr c);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseCameraCalibrationSetDownsampleFactor", CallingConvention = CallingConvention.Cdecl)]
        public static extern void setDownsampleFactor(IntPtr c, float value);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseCameraCalibrationDispose", CallingConvention = CallingConvention.Cdecl)]
        public static extern void dispose(IntPtr c);
    }
}