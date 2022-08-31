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
using I3DR.Phase.Types;
using I3DR.CPhase.Calib;

namespace I3DR.Phase.Calib
{
    //!  CameraSelection enum
    /*!
    Enum to indicate left or right camera/image
    */
    public enum CameraSelection { 
        LEFT, //!< Left camera/image
        RIGHT //!< Right camera/image
    };

    //!  Stereo Camera Calibration class
    /*!
    Store and manipulate stereo camera calibration data.
    */
    public class StereoCameraCalibration
    {
        private IntPtr m_StereoCameraCalibration_instance; //!< pointer to StereoCameraCalibration C API instance
        private CameraCalibration m_LeftCameraCalibration; //!< left CameraCalibration instance
        private CameraCalibration m_RightCameraCalibration; //!< right CameraCalibration instance
        private byte[] left_rect_image; //!< stores rectified left image
        private byte[] right_rect_image; //!< stores rectified right image
        private float[] Q; //!< stores Q matrix

        /*!
        * Initalise class using C API class instance reference
        * 
        * @IntPtr stereoCameraCalibration_instance
        */
        public StereoCameraCalibration(IntPtr stereoCameraCalibration_instance){
            m_StereoCameraCalibration_instance = stereoCameraCalibration_instance;
            m_LeftCameraCalibration = new CameraCalibration(
                CStereoCameraCalibration.getLeftCalibration(m_StereoCameraCalibration_instance));
            m_RightCameraCalibration = new CameraCalibration(
                CStereoCameraCalibration.getRightCalibration(m_StereoCameraCalibration_instance));
        }

        /*!
        * Get C API instance reference
        * 
        */
        public IntPtr getInstancePtr(){
            return m_StereoCameraCalibration_instance;
        }

        /*!
        * Load stereo camera calibration from YAML files
        * 
        * @param left_calibration_filepath left camera calibration filepath
        * @param right_calibration_filepath right camera calibration filepath
        * @returns stereo camera calibration
        */
        public static StereoCameraCalibration calibrationFromYAML(string left_yaml_filepath, string right_yaml_filepath){
            return new StereoCameraCalibration(CStereoCameraCalibration.calibrationFromYAML(left_yaml_filepath, right_yaml_filepath));
        }

        /*!
        * Create ideal stereo calibration from camera information
        * 
        * @param width image width of cameras
        * @param height image height of cameras
        * @param pixel_pitch pixel pitch of cameras
        * @param focal_length focal length of cameras
        * @param baseline baseline of stereo camera
        * @returns stereo camera calibration
        */
        public static StereoCameraCalibration calibrationFromIdeal(int width, int height, double pixel_pitch, double focal_length, double baseline){
            return new StereoCameraCalibration(CStereoCameraCalibration.calibrationFromIdeal(width, height, pixel_pitch, focal_length, baseline));
        }

        /*!
        * Load stereo camera calibration from collection of images taken with calibration board
        * 
        * @param left_cal_folder path to folder with left calibration images
        * @param right_cal_folder path to folder with right calibration images
        * @param left_img_wildcard wildcard to use for identifying left images
        * @param right_img_wildcard wildcard to use for identifying right images
        * @param board_type calibration board type used in calibration images
        * @param pattern_size_x number of rows in calibration board pattern
        * @param pattern_size_y number of columns in calibration board pattern
        * @param square_size width of single square in calibration board pattern (in meters)
        * @returns stereo camera calibration
        */
        public static StereoCameraCalibration calibrationFromImages(
                string left_cal_folder, string right_cal_folder,
                string left_img_wildcard, string right_img_wildcard,
                CalibrationBoardType board_type, int pattern_size_x, int pattern_size_y, double square_size){
            return new StereoCameraCalibration(CStereoCameraCalibration.calibrationFromImages(
                left_cal_folder, right_cal_folder, left_img_wildcard, right_img_wildcard,
                board_type, pattern_size_x, pattern_size_y, square_size));
        }

        /*!
        * Check if loaded calibration is valid
        * 
        * @returns true if valid calibration
        */
        public bool isValid(){
            return CStereoCameraCalibration.isValid(m_StereoCameraCalibration_instance);
        }

        /*!
        * Check if loaded calibration image width and height match specified values
        * 
        * @param width image width to check against
        * @param height image height to check against
        * @returns true if calibration size matches specified values
        */
        public bool isValidSize(int width, int height){
            return CStereoCameraCalibration.isValidSize(m_StereoCameraCalibration_instance, width, height);
        }

        /*!
        * Get left camera calibration
        * 
        * @params cameraCalibration camera calibration to store left camera calibration
        */
        public void getLeftCalibration(out CameraCalibration cameraCalibration){
            cameraCalibration = m_LeftCameraCalibration;
        }

        /*!
        * Get right camera calibration
        * 
        * @params cameraCalibration camera calibration to store right camera calibration
        */
        public void getRightCalibration(out CameraCalibration cameraCalibration){
            cameraCalibration = m_RightCameraCalibration;
        }

        /*!
        * Get camera horizontal field of view
        * 
        * @returns horizontal field of view
        */
        public float getHFOV(){
            return CStereoCameraCalibration.getHFOV(m_StereoCameraCalibration_instance);
        }

        /*!
        * Get stereo camera baseline
        * 
        * @returns baseline
        */
        public double getBaseline(){
            return CStereoCameraCalibration.getBaseline(m_StereoCameraCalibration_instance);
        }

        /*!
        * Get downsample factor
        * 
        * @returns downsample factor value
        */
        public float getDownsampleFactor(){
            return CStereoCameraCalibration.getDownsampleFactor(m_StereoCameraCalibration_instance);
        }

        /*!
        * Set downsample factor for calibration
        * 
        * @param value value of downsample factor
        */
        public void setDownsampleFactor(float value){
            CStereoCameraCalibration.setDownsampleFactor(m_StereoCameraCalibration_instance, value);
        }

        /*!
        * Get calibration Q matrix (4 x 4)
        * 
        * @returns Q matrix
        */
        public float[] getQ(){
            Q = new float[4*4];
            CStereoCameraCalibration.getQ(m_StereoCameraCalibration_instance, Q);
            return Q;
        }

        /*!
        * Rectify stereo images based on calibration
        * 
        * @param left_image left image to rectify
        * @param right_image right image to rectify
        * @param width image width
        * @param height image height
        * @returns rectified stereo image pair
        */
        public StereoImagePair rectify(byte[] left_image, byte[] right_image, int width, int height){
            left_rect_image = new byte[width * height * 3];
            right_rect_image = new byte[width * height * 3];
            CStereoCameraCalibration.rectify(
                m_StereoCameraCalibration_instance,
                left_image, right_image,
                width, height,
                left_rect_image, right_rect_image
            );
            return new StereoImagePair(left_rect_image, right_rect_image);
        }

        /*!
        * Save stereo camera calibration to YAML files
        * 
        * @param left_calibration_filepath left camera calibration filepath
        * @param right_calibration_filepath right camera calibration filepath
        * @param cal_file_type file type to save calibration as (ROS YAML or OpenCV YAML)
        * @returns success of saving calibration
        */
        public bool saveToYAML(string left_calibration_filepath, string right_calibration_filepath, CalibrationFileType cal_file_type = CalibrationFileType.ROS_YAML){
            return CStereoCameraCalibration.saveToYAML(
                m_StereoCameraCalibration_instance,
                left_calibration_filepath, right_calibration_filepath,
                cal_file_type
            );
        }

        /*!
        * Remove C API instance reference
        * 
        */
        public void markDisposed()
        {
            m_StereoCameraCalibration_instance = IntPtr.Zero;
        }

        /*!
        * Manually dispose instance of RGBD Video Writer class
        * 
        */
        // [HandleProcessCorruptedStateExceptions]
        public void dispose(){
            if (m_StereoCameraCalibration_instance != IntPtr.Zero){
                try {
                    CStereoCameraCalibration.dispose(m_StereoCameraCalibration_instance);
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