/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file phaseversion.cs
 * @brief version functions
 * @details TODOC
 */

using System;
using System.Runtime.InteropServices;
using System.Runtime.ExceptionServices;

namespace I3DR.Phase
{
    // TODOC: Class definition
    public class PhaseVersion
    {
        // Import Phase functions from C API
        [DllImport("phase", EntryPoint = "I3DR_getVersionString", CallingConvention = CallingConvention.Cdecl)]
        private static extern string I3DR_getVersionString();

        [DllImport("phase", EntryPoint = "I3DR_getVersionMajor", CallingConvention = CallingConvention.Cdecl)]
        private static extern int I3DR_getVersionMajor();

        [DllImport("phase", EntryPoint = "I3DR_getVersionMinor", CallingConvention = CallingConvention.Cdecl)]
        private static extern int I3DR_getVersionMinor();

        [DllImport("phase", EntryPoint = "I3DR_getVersionPatch", CallingConvention = CallingConvention.Cdecl)]
        private static extern int I3DR_getVersionPatch();

        // TODOC
        public static string getVersionString(){
            // using safe integer passing rather than relying on string passing
            return getVersionMajor().ToString() + "." + getVersionMinor().ToString() + "." + getVersionPatch().ToString();
        }

        // TODOC
        public static int getVersionMajor(){
            return I3DR_getVersionMajor();
        }

        // TODOC
        public static int getVersionMinor(){
            return I3DR_getVersionMinor();
        }

        // TODOC
        public static int getVersionPatch(){
            return I3DR_getVersionPatch();
        }
    }
}