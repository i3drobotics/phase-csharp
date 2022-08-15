/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-06-21
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file stereoprocess.cs
 * @brief Functions for running Phase with local files
 */

using System;
using System.Runtime.InteropServices;
using System.Runtime.ExceptionServices;

namespace I3DR.Phase
{
    //!  Stereo Process class
    /*!
    Functions for running Phase with local files
    */
    public class StereoProcess
    {
        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_ProcessStereoFiles")]
        private static extern bool CProcessStereoFiles(
            StereoParams stereo_params, string left_yaml, string right_yaml,
            string left_image_path, string right_image_path, string output_folder, bool rectify);
        
        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_ProcessStereo")]
        private static extern IntPtr CProcessStereo(
            StereoParams stereo_params, IntPtr left_image, IntPtr right_image,
            IntPtr calibration, bool rectify);

        /*!
        * Process stereo image files \n
        * Generate 3D data from stereo images and calibration files.
        * Output results to provided output folder. \n
        * Must have the same number of left and right images.
        *
        * @param stereo_params stereo matcher parameters
        * @param left_yaml filepath to left camera calibration yaml file
        * @param right_yaml filepath to right camera calibration yaml file
        * @param left_image_path filepath to folder with left image files
        * @param right_image_path filepath to folder with right image files
        * @param output_folder filepath to folder where output files will be saved
        * @param rectify toggle to rectify images before processing
        * @return success of process
        */
        static public bool processStereoFiles(StereoParams stereo_params, string left_yaml, string right_yaml,
            string left_image_path, string right_image_path, string output_folder, bool rectify = true)
        {
            return CProcessStereoFiles(stereo_params, left_yaml, right_yaml, left_image_path, right_image_path, output_folder, rectify);
        }

        /*!
        * Process single image pair using provided calibration instance.
        *
        * @param stereo_params stereo matcher parameters
        * @param left_image left image to use in stereo processing
        * @param right_image right image to use in stereo processing
        * @param calibration calibration to use in stereo processing
        * @param rectify toggle to rectify images before processing
        * @return disparity result from stereo matching
        */
        static public MatrixFloat processStereo(
            StereoParams stereo_params, MatrixUInt8 left_image, MatrixUInt8 right_image,
            StereoCameraCalibration calibration, bool rectify = true)
        {
            return new MatrixFloat(
                CProcessStereo(stereo_params, left_image.getInstancePtr(), right_image.getInstancePtr(),
                calibration.getInstancePtr(), rectify));
        }
    }
}