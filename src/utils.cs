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
        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_CScaleImageUChar")]
        private static extern void CScaleImageUChar([In] byte[] in_img, int width, int height, float scale_factor, [Out] byte[] out_scaled_img);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_CNormaliseDisparity")]
        private static extern void CNormaliseDisparity([In] float[] in_disparity, int width, int height, [Out] byte[] out_norm_disparity);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_CBgra2rgba")]
        private static extern void CBgra2rgba([In] byte[] in_bgra, int width, int height, [Out] byte[] out_rgba);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_CBgr2rgba")]
        private static extern void CBgr2rgba([In] byte[] in_bgr, int width, int height, [Out] byte[] out_rgba);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_CBgr2bgra")]
        private static extern void CBgr2bgra([In] byte[] in_bgr, int width, int height, [Out] byte[] out_bgra);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_CDisparity2depth")]
        private static extern void CDisparity2Depth([In] float[] in_disparity, int width, int height, [In] float[] in_Q, [Out] float[] out_depth);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_CDisparity2xyz")]
        private static extern void CDisparity2xyz([In] float[] in_disparity, int width, int height, [In] float[] in_Q, [Out] float[] out_xyz);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_CDepth2xyz")]
        private static extern void CDepth2xyz([In] float[] in_depth, int width, int height, float hfov, [Out] float[] out_xyz);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_CXyz2depth")]
        private static extern void CXyz2depth([In] float[] in_xyz, int width, int height, [Out] float[] out_depth);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_CShowImageUChar")]
        private static extern int CShowImageUChar(string window_name, [In] byte[] in_img, int img_width, int img_height);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_CReadImageUChar")]
        private static extern bool CReadImageUChar(string image_filepath, [Out] byte[] out_img, int img_width, int img_height);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_CFlipUChar")]
        private static extern void CFlipUChar([In] byte[] in_img, [Out] byte[] out_flipped_img, int img_width, int img_height, int img_channels, int flipcode);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_CFlipFloat")]
        private static extern void CFlipFloat([In] float[] in_img, [Out] float[] out_flipped_img, int img_width, int img_height, int img_channels, int flipcode);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_CSavePLY")]
        private static extern bool CSavePLY(string ply_filepath, [In] float[] in_xyz, byte[] in_bgr, int width, int height);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_CcvMatIsEqualUChar")]
        private static extern bool CcvMatIsEqualUChar([In] byte[] in_mat1, [In] byte[] in_mat2, int width, int height, int channels);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_CcvMatIsEqualFloat")]
        private static extern bool CcvMatIsEqualFloat([In] float[] in_mat1, [In] float[] in_mat2, int width, int height, int channels);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_CcvMatIsEqualDouble")]
        private static extern bool CcvMatIsEqualDouble([In] double[] in_mat1, [In] double[] in_mat2, int width, int height, int channels);

        /*!
        * Resize image to by a specified scaling factor \n
        * Scaled image will be populated into \p out_scaled_img
        *
        * @param image input image to apply scaling to
        * @param input_width width of input image
        * @param input_height height of input image
        * @param scale_factor scaling factor to apply (0.5 = half size, 2.0 = double size)
        * @return scaled image
        */
        static public byte[] scaleImage(byte[] image, int input_width, int input_height, float scaling_factor)
        {
            int scaled_width = (int)((float)input_width * scaling_factor);
            int scaled_height = (int)((float)input_height * scaling_factor);
            byte[] scaled_image = new byte[scaled_width * scaled_height * 3];
            CScaleImageUChar(image, input_width, input_height, scaling_factor, scaled_image);
            return scaled_image;
        }

        /*!
        * Normalise disparity image to floating point 0-1 range \n
        * Disparity image is the output from stereo matching that describes
        * the pixel disparity of each pixel from left to right image \n
        * Normalised disparity image will be populated into \p out_norm_disparity
        *
        * @param disparity input \p disparity image to normalise
        * @param width \p width of input image
        * @param height \p height of input image
        * @return normalised disparity image
        */
        static public byte[] normaliseDisparity(float[] disparity, int width, int height)
        {
            byte[] norm_disparity = new byte[width * height * 3];
            CNormaliseDisparity(disparity, width, height, norm_disparity);
            return norm_disparity;
        }

        /*!
        * Convert BGRA image to RGBA image
        *
        * @param bgra input BGRA image to convert
        * @param width \p width of input image
        * @param height \p height of input image
        * @return converted RGBA image
        */
        static public byte[] bgra2rgba(byte[] bgra, int width, int height)
        {
            byte[] rgba = new byte[width * height * 4];
            CBgra2rgba(bgra, width, height, rgba);
            return rgba;
        }

        /*!
        * Convert BGR image to RGBA image
        *
        * @param bgr input BGR image to convert
        * @param width \p width of input image
        * @param height \p height of input image
        * @return converted RGBA image
        */
        static public byte[] bgr2rgba(byte[] bgr, int width, int height)
        {
            byte[] rgba = new byte[width * height * 4];
            CBgr2rgba(bgr, width, height, rgba);
            return rgba;
        }

        /*!
        * Convert BGR image to BGRA image
        *
        * @param bgr input BGR image to convert
        * @param width \p width of input image
        * @param height \p height of input image
        * @return converted BGRA image
        */
        static public byte[] bgr2bgra(byte[] bgr, int width, int height)
        {
            byte[] bgra = new byte[width * height * 4];
            CBgr2bgra(bgr, width, height, bgra);
            return bgra;
        }

        /*!
        * Convert \p disparity image to depth image \n
        * Disparity image is the output from stereo matching that describes
        * the pixel disparity of each pixel from left to right image \n
        * Depth image is the z distance for each pixel in the image
        * 
        * @param disparity input \p disparity image to convert
        * @param width \p width of input image
        * @param height \p height of input image
        * @param Q \p Q matrix from camera calibration
        * @return depth image (z distance for each pixel)
        */
        static public float[] disparity2Depth(float[] disparity, int width, int height, float[] Q)
        {
            float[] depth = new float[width * height];
            CDisparity2Depth(disparity, width, height, Q, depth);
            return depth;
        }

        /*!
        * Convert \p disparity image to xyz image \n
        * Disparity image is the output from stereo matching that describes
        * the pixel disparity of each pixel from left to right image \n
        * XYZ image is a 3 channel image storing the xyz position \n
        * for each pixel in the image (in meters)
        * 
        * @param disparity input \p disparity image to convert
        * @param width \p width of input image
        * @param height \p height of input image
        * @param Q \p Q matrix from camera calibration
        * @return xyz image (xyz position for each pixel)
        */
        static public float[] disparity2xyz(float[] disparity, int width, int height, float[] Q)
        {
            float[] xyz = new float[width * height * 3];
            CDisparity2xyz(disparity, width, height, Q, xyz);
            return xyz;
        }

        /*!
        * Convert \p depth image to xyz image \n
        * Depth image is the z distance for each pixel in the image \n
        * XYZ image is a 3 channel image storing the xyz position \n
        * for each pixel in the image (in meters)
        * 
        * @param depth input \p depth image to convert
        * @param width \p width of input image
        * @param height \p height of input image
        * @param hfov horizontal field of view from camera calibration
        * @return xyz image (xyz position for each pixel)
        */
        static public float[] depth2xyz(float[] depth, int width, int height, float hfov)
        {
            float[] xyz = new float[width * height * 3];
            CDepth2xyz(depth, width, height, hfov, xyz);
            return xyz;
        }

        /*!
        * Convert xyz image to \p depth image \n
        * XYZ image is a 3 channel image storing the xyz position \n
        * for each pixel in the image (in meters)
        * Depth image is the z distance for each pixel in the image \n
        * 
        * @param xyz input \p xyz image to convert
        * @param width \p width of input image
        * @param height \p height of input image
        * @return depth image (z distance for each pixel)
        */
        static public float[] xyz2depth(float[] xyz, int width, int height)
        {
            float[] depth = new float[width * height];
            CXyz2depth(xyz, width, height, depth);
            return depth;
        }

        /*!
        * Show image in a window \n
        * Uses OpenCV's imshow function \n
        * This also uses the waitKey function to display the window
        * imediately. Key pressed while window is active is returned.
        * 
        * @param window_name name to give the window
        * @param image \p image to display in window
        * @param width \p width of input image
        * @param height \p height of input image
        * @return key pressed while window is active
        */
        static public int showImage(string window_name, byte[] image, int width, int height)
        {
            return CShowImageUChar(window_name, image, width, height);
        }

        /*!
        * Read image from file \n
        * 
        * @param image_filepath filepath of image to read
        * @param width \p width of input image
        * @param height \p height of input image
        * @return image read from file
        */
        static public byte[] readImage(string image_filepath, int width, int height)
        {
            byte[] image = new byte[width * height * 3];
            if (CReadImageUChar(image_filepath, image, width, height)){
                return image;
            }
            return new byte[0];
        }

        /*!
        * Flip an image horizontally, vertically, or both \n
        * Flip code 0 = horizontal, 1 = vertical, -1 = both
        * 
        * @param in_img image to flip
        * @param width \p width of input image
        * @param height \p height of input image
        * @param channels \p channels of input image
        * @param flipcode flip code to apply (0 = horizontal, 1 = vertical, -1 = both)
        * @return flipped image
        */
        static public byte[] flip(byte[] in_img, int width, int height, int channels, int flipcode)
        {
            byte[] flipped_img = new byte[width * height * channels];
            CFlipUChar(in_img, flipped_img, width, height, channels, flipcode);
            return flipped_img;
        }

        /*!
        * Flip an image horizontally, vertically, or both \n
        * Flip code 0 = horizontal, 1 = vertical, -1 = both
        * 
        * @param in_img image to flip
        * @param width \p width of input image
        * @param height \p height of input image
        * @param channels \p channels of input image
        * @param flipcode flip code to apply (0 = horizontal, 1 = vertical, -1 = both)
        * @return flipped image
        */
        static public float[] flip(float[] in_img, int width, int height, int channels, int flipcode)
        {
            float[] flipped_img = new float[width * height * channels];
            CFlipFloat(in_img, flipped_img, width, height, channels, flipcode);
            return flipped_img;
        }

        /*!
        * Save xyz image and rgb image as ply file \n
        * XYZ image is a 3 channel image storing the xyz position
        * for each pixel in the image (in meters) \n
        * RGB image is the colour for each pixel \n
        * PLY file is a point cloud file format \
        * RGB and XYZ images must be the same height and width \n
        * 
        * @param ply_filepath filepath to save ply point cloud to
        * @param xyz \p xyz image
        * @param rgb \p rgb image
        * @param width \p width of input image
        * @param height \p height of input image
        * @return success of saving ply file
        */
        static public bool savePLY(string ply_filepath, float[] xyz, byte[] bgr, int width, int height)
        {
            return CSavePLY(ply_filepath, xyz, bgr, width, height);
        }

        /*!
        * Check if two matrices are equal
        * 
        * @param mat1 first matrices to compare
        * @param mat2 second matrices to compare
        * @param width \p width of input matrices
        * @param height \p height of input matrices
        * @param channels \p channels of input matrices
        * @return equality of input matrices
        */
        static public bool cvMatIsEqual(byte[] in_mat1, byte[] in_mat2, int width, int height, int channels)
        {
            return CcvMatIsEqualUChar(in_mat1, in_mat2, width, height, channels);
        }

        /*!
        * Check if two matrices are equal
        * 
        * @param mat1 first matrices to compare
        * @param mat2 second matrices to compare
        * @param width \p width of input matrices
        * @param height \p height of input matrices
        * @param channels \p channels of input matrices
        * @return equality of input matrices
        */
        static public bool cvMatIsEqual(float[] in_mat1, float[] in_mat2, int width, int height, int channels)
        {
            return CcvMatIsEqualFloat(in_mat1, in_mat2, width, height, channels);
        }

        /*!
        * Check if two matrices are equal
        * 
        * @param mat1 first matrices to compare
        * @param mat2 second matrices to compare
        * @param width \p width of input matrices
        * @param height \p height of input matrices
        * @param channels \p channels of input matrices
        * @return equality of input matrices
        */
        static public bool cvMatIsEqual(double[] in_mat1, double[] in_mat2, int width, int height, int channels)
        {
            return CcvMatIsEqualDouble(in_mat1, in_mat2, width, height, channels);
        }
    }
}