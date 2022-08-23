/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file phaseversion.cs
 * @brief version functions
 * @brief Phase version information
 */

using System.Runtime.InteropServices;

namespace I3DR.CPhase
{
    //!  Phase Version class
    /*!
    Phase version information
    */
    public class CVersion
    {
        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseGetVersionString", CallingConvention = CallingConvention.Cdecl)]
        public static extern string getVersionString();

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseGetVersionMajor", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getVersionMajor();

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseGetVersionMinor", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getVersionMinor();

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseGetVersionPatch", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getVersionPatch();

    }
}