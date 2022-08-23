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

namespace I3DR.CPhase
{
    //!  Abstract Stereo Camera class
    /*!
    Abstract base class for building stereo camera
    classes. Includes functions/structures common across
    all stereo cameras.
    */
    public class AbstractStereoCamera
    {
        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoCamera_CConnect", CallingConvention = CallingConvention.Cdecl)]
        protected static extern bool AbstractStereoCamera_connect(IntPtr cam);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoCamera_CStartCapture", CallingConvention = CallingConvention.Cdecl)]
        protected static extern bool AbstractStereoCamera_startCapture(IntPtr cam);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoCamera_CStopCapture", CallingConvention = CallingConvention.Cdecl)]
        protected static extern void AbstractStereoCamera_stopCapture(IntPtr cam);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoCamera_CIsCapturing", CallingConvention = CallingConvention.Cdecl)]
        protected static extern bool AbstractStereoCamera_isCapturing(IntPtr cam);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoCamera_CIsConnected", CallingConvention = CallingConvention.Cdecl)]
        protected static extern bool AbstractStereoCamera_isConnected(IntPtr cam);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoCamera_CGetWidth", CallingConvention = CallingConvention.Cdecl)]
        protected static extern int AbstractStereoCamera_getWidth(IntPtr cam);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoCamera_CGetHeight", CallingConvention = CallingConvention.Cdecl)]
        protected static extern int AbstractStereoCamera_getHeight(IntPtr cam);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoCamera_CGetFrameRate", CallingConvention = CallingConvention.Cdecl)]
        protected static extern float AbstractStereoCamera_getFrameRate(IntPtr cam);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoCamera_CSetTestImagePaths", CallingConvention = CallingConvention.Cdecl)]
        protected static extern void AbstractStereoCamera_setTestImagePaths(IntPtr cam, string left_test_image_path, string right_test_image_path);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoCamera_CRead", CallingConvention = CallingConvention.Cdecl)]
        protected static extern bool AbstractStereoCamera_read(IntPtr cam, int timeout, [In] byte[] left_img, [In] byte[] right_img);
        
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoCamera_CStartReadThread", CallingConvention = CallingConvention.Cdecl)]
        protected static extern void AbstractStereoCamera_startReadThread(IntPtr cam, int timeout);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoCamera_CIsReadThreadRunning", CallingConvention = CallingConvention.Cdecl)]
        protected static extern bool AbstractStereoCamera_isReadThreadRunning(IntPtr cam);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoCamera_CGetReadThreadResult", CallingConvention = CallingConvention.Cdecl)]
        protected static extern bool AbstractStereoCamera_getReadThreadResult(IntPtr cam, [In] byte[] left_img, [In] byte[] right_img);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoCamera_CSetDownsampleFactor", CallingConvention = CallingConvention.Cdecl)]
        protected static extern void AbstractStereoCamera_setDownsampleFactor(IntPtr cam, float value);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoCamera_CSetExposure", CallingConvention = CallingConvention.Cdecl)]
        protected static extern void AbstractStereoCamera_setExposure(IntPtr cam, int value);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoCamera_CSetFrameRate", CallingConvention = CallingConvention.Cdecl)]
        protected static extern void AbstractStereoCamera_setFrameRate(IntPtr cam, float value);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoCamera_CEnableHardwareTrigger", CallingConvention = CallingConvention.Cdecl)]
        protected static extern void AbstractStereoCamera_enableHardwareTrigger(IntPtr cam, bool enable);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoCamera_CSetLeftAOI", CallingConvention = CallingConvention.Cdecl)]
        protected static extern void AbstractStereoCamera_setLeftAOI(IntPtr cam, int x_min, int y_min, int x_max, int y_max);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoCamera_CSetRightAOI", CallingConvention = CallingConvention.Cdecl)]
        protected static extern void AbstractStereoCamera_setRightAOI(IntPtr cam, int x_min, int y_min, int x_max, int y_max);
        
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoCamera_CDisconnect", CallingConvention = CallingConvention.Cdecl)]
        protected static extern void AbstractStereoCamera_disconnect(IntPtr cam);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoCamera_dispose", CallingConvention = CallingConvention.Cdecl)]
        protected static extern void AbstractStereoCamera_dispose(IntPtr cam);
    }
}