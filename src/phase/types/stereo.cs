/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file stereo.cs
 * @brief Stereo types.
 * @brief Stereo types used in Phase
 */

namespace I3DR.Phase.Types
{

    //!  Stereo Image Pair structure
    /*!
    Struture to store stereo image pair (left, right)
    */
    public struct StereoImagePair
    {
        public byte[] left; //!< left image
        public byte[] right; //!< right image

        public StereoImagePair(byte[] left, byte[] right)
        {
            this.left = left;
            this.right = right;
        }
    }
}