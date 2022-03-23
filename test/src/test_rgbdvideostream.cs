/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file test_rgbdvideostream.cs
 * @brief Unit tests for RGBD Video Stream class
 * @details Unit tests generated using MSTest
 */

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using I3DR;

namespace I3DR.Phase.Test
{

    [TestClass]
    public class RGBDVideoStreamTests
    {
        [TestMethod]
        public void test_RGBDVideoStream()
        {
            string camera_name = "stereotheatresim";
            string cal_type = "ros";
            string out_folder = "../../out/csharp";
            string resource_folder = "../../resources";
            string left_yaml = resource_folder+"/test/"+ camera_name +"/"+ cal_type +"/left.yaml";
            string right_yaml = resource_folder + "/test/" + camera_name + "/" + cal_type + "/right.yaml";
            string left_image_file = resource_folder + "/test/" + camera_name + "/left.png";
            string right_image_file = resource_folder + "/test/" + camera_name + "/right.png";
            string out_rgb_video = out_folder + "/rgb.mp4";
            string out_depth_video = out_folder + "/depth.avi";

            Directory.CreateDirectory(out_folder);

            int num_of_frames = 1;

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

            Console.WriteLine("Setting up video writing...");
            RGBDVideoWriter rgbdVideoWriter = new RGBDVideoWriter(
                out_rgb_video, out_depth_video,
                left_image.getColumns(), left_image.getRows()
            );
            Assert.IsTrue(rgbdVideoWriter.isOpened());
            Console.WriteLine("Writing video...");
            for (int i = 0; i < num_of_frames; i++){
                rgbdVideoWriter.add(rect_image_pair.left, depth);
            }

            Console.WriteLine("Saving video file...");
            rgbdVideoWriter.saveThreaded();
            while(rgbdVideoWriter.isSaveThreadRunning()){}
            Assert.IsTrue(rgbdVideoWriter.getSaveThreadResult());

            Console.WriteLine("Loading video stream...");
            RGBDVideoStream rgbdVideoStream = new RGBDVideoStream(
                out_rgb_video, out_depth_video,
                left_image.getColumns(), left_image.getRows()
            );
            Assert.IsTrue(rgbdVideoStream.isOpened());
            rgbdVideoStream.loadThreaded();
            while(rgbdVideoStream.isLoadThreadRunning()){};
            Assert.IsTrue(rgbdVideoStream.getLoadThreadResult());

            // cv::Mat depth16;
            // depth.convertTo(depth16, CV_16UC1, 6553.5);
            // depth16.convertTo(depth16, CV_32FC1, 1/6553.5);
            float[] depth_sim_input = new float[disparity.getLength()];
            depth.CopyTo(depth_sim_input, 0);

            for (int i = 0; i < disparity.getRows(); i++){
                for (int j = 0; j < disparity.getColumns(); j++){
                    float val = depth_sim_input[i * disparity.getColumns() + j];
                    val *= 6553.5f;
                    // TODO replace Math.Round here as it is very slow
                    ushort sval = (ushort)(Math.Round(val));
                    float fval = (float)sval;
                    fval *= (1.0f/6553.5f);
                    depth_sim_input[i * disparity.getColumns() + j] = fval;
                }
            }

            // float min_resolv = 10.0f / 65535.0f;

            Console.WriteLine("Streaming video...");
            while(!rgbdVideoStream.isFinished()){
                RGBDVideoFrame frame = rgbdVideoStream.read();
                Assert.IsTrue(Utils.cvMatIsEqual(frame.depth, depth_sim_input, image_width, image_height, 1));
            }
            Console.WriteLine("Closing video stream...");
            rgbdVideoStream.close();

            Console.WriteLine("Done.");

            rgbdVideoWriter.dispose();
            rgbdVideoStream.dispose();
        }
    }
}
