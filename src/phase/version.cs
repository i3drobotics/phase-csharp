/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file phaseversion.cs
 * @brief version functions
 * @brief Phase version information
 */

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
        public static string getAPIVersionString(){
            // using safe integer passing rather than relying on string passing
            return getAPIVersionMajor().ToString() + "." + getAPIVersionMinor().ToString() + "." + getAPIVersionPatch().ToString();
        }

        /*!
        * Get the major Phase version number
        * 
        * @return Phase major version number
        */
        public static int getAPIVersionMajor(){
            return CVersion.getVersionMajor();
        }

        /*!
        * Get the minor Phase version number
        * 
        * @return Phase minor version number
        */
        public static int getAPIVersionMinor(){
            return CVersion.getVersionMinor();
        }

        /*!
        * Get the patch Phase version number
        * 
        * @return Phase patch version number
        */
        public static int getAPIVersionPatch(){
            return CVersion.getVersionPatch();
        }
    }
}