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

namespace I3DR.Phase
{
    //!  Stereo Camera Calibration class
    /*!
    Store and manipulate stereo camera calibration data.
    */
    public class StereoCameraCalibration
    {
        //! Imported from Phase C API

        // TODO load calibration from cameracalibration types
        // [DllImport("phase", EntryPoint = "I3DR_CStereoCameraCalibration_create", CallingConvention = CallingConvention.Cdecl)]
        // private static extern IntPtr CStereoCameraCalibration_create(string left_yaml_filepath, string right_yaml_filepath);

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
        [DllImport("phase", EntryPoint = "I3DR_StereoCameraCalibration_CRemapPoint", CallingConvention = CallingConvention.Cdecl)]
        protected static extern void CRemapPoint(IntPtr c, int x, int y, LeftOrRight camera_selection, ref int remapped_x, ref int remapped_y);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoCameraCalibration_CSaveToYAML", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool CSaveToYAML(IntPtr c, string left_calibration_filepath, string right_calibration_filepath, CalibrationFileType cal_file_type);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoCameraCalibration_dispose", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StereoCameraCalibration_dispose(IntPtr c);

        private IntPtr m_StereoCameraCalibration_instance; // TODOC
        private byte[] left_rect_image; // TODOC
        private byte[] right_rect_image; // TODOC
        private float[] Q; // TODOC

        // TODOC
        // public StereoCameraCalibration(string left_yaml_filepath, string right_yaml_filepath)
        // {
        //     m_StereoCameraCalibration_instance = CLoadCalibrationFromFile(
        //         left_yaml_filepath, right_yaml_filepath);
        // }

        // TODOC
        public StereoCameraCalibration(IntPtr stereoCameraCalibration_instance){
            m_StereoCameraCalibration_instance = stereoCameraCalibration_instance;
        }

        // TODOC
        public IntPtr getInstancePtr(){
            return m_StereoCameraCalibration_instance;
        }

        // TODOC
        public static StereoCameraCalibration calibrationFromYAML(string left_yaml_filepath, string right_yaml_filepath){
            return new StereoCameraCalibration(CCalibrationFromYAML(left_yaml_filepath, right_yaml_filepath));
        }

        // TODOC
        public static StereoCameraCalibration calibrationFromIdeal(int width, int height, double pixel_pitch, double focal_length, double baseline){
            return new StereoCameraCalibration(CCalibrationFromIdeal(width, height, pixel_pitch, focal_length, baseline));
        }

        // TODOC
        public bool isValid(){
            return CIsValid(m_StereoCameraCalibration_instance);
        }

        // TODOC
        public bool isValidSize(int width, int height){
            return CIsValidSize(m_StereoCameraCalibration_instance, width, height);
        }

        // TODOC
        public float getHFOV(){
            return CGetHFOV(m_StereoCameraCalibration_instance);
        }

        // TODOC
        public double getBaseline(){
            return CGetBaseline(m_StereoCameraCalibration_instance);
        }

        // TODOC
        public float getDownsampleFactor(){
            return CGetDownsampleFactor(m_StereoCameraCalibration_instance);
        }

        // TODOC
        public float[] getQ(){
            Q = new float[4*4];
            CGetQ(m_StereoCameraCalibration_instance, Q);
            return Q;
        }

        // TODOC
        public void setDownsampleFactor(float value){
            CSetDownsampleFactor(m_StereoCameraCalibration_instance, value);
        }

        // TODOC
        public StereoImagePair rectify(byte[] left_image, byte[] right_image, int width, int height){
            left_rect_image = new byte[width * height * 3];
            right_rect_image = new byte[width * height * 3];
            CRectify(
                m_StereoCameraCalibration_instance,
                left_image, right_image,
                width, height,
                left_rect_image, right_rect_image
            );
            return new StereoImagePair(left_rect_image, right_rect_image);
        }

        // TODOC
        public Point2i remapPoint(Point2i point, LeftOrRight camera_selection){
            int remapped_x = -1;
            int remapped_y = -1;
            CRemapPoint(
                m_StereoCameraCalibration_instance,
                point.x, point.y,
                camera_selection,
                ref remapped_x, ref remapped_y
            );
            return new Point2i(remapped_x, remapped_y);
        }

        // TODOC
        public bool saveToYAML(string left_calibration_filepath, string right_calibration_filepath, CalibrationFileType cal_file_type = CalibrationFileType.ROS_YAML){
            return CSaveToYAML(
                m_StereoCameraCalibration_instance,
                left_calibration_filepath, right_calibration_filepath,
                cal_file_type
            );
        }

        // TODOC
        public void markDisposed()
        {
            m_StereoCameraCalibration_instance = IntPtr.Zero;
        }

        // TODOC
        // [HandleProcessCorruptedStateExceptions]
        public void dispose(){
            if (m_StereoCameraCalibration_instance != IntPtr.Zero){
                try {
                    StereoCameraCalibration_dispose(m_StereoCameraCalibration_instance);
                }
                catch (AccessViolationException e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine("Please call 'dispose()' to make sure library memory is freed.");
                }
                m_StereoCameraCalibration_instance = IntPtr.Zero;
            }
        }

        // TODOC
        ~StereoCameraCalibration()
        {
            dispose();
        }
    }
}