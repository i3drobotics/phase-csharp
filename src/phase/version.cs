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
using I3DR.CPhase;

namespace I3DR.Phase
{
    //!  Phase Version class
    /*!
    Phase version information
    */
    public class Version
    {

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
            return PhaseGetVersionMajor();
        }

        /*!
        * Get the minor Phase version number
        * 
        * @return Phase minor version number
        */
        public static int getVersionMinor(){
            return PhaseGetVersionMinor();
        }

        /*!
        * Get the patch Phase version number
        * 
        * @return Phase patch version number
        */
        public static int getVersionPatch(){
            return PhaseGetVersionPatch();
        }
    }
}