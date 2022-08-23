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
            return CAbstractStereoCamera.connect(m_AbstractStereoCamera_instance);
        }

        /*!
        * Start stereo camera capture \n
        * Must be started before read() is called \n
        * Must be implemented by child class
        * 
        * @return success of capture start
        */
        public bool startCapture(){
            return CAbstractStereoCamera.startCapture(m_AbstractStereoCamera_instance);
        }  

        /*!
        * Stop stereo camera capture \n
        * Will no longer be able to read() after this is called \n
        * Must be implemented by child class
        */
        public void stopCapture(){
            CAbstractStereoCamera.stopCapture(m_AbstractStereoCamera_instance);
        }

        /*!
        * Check if stereo camera capture has been started \n
        * Must be implemented by child class
        * 
        * @return status of camera capture
        */
        public bool isCapturing(){
            return CAbstractStereoCamera.isCapturing(m_AbstractStereoCamera_instance);
        }

        /*!
        * Check if camera is connected \n
        * Must be implemented by child class
        * 
        * @returns true if connected
        */
        public bool isConnected(){
            return CAbstractStereoCamera.isConnected(m_AbstractStereoCamera_instance);
        }

        /*!
        * Get camera image width
        * 
        * @return camera image width
        */
        public int getWidth(){
            return CAbstractStereoCamera.getWidth(m_AbstractStereoCamera_instance);
        }

        /*!
        * Get camera image height
        * 
        * @return camera image height
        */
        public int getHeight(){
            return CAbstractStereoCamera.getHeight(m_AbstractStereoCamera_instance); ;
        }

        /*!
        * Get frame rate of camera \n
        * Must be implemented by child class
        * 
        * @return frame rate of camera
        */
        public float getFrameRate(){
            return CAbstractStereoCamera.getFrameRate(m_AbstractStereoCamera_instance);
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
            CAbstractStereoCamera.setTestImagePaths(m_AbstractStereoCamera_instance, left_test_image_path, right_test_image_path);
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
            bool valid = CAbstractStereoCamera.read(
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
            CAbstractStereoCamera.startReadThread(m_AbstractStereoCamera_instance, timeout);
        }

        /*!
        * Check if read thread is running \n
        * Should be used with startReadThread()
        * 
        * @return read thread running status
        */
        public bool isReadThreadRunning(){
            return CAbstractStereoCamera.isReadThreadRunning(m_AbstractStereoCamera_instance);
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
            bool valid = CAbstractStereoCamera.getReadThreadResult(
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
            CAbstractStereoCamera.setDownsampleFactor(m_AbstractStereoCamera_instance, value);
        }

        /*!
        * Set exposure time of camera \n
        * Must be implemented by child class
        * 
        * @param value exposure value in microseconds
        */
        public void setExposure(int value){
            CAbstractStereoCamera.setExposure(m_AbstractStereoCamera_instance, value);
        }

        /*!
        * Set frame rate of camera \n
        * Must be implemented by child class
        * 
        * @param value frame rate in frames per second
        */
        public void setFrameRate(float value){
            CAbstractStereoCamera.setFrameRate(m_AbstractStereoCamera_instance, value);
        }

        /*!
        * Enable/disable hardware triggering \n
        * Must be implemented by child class
        * 
        * @param enable toggle hardware triggering
        */
        public void enableHardwareTrigger(bool enable){
            CAbstractStereoCamera.enableHardwareTrigger(m_AbstractStereoCamera_instance, enable);
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
            CAbstractStereoCamera.setLeftAOI(m_AbstractStereoCamera_instance, x_min, y_min, x_max, y_max);
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
            CAbstractStereoCamera.setRightAOI(m_AbstractStereoCamera_instance, x_min, y_min, x_max, y_max);
        }

        /*!
        * Disconnect from stereo camera \n
        * Must be implemented by child class
        * 
        */
        public void disconnect(){
            CAbstractStereoCamera.disconnect(m_AbstractStereoCamera_instance);
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
                    CAbstractStereoCamera.dispose(m_AbstractStereoCamera_instance);
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