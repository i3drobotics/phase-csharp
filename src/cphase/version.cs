/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file phaseversion.cs
 * @brief version functions
 * @brief Phase version information
 */

using System;
using System.Runtime.InteropServices;
using System.Runtime.ExceptionServices;

namespace I3DR.CPhase
{
    //!  Phase Version class
    /*!
    Phase version information
    */
    public class Version
    {
        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseGetVersionString", CallingConvention = CallingConvention.Cdecl)]
        private static extern string PhaseGetVersionString();

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseGetVersionMajor", CallingConvention = CallingConvention.Cdecl)]
        private static extern int PhaseGetVersionMajor();

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseGetVersionMinor", CallingConvention = CallingConvention.Cdecl)]
        private static extern int PhaseGetVersionMinor();

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseGetVersionPatch", CallingConvention = CallingConvention.Cdecl)]
        private static extern int PhaseGetVersionPatch();

    }
}