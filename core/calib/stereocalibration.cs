/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file stereocalibration.cs
 * @brief Stereo Calibration  class
 * @details C#  class for Stereo Calibration class export.
 * DllImports for using C type exports. Pointer to class instance
 * is passed between functions.
 */

using System;
using System.Runtime.InteropServices;
using System.Runtime.ExceptionServices;

namespace I3DR.Phase
{
    public class StereoCameraCalibration
    {
        // TODO load calibration from cameracalibration types
        // [DllImport("phase", EntryPoint = "I3DR_CStereoCameraCalibration_create", CallingConvention = CallingConvention.Cdecl)]
        // private static extern IntPtr CStereoCameraCalibration_create(string left_yaml_filepath, string right_yaml_filepath);

        [DllImport("phase", EntryPoint = "I3DR_StereoCameraCalibration_CalibrationFromYAML", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr CCalibrationFromYAML(string left_yaml_filepath, string right_yaml_filepath);

        [DllImport("phase", EntryPoint = "I3DR_StereoCameraCalibration_CalibrationFromIdeal", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr CCalibrationFromIdeal(int width, int height, double pixel_pitch, double focal_length, double baseline);

        [DllImport("phase", EntryPoint = "I3DR_StereoCameraCalibration_CIsValid", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool CIsValid(IntPtr c);

        [DllImport("phase", EntryPoint = "I3DR_StereoCameraCalibration_CIsValidSize", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool CIsValidSize(IntPtr c, int width, int height);

        [DllImport("phase", EntryPoint = "I3DR_StereoCameraCalibration_CGetHFOV", CallingConvention = CallingConvention.Cdecl)]
        private static extern float CGetHFOV(IntPtr c);

        [DllImport("phase", EntryPoint = "I3DR_StereoCameraCalibration_CGetBaseline", CallingConvention = CallingConvention.Cdecl)]
        private static extern double CGetBaseline(IntPtr c);

        [DllImport("phase", EntryPoint = "I3DR_StereoCameraCalibration_CGetQ", CallingConvention = CallingConvention.Cdecl)]
        private static extern void CGetQ(IntPtr c, [Out] float[] out_Q);

        [DllImport("phase", EntryPoint = "I3DR_StereoCameraCalibration_CGetDownsampleFactor", CallingConvention = CallingConvention.Cdecl)]
        private static extern float CGetDownsampleFactor(IntPtr c);

        [DllImport("phase", EntryPoint = "I3DR_StereoCameraCalibration_CSetDownsampleFactor", CallingConvention = CallingConvention.Cdecl)]
        private static extern void CSetDownsampleFactor(IntPtr c, float value);

        [DllImport("phase", EntryPoint = "I3DR_StereoCameraCalibration_CRectify", CallingConvention = CallingConvention.Cdecl)]
        protected static extern bool CRectify(IntPtr c, [In] byte[] left_image, [In] byte[] right_image, int width, int height, [Out] byte[] left_rect_image, [Out] byte[] right_rect_image);

        [DllImport("phase", EntryPoint = "I3DR_StereoCameraCalibration_CRemapPoint", CallingConvention = CallingConvention.Cdecl)]
        protected static extern void CRemapPoint(IntPtr c, int x, int y, LeftOrRight camera_selection, ref int remapped_x, ref int remapped_y);

        [DllImport("phase", EntryPoint = "I3DR_StereoCameraCalibration_CSaveToYAML", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool CSaveToYAML(IntPtr c, string left_calibration_filepath, string right_calibration_filepath, CalibrationFileType cal_file_type);

        [DllImport("phase", EntryPoint = "I3DR_StereoCameraCalibration_dispose", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StereoCameraCalibration_dispose(IntPtr c);

        private IntPtr m_StereoCameraCalibration_instance;

        private byte[] left_rect_image;
        private byte[] right_rect_image;
        private float[] Q;

        // public StereoCameraCalibration(string left_yaml_filepath, string right_yaml_filepath)
        // {
        //     m_StereoCameraCalibration_instance = CLoadCalibrationFromFile(
        //         left_yaml_filepath, right_yaml_filepath);
        // }

        public StereoCameraCalibration(IntPtr stereoCameraCalibration_instance){
            m_StereoCameraCalibration_instance = stereoCameraCalibration_instance;
        }

        public IntPtr getInstancePtr(){
            return m_StereoCameraCalibration_instance;
        }

        public static StereoCameraCalibration calibrationFromYAML(string left_yaml_filepath, string right_yaml_filepath){
            return new StereoCameraCalibration(CCalibrationFromYAML(left_yaml_filepath, right_yaml_filepath));
        }

        public static StereoCameraCalibration calibrationFromIdeal(int width, int height, double pixel_pitch, double focal_length, double baseline){
            return new StereoCameraCalibration(CCalibrationFromIdeal(width, height, pixel_pitch, focal_length, baseline));
        }

        public bool isValid(){
            return CIsValid(m_StereoCameraCalibration_instance);
        }

        public bool isValidSize(int width, int height){
            return CIsValidSize(m_StereoCameraCalibration_instance, width, height);
        }

        public float getHFOV(){
            return CGetHFOV(m_StereoCameraCalibration_instance);
        }

        public double getBaseline(){
            return CGetBaseline(m_StereoCameraCalibration_instance);
        }

        public float getDownsampleFactor(){
            return CGetDownsampleFactor(m_StereoCameraCalibration_instance);
        }

        public float[] getQ(){
            Q = new float[4*4];
            CGetQ(m_StereoCameraCalibration_instance, Q);
            return Q;
        }

        public void setDownsampleFactor(float value){
            CSetDownsampleFactor(m_StereoCameraCalibration_instance, value);
        }

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

        public bool saveToYAML(string left_calibration_filepath, string right_calibration_filepath, CalibrationFileType cal_file_type = CalibrationFileType.ROS_YAML){
            return CSaveToYAML(
                m_StereoCameraCalibration_instance,
                left_calibration_filepath, right_calibration_filepath,
                cal_file_type
            );
        }

        public void markDisposed()
        {
            m_StereoCameraCalibration_instance = IntPtr.Zero;
        }

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

        ~StereoCameraCalibration()
        {
            dispose();
        }
    }
}