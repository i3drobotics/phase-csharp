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
using I3DR.CPhase.StereoCamera;

namespace I3DR.Phase.StereoCamera
{
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

    //!  Camera Device Info class
    /*!
    Structure to hold information on a camera.
    Includes serial, interface, and device type.
    */
    public class CameraDeviceInfo {
        private IntPtr m_CameraDeviceInfo_ptr; //!< pointer to CameraDeviceInfo C API instance

        /*!
        * CameraDeviceInfo pointer constructor \n
        * Initalise CameraDeviceInfo with reference to existing CameraDeviceInfo pointer
        * 
        * @param CameraDeviceInfo_ptr CameraDeviceInfo instance pointer
        */
        public CameraDeviceInfo(IntPtr CameraDeviceInfo_ptr){
            m_CameraDeviceInfo_ptr = CameraDeviceInfo_ptr;
        }

        /*!
        * Matrix assignment contructor
        * 
        * @param rows number of rows to create in matrix
        * @param columns number of columns to create in matrix
        * @param layers number of layers to create in matrix
        */
        public CameraDeviceInfo(string left_serial, string right_serial, string unique_serial, CameraDeviceType device_type, CameraInterfaceType interface_type){
            m_CameraDeviceInfo_ptr = CCameraDeviceInfo.create(left_serial, right_serial, unique_serial, device_type, interface_type);
        }

        public string left_camera_serial
        {
            get {
                int length = CCameraDeviceInfo.getLeftCameraSerialLength(m_CameraDeviceInfo_ptr);
                StringBuilder m_left_camera_serial = new StringBuilder(length + 1);
                CCameraDeviceInfo.getLeftCameraSerial(m_CameraDeviceInfo_ptr, m_left_camera_serial, m_left_camera_serial.Capacity);
                return m_left_camera_serial.ToString();
            }
            set {
                CCameraDeviceInfo.setLeftCameraSerial(m_CameraDeviceInfo_ptr, value);
            }
        }

        public string right_camera_serial
        {
            get {
                int length = CCameraDeviceInfo.getRightCameraSerialLength(m_CameraDeviceInfo_ptr);
                StringBuilder m_right_camera_serial = new StringBuilder(length + 1);
                CCameraDeviceInfo.getRightCameraSerial(m_CameraDeviceInfo_ptr, m_right_camera_serial, m_right_camera_serial.Capacity);
                return m_right_camera_serial.ToString();
            }
            set {
                CCameraDeviceInfo.setRightCameraSerial(m_CameraDeviceInfo_ptr, value);
            }
        }

        public string unique_serial
        {
            get {
                int length = CCameraDeviceInfo.getUniqueSerialLength(m_CameraDeviceInfo_ptr);
                StringBuilder m_unique_serial = new StringBuilder(length + 1);
                CCameraDeviceInfo.getUniqueSerial(m_CameraDeviceInfo_ptr, m_unique_serial, m_unique_serial.Capacity);
                return m_unique_serial.ToString();
            }
            set {
                CCameraDeviceInfo.setUniqueSerial(m_CameraDeviceInfo_ptr, value);
            }
        }

        public CameraDeviceType device_type
        {
            get {
                return CCameraDeviceInfo.getDeviceType(m_CameraDeviceInfo_ptr);
            }
            set {
                CCameraDeviceInfo.setDeviceType(m_CameraDeviceInfo_ptr, value);
            }
        }

        public CameraInterfaceType interface_type
        {
            get {
                return CCameraDeviceInfo.getInterfaceType(m_CameraDeviceInfo_ptr);
            }
            set {
                CCameraDeviceInfo.setInterfaceType(m_CameraDeviceInfo_ptr, value);
            }
        }

        /*!
        * Manually dispose instance of CameraDeviceInfo class
        * 
        */
        // [HandleProcessCorruptedStateExceptions]
        public void dispose(){
            if (m_CameraDeviceInfo_ptr != IntPtr.Zero){
                try
                {
                    CCameraDeviceInfo.dispose(m_CameraDeviceInfo_ptr);
                }
                catch (AccessViolationException e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine("Please call 'dispose()' to make sure library memory is freed.");
                }
                m_CameraDeviceInfo_ptr = IntPtr.Zero;
            }
        }

        ~CameraDeviceInfo()
        {
            dispose();
        }

    };
}
