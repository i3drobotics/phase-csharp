/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file abstractstereocamera.cs
 * @brief Abstract Stereo Camera class
 * @details Parent class for building stereo camera
 * classes. Includes functions/structures common across
 * all stereo cameras.
 */

using System;
using System.Runtime.InteropServices;
using System.Runtime.ExceptionServices;

namespace I3DR.Phase
{
    //!  Abstract Stereo Camera class
    /*!
    Abstract base class for building stereo camera
    classes. Includes functions/structures common across
    all stereo cameras.
    */
    public class AbstractStereoCamera
    {
        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoCamera_CConnect", CallingConvention = CallingConvention.Cdecl)]
        protected static extern bool AbstractStereoCamera_connect(IntPtr cam);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoCamera_CStartCapture", CallingConvention = CallingConvention.Cdecl)]
        protected static extern bool AbstractStereoCamera_startCapture(IntPtr cam);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoCamera_CStopCapture", CallingConvention = CallingConvention.Cdecl)]
        protected static extern void AbstractStereoCamera_stopCapture(IntPtr cam);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoCamera_CIsCapturing", CallingConvention = CallingConvention.Cdecl)]
        protected static extern bool AbstractStereoCamera_isCapturing(IntPtr cam);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoCamera_CIsConnected", CallingConvention = CallingConvention.Cdecl)]
        protected static extern bool AbstractStereoCamera_isConnected(IntPtr cam);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoCamera_CGetWidth", CallingConvention = CallingConvention.Cdecl)]
        protected static extern int AbstractStereoCamera_getWidth(IntPtr cam);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoCamera_CGetHeight", CallingConvention = CallingConvention.Cdecl)]
        protected static extern int AbstractStereoCamera_getHeight(IntPtr cam);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoCamera_CGetFrameRate", CallingConvention = CallingConvention.Cdecl)]
        protected static extern float AbstractStereoCamera_getFrameRate(IntPtr cam);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoCamera_CSetTestImagePaths", CallingConvention = CallingConvention.Cdecl)]
        protected static extern void AbstractStereoCamera_setTestImagePaths(IntPtr cam, string left_test_image_path, string right_test_image_path);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoCamera_CRead", CallingConvention = CallingConvention.Cdecl)]
        protected static extern bool AbstractStereoCamera_read(IntPtr cam, int timeout, [In] byte[] left_img, [In] byte[] right_img);
        
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoCamera_CStartReadThread", CallingConvention = CallingConvention.Cdecl)]
        protected static extern void AbstractStereoCamera_startReadThread(IntPtr cam, int timeout);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoCamera_CIsReadThreadRunning", CallingConvention = CallingConvention.Cdecl)]
        protected static extern bool AbstractStereoCamera_isReadThreadRunning(IntPtr cam);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoCamera_CGetReadThreadResult", CallingConvention = CallingConvention.Cdecl)]
        protected static extern bool AbstractStereoCamera_getReadThreadResult(IntPtr cam, [In] byte[] left_img, [In] byte[] right_img);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoCamera_CSetDownsampleFactor", CallingConvention = CallingConvention.Cdecl)]
        protected static extern void AbstractStereoCamera_setDownsampleFactor(IntPtr cam, float value);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoCamera_CSetExposure", CallingConvention = CallingConvention.Cdecl)]
        protected static extern void AbstractStereoCamera_setExposure(IntPtr cam, int value);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoCamera_CSetFrameRate", CallingConvention = CallingConvention.Cdecl)]
        protected static extern void AbstractStereoCamera_setFrameRate(IntPtr cam, float value);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoCamera_CEnableHardwareTrigger", CallingConvention = CallingConvention.Cdecl)]
        protected static extern void AbstractStereoCamera_enableHardwareTrigger(IntPtr cam, bool enable);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoCamera_CSetLeftAOI", CallingConvention = CallingConvention.Cdecl)]
        protected static extern void AbstractStereoCamera_setLeftAOI(IntPtr cam, int x_min, int y_min, int x_max, int y_max);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoCamera_CSetRightAOI", CallingConvention = CallingConvention.Cdecl)]
        protected static extern void AbstractStereoCamera_setRightAOI(IntPtr cam, int x_min, int y_min, int x_max, int y_max);
        
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoCamera_CDisconnect", CallingConvention = CallingConvention.Cdecl)]
        protected static extern void AbstractStereoCamera_disconnect(IntPtr cam);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoCamera_dispose", CallingConvention = CallingConvention.Cdecl)]
        protected static extern void AbstractStereoCamera_dispose(IntPtr cam);

        protected IntPtr m_AbstractStereoCamera_instance; // TODOC
        private byte[] left_image; // TODOC
        private byte[] right_image; // TODOC
        
        // TODOC
        public AbstractStereoCamera(CameraDeviceInfo camera_device_info){
            init(camera_device_info);
        }

        // TODOC
        public AbstractStereoCamera(IntPtr abstractStereoCamera_instance){
            m_AbstractStereoCamera_instance = abstractStereoCamera_instance;
        }

        // TODOC
        public IntPtr getInstancePtr(){
            return m_AbstractStereoCamera_instance;
        }

        // TODOC
        protected virtual void init(CameraDeviceInfo camera_device_info){}

        // TODOC
        public bool connect(){
            return AbstractStereoCamera_connect(m_AbstractStereoCamera_instance);
        }

        // TODOC
        public bool startCapture(){
            return AbstractStereoCamera_startCapture(m_AbstractStereoCamera_instance);
        }  

        // TODOC
        public void stopCapture(){
            AbstractStereoCamera_stopCapture(m_AbstractStereoCamera_instance);
        }

        // TODOC
        public bool isCapturing(){
            return AbstractStereoCamera_isCapturing(m_AbstractStereoCamera_instance);
        }

        // TODOC
        public bool isConnected(){
            return AbstractStereoCamera_isConnected(m_AbstractStereoCamera_instance);
        }

        // TODOC
        public int getWidth(){
            return AbstractStereoCamera_getWidth(m_AbstractStereoCamera_instance);
        }

        // TODOC
        public int getHeight(){
            return AbstractStereoCamera_getHeight(m_AbstractStereoCamera_instance); ;
        }

        // TODOC
        public float getFrameRate(){
            return AbstractStereoCamera_getFrameRate(m_AbstractStereoCamera_instance);
        }

        // TODOC
        public void setTestImagePaths(string left_test_image_path, string right_test_image_path){
            AbstractStereoCamera_setTestImagePaths(m_AbstractStereoCamera_instance, left_test_image_path, right_test_image_path);
        }

        // TODOC
        public CameraReadResult read(int timeout = 1000)
        {
            int image_size = getWidth() * getHeight();
            if (left_image == null){
                left_image = new byte[image_size * 3];
            }
            if (right_image == null){
                right_image = new byte[image_size * 3];
            }
            bool valid = AbstractStereoCamera_read(
                m_AbstractStereoCamera_instance, timeout,
                left_image, right_image
            );
            return new CameraReadResult(valid, left_image, right_image);
        }

        // TODOC
        public void startReadThread(int timeout = 1000){
            AbstractStereoCamera_startReadThread(m_AbstractStereoCamera_instance, timeout);
        }

        // TODOC
        public bool isReadThreadRunning(){
            return AbstractStereoCamera_isReadThreadRunning(m_AbstractStereoCamera_instance);
        }

        // TODOC
        public CameraReadResult getReadThreadResult()
        {
            int image_size = getWidth() * getHeight();
            if (left_image == null){
                left_image = new byte[image_size * 3];
            }
            if (right_image == null){
                right_image = new byte[image_size * 3];
            }
            bool valid = AbstractStereoCamera_getReadThreadResult(
                m_AbstractStereoCamera_instance,
                left_image, right_image
            );
            return new CameraReadResult(valid, left_image, right_image);
        }

        // TODOC
        public void setDownsampleFactor(float value){
            AbstractStereoCamera_setDownsampleFactor(m_AbstractStereoCamera_instance, value);
        }

        // TODOC
        public void setExposure(int value){
            AbstractStereoCamera_setExposure(m_AbstractStereoCamera_instance, value);
        }

        // TODOC
        public void setFrameRate(float value){
            AbstractStereoCamera_setFrameRate(m_AbstractStereoCamera_instance, value);
        }

        // TODOC
        public void enableHardwareTrigger(bool enable){
            AbstractStereoCamera_enableHardwareTrigger(m_AbstractStereoCamera_instance, enable);
        }

        // TODOC
        public void setLeftAOI(int x_min, int y_min, int x_max, int y_max){
            AbstractStereoCamera_setLeftAOI(m_AbstractStereoCamera_instance, x_min, y_min, x_max, y_max);
        }

        // TODOC
        public void setRightAOI(int x_min, int y_min, int x_max, int y_max){
            AbstractStereoCamera_setRightAOI(m_AbstractStereoCamera_instance, x_min, y_min, x_max, y_max);
        }

        // TODOC
        public void disconnect(){
            AbstractStereoCamera_disconnect(m_AbstractStereoCamera_instance);
        }

        // TODOC
        public void markDisposed()
        {
            m_AbstractStereoCamera_instance = IntPtr.Zero;
        }

        // TODOC
        // [HandleProcessCorruptedStateExceptions]
        public void dispose(){
            if (m_AbstractStereoCamera_instance != IntPtr.Zero){
                try
                {
                    AbstractStereoCamera_dispose(m_AbstractStereoCamera_instance);
                }
                catch (AccessViolationException e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine("Please call 'dispose()' to make sure library memory is freed.");
                }
                m_AbstractStereoCamera_instance = IntPtr.Zero;
            }
        }

        // TODOC
        ~AbstractStereoCamera()
        {
            dispose();
        }
    }
}