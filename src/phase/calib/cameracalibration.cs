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

    // TODO add camera calibration class
    // //!  Camera Calibration class
    // /*!
    // Store and manipulate camera calibration data.
    // */
    // public class CameraCalibration
    // {
    //     private IntPtr m_StereoCameraCalibration_instance; //!< pointer to StereoCameraCalibration C API instance
    //     private byte[] left_rect_image; //!< stores rectified left image
    //     private byte[] right_rect_image; //!< stores rectified right image
    //     private float[] Q; //!< stores Q matrix

    //     /*!
    //     * Initalise class using C API class instance reference
    //     * 
    //     * @IntPtr stereoCameraCalibration_instance
    //     */
    //     public StereoCameraCalibration(IntPtr stereoCameraCalibration_instance){
    //         m_StereoCameraCalibration_instance = stereoCameraCalibration_instance;
    //     }

    //     /*!
    //     * Get C API instance reference
    //     * 
    //     */
    //     public IntPtr getInstancePtr(){
    //         return m_StereoCameraCalibration_instance;
    //     }

    //     /*!
    //     * Load stereo camera calibration from YAML files
    //     * 
    //     * @param left_calibration_filepath left camera calibration filepath
    //     * @param right_calibration_filepath right camera calibration filepath
    //     * @returns stereo camera calibration
    //     */
    //     public static StereoCameraCalibration calibrationFromYAML(string left_yaml_filepath, string right_yaml_filepath){
    //         return new StereoCameraCalibration(CCalibrationFromYAML(left_yaml_filepath, right_yaml_filepath));
    //     }

    //     /*!
    //     * Create ideal stereo calibration from camera information
    //     * 
    //     * @param width image width of cameras
    //     * @param height image height of cameras
    //     * @param pixel_pitch pixel pitch of cameras
    //     * @param focal_length focal length of cameras
    //     * @param baseline baseline of stereo camera
    //     * @returns stereo camera calibration
    //     */
    //     public static StereoCameraCalibration calibrationFromIdeal(int width, int height, double pixel_pitch, double focal_length, double baseline){
    //         return new StereoCameraCalibration(CCalibrationFromIdeal(width, height, pixel_pitch, focal_length, baseline));
    //     }

    //     /*!
    //     * Check if loaded calibration is valid
    //     * 
    //     * @returns true if valid calibration
    //     */
    //     public bool isValid(){
    //         return CIsValid(m_StereoCameraCalibration_instance);
    //     }

    //     /*!
    //     * Check if loaded calibration image width and height match specified values
    //     * 
    //     * @param width image width to check against
    //     * @param height image height to check against
    //     * @returns true if calibration size matches specified values
    //     */
    //     public bool isValidSize(int width, int height){
    //         return CIsValidSize(m_StereoCameraCalibration_instance, width, height);
    //     }

    //     /*!
    //     * Get camera horizontal field of view
    //     * 
    //     * @returns horizontal field of view
    //     */
    //     public float getHFOV(){
    //         return CGetHFOV(m_StereoCameraCalibration_instance);
    //     }

    //     /*!
    //     * Get stereo camera baseline
    //     * 
    //     * @returns baseline
    //     */
    //     public double getBaseline(){
    //         return CGetBaseline(m_StereoCameraCalibration_instance);
    //     }

    //     /*!
    //     * Get downsample factor
    //     * 
    //     * @returns downsample factor value
    //     */
    //     public float getDownsampleFactor(){
    //         return CGetDownsampleFactor(m_StereoCameraCalibration_instance);
    //     }

    //     /*!
    //     * Get calibration Q matrix (4 x 4)
    //     * 
    //     * @returns Q matrix
    //     */
    //     public float[] getQ(){
    //         Q = new float[4*4];
    //         CGetQ(m_StereoCameraCalibration_instance, Q);
    //         return Q;
    //     }

    //     /*!
    //     * Set downsample factor for calibration
    //     * 
    //     * @param value value of downsample factor
    //     */
    //     public void setDownsampleFactor(float value){
    //         CSetDownsampleFactor(m_StereoCameraCalibration_instance, value);
    //     }

    //     /*!
    //     * Rectify stereo images based on calibration
    //     * 
    //     * @param left_image left image to rectify
    //     * @param right_image right image to rectify
    //     * @param width image width
    //     * @param height image height
    //     * @returns rectified stereo image pair
    //     */
    //     public StereoImagePair rectify(byte[] left_image, byte[] right_image, int width, int height){
    //         left_rect_image = new byte[width * height * 3];
    //         right_rect_image = new byte[width * height * 3];
    //         CRectify(
    //             m_StereoCameraCalibration_instance,
    //             left_image, right_image,
    //             width, height,
    //             left_rect_image, right_rect_image
    //         );
    //         return new StereoImagePair(left_rect_image, right_rect_image);
    //     }

    //     /*!
    //     * Save stereo camera calibration to YAML files
    //     * 
    //     * @param left_calibration_filepath left camera calibration filepath
    //     * @param right_calibration_filepath right camera calibration filepath
    //     * @param cal_file_type file type to save calibration as (ROS YAML or OpenCV YAML)
    //     * @returns success of saving calibration
    //     */
    //     public bool saveToYAML(string left_calibration_filepath, string right_calibration_filepath, CalibrationFileType cal_file_type = CalibrationFileType.ROS_YAML){
    //         return CSaveToYAML(
    //             m_StereoCameraCalibration_instance,
    //             left_calibration_filepath, right_calibration_filepath,
    //             cal_file_type
    //         );
    //     }

    //     /*!
    //     * Remove C API instance reference
    //     * 
    //     */
    //     public void markDisposed()
    //     {
    //         m_StereoCameraCalibration_instance = IntPtr.Zero;
    //     }

    //     /*!
    //     * Manually dispose instance of RGBD Video Writer class
    //     * 
    //     */
    //     // [HandleProcessCorruptedStateExceptions]
    //     public void dispose(){
    //         if (m_StereoCameraCalibration_instance != IntPtr.Zero){
    //             try {
    //                 StereoCameraCalibration_dispose(m_StereoCameraCalibration_instance);
    //             }
    //             catch (AccessViolationException e)
    //             {
    //                 Console.WriteLine(e);
    //                 Console.WriteLine("Please call 'dispose()' to make sure library memory is freed.");
    //             }
    //             m_StereoCameraCalibration_instance = IntPtr.Zero;
    //         }
    //     }

    //     ~StereoCameraCalibration()
    //     {
    //         dispose();
    //     }
    // }
}