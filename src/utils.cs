/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file utils.cs
 * @brief Utility functions.
 * @details TODOC
 */

using System;
using System.Runtime.InteropServices;
using System.Runtime.ExceptionServices;

namespace I3DR.Phase
{
    //!  Utils class
    /*!
    Utility functions for common tasks in Phase
    */
    public class Utils
    {
        // Import Phase functions from C API
        [DllImport("phase", EntryPoint = "I3DR_CScaleImageUChar")]
        private static extern void CScaleImageUChar([In] byte[] in_img, int width, int height, float scale_factor, [Out] byte[] out_scaled_img);

        [DllImport("phase", EntryPoint = "I3DR_CNormaliseDisparity")]
        private static extern void CNormaliseDisparity([In] float[] in_disparity, int width, int height, [Out] byte[] out_norm_disparity);

        [DllImport("phase", EntryPoint = "I3DR_CBgra2rgba")]
        private static extern void CBgra2rgba([In] byte[] in_bgra, int width, int height, [Out] byte[] out_rgba);

        [DllImport("phase", EntryPoint = "I3DR_CBgr2rgba")]
        private static extern void CBgr2rgba([In] byte[] in_bgr, int width, int height, [Out] byte[] out_rgba);

        [DllImport("phase", EntryPoint = "I3DR_CBgr2bgra")]
        private static extern void CBgr2bgra([In] byte[] in_bgr, int width, int height, [Out] byte[] out_bgra);

        [DllImport("phase", EntryPoint = "I3DR_CDisparity2depth")]
        private static extern void CDisparity2Depth([In] float[] in_disparity, int width, int height, [In] float[] in_Q, [Out] float[] out_depth);

        [DllImport("phase", EntryPoint = "I3DR_CDisparity2xyz")]
        private static extern void CDisparity2xyz([In] float[] in_disparity, int width, int height, [In] float[] in_Q, [Out] float[] out_xyz);

        [DllImport("phase", EntryPoint = "I3DR_CDepth2xyz")]
        private static extern void CDepth2xyz([In] float[] in_depth, int width, int height, float hfov, [Out] float[] out_xyz);

        [DllImport("phase", EntryPoint = "I3DR_CXyz2depth")]
        private static extern void CXyz2depth([In] float[] in_xyz, int width, int height, [Out] float[] out_depth);

        [DllImport("phase", EntryPoint = "I3DR_CShowImageUChar")]
        private static extern int CShowImageUChar(string window_name, [In] byte[] in_img, int img_width, int img_height);

        [DllImport("phase", EntryPoint = "I3DR_CReadImageUChar")]
        private static extern bool CReadImageUChar(string image_filepath, [Out] byte[] out_img, int img_width, int img_height);

        [DllImport("phase", EntryPoint = "I3DR_CFlipUChar")]
        private static extern void CFlipUChar([In] byte[] in_img, [Out] byte[] out_flipped_img, int img_width, int img_height, int img_channels, int flipcode);

        [DllImport("phase", EntryPoint = "I3DR_CFlipFloat")]
        private static extern void CFlipFloat([In] float[] in_img, [Out] float[] out_flipped_img, int img_width, int img_height, int img_channels, int flipcode);

        [DllImport("phase", EntryPoint = "I3DR_CSavePLY")]
        private static extern bool CSavePLY(string ply_filepath, [In] float[] in_xyz, byte[] in_bgr, int width, int height);

        [DllImport("phase", EntryPoint = "I3DR_CcvMatIsEqualUChar")]
        private static extern bool CcvMatIsEqualUChar([In] byte[] in_mat1, [In] byte[] in_mat2, int width, int height, int channels);

        [DllImport("phase", EntryPoint = "I3DR_CcvMatIsEqualFloat")]
        private static extern bool CcvMatIsEqualFloat([In] float[] in_mat1, [In] float[] in_mat2, int width, int height, int channels);

        [DllImport("phase", EntryPoint = "I3DR_CcvMatIsEqualDouble")]
        private static extern bool CcvMatIsEqualDouble([In] double[] in_mat1, [In] double[] in_mat2, int width, int height, int channels);

        // TODOC
        static public byte[] scaleImage(byte[] image, int input_width, int input_height, float scaling_factor)
        {
            int scaled_width = (int)((float)input_width * scaling_factor);
            int scaled_height = (int)((float)input_height * scaling_factor);
            byte[] scaled_image = new byte[scaled_width * scaled_height * 3];
            CScaleImageUChar(image, input_width, input_height, scaling_factor, scaled_image);
            return scaled_image;
        }

        // TODOC
        static public byte[] normaliseDisparity(float[] disparity, int width, int height)
        {
            byte[] norm_disparity = new byte[width * height * 3];
            CNormaliseDisparity(disparity, width, height, norm_disparity);
            return norm_disparity;
        }

        // TODOC
        static public byte[] bgra2rgba(byte[] bgra, int width, int height)
        {
            byte[] rgba = new byte[width * height * 4];
            CBgra2rgba(bgra, width, height, rgba);
            return rgba;
        }

        // TODOC
        static public byte[] bgr2rgba(byte[] bgr, int width, int height)
        {
            byte[] rgba = new byte[width * height * 4];
            CBgr2rgba(bgr, width, height, rgba);
            return rgba;
        }

        // TODOC
        static public byte[] bgr2bgra(byte[] bgr, int width, int height)
        {
            byte[] bgra = new byte[width * height * 4];
            CBgr2bgra(bgr, width, height, bgra);
            return bgra;
        }

        // TODOC
        static public float[] disparity2Depth(float[] disparity, int width, int height, float[] Q)
        {
            float[] depth = new float[width * height];
            CDisparity2Depth(disparity, width, height, Q, depth);
            return depth;
        }

        // TODOC
        static public float[] disparity2xyz(float[] disparity, int width, int height, float[] Q)
        {
            float[] xyz = new float[width * height * 3];
            CDisparity2xyz(disparity, width, height, Q, xyz);
            return xyz;
        }

        // TODOC
        static public float[] depth2xyz(float[] depth, int width, int height, float hfov)
        {
            float[] xyz = new float[width * height * 3];
            CDepth2xyz(depth, width, height, hfov, xyz);
            return xyz;
        }

        // TODOC
        static public float[] xyz2depth(float[] xyz, int width, int height)
        {
            float[] depth = new float[width * height];
            CXyz2depth(xyz, width, height, depth);
            return depth;
        }

        // TODOC
        static public int showImage(string window_name, byte[] image, int width, int height)
        {
            return CShowImageUChar(window_name, image, width, height);
        }

        // TODOC
        static public byte[] readImage(string image_filepath, int width, int height)
        {
            byte[] image = new byte[width * height * 3];
            if (CReadImageUChar(image_filepath, image, width, height)){
                return image;
            }
            return new byte[0];
        }

        // TODOC
        static public byte[] flip(byte[] in_img, int width, int height, int channels, int flipcode)
        {
            byte[] flipped_img = new byte[width * height * channels];
            CFlipUChar(in_img, flipped_img, width, height, channels, flipcode);
            return flipped_img;
        }

        // TODOC
        static public float[] flip(float[] in_img, int width, int height, int channels, int flipcode)
        {
            float[] flipped_img = new float[width * height * channels];
            CFlipFloat(in_img, flipped_img, width, height, channels, flipcode);
            return flipped_img;
        }

        // TODOC
        static public bool savePLY(string ply_filepath, float[] xyz, byte[] bgr, int width, int height)
        {
            return CSavePLY(ply_filepath, xyz, bgr, width, height);
        }

        // TODOC
        static public bool cvMatIsEqual(byte[] in_mat1, byte[] in_mat2, int width, int height, int channels)
        {
            return CcvMatIsEqualUChar(in_mat1, in_mat2, width, height, channels);
        }

        // TODOC
        static public bool cvMatIsEqual(float[] in_mat1, float[] in_mat2, int width, int height, int channels)
        {
            return CcvMatIsEqualFloat(in_mat1, in_mat2, width, height, channels);
        }

        // TODOC
        static public bool cvMatIsEqual(double[] in_mat1, double[] in_mat2, int width, int height, int channels)
        {
            return CcvMatIsEqualDouble(in_mat1, in_mat2, width, height, channels);
        }
    }
}