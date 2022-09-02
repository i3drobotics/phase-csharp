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
            return new AbstractStereoCamera(CStereoCamera.createStereoCamera(
                camera_device_info.left_camera_serial, camera_device_info.right_camera_serial, 
                camera_device_info.unique_serial, 
                camera_device_info.device_type, camera_device_info.interface_type
            ));
        }
    }
}