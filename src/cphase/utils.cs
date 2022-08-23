/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file utils.cs
 * @brief Utility functions.
 * @details TODOC
 */

using System.Runtime.InteropServices;

namespace I3DR.CPhase
{
    //!  Utils class
    /*!
    Utility functions for common tasks in Phase
    */
    public class CUtils
    {
        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseScaleImageUChar")]
        public static extern void PhaseScaleImageUChar([In] byte[] in_img, int width, int height, float scale_factor, [Out] byte[] out_scaled_img);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseNormaliseDisparity")]
        public static extern void PhaseNormaliseDisparity([In] float[] in_disparity, int width, int height, [Out] byte[] out_norm_disparity);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseBgra2rgba")]
        public static extern void PhaseBgra2rgba([In] byte[] in_bgra, int width, int height, [Out] byte[] out_rgba);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseBgr2rgba")]
        public static extern void PhaseBgr2rgba([In] byte[] in_bgr, int width, int height, [Out] byte[] out_rgba);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseBgr2bgra")]
        public static extern void PhaseBgr2bgra([In] byte[] in_bgr, int width, int height, [Out] byte[] out_bgra);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseDisparity2depth")]
        public static extern void PhaseDisparity2depth([In] float[] in_disparity, int width, int height, [In] float[] in_Q, [Out] float[] out_depth);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseDisparity2xyz")]
        public static extern void PhaseDisparity2xyz([In] float[] in_disparity, int width, int height, [In] float[] in_Q, [Out] float[] out_xyz);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseDepth2xyz")]
        public static extern void PhaseDepth2xyz([In] float[] in_depth, int width, int height, float hfov, [Out] float[] out_xyz);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseXyz2depth")]
        public static extern void PhaseXyz2depth([In] float[] in_xyz, int width, int height, [Out] float[] out_depth);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseShowImageUChar")]
        public static extern int PhaseShowImageUChar(string window_name, [In] byte[] in_img, int img_width, int img_height);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseReadImageUChar")]
        public static extern bool PhaseReadImageUChar(string image_filepath, [Out] byte[] out_img, int img_width, int img_height);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseFlipUChar")]
        public static extern void PhaseFlipUChar([In] byte[] in_img, [Out] byte[] out_flipped_img, int img_width, int img_height, int img_channels, int flipcode);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseFlipFloat")]
        public static extern void PhaseFlipFloat([In] float[] in_img, [Out] float[] out_flipped_img, int img_width, int img_height, int img_channels, int flipcode);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseSavePLY")]
        public static extern bool PhaseSavePLY(string ply_filepath, [In] float[] in_xyz, byte[] in_rgb, int width, int height);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseCVMatIsEqualUChar")]
        public static extern bool PhaseCVMatIsEqualUChar([In] byte[] in_mat1, [In] byte[] in_mat2, int width, int height, int channels);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseCVMatIsEqualFloat")]
        public static extern bool PhaseCVMatIsEqualFloat([In] float[] in_mat1, [In] float[] in_mat2, int width, int height, int channels);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseCVMatIsEqualDouble")]
        public static extern bool PhaseCVMatIsEqualDouble([In] double[] in_mat1, [In] double[] in_mat2, int width, int height, int channels);
    }
}
