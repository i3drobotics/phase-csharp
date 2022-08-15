/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file stereovision.cs
 * @brief Stereo Vision class
 * @details Capture and process images from stereo cameras.
 */

using System;
using System.Runtime.InteropServices;
using System.Runtime.ExceptionServices;

namespace I3DR.Phase
{
    //!  Stereo Vision class
    /*!
    Capture images from stereo camera and process with stereo matcher
    to generate depth. Brings together Stereo Camera and Stereo Matcher classes into
    single class for easy use.
    */
    public class StereoVision
    {
        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoVision_create", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr StereoVision_create(
            string left_serial, string right_serial, string unique_serial,
            CameraDeviceType device_type, CameraInterfaceType interface_type, StereoMatcherType matcher_type,
            string left_yaml, string right_yaml);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoVision_CGetCamera", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr StereoVision_getCamera(IntPtr sv);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoVision_CGetMatcher", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr StereoVision_getMatcher(IntPtr sv);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoVision_CGetCalibration", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr StereoVision_getCalibration(IntPtr sv);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoVision_CConnect", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool StereoVision_connect(IntPtr sv);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoVision_CIsConnected", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool StereoVision_isConnected(IntPtr sv);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoVision_CStartCapture", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool StereoVision_startCapture(IntPtr sv);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoVision_CStopCapture", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StereoVision_stopCapture(IntPtr sv);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoVision_CIsCapturing", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool StereoVision_isCapturing(IntPtr sv);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoVision_CIsValidCalibration", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool StereoVision_isValidCalibration(IntPtr sv);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoVision_CGetWidth", CallingConvention = CallingConvention.Cdecl)]
        private static extern int StereoVision_getWidth(IntPtr sv);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoVision_CGetHeight", CallingConvention = CallingConvention.Cdecl)]
        private static extern int StereoVision_getHeight(IntPtr sv);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoVision_CGetHFOV", CallingConvention = CallingConvention.Cdecl)]
        private static extern float StereoVision_getHFOV(IntPtr sv);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoVision_CGetDownsampleFactor", CallingConvention = CallingConvention.Cdecl)]
        private static extern float StereoVision_getDownsampleFactor(IntPtr sv);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoVision_CSetDownsampleFactor", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StereoVision_setDownsampleFactor(IntPtr sv, float value);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoVision_CSetTestImagePaths", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StereoVision_setTestImagePaths(IntPtr cam, string left_test_image_path, string right_test_image_path);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoVision_CRead", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool StereoVision_read(
            IntPtr sv, int timeout, bool rectify, [Out] byte[] left_image, [Out] byte[] right_image, [Out] float[] disparity);
        
        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoVision_CStartReadThread", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StereoVision_startReadThread(IntPtr sv, int timeout, bool rectify);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoVision_CIsReadThreadRunning", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool StereoVision_isReadThreadRunning(IntPtr sv);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoVision_CGetReadThreadResult", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool StereoVision_getReadThreadResult(
            IntPtr sv, [Out] byte[] left_image, [Out] byte[] right_image, [Out] float[] disparity);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoVision_CDisconnect", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StereoVision_disconnect(IntPtr sv);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_StereoVision_dispose", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StereoVision_dispose(IntPtr sv);

        private IntPtr m_StereoVision_instance; //!< pointer to StereoVision C API instance
        private byte[] left_image; //!< stores left image data
        private byte[] right_image; //!< stores right image data
        private float[] disparity; //!< stores disparity data
        private AbstractStereoCamera m_abstractStereoCamera; //!< instance of stereo camera
        private AbstractStereoMatcher m_abstractStereoMatcher; //!< instance of stereo matcher
        private StereoCameraCalibration m_stereoCameraCalibration; //!< instance of stereo camera calibration

        /*!
        * Stereo Vision constructor \n
        * Initalise Stereo Vision class using provided camera and matcher information
        * as well as loading the calibration from provided calibration files.
        * 
        * @param camera_device_info camera device info
        * @param stereo_matcher_type stereo matcher type
        * @param left_yaml filepath to left calibration yaml file
        * @param right_yaml filepath to right calibration yaml file
        */
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

        /*!
        * Get instance of stereo camera class created by Stereo Vision class \n
        * Can be used to access camera specific functions
        * 
        * @param abstractStereoCamera overridden with instance of stereo camera
        */
        public void getCamera(out AbstractStereoCamera abstractStereoCamera){
            abstractStereoCamera = m_abstractStereoCamera;
        }

        /*!
        * Get instance of stereo matcher class created by Stereo Vision class \n
        * Can be used to access matcher specific functions
        * 
        * @param abstractStereoMatcher overridden with instance of stereo matcher
        */
        public void getMatcher(out AbstractStereoMatcher abstractStereoMatcher){
            abstractStereoMatcher = m_abstractStereoMatcher;
        }

        /*!
        * Get instance of stereo calibration class created by Stereo Vision class \n
        * Can be used to access calibration specific functions
        * 
        * @param stereoCameraCalibration overridden with instance of stereo camera calibration
        */
        public void getCalibration(out StereoCameraCalibration stereoCameraCalibration){
            stereoCameraCalibration = m_stereoCameraCalibration;
        }

        /*!
        * Connect to stereo camera
        * 
        * @return success of connection
        */
        public bool connect(){
            bool success = StereoVision_connect(m_StereoVision_instance);
            return success;
        }

        /*!
        * Check if stereo camera is connected
        * 
        * @return status of connection
        */
        public bool isConnected(){
            return StereoVision_isConnected(m_StereoVision_instance);
        }

        /*!
        * Start stereo camera capture \n
        * Must be started before read() is called
        * 
        * @return success of capture start
        */
        public bool startCapture(){
            return StereoVision_startCapture(m_StereoVision_instance);
        }

        /*!
        * Stop stereo camera capture \n
        * Will no longer be able to read() after this is called
        */
        public void stopCapture(){
            StereoVision_stopCapture(m_StereoVision_instance);
        }

        /*!
        * Check if stereo camera capture has been started
        * 
        * @return status of camera capture
        */
        public bool isCapturing(){
            return StereoVision_isCapturing(m_StereoVision_instance);
        }

        /*!
        * Check calibration provided is valid
        * 
        * @return valid status of calibration
        */
        public bool isValidCalibration(){
            return StereoVision_isValidCalibration(m_StereoVision_instance);
        }

        /*!
        * Get image width of stereo camera
        * 
        * @return image width
        */
        public int getWidth(){
            return StereoVision_getWidth(m_StereoVision_instance);
        }

        /*!
        * Get image height of stereo camera
        * 
        * @return image height
        */
        public int getHeight(){
            return StereoVision_getHeight(m_StereoVision_instance);
        }

        /*!
        * Get horizontal field of view of stereo camera
        * 
        * @return horizontal field of view
        */
        public float getHFOV(){
            return StereoVision_getHFOV(m_StereoVision_instance);
        }

        /*!
        * Get current downsample factor
        * 
        * @return downsample factor
        */
        public float getDownsampleFactor(){
            return StereoVision_getDownsampleFactor(m_StereoVision_instance);
        }

        /*!
        * Set downsample factor \n
        * This is applied to image and stereo processing
        * 
        * @param value downsample factor value
        */
        public void setDownsampleFactor(float value){
            StereoVision_setDownsampleFactor(m_StereoVision_instance, value);
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
            StereoVision_setTestImagePaths(m_StereoVision_instance, left_test_image_path, right_test_image_path);
        }

        /*!
        * Read stereo data from cameras and generate 3D results
        * 
        * @param timeout timeout for camera data capture
        * @param rectify toggle if the process should rectify the stereo images
        * @return results from data capture and processing
        */
        public StereoVisionReadResult read(int timeout = 1000, bool rectify = true)
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
                m_StereoVision_instance, timeout, rectify,
                left_image, right_image, disparity
            );
            StereoVisionReadResult readResult = new StereoVisionReadResult(valid, left_image, right_image, disparity);
            return readResult;
        }

        /*!
        * Start threaded process to read stereo data from cameras and generate 3D results \n
        * Use getReadThreadResult() to get results of process.
        * 
        * @param timeout timeout for camera data capture
        * @param rectify toggle if the process should rectify the stereo images
        */
        public void startReadThread(int timeout = 1000, bool rectify = true){
            StereoVision_startReadThread(m_StereoVision_instance, timeout, rectify);
        }

        /*!
        * Check if read thread is running \n
        * Should be used with startReadThread()
        * 
        * @return read thread running status
        */
        public bool isReadThreadRunning(){
            return StereoVision_isReadThreadRunning(m_StereoVision_instance);
        }

        /*!
        * Get results from threaded read process \n
        * Should be used with startReadThread()
        * 
        * @return results from read process
        */
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

        /*!
        * Disconnect from stereo camera
        * 
        */
        public void disconnect(){
            StereoVision_disconnect(m_StereoVision_instance);
        }

        /*!
        * Manually dispose instance of Stereo Vision class
        * 
        */
        // [HandleProcessCorruptedStateExceptions]
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