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

namespace I3DR.Phase
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
    public struct CameraDeviceInfo {
        public string left_camera_serial; //!< right camera serial
        public string right_camera_serial; //!< left camera serial
        public string unique_serial; //!< defined unique serial for stereo camera pair
        public CameraDeviceType device_type; //!< device type of camera
        public CameraInterfaceType interface_type; //!< interface type of camera
        
        /*!
        * CameraDeviceInfo contructor \n
        * Create device information about the camera
        * 
        * @param left_camera_serial left camera serial
        * @param right_camera_serial right camera serial
        * @param unique_serial stereo camera unique identifier
        * @param device_type camera device type
        * @param interface_type camera interface type
        */
        public CameraDeviceInfo(
            string left_camera_serial, string right_camera_serial,
            string unique_serial, 
            CameraDeviceType device_type, CameraInterfaceType interface_type
            )
        {
            this.left_camera_serial = left_camera_serial;
            this.right_camera_serial = right_camera_serial;
            this.unique_serial = unique_serial;
            this.device_type = device_type;
            this.interface_type = interface_type;
        }
    };
}