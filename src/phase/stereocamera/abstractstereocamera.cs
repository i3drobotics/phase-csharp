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
using I3DR.CPhase;

namespace I3DR.Phase
{

    //!  Camera Read Result structure
    /*!
    Struture to store the result from reading a camera frame. Used in the stereo camera classes.
    */
    public struct CameraReadResult
    {
        public bool valid; //!< true if camera read was successful
        public byte[] left; //!< left camera image
        public byte[] right; //!< right camera image

        public CameraReadResult(bool valid, byte[] left, byte[] right)
        {
            this.valid = valid;
            this.left = left;
            this.right = right;
        }
    }

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

        protected IntPtr m_AbstractStereoCamera_instance; //!< pointer to AbstractStereoCamera C API instance
        private byte[] left_image; //!< store left image
        private byte[] right_image; //!< store right image
        
        /*!
        * AbstractStereoCamera constructor \n
        * Initalise Abstract Stereo Camera with the given \p device_info.
        * 
        * @param camera_device_info camera device information
        */
        public AbstractStereoCamera(CameraDeviceInfo camera_device_info){
            init(camera_device_info);
        }

        /*!
        * Initalise class using C API class instance reference
        * 
        * @IntPtr stereoCameraCalibration_instance
        */
        public AbstractStereoCamera(IntPtr abstractStereoCamera_instance){
            m_AbstractStereoCamera_instance = abstractStereoCamera_instance;
        }

        /*!
        * Get C API instance reference
        * 
        */
        public IntPtr getInstancePtr(){
            return m_AbstractStereoCamera_instance;
        }

        /*!
        * Initalise stereo matcher
        * Should be implemented in derived classes.
        * 
        */
        protected virtual void init(CameraDeviceInfo camera_device_info){}

        /*!
        * Connect to camera \n
        * Must be implemented by child class
        * 
        * @returns true if connected successfully
        */
        public bool connect(){
            return AbstractStereoCamera_connect(m_AbstractStereoCamera_instance);
        }

        /*!
        * Start stereo camera capture \n
        * Must be started before read() is called \n
        * Must be implemented by child class
        * 
        * @return success of capture start
        */
        public bool startCapture(){
            return AbstractStereoCamera_startCapture(m_AbstractStereoCamera_instance);
        }  

        /*!
        * Stop stereo camera capture \n
        * Will no longer be able to read() after this is called \n
        * Must be implemented by child class
        */
        public void stopCapture(){
            AbstractStereoCamera_stopCapture(m_AbstractStereoCamera_instance);
        }

        /*!
        * Check if stereo camera capture has been started \n
        * Must be implemented by child class
        * 
        * @return status of camera capture
        */
        public bool isCapturing(){
            return AbstractStereoCamera_isCapturing(m_AbstractStereoCamera_instance);
        }

        /*!
        * Check if camera is connected \n
        * Must be implemented by child class
        * 
        * @returns true if connected
        */
        public bool isConnected(){
            return AbstractStereoCamera_isConnected(m_AbstractStereoCamera_instance);
        }

        /*!
        * Get camera image width
        * 
        * @return camera image width
        */
        public int getWidth(){
            return AbstractStereoCamera_getWidth(m_AbstractStereoCamera_instance);
        }

        /*!
        * Get camera image height
        * 
        * @return camera image height
        */
        public int getHeight(){
            return AbstractStereoCamera_getHeight(m_AbstractStereoCamera_instance); ;
        }

        /*!
        * Get frame rate of camera \n
        * Must be implemented by child class
        * 
        * @return frame rate of camera
        */
        public float getFrameRate(){
            return AbstractStereoCamera_getFrameRate(m_AbstractStereoCamera_instance);
        }

        /*!
        * Set filepath of images to use as test images \n
        * Only used by virtual stereo cameras \n
        * Can be useful when testing
        * 
        * @param left_test_image_path filepath to left test image
        * @param right_test_image_path filepath to right test image
        */
        public void setTestImagePaths(string left_test_image_path, string right_test_image_path){
            AbstractStereoCamera_setTestImagePaths(m_AbstractStereoCamera_instance, left_test_image_path, right_test_image_path);
        }

        /*!
        * Read frame from camera
        *
        * @param timeout timeout to wait for frame before returning failure
        * @return read result from camera
        */
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

        /*!
        * Start threaded process to read stereo images from cameras \n
        * Use getReadThreadResult() to get results of process.
        * 
        * @param timeout timeout for camera data capture
        */
        public void startReadThread(int timeout = 1000){
            AbstractStereoCamera_startReadThread(m_AbstractStereoCamera_instance, timeout);
        }

        /*!
        * Check if read thread is running \n
        * Should be used with startReadThread()
        * 
        * @return read thread running status
        */
        public bool isReadThreadRunning(){
            return AbstractStereoCamera_isReadThreadRunning(m_AbstractStereoCamera_instance);
        }

        /*!
        * Get results from threaded read process \n
        * Should be used with startReadThread()
        * 
        * @return results from read process
        */
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

        /*!
        * Set downsample factor \n
        * This is applied to image and stereo processing
        * 
        * @param value downsample factor value
        */
        public void setDownsampleFactor(float value){
            AbstractStereoCamera_setDownsampleFactor(m_AbstractStereoCamera_instance, value);
        }

        /*!
        * Set exposure time of camera \n
        * Must be implemented by child class
        * 
        * @param value exposure value in microseconds
        */
        public void setExposure(int value){
            AbstractStereoCamera_setExposure(m_AbstractStereoCamera_instance, value);
        }

        /*!
        * Set frame rate of camera \n
        * Must be implemented by child class
        * 
        * @param value frame rate in frames per second
        */
        public void setFrameRate(float value){
            AbstractStereoCamera_setFrameRate(m_AbstractStereoCamera_instance, value);
        }

        /*!
        * Enable/disable hardware triggering \n
        * Must be implemented by child class
        * 
        * @param enable toggle hardware triggering
        */
        public void enableHardwareTrigger(bool enable){
            AbstractStereoCamera_enableHardwareTrigger(m_AbstractStereoCamera_instance, enable);
        }

        /*!
        * Set area of interest of left camera \n
        * Must be implemented by child class
        * 
        * @param x_min x coordinate of top left corner of area of interest
        * @param y_min y coordinate of top left corner of area of interest
        * @param x_max x coordinate of bottom right corner of area of interest
        * @param y_max y coordinate of bottom right corner of area of interest
        */
        public void setLeftAOI(int x_min, int y_min, int x_max, int y_max){
            AbstractStereoCamera_setLeftAOI(m_AbstractStereoCamera_instance, x_min, y_min, x_max, y_max);
        }

        /*!
        * Set area of interest of right camera \n
        * Must be implemented by child class
        *
        * @param x_min x coordinate of top left corner of area of interest
        * @param y_min y coordinate of top left corner of area of interest
        * @param x_max x coordinate of bottom right corner of area of interest
        * @param y_max y coordinate of bottom right corner of area of interest
        */
        public void setRightAOI(int x_min, int y_min, int x_max, int y_max){
            AbstractStereoCamera_setRightAOI(m_AbstractStereoCamera_instance, x_min, y_min, x_max, y_max);
        }

        /*!
        * Disconnect from stereo camera \n
        * Must be implemented by child class
        * 
        */
        public void disconnect(){
            AbstractStereoCamera_disconnect(m_AbstractStereoCamera_instance);
        }

        /*!
        * Remove C API instance reference
        * 
        */
        public void markDisposed()
        {
            m_AbstractStereoCamera_instance = IntPtr.Zero;
        }

        /*!
        * Manually dispose instance of RGBD Video Writer class
        * 
        */
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

        ~AbstractStereoCamera()
        {
            dispose();
        }
    }
}