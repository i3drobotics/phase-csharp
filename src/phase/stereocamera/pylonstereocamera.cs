/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file pylonstereocamera.cs
 * @brief Pylon Stereo Camera class
 * @details Capture data from a stereo camera using Basler cameras.
 */

using I3DR.CPhase;

namespace I3DR.Phase
{
    //!  Pylon Stereo Camera class
    /*!
    Capture data from a stereo camera using Basler cameras via the Pylon API
    */
    public class PylonStereoCamera : AbstractStereoCamera
    {
        /*!
        * PylonStereoCamera constructor \n
        * Initalise Pylon Stereo Camera with the given \p device_info.
        * 
        * @param device_info camera device information
        */
        public PylonStereoCamera(CameraDeviceInfo camera_device_info): base(camera_device_info){}

        /*!
        * Initalise Pylon Stereo camera
        * 
        * @param camera_device_info camera device information
        */
        protected override void init(CameraDeviceInfo camera_device_info){
            m_AbstractStereoCamera_instance = CPylonStereoCamera.PhasePylonStereoCameraCreate(
                camera_device_info.left_camera_serial, camera_device_info.right_camera_serial, 
                camera_device_info.unique_serial, 
                camera_device_info.device_type, camera_device_info.interface_type
            );
        }
    }
}