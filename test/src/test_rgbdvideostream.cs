/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file test_rgbdvideostream.cs
 * @brief Unit tests for RGBD Video Stream class
 * @details Unit tests generated using MSTest
 */

using Xunit;
using System;
using System.IO;
using I3DR;

namespace I3DR.Phase.Test
{

    public class RGBDVideoStreamTests
    {
        [Fact]
        public void test_RGBDVideoStream()
        {
            string test_folder = ".phase_test";
            string data_folder = "../../../../data";
            string left_image_file = data_folder + "/left.png";
            string right_image_file = data_folder + "/right.png";
            string left_yaml = test_folder + "/left.yaml";
            string right_yaml = test_folder + "/right.yaml";
            string out_rgb_video = test_folder + "/rgb.mp4";
            string out_depth_video = test_folder + "/depth.avi";

            Directory.CreateDirectory(test_folder);

            Console.WriteLine("Generating test data...");

            string left_yaml_data = "" +
                "image_width: 2448\n" +
                "image_height: 2048\n" +
                "camera_name: leftCamera\n" +
                "camera_matrix:\n" +
                "   rows: 3\n" +
                "   cols: 3\n" +
                "   data: [ 3.4782608695652175e+03, 0., 1224., 0., 3.4782608695652175e+03, 1024., 0., 0., 1. ]\n" +
                "distortion_model: plumb_bob\n" +
                "distortion_coefficients:\n" +
                "   rows: 1\n" +
                "   cols: 5\n" +
                "   data: [ 0., 0., 0., 0., 0. ]\n" +
                "rectification_matrix:\n" +
                "   rows: 3\n" +
                "   cols: 3\n" +
                "   data: [1., 0., 0., 0., 1., 0., 0., 0., 1.]\n" +
                "projection_matrix:\n" +
                "   rows: 3\n" +
                "   cols: 4\n" +
                "   data: [ 3.4782608695652175e+03, 0., 1224., 0., 0., 3.4782608695652175e+03, 1024., 0., 0., 0., 1., 0. ]\n";
            string right_yaml_data = "" +
                "image_width: 2448\n" +
                "image_height: 2048\n" +
                "camera_name: rightCamera\n" +
                "camera_matrix:\n" +
                "   rows: 3\n" +
                "   cols: 3\n" +
                "   data: [ 3.4782608695652175e+03, 0., 1224., 0., 3.4782608695652175e+03, 1024., 0., 0., 1. ]\n" +
                "distortion_model: plumb_bob\n" +
                "distortion_coefficients:\n" +
                "   rows: 1\n" +
                "   cols: 5\n" +
                "   data: [ 0., 0., 0., 0., 0. ]\n" +
                "rectification_matrix:\n" +
                "   rows: 3\n" +
                "   cols: 3\n" +
                "   data: [1., 0., 0., 0., 1., 0., 0., 0., 1.]\n" +
                "projection_matrix:\n" +
                "   rows: 3\n" +
                "   cols: 4\n" +
                "   data: [ 3.4782608695652175e+03, 0., 1224., -3.4782608695652175e+02, 0., 3.4782608695652175e+03, 1024., 0., 0., 0., 1., 0. ]\n";

            File.WriteAllText(left_yaml, left_yaml_data);
            File.WriteAllText(right_yaml, right_yaml_data);

            int num_of_frames = 1;

            Console.WriteLine("Loading test images...");
            //TODO get image size from file
            int image_width = 2448;
            int image_height = 2048;
            byte[] left_image_cv = Utils.readImage(left_image_file, image_width, image_height);
            byte[] right_image_cv = Utils.readImage(right_image_file, image_width, image_height);

            Assert.True(left_image_cv.Length != 0);
            Assert.True(right_image_cv.Length != 0);

            StereoCameraCalibration calibration = StereoCameraCalibration.calibrationFromYAML(left_yaml, right_yaml);

            Assert.True(calibration.isValid());

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

            Assert.True(!disparity.isEmpty());

            float[] disparity_cv = new float[disparity.getLength()];
            disparity_cv = disparity.getData();

            float[] depth = Utils.disparity2Depth(disparity_cv, image_width, image_height, calibration.getQ());

            Assert.True(depth.Length != 0);

            Console.WriteLine("Setting up video writing...");
            RGBDVideoWriter rgbdVideoWriter = new RGBDVideoWriter(
                out_rgb_video, out_depth_video,
                left_image.getColumns(), left_image.getRows()
            );
            Assert.True(rgbdVideoWriter.isOpened());
            Console.WriteLine("Writing video...");
            for (int i = 0; i < num_of_frames; i++){
                rgbdVideoWriter.add(rect_image_pair.left, depth);
            }

            Console.WriteLine("Saving video file...");
            rgbdVideoWriter.saveThreaded();
            while(rgbdVideoWriter.isSaveThreadRunning()){}
            Assert.True(rgbdVideoWriter.getSaveThreadResult());

            Console.WriteLine("Loading video stream...");
            RGBDVideoStream rgbdVideoStream = new RGBDVideoStream(
                out_rgb_video, out_depth_video,
                left_image.getColumns(), left_image.getRows()
            );
            Assert.True(rgbdVideoStream.isOpened());
            rgbdVideoStream.loadThreaded();
            while(rgbdVideoStream.isLoadThreadRunning()){};
            Assert.True(rgbdVideoStream.getLoadThreadResult());

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
                Assert.True(Utils.cvMatIsEqual(frame.depth, depth_sim_input, image_width, image_height, 1));
            }
            Console.WriteLine("Closing video stream...");
            rgbdVideoStream.close();

            Console.WriteLine("Done.");

            rgbdVideoWriter.dispose();
            rgbdVideoStream.dispose();
        }
    }
}
