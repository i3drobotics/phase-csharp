/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file phaseversion.cs
 * @brief version functions
 * @details C# class for version functions export.
 * DllImports for using C type exports. Pointer to class instance
 * is passed between functions.
 */

using System;
using System.Runtime.InteropServices;
using System.Runtime.ExceptionServices;

namespace I3DR.Phase
{
    public class PhaseVersion
    {
        [DllImport("i3dr-phase_core", EntryPoint = "I3DR_getVersionString", CallingConvention = CallingConvention.Cdecl)]
        private static extern string I3DR_getVersionString();

        [DllImport("i3dr-phase_core", EntryPoint = "I3DR_getVersionMajor", CallingConvention = CallingConvention.Cdecl)]
        private static extern int I3DR_getVersionMajor();

        [DllImport("i3dr-phase_core", EntryPoint = "I3DR_getVersionMinor", CallingConvention = CallingConvention.Cdecl)]
        private static extern int I3DR_getVersionMinor();

        [DllImport("i3dr-phase_core", EntryPoint = "I3DR_getVersionPatch", CallingConvention = CallingConvention.Cdecl)]
        private static extern int I3DR_getVersionPatch();

        public static string getVersionString(){
            // using safe integer passing rather than relying on string passing
            return getVersionMajor().ToString() + "." + getVersionMinor().ToString() + "." + getVersionPatch().ToString();
        }

        public static int getVersionMajor(){
            return I3DR_getVersionMajor();
        }

        public static int getVersionMinor(){
            return I3DR_getVersionMinor();
        }

        public static int getVersionPatch(){
            return I3DR_getVersionPatch();
        }
    }
}