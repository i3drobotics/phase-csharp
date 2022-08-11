/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file common.cs
 * @brief Common types.
 * @brief Commmon types used in Phase
 */

using System;
using System.Runtime.InteropServices;
using System.Runtime.ExceptionServices;

namespace I3DR.Phase
{
    //!  2D point structure
    /*!
    Struture to 2D point (x, y) with double precision
    */
    public struct Point2d {
        public double x;
        public double y;
        public Point2d(double x, double y) {
            this.x = x;
            this.y = y;
        }
    };

    //!  2D point structure
    /*!
    Struture to 2D point (x, y) with float precision
    */
    public struct Point2f {
        public float x;
        public float y;
        public Point2f(float x, float y) {
            this.x = x;
            this.y = y;
        }
    };

    //!  2D point structure
    /*!
    Struture to 2D point (x, y) with integer precision
    */
    public struct Point2i {
        public int x;
        public int y;
        public Point2i(int x, int y) {
            this.x = x;
            this.y = y;
        }
    };

    //!  Stereo Image Pair structure
    /*!
    Struture to store stereo image pair (left, right)
    */
    public struct StereoImagePair
    {
        public byte[] left;
        public byte[] right;

        public StereoImagePair(byte[] left, byte[] right)
        {
            this.left = left;
            this.right = right;
        }
    }

    //!  Camera Read Result structure
    /*!
    Struture to store the result from reading a camera frame. Used in the stereo camera classes.
    */
    public struct CameraReadResult
    {
        public bool valid;
        public byte[] left_image;
        public byte[] right_image;

        public CameraReadResult(bool valid, byte[] left_image, byte[] right_image)
        {
            this.valid = valid;
            this.left_image = left_image;
            this.right_image = right_image;
        }
    }

    //!  Left or Right enum
    /*!
    Enum to indicate left or right camera/image
    */
    public enum LeftOrRight { 
        LEFT,
        RIGHT
    };

    //!  Camera Device Type enum
    /*!
    Enum to indicate the device type of the camera. Used in stereo camera class to select which type to use.
    */
    public enum CameraDeviceType { 
        DEVICE_TYPE_GENERIC_PYLON,
        DEVICE_TYPE_GENERIC_UVC,
        DEVICE_TYPE_DEIMOS,
        DEVICE_TYPE_PHOBOS,
        DEVICE_TYPE_TITANIA,
        DEVICE_TYPE_INVALID
    };

    //!  Camera Interface Type enum
    /*!
    Enum to indicate the interface type of the camera. Used in stereo camera class to select which interface to use.
    */
    public enum CameraInterfaceType { 
        INTERFACE_TYPE_USB, INTERFACE_TYPE_GIGE, INTERFACE_TYPE_VIRTUAL
    };

    //!  Stereo Matcher Type enum
    /*!
    Enum to indicate stereo matcher type. Used in stereo matcher class to select which matcher to use.
    */
    public enum StereoMatcherType { 
        STEREO_MATCHER_BM, STEREO_MATCHER_SGBM, STEREO_MATCHER_I3DRSGM, STEREO_MATCHER_HOBM
    };

    //!  Stereo Matcher Compute Result structure
    /*!
    Struture to store the result from a stereo match. Used in the stereo matcher classes.
    */
    public struct StereoMatcherComputeResult
    {
        public bool valid;
        public float[] disparity;

        public StereoMatcherComputeResult(bool valid, float[] disparity)
        {
            this.valid = valid;
            this.disparity = disparity;
        }
    }

    //!  Stereo Vision Read Result structure
    /*!
    Struture to store the result from reading a stereo vision frame. Used in the stereo vision class.
    */
    public struct StereoVisionReadResult
    {
        public bool valid;
        public byte[] left_image;
        public byte[] right_image;
        public float[] disparity;

        public StereoVisionReadResult(bool valid, byte[] left_image, byte[] right_image, float[] disparity)
        {
            this.valid = valid;
            this.left_image = left_image;
            this.right_image = right_image;
            this.disparity = disparity;
        }
    }


    //!  RGBD Video Frame structure
    /*!
    Struture to store RGBD Video frame data (image, depth)
    */
    public struct RGBDVideoFrame
    {
        public bool valid;
        public byte[] image;
        public float[] depth;

        public RGBDVideoFrame(bool valid, byte[] image, float[] depth)
        {
            this.valid = valid;
            this.image = image;
            this.depth = depth;
        }
    }
}