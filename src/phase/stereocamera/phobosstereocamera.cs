/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file phobosstereocamera.cs
 * @brief Phobos Stereo Camera class
 * @details Capture data from I3DR's Phobos stereo camera.
 */

using System;
using I3DR.CPhase.StereoCamera;

namespace I3DR.Phase.StereoCamera
{
    //!  Phobos Stereo Camera class
    /*!
    Capture data from I3DR's Phobos stereo camera.
    */
    public class PhobosStereoCamera : AbstractStereoCamera
    {
        /*!
        * PhobosStereoCamera constructor \n
        * Initalise Phobos Stereo Camera with the given \p device_info.
        * 
        * @param device_info camera device information
        */
        public PhobosStereoCamera(CameraDeviceInfo camera_device_info): base(camera_device_info){}

        /*!
        * PhobosStereoCamera constructor \n
        * Initalise Phobos Stereo Camera with the given \p device_info.
        * 
        * @param abstractStereoCamera_instance stereo camera instance pointer
        */
        public PhobosStereoCamera(IntPtr abstractStereoCamera_instance): base(abstractStereoCamera_instance){}

        /*!
        * Initalise Phobos Stereo camera
        * 
        * @param camera_device_info camera device information
        */
        protected override void init(CameraDeviceInfo camera_device_info){
            m_AbstractStereoCamera_instance = CPhobosStereoCamera.create(
                camera_device_info.left_camera_serial, camera_device_info.right_camera_serial, 
                camera_device_info.unique_serial, 
                camera_device_info.device_type, camera_device_info.interface_type
            );
        }
    }
}