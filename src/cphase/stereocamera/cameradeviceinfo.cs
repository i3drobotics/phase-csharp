/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file cameradeviceinfo.cs
 * @brief Camera Device Info class
 * @details Stores information about a camera device
 * including the camera's serials, interface, and device type
 */
using System;
using System.Text;
using System.Runtime.InteropServices;
using I3DR.Phase.StereoCamera;

namespace I3DR.CPhase.StereoCamera
{
    public class CCameraDeviceInfo
    {
        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseCreateCameraDeviceInfo", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create(string left_serial, string right_serial, string unique_serial, CameraDeviceType device_type, CameraInterfaceType interface_type);

        [DllImport("phase", EntryPoint = "PhaseCameraDeviceInfoGetLeftCameraSerialLength", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getLeftCameraSerialLength(IntPtr info);

        [DllImport("phase", EntryPoint = "PhaseCameraDeviceInfoGetLeftCameraSerial", CallingConvention = CallingConvention.Cdecl)]
        public static extern void getLeftCameraSerial(IntPtr info, StringBuilder left_camera_serial, int length);

        [DllImport("phase", EntryPoint = "PhaseCameraDeviceInfoSetLeftCameraSerial", CallingConvention = CallingConvention.Cdecl)]
        public static extern void setLeftCameraSerial(IntPtr info, string left_camera_serial);

        [DllImport("phase", EntryPoint = "PhaseCameraDeviceInfoGetRightCameraSerialLength", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getRightCameraSerialLength(IntPtr info);

        [DllImport("phase", EntryPoint = "PhaseCameraDeviceInfoGetRightCameraSerial", CallingConvention = CallingConvention.Cdecl)]
        public static extern void getRightCameraSerial(IntPtr info, StringBuilder right_camera_serial, int length);

        [DllImport("phase", EntryPoint = "PhaseCameraDeviceInfoSetRightCameraSerial", CallingConvention = CallingConvention.Cdecl)]
        public static extern void setRightCameraSerial(IntPtr info, string right_camera_serial);

        [DllImport("phase", EntryPoint = "PhaseCameraDeviceInfoGetUniqueSerialLength", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getUniqueSerialLength(IntPtr info);

        [DllImport("phase", EntryPoint = "PhaseCameraDeviceInfoGetUniqueSerial", CallingConvention = CallingConvention.Cdecl)]
        public static extern void getUniqueSerial(IntPtr info, StringBuilder right_camera_serial, int length);

        [DllImport("phase", EntryPoint = "PhaseCameraDeviceInfoSetUniqueSerial", CallingConvention = CallingConvention.Cdecl)]
        public static extern void setUniqueSerial(IntPtr info, string right_camera_serial);

        [DllImport("phase", EntryPoint = "PhaseCameraDeviceInfoSetDeviceType", CallingConvention = CallingConvention.Cdecl)]
        public static extern void setDeviceType(IntPtr info, CameraDeviceType device_type);   

        [DllImport("phase", EntryPoint = "PhaseCameraDeviceInfoGetDeviceType", CallingConvention = CallingConvention.Cdecl)]
        public static extern CameraDeviceType getDeviceType(IntPtr info);

        [DllImport("phase", EntryPoint = "PhaseCameraDeviceInfoSetInterfaceType", CallingConvention = CallingConvention.Cdecl)]
        public static extern void setInterfaceType(IntPtr info, CameraInterfaceType interface_type);   

        [DllImport("phase", EntryPoint = "PhaseCameraDeviceInfoGetInterfaceType", CallingConvention = CallingConvention.Cdecl)]
        public static extern CameraInterfaceType getInterfaceType(IntPtr info);

        [DllImport("phase", EntryPoint = "PhaseCameraDeviceInfoDispose", CallingConvention = CallingConvention.Cdecl)]
        public static extern void dispose(IntPtr info);

    }

}