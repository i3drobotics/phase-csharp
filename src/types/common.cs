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
        public double x; //!< x coordinate
        public double y; //!< y coordinate
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
        public float x; //!< x coordinate
        public float y; //!< y coordinate
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
        public int x; //!< x coordinate
        public int y; //!< y coordinate
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
        public byte[] left; //!< left image
        public byte[] right; //!< right image

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
        public bool valid; //!< true if camera read was successful
        public byte[] left_image; //!< left camera image
        public byte[] right_image; //!< right camera image

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
        LEFT, //!< Left camera/image
        RIGHT //!< Right camera/image
    };

    //!  Camera Device Type enum
    /*!
    Enum to indicate the device type of the camera. Used in stereo camera class to select which type to use.
    */
    public enum CameraDeviceType { 
        DEVICE_TYPE_GENERIC_PYLON, //!< Generic Pylon device
        DEVICE_TYPE_GENERIC_UVC, //!< Generic UVC device
        DEVICE_TYPE_DEIMOS, //!< I3DR's Deimos device
        DEVICE_TYPE_PHOBOS, //!< I3DR's Phobos device
        DEVICE_TYPE_TITANIA, //!< I3DR's Titania device
        DEVICE_TYPE_INVALID //!< Invalid device
    };

    //!  Camera Interface Type enum
    /*!
    Enum to indicate the interface type of the camera. Used in stereo camera class to select which interface to use.
    */
    public enum CameraInterfaceType { 
        INTERFACE_TYPE_USB, //!< USB interface
        INTERFACE_TYPE_GIGE, //!< GigE interface
        INTERFACE_TYPE_VIRTUAL, //!< Virtual interface
        INTERFACE_TYPE_INVALID //!< Invalid interface
    };

    //!  Stereo Matcher Type enum
    /*!
    Enum to indicate stereo matcher type. Used in stereo matcher class to select which matcher to use.
    */
    public enum StereoMatcherType { 
        STEREO_MATCHER_BM, //!< OpenCV Block Matcher
        STEREO_MATCHER_SGBM, //!< OpenCV Semi-Global Block Matcher
        STEREO_MATCHER_I3DRSGM, //!< I3DR's Semi-Global Block Matcher
        STEREO_MATCHER_HOBM, //!< I3DR's High resolution Optimised Block Matcher
    };

    //!  Stereo Matcher Compute Result structure
    /*!
    Struture to store the result from a stereo match. Used in the stereo matcher classes.
    */
    public struct StereoMatcherComputeResult
    {
        public bool valid; //!< true if stereo match was successful
        public float[] disparity; //!< disparity image

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
        public bool valid; //!< true if valid frame
        public byte[] left_image; //!< left image
        public byte[] right_image; //!< right image
        public float[] disparity; //!< disparity image

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
        public bool valid; //!< true if frame is valid
        public byte[] image; //!< image data (RGB)
        public float[] depth; //!< depth data

        public RGBDVideoFrame(bool valid, byte[] image, float[] depth)
        {
            this.valid = valid;
            this.image = image;
            this.depth = depth;
        }
    }
}