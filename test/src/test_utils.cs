/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file test_utils.cs
 * @brief Unit tests for Stereo Support class
 * @details Unit tests generated using MSTest
 */

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using I3DR;

namespace I3DR.Phase.Test
{

    [TestClass]
    public class UtilsTests
    {
        [TestMethod]
        public void test_Utils_checkEqualMat()
        {
            // Create equal matrices
            int width = 3;
            int height = 3;
            int channels = 1;
            float[] mat_a = new float[width*height*channels];
            float[] mat_b = new float[width*height*channels];
            for (int i = 0; i < width*height*channels; i++){
                mat_a[i] = 1.0f;
                mat_b[i] = 1.0f;
            }

            // Check equal is equal check is correct
            Assert.IsTrue(Utils.cvMatIsEqual(mat_a, mat_b, width, height, channels));

            // Change one element to make it not equal
            mat_a[0] = 0.0f;

            // Check is not equal check is correct
            Assert.IsTrue(!Utils.cvMatIsEqual(mat_a, mat_b, width, height, channels));
        }

        [TestMethod]
        public void test_Utils_savePLY()
        {
            string camera_name = "stereotheatresim";
            string cal_type = "ros";
            string out_folder = "../../out/csharp";
            string resource_folder = "../../resources";
            string left_yaml = resource_folder+"/test/"+ camera_name +"/"+ cal_type +"/left.yaml";
            string right_yaml = resource_folder + "/test/" + camera_name + "/" + cal_type + "/right.yaml";
            string left_image_file = resource_folder + "/test/" + camera_name + "/left.png";
            string right_image_file = resource_folder + "/test/" + camera_name + "/right.png";
            string out_ply = out_folder + "/out.ply";

            Directory.CreateDirectory(out_folder);

            Console.WriteLine("Loading test images...");
            //TODO get image size from file
            int image_width = 2448;
            int image_height = 2048;
            byte[] left_image_cv = Utils.readImage(left_image_file, image_width, image_height);
            byte[] right_image_cv = Utils.readImage(right_image_file, image_width, image_height);

            Assert.IsTrue(left_image_cv.Length != 0);
            Assert.IsTrue(right_image_cv.Length != 0);

            StereoCameraCalibration calibration = StereoCameraCalibration.calibrationFromYAML(left_yaml, right_yaml);

            Assert.IsTrue(calibration.isValid());

            StereoImagePair rect_image_pair = calibration.rectify(left_image_cv, right_image_cv, image_width, image_height);

            int image_rows = image_height;
            int image_cols = image_width;
            int image_channels = 3;
            
            MatrixUInt8 left_image = new MatrixUInt8(
                image_rows, image_cols, image_channels,
                rect_image_pair.left, true);
            MatrixUInt8 right_image = new MatrixUInt8(
                image_rows, image_cols, image_channels,
                rect_image_pair.right, true);

            Console.WriteLine("Processing stereo...");
            StereoParams stereo_params = new StereoParams(
                StereoMatcherType.STEREO_MATCHER_BM,
                11, 0, 25, false
            );
            MatrixFloat disparity = StereoProcess.processStereo(
                stereo_params, left_image, right_image, calibration, false
            );

            Assert.IsTrue(!disparity.isEmpty());

            float[] disparity_cv = new float[disparity.getLength()];
            disparity_cv = disparity.getData();

            float[] depth = Utils.disparity2Depth(disparity_cv, image_width, image_height, calibration.getQ());

            Assert.IsTrue(depth.Length != 0);

            float[] xyz = Utils.depth2xyz(depth, image_width, image_height, calibration.getHFOV());

            Utils.savePLY(out_ply, xyz, rect_image_pair.left, image_width, image_height);
        }
    }
}
