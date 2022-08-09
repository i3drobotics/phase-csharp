/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file common.cs
 * @brief Common types.
 * @details C# wrapper for common types export.
 * DllImports for using C type exports. Pointer to class instance
 * is passed between functions.
 */

using System;
using System.Runtime.InteropServices;
using System.Runtime.ExceptionServices;

namespace I3DR.Phase
{
    public struct Point2d {
        public double x;
        public double y;
        public Point2d(double x, double y) {
            this.x = x;
            this.y = y;
        }
    };

    public struct Point2f {
        public float x;
        public float y;
        public Point2f(float x, float y) {
            this.x = x;
            this.y = y;
        }
    };

    public struct Point2i {
        public int x;
        public int y;
        public Point2i(int x, int y) {
            this.x = x;
            this.y = y;
        }
    };

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

    public enum LeftOrRight { 
        LEFT,
        RIGHT
    };

    public enum CameraDeviceType { 
        DEVICE_TYPE_GENERIC_PYLON,
        DEVICE_TYPE_GENERIC_UVC,
        DEVICE_TYPE_DEIMOS,
        DEVICE_TYPE_PHOBOS,
        DEVICE_TYPE_TITANIA,
        DEVICE_TYPE_INVALID
    };
    public enum CameraInterfaceType { 
        INTERFACE_TYPE_USB, INTERFACE_TYPE_GIGE, INTERFACE_TYPE_VIRTUAL
    };

    public enum StereoMatcherType { 
        STEREO_MATCHER_BM, STEREO_MATCHER_SGBM, STEREO_MATCHER_I3DRSGM, STEREO_MATCHER_HOBM
    };

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