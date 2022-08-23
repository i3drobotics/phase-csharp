/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file uvcstereocamera.cs
 * @brief UVC Stereo Camera class
 * @details Capture data from a stereo camera using UVC cameras
 * where left and right is transported via green and red channels.
 */

using I3DR.CPhase.StereoCamera;

namespace I3DR.Phase.StereoCamera
{   
    //!  UVC Stereo Camera class
    /*!
    Capture data from a stereo camera using UVC cameras
    where left and right is transported via green and red channels.
    */
    public class UVCStereoCamera : AbstractStereoCamera
    {
        /*!
        * UVCStereoCamera constructor \n
        * Initalise UVC Stereo Camera with the given \p device_info.
        * 
        * @param device_info camera device information
        */
        public UVCStereoCamera(CameraDeviceInfo camera_device_info): base(camera_device_info){}

        /*!
        * Initalise UVC Stereo camera
        * 
        * @param camera_device_info camera device information
        */
        protected override void init(CameraDeviceInfo camera_device_info){
            m_AbstractStereoCamera_instance = CUVCStereoCamera.create(
                camera_device_info.left_camera_serial, camera_device_info.right_camera_serial, 
                camera_device_info.unique_serial, 
                camera_device_info.device_type, camera_device_info.interface_type
            );
        }
    }
}