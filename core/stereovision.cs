/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file stereovision.cs
 * @brief Stereo Vision class
 * @details C# class for Stereo Vision class export.
 * DllImports for using C type exports. Pointer to class instance
 * is passed between functions.
 */

using System;
using System.Runtime.InteropServices;
using System.Runtime.ExceptionServices;

namespace I3DR.Phase
{
    public class StereoVision
    {
        [DllImport("phase", EntryPoint = "I3DR_StereoVision_create", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr StereoVision_create(
            string left_serial, string right_serial, string unique_serial,
            CameraDeviceType device_type, CameraInterfaceType interface_type, StereoMatcherType matcher_type,
            string left_yaml, string right_yaml);

        [DllImport("phase", EntryPoint = "I3DR_StereoVision_CGetCamera", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr StereoVision_getCamera(IntPtr sv);

        [DllImport("phase", EntryPoint = "I3DR_StereoVision_CGetMatcher", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr StereoVision_getMatcher(IntPtr sv);

        [DllImport("phase", EntryPoint = "I3DR_StereoVision_CGetCalibration", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr StereoVision_getCalibration(IntPtr sv);

        [DllImport("phase", EntryPoint = "I3DR_StereoVision_CConnect", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool StereoVision_connect(IntPtr sv);

        [DllImport("phase", EntryPoint = "I3DR_StereoVision_CIsConnected", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool StereoVision_isConnected(IntPtr sv);

        [DllImport("phase", EntryPoint = "I3DR_StereoVision_CStartCapture", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool StereoVision_startCapture(IntPtr sv);

        [DllImport("phase", EntryPoint = "I3DR_StereoVision_CStopCapture", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StereoVision_stopCapture(IntPtr sv);

        [DllImport("phase", EntryPoint = "I3DR_StereoVision_CIsCapturing", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool StereoVision_isCapturing(IntPtr sv);

        [DllImport("phase", EntryPoint = "I3DR_StereoVision_CIsValidCalibration", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool StereoVision_isValidCalibration(IntPtr sv);

        [DllImport("phase", EntryPoint = "I3DR_StereoVision_CGetWidth", CallingConvention = CallingConvention.Cdecl)]
        private static extern int StereoVision_getWidth(IntPtr sv);

        [DllImport("phase", EntryPoint = "I3DR_StereoVision_CGetHeight", CallingConvention = CallingConvention.Cdecl)]
        private static extern int StereoVision_getHeight(IntPtr sv);

        [DllImport("phase", EntryPoint = "I3DR_StereoVision_CGetHFOV", CallingConvention = CallingConvention.Cdecl)]
        private static extern float StereoVision_getHFOV(IntPtr sv);

        [DllImport("phase", EntryPoint = "I3DR_StereoVision_CGetDownsampleFactor", CallingConvention = CallingConvention.Cdecl)]
        private static extern float StereoVision_getDownsampleFactor(IntPtr sv);

        [DllImport("phase", EntryPoint = "I3DR_StereoVision_CSetDownsampleFactor", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StereoVision_setDownsampleFactor(IntPtr sv, float value);

        [DllImport("phase", EntryPoint = "I3DR_StereoVision_CSetTestImagePaths", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StereoVision_setTestImagePaths(IntPtr cam, string left_test_image_path, string right_test_image_path);

        [DllImport("phase", EntryPoint = "I3DR_StereoVision_CRead", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool StereoVision_read(
            IntPtr sv, int timeout, bool rectify, [Out] byte[] left_image, [Out] byte[] right_image, [Out] float[] disparity);
        
        [DllImport("phase", EntryPoint = "I3DR_StereoVision_CStartReadThread", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StereoVision_startReadThread(IntPtr sv, int timeout, bool rectify);

        [DllImport("phase", EntryPoint = "I3DR_StereoVision_CIsReadThreadRunning", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool StereoVision_isReadThreadRunning(IntPtr sv);

        [DllImport("phase", EntryPoint = "I3DR_StereoVision_CGetReadThreadResult", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool StereoVision_getReadThreadResult(
            IntPtr sv, [Out] byte[] left_image, [Out] byte[] right_image, [Out] float[] disparity);

        [DllImport("phase", EntryPoint = "I3DR_StereoVision_CDisconnect", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StereoVision_disconnect(IntPtr sv);

        [DllImport("phase", EntryPoint = "I3DR_StereoVision_dispose", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StereoVision_dispose(IntPtr sv);

        private IntPtr m_StereoVision_instance;
        private byte[] left_image;
        private byte[] right_image;
        private float[] disparity;
        private AbstractStereoCamera m_abstractStereoCamera;
        private AbstractStereoMatcher m_abstractStereoMatcher;
        private StereoCameraCalibration m_stereoCameraCalibration;

        public StereoVision(
            CameraDeviceInfo camera_device_info, StereoMatcherType stereo_matcher_type, string left_yaml, string right_yaml)
        {
            m_StereoVision_instance = StereoVision_create(
                camera_device_info.left_camera_serial, camera_device_info.right_camera_serial, 
                camera_device_info.unique_serial, 
                camera_device_info.device_type, camera_device_info.interface_type,
                stereo_matcher_type, 
                left_yaml,
                right_yaml
            );
            // TODO do specific camera type initalisation
            m_abstractStereoCamera = new AbstractStereoCamera(StereoVision_getCamera(m_StereoVision_instance));
            if (stereo_matcher_type == StereoMatcherType.STEREO_MATCHER_I3DRSGM){
                m_abstractStereoMatcher = new StereoI3DRSGM(StereoVision_getMatcher(m_StereoVision_instance));
            } else if (stereo_matcher_type == StereoMatcherType.STEREO_MATCHER_BM){
                m_abstractStereoMatcher = new StereoBM(StereoVision_getMatcher(m_StereoVision_instance));
            } else if (stereo_matcher_type == StereoMatcherType.STEREO_MATCHER_SGBM){
                m_abstractStereoMatcher = new StereoSGBM(StereoVision_getMatcher(m_StereoVision_instance));
            } else {
                throw new ArgumentException(
                    String.Format("Unsupported stereo matcher type: {0}", stereo_matcher_type),"stereo_matcher_type");
            }
            m_stereoCameraCalibration = new StereoCameraCalibration(StereoVision_getCalibration(m_StereoVision_instance));
        }

        public void getCamera(out AbstractStereoCamera abstractStereoCamera){
            abstractStereoCamera = m_abstractStereoCamera;
        }

        public void getMatcher(out AbstractStereoMatcher abstractStereoMatcher){
            abstractStereoMatcher = m_abstractStereoMatcher;
        }

        public void getCalibration(out StereoCameraCalibration stereoCameraCalibration){
            stereoCameraCalibration = m_stereoCameraCalibration;
        }

        public bool connect(){
            bool success = StereoVision_connect(m_StereoVision_instance);
            return success;
        }

        public bool isConnected(){
            return StereoVision_isConnected(m_StereoVision_instance);
        }

        public bool startCapture(){
            return StereoVision_startCapture(m_StereoVision_instance);
        }

        public void stopCapture(){
            StereoVision_stopCapture(m_StereoVision_instance);
        }

        public bool isCapturing(){
            return StereoVision_isCapturing(m_StereoVision_instance);
        }

        public bool isValidCalibration(){
            return StereoVision_isValidCalibration(m_StereoVision_instance);
        }

        public int getWidth(){
            return StereoVision_getWidth(m_StereoVision_instance);
        }

        public int getHeight(){
            return StereoVision_getHeight(m_StereoVision_instance);
        }

        public float getHFOV(){
            return StereoVision_getHFOV(m_StereoVision_instance);
        }

        public float getDownsampleFactor(){
            return StereoVision_getDownsampleFactor(m_StereoVision_instance);
        }

        public void setDownsampleFactor(float value){
            StereoVision_setDownsampleFactor(m_StereoVision_instance, value);
        }

        public void setTestImagePaths(string left_test_image_path, string right_test_image_path){
            StereoVision_setTestImagePaths(m_StereoVision_instance, left_test_image_path, right_test_image_path);
        }

        public StereoVisionReadResult read(int timeout = 1000, bool recitfy = true)
        {
            int image_size = getWidth() * getHeight();
            if (left_image == null){
                left_image = new byte[image_size * 3];
            }
            if (right_image == null){
                right_image = new byte[image_size * 3];
            }
            if (disparity == null){
                disparity = new float[image_size];
            }
            bool valid = StereoVision_read(
                m_StereoVision_instance, timeout, recitfy,
                left_image, right_image, disparity
            );
            StereoVisionReadResult readResult = new StereoVisionReadResult(valid, left_image, right_image, disparity);
            return readResult;
        }

        public void startReadThread(int timeout = 1000, bool rectify = true){
            StereoVision_startReadThread(m_StereoVision_instance, timeout, rectify);
        }

        public bool isReadThreadRunning(){
            return StereoVision_isReadThreadRunning(m_StereoVision_instance);
        }

        public StereoVisionReadResult getReadThreadResult()
        {
            int image_size = getWidth() * getHeight();
            if (left_image == null){
                left_image = new byte[image_size * 3];
            }
            if (right_image == null){
                right_image = new byte[image_size * 3];
            }
            if (disparity == null){
                disparity = new float[image_size];
            }
            bool valid = StereoVision_getReadThreadResult(
                m_StereoVision_instance,
                left_image, right_image, disparity
            );
            StereoVisionReadResult readResult = new StereoVisionReadResult(valid, left_image, right_image, disparity);
            return readResult;
        }

        public void disconnect(){
            StereoVision_disconnect(m_StereoVision_instance);
        }

        [HandleProcessCorruptedStateExceptions]
        public void dispose(){
            
            if (m_StereoVision_instance != IntPtr.Zero)
            {
                try
                {
                    StereoVision_dispose(m_StereoVision_instance);
                }
                catch (AccessViolationException e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine("Please call 'dispose()' to make sure memory is freed.");
                }
                m_StereoVision_instance = IntPtr.Zero;
            }
            m_abstractStereoCamera.markDisposed();
            m_abstractStereoMatcher.markDisposed();
            m_stereoCameraCalibration.markDisposed();
        }

        ~StereoVision()
        {
            dispose();
        }
    }
}