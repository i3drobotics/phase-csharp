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

namespace I3DR.Phase
{
    //!  Phase Version class
    /*!
    Phase version information
    */
    public class PhaseVersion
    {
        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_getVersionString", CallingConvention = CallingConvention.Cdecl)]
        private static extern string I3DR_getVersionString();

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_getVersionMajor", CallingConvention = CallingConvention.Cdecl)]
        private static extern int I3DR_getVersionMajor();

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_getVersionMinor", CallingConvention = CallingConvention.Cdecl)]
        private static extern int I3DR_getVersionMinor();

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_getVersionPatch", CallingConvention = CallingConvention.Cdecl)]
        private static extern int I3DR_getVersionPatch();

        /*!
        * Get the Phase version information in format "major.minor.patch"
        * 
        * @return Phase version string
        */
        public static string getVersionString(){
            // using safe integer passing rather than relying on string passing
            return getVersionMajor().ToString() + "." + getVersionMinor().ToString() + "." + getVersionPatch().ToString();
        }

        /*!
        * Get the major Phase version number
        * 
        * @return Phase major version number
        */
        public static int getVersionMajor(){
            return I3DR_getVersionMajor();
        }

        /*!
        * Get the minor Phase version number
        * 
        * @return Phase minor version number
        */
        public static int getVersionMinor(){
            return I3DR_getVersionMinor();
        }

        /*!
        * Get the patch Phase version number
        * 
        * @return Phase patch version number
        */
        public static int getVersionPatch(){
            return I3DR_getVersionPatch();
        }
    }
}