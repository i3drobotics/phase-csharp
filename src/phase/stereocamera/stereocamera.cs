/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file stereocamera.cs
 * @brief Stereo Camera class
 * @details Create stereo camera of any type using 
 * CameraDeviceInfo. This allows for the same interface to be
 * used for any stereo camera. 
 */
 
using System;
using System.Runtime.InteropServices;
using I3DR.CPhase.StereoCamera;

namespace I3DR.Phase.StereoCamera
{
    //!  Stereo Camera class
    /*!
    Create stereo camera of any type using 
    CameraDeviceInfo. This allows for the same interface to be
    used for any stereo camera. 
    */
    public class StereoCamera
    {
        /*!
        * Create Stereo Camera from camera device information \n
        * Generic way to create any stereo camera without needing to use specific camera classes.
        * 
        * @param device_info device info
        * @return stereo camera
        */
        public static AbstractStereoCamera createStereoCamera(CameraDeviceInfo camera_device_info){
            return new AbstractStereoCamera(CStereoCamera.createStereoCameraFromParams(
                camera_device_info.left_camera_serial, camera_device_info.right_camera_serial, 
                camera_device_info.unique_serial, 
                camera_device_info.device_type, camera_device_info.interface_type
            ));
        }

        /*!
        * Get available camera list \n
        * Call to get available camera as a list of CameraDeviceInfo.
        * 
        * @return available camera in CameraDeviceInfo array
        */
        public static CameraDeviceInfo[] availableDevices(){
            int device_count = CStereoCamera.availableDevicesCount();
            CameraDeviceInfo[] device_infos = new CameraDeviceInfo[device_count];
            IntPtr[] instances = new IntPtr[device_count];
            for(int i = 0; i < device_count; i++){
                device_infos[i] = new CameraDeviceInfo();
                instances[i] = device_infos[i].getInstance();
            }

            CStereoCamera.availableDevices(instances ,device_count);
            return device_infos;
        }

    }
}