/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file titaniastereocamera.cs
 * @brief Titania Stereo Camera class
 * @details Capture data from I3DR's Titania stereo camera.
 */

using System;
using I3DR.CPhase.StereoCamera;

namespace I3DR.Phase.StereoCamera
{
    //!  Titania Stereo Camera class
    /*!
    Capture data from I3DR's Titania stereo camera.
    */
    public class TitaniaStereoCamera : AbstractStereoCamera
    {
         /*!
        * TitaniaStereoCamera constructor \n
        * Initalise Titania Stereo Camera with the given \p device_info.
        * 
        * @param device_info camera device information
        */
        public TitaniaStereoCamera(CameraDeviceInfo camera_device_info): base(camera_device_info){}

        /*!
        * TitaniaStereoCamera constructor \n
        * Initalise Titania Stereo Camera with the given \p device_info.
        * 
        * @param abstractStereoCamera_instance stereo camera instance pointer
        */
        public TitaniaStereoCamera(IntPtr abstractStereoCamera_instance): base(abstractStereoCamera_instance){}

        /*!
        * Initalise Titania Stereo camera
        * 
        * @param camera_device_info camera device information
        */
        protected override void init(CameraDeviceInfo camera_device_info){
            m_AbstractStereoCamera_instance = CTitaniaStereoCamera.create(
                camera_device_info.left_camera_serial, camera_device_info.right_camera_serial, 
                camera_device_info.unique_serial, 
                camera_device_info.device_type, camera_device_info.interface_type
            );
        }
    }
}