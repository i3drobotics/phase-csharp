/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file deimosstereocamera.cs
 * @brief Deimos Stereo Camera class
 * @details Capture data from I3DR's Deimos stereo camera
 */

using I3DR.CPhase.StereoCamera;

namespace I3DR.Phase.StereoCamera
{
    //!  Deimos Stereo Camera class
    /*!
    Capture data from I3DR's Deimos stereo camera.
    */
    public class DeimosStereoCamera : AbstractStereoCamera
    {
        /*!
        * DeimosStereoCamera constructor \n
        * Initalise Deimos Stereo Camera with the given \p device_info.
        * 
        * @param device_info camera device information
        */
        public DeimosStereoCamera(CameraDeviceInfo camera_device_info): base(camera_device_info){}

        /*!
        * Initalise Deimos Stereo camera
        * 
        * @param camera_device_info camera device information
        */
        protected override void init(CameraDeviceInfo camera_device_info){
            m_AbstractStereoCamera_instance = CDeimosStereoCamera.create(
                camera_device_info.left_camera_serial, camera_device_info.right_camera_serial, 
                camera_device_info.unique_serial, 
                camera_device_info.device_type, camera_device_info.interface_type
            );
        }
    }
}