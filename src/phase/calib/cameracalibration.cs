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
using I3DR.CPhase;

namespace I3DR.Phase
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

        /*!
        * Initalise class using C API class instance reference
        * 
        * @IntPtr cameraCalibration_instance
        */
        public CameraCalibration(IntPtr cameraCalibration_instance){
            m_CameraCalibration_instance = cameraCalibration_instance;
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
        public void rectify(byte[] image, int width, int height, out byte[] rect_image){
            rect_image = new byte[width * height * 3];
            CCameraCalibration.rectify(
                m_CameraCalibration_instance,
                image,
                width, height,
                rect_image
            );
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