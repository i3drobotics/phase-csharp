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
using I3DR.CPhase.Calib;

namespace I3DR.Phase.Calib
{
    //!  Calibration File Type enum
    /*!
    Enum to indicate calibration file type. OpenCV uses different YAML standard from ROS.
    */
    public enum CalibrationFileType { 
        ROS_YAML,
        OPENCV_YAML,
        INVALID
    };

    //!  Camera Calibration class
    /*!
    Store and manipulate camera calibration data.
    */
    public class CameraCalibration
    {
        private IntPtr m_CameraCalibration_instance; //!< pointer to CameraCalibration C API instance
        private double[] cam_mat; //!< stores camera matrix
        private double[] dist_coef; //!< stores distortion coefficients
        private double[] rect_mat; //!< stores rectification matrix
        private double[] proj_mat; //!< stores projection matrix

        /*!
        * Initalise class using C API class instance reference
        * 
        * @IntPtr cameraCalibration_instance
        */
        public CameraCalibration(IntPtr cameraCalibration_instance){
            m_CameraCalibration_instance = cameraCalibration_instance;
        }

        /*!
        * Initalise class using C API class instance reference
        * 
        * @IntPtr cameraCalibration_instance
        */
        public CameraCalibration(string yaml_filepath){
            m_CameraCalibration_instance = CCameraCalibration.create(yaml_filepath);
        }

        /*!
        * Get C API instance reference
        * 
        */
        public IntPtr getInstancePtr(){
            return m_CameraCalibration_instance;
        }

        /*!
        * Create ideal calibration from camera information
        * 
        * @param width image width of camera
        * @param height image height of camera
        * @param pixel_pitch pixel pitch of camera
        * @param focal_length focal length of camera
        * @param translation_x translation of principle point in X
        * @param translation_y translation of principle point in Y
        */
        public static CameraCalibration calibrationFromIdeal(int width, int height, double pixel_pitch, double focal_length, double translation_x, double translation_y){
            return new CameraCalibration(CCameraCalibration.calibrationFromIdeal(width, height, pixel_pitch, focal_length, translation_x, translation_y));
        }

        /*!
        * Check if loaded calibration is valid
        * 
        * @returns true if valid calibration
        */
        public bool isValid(){
            return CCameraCalibration.isValid(m_CameraCalibration_instance);
        }

        /*!
        * Get camera image width in calibration
        * 
        * @returns camera image width
        */
        public int getImageWidth(){
            return CCameraCalibration.getImageWidth(m_CameraCalibration_instance);
        }

        /*!
        * Get camera image height in calibration
        * 
        * @returns camera image height
        */
        public int getImageHeight(){
            return CCameraCalibration.getImageHeight(m_CameraCalibration_instance);
        }

        /*!
        * Get camera focal length in X in calibration (in pixels)
        * 
        * @returns focal length in X
        */
        public double getCameraFX(){
            return CCameraCalibration.getCameraFX(m_CameraCalibration_instance);
        }

        /*!
        * Get camera focal length in Y in calibration (in pixels)
        * 
        * @returns focal length in Y
        */
        public double getCameraFY(){
            return CCameraCalibration.getCameraFY(m_CameraCalibration_instance);
        }

        /*!
        * Get camera principle point in X in calibration (in pixels)
        * 
        * @returns principle point in X
        */
        public double getCameraCX(){
            return CCameraCalibration.getCameraCX(m_CameraCalibration_instance);
        }

        /*!
        * Get camera principle point in Y in calibration (in pixels)
        * 
        * @returns principle point in Y
        */
        public double getCameraCY(){
            return CCameraCalibration.getCameraCY(m_CameraCalibration_instance);
        }

        /*!
        * Get camera focal length in X in calibration projection (in pixels)
        * 
        * @returns focal length in X
        */
        public double getProjectionFX(){
            return CCameraCalibration.getProjectionFX(m_CameraCalibration_instance);
        }

        /*!
        * Get camera focal length in Y in calibration projection (in pixels)
        * 
        * @returns focal length in Y
        */
        public double getProjectionFY(){
            return CCameraCalibration.getProjectionFY(m_CameraCalibration_instance);
        }

        /*!
        * Get camera principle point in X in calibration projection (in pixels)
        * 
        * @returns principle point in X
        */
        public double getProjectionCX(){
            return CCameraCalibration.getProjectionCX(m_CameraCalibration_instance);
        }

        /*!
        * Get camera principle point in Y in calibration projection (in pixels)
        * 
        * @returns principle point in Y
        */
        public double getProjectionCY(){
            return CCameraCalibration.getProjectionCY(m_CameraCalibration_instance);
        }

        /*!
        * Get camera baseline in calibration projection (in pixels)
        * 
        * @returns baseline
        */
        public double getProjectionTX(){
            return CCameraCalibration.getProjectionTX(m_CameraCalibration_instance);
        }

        /*!
        * Get camera matrix from calibration
        * 
        * @returns camera matrix
        */
        public double[] getCameraMatrix(){
            cam_mat = new double[3*3];
            CCameraCalibration.getCameraMatrix(m_CameraCalibration_instance, cam_mat);
            return cam_mat;
        }

        /*!
        * Get distortion coefficients from calibration
        * 
        * @returns distortion coefficients
        */
        public double[] getDistortionCoefficients(){
            dist_coef = new double[1*5];
            CCameraCalibration.getDistortionCoefficients(m_CameraCalibration_instance, dist_coef);
            return dist_coef;
        }

        /*!
        * Get rectification matrix from calibration
        * 
        * @returns rectification matrix
        */
        public double[] getRectificationMatrix(){
            rect_mat = new double[3*3];
            CCameraCalibration.getRectificationMatrix(m_CameraCalibration_instance, rect_mat);
            return rect_mat;
        }

        /*!
        * Get projection matrix from calibration
        * 
        * @returns projection matrix
        */
        public double[] getProjectionMatrix(){
            proj_mat = new double[3*4];
            CCameraCalibration.getProjectionMatrix(m_CameraCalibration_instance, proj_mat);
            return proj_mat;
        }

        /*!
        * Get downsample factor
        * 
        * @returns downsample factor value
        */
        public float getDownsampleFactor(){
            return CCameraCalibration.getDownsampleFactor(m_CameraCalibration_instance);
        }

        /*!
        * Set downsample factor for calibration
        * 
        * @param value value of downsample factor
        */
        public void setDownsampleFactor(float value){
            CCameraCalibration.setDownsampleFactor(m_CameraCalibration_instance, value);
        }

        /*!
        * Rectify image based on calibration
        * 
        * @param image image to rectify
        * @param width image width
        * @param height image height
        * @returns rectified image
        */
        public byte[] rectify(byte[] image, int width, int height){
            byte[] rect_image = new byte[width * height * 3];
            CCameraCalibration.rectify(
                m_CameraCalibration_instance,
                image,
                width, height,
                rect_image
            );
            return rect_image;
        }

        /*!
        * Remove C API instance reference
        * 
        */
        public void markDisposed()
        {
            m_CameraCalibration_instance = IntPtr.Zero;
        }

        /*!
        * Manually dispose instance of RGBD Video Writer class
        * 
        */
        // [HandleProcessCorruptedStateExceptions]
        public void dispose(){
            if (m_CameraCalibration_instance != IntPtr.Zero){
                try {
                    CCameraCalibration.dispose(m_CameraCalibration_instance);
                }
                catch (AccessViolationException e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine("Please call 'dispose()' to make sure library memory is freed.");
                }
                m_CameraCalibration_instance = IntPtr.Zero;
            }
        }

        ~CameraCalibration()
        {
            dispose();
        }
    }
}