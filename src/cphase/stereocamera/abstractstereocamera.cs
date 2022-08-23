/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file abstractstereocamera.cs
 * @brief Abstract Stereo Camera class
 * @details Parent class for building stereo camera
 * classes. Includes functions/structures common across
 * all stereo cameras.
 */

using System;
using System.Runtime.InteropServices;
using System.Runtime.ExceptionServices;

namespace I3DR.CPhase.StereoCamera
{
    //!  Abstract Stereo Camera class
    /*!
    Abstract base class for building stereo camera
    classes. Includes functions/structures common across
    all stereo cameras.
    */
    public class CAbstractStereoCamera
    {
        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseAbstractStereoCameraConnect", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool connect(IntPtr cam);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseAbstractStereoCameraStartCapture", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool startCapture(IntPtr cam);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseAbstractStereoCameraStopCapture", CallingConvention = CallingConvention.Cdecl)]
        public static extern void stopCapture(IntPtr cam);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseAbstractStereoCameraIsCapturing", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool isCapturing(IntPtr cam);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseAbstractStereoCameraIsConnected", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool isConnected(IntPtr cam);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseAbstractStereoCameraGetWidth", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getWidth(IntPtr cam);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseAbstractStereoCameraGetHeight", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getHeight(IntPtr cam);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseAbstractStereoCameraGetFrameRate", CallingConvention = CallingConvention.Cdecl)]
        public static extern float getFrameRate(IntPtr cam);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseAbstractStereoCameraSetTestImagePaths", CallingConvention = CallingConvention.Cdecl)]
        public static extern void setTestImagePaths(IntPtr cam, string left_test_image_path, string right_test_image_path);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseAbstractStereoCameraRead", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool read(IntPtr cam, int timeout, [In] byte[] left_img, [In] byte[] right_img);
        
        [DllImport("phase", EntryPoint = "PhaseAbstractStereoCameraStartReadThread", CallingConvention = CallingConvention.Cdecl)]
        public static extern void startReadThread(IntPtr cam, int timeout);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseAbstractStereoCameraIsReadThreadRunning", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool isReadThreadRunning(IntPtr cam);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseAbstractStereoCameraGetReadThreadResult", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool getReadThreadResult(IntPtr cam, [In] byte[] left_img, [In] byte[] right_img);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseAbstractStereoCameraSetDownsampleFactor", CallingConvention = CallingConvention.Cdecl)]
        public static extern void setDownsampleFactor(IntPtr cam, float value);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseAbstractStereoCameraSetExposure", CallingConvention = CallingConvention.Cdecl)]
        public static extern void setExposure(IntPtr cam, int value);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseAbstractStereoCameraSetFrameRate", CallingConvention = CallingConvention.Cdecl)]
        public static extern void setFrameRate(IntPtr cam, float value);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseAbstractStereoCameraEnableHardwareTrigger", CallingConvention = CallingConvention.Cdecl)]
        public static extern void enableHardwareTrigger(IntPtr cam, bool enable);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseAbstractStereoCameraSetLeftAOI", CallingConvention = CallingConvention.Cdecl)]
        public static extern void setLeftAOI(IntPtr cam, int x_min, int y_min, int x_max, int y_max);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseAbstractStereoCameraSetRightAOI", CallingConvention = CallingConvention.Cdecl)]
        public static extern void setRightAOI(IntPtr cam, int x_min, int y_min, int x_max, int y_max);
        
        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseAbstractStereoCameraDisconnect", CallingConvention = CallingConvention.Cdecl)]
        public static extern void disconnect(IntPtr cam);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseAbstractStereoCameraEnableDataCapture", CallingConvention = CallingConvention.Cdecl)]
        public static extern void enableDataCapture(IntPtr cam, bool enable);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseAbstractStereoCameraSetDataCapturePath", CallingConvention = CallingConvention.Cdecl)]
        public static extern void setDataCapturePath(IntPtr cam, string data_capture_path);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseAbstractStereoCameraResetCaptureCount", CallingConvention = CallingConvention.Cdecl)]
        public static extern void resetCaptureCount(IntPtr cam);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseAbstractStereoCameraGetCaptureCount", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getCaptureCount(IntPtr cam);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseAbstractStereoCameraStartContinousReadThread", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool startContinousReadThread(IntPtr cam, int timeout);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseAbstractStereoCameraStopContinousReadThread", CallingConvention = CallingConvention.Cdecl)]
        public static extern int stopContinousReadThread(IntPtr cam);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseAbstractStereoCameraIsContinousReadThreadRunning", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool isContinousReadThreadRunning(IntPtr cam);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseAbstractStereoCameraDispose", CallingConvention = CallingConvention.Cdecl)]
        public static extern void dispose(IntPtr cam);
    }
}