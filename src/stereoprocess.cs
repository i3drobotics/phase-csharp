/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-06-21
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file stereoprocess.cs
 * @brief Stereo File System Wrapper class
 * @details C# wrapper class for Stereo Filesystem class export.
 * DllImports for using C type exports. Pointer to class instance
 * is passed between functions.
 */

using System;
using System.Runtime.InteropServices;
using System.Runtime.ExceptionServices;

namespace I3DR.Phase
{
    public class StereoProcess
    {
        // Straight From the c++ Dll (unmanaged)
        [DllImport("phase", EntryPoint = "I3DR_ProcessStereoFiles")]
        private static extern bool CProcessStereoFiles(
            StereoParams stereo_params, string left_yaml, string right_yaml,
            string left_image_path, string right_image_path, string output_folder, bool rectify);

        [DllImport("phase", EntryPoint = "I3DR_ProcessStereo")]
        private static extern IntPtr CProcessStereo(
            StereoParams stereo_params, IntPtr left_image, IntPtr right_image,
            IntPtr calibration, bool rectify);

        static public bool processStereoFiles(StereoParams stereo_params, string left_yaml, string right_yaml,
            string left_image_path, string right_image_path, string output_folder, bool rectify = true)
        {
            return CProcessStereoFiles(stereo_params, left_yaml, right_yaml, left_image_path, right_image_path, output_folder, rectify);
        }

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