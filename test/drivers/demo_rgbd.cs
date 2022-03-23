/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file main.cs
 * @brief Example application using I3DR Stereo Vision C# API
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace I3DR
{
    namespace Phase
    {
        class ImageViewer
        {
            private Form form;
            private PictureBox pm;
            public ImageViewer(){
                form = new Form(){
                    FormBorderStyle = FormBorderStyle.FixedDialog
                };
                pm = new PictureBox(){
                    Dock = DockStyle.Fill
                };
                form.Controls.Add(pm);
            }

            public void setImage(byte[] byte_image, int width, int height, int stride){
                Bitmap bit_image = new Bitmap(width, height, stride, 
                    PixelFormat.Format32bppArgb,
                    Marshal.UnsafeAddrOfPinnedArrayElement(byte_image, 0));
                form.Size = new Size(width,height+25);
                pm.Image = bit_image;
            }

            public void show(int wait_time=10){
                form.TopMost = true;
                if (wait_time == 0){
                    form.ShowDialog();
                } else {
                    form.Show();
                    form.Refresh();
                    System.Threading.Thread.Sleep(wait_time);
                }
            }
        }

        class DemoRGBD
        {
            static int Main(string[] args)
            {
                string camera_name = "stereotheatresim";
                string cal_type = "ros";
                string out_folder = "out/csharp";
                string resource_folder = "resources";
                string left_yaml = resource_folder + "/test/" + camera_name + "/" + cal_type + "/left.yaml";
                string right_yaml = resource_folder + "/test/" + camera_name + "/" + cal_type + "/right.yaml";
                string left_image_file = resource_folder + "/test/" + camera_name + "/left.png";
                string right_image_file = resource_folder + "/test/" + camera_name + "/right.png";
                string out_rgb_video = out_folder + "/rgb.mp4";
                string out_depth_video = out_folder + "/depth.avi";

                int num_of_frames = 1;

                Console.WriteLine("Loading test images...");
                //TODO get image size from file
                int image_width = 2448;
                int image_height = 2048;
                byte[] left_image_cv = Utils.readImage(left_image_file, image_width, image_height);
                byte[] right_image_cv = Utils.readImage(right_image_file, image_width, image_height);

                if (left_image_cv.Length == 0) { return 1; }
                if (right_image_cv.Length == 0) { return 1; }

                StereoCameraCalibration calibration = StereoCameraCalibration.calibrationFromYAML(left_yaml, right_yaml);

                if (!calibration.isValid()) { return 1; }

                StereoImagePair rect_image_pair = calibration.rectify(left_image_cv, right_image_cv, image_width, image_height);

                int image_rows = 2048;
                int image_cols = 2448;
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

                if (disparity.isEmpty()) { return 1; }

                float[] disparity_cv = new float[disparity.getLength()];
                disparity_cv = disparity.getData();

                float[] depth = Utils.disparity2Depth(disparity_cv, image_width, image_height, calibration.getQ());

                if (depth.Length == 0) { return 1; }

                Console.WriteLine("Setting up video writing...");
                RGBDVideoWriter rgbdVideoWriter = new RGBDVideoWriter(
                    out_rgb_video, out_depth_video,
                    left_image.getColumns(), left_image.getRows()
                );
                if (!rgbdVideoWriter.isOpened()) { return 1; }
                Console.WriteLine("Writing video...");
                for (int i = 0; i < num_of_frames; i++)
                {
                    rgbdVideoWriter.add(rect_image_pair.left, depth);
                }

                Console.WriteLine("Saving video file...");
                rgbdVideoWriter.saveThreaded();
                while (rgbdVideoWriter.isSaveThreadRunning()) { }
                if (!rgbdVideoWriter.getSaveThreadResult()) { return 1; }

                Console.WriteLine("Loading video stream...");
                RGBDVideoStream rgbdVideoStream = new RGBDVideoStream(
                    out_rgb_video, out_depth_video,
                    left_image.getColumns(), left_image.getRows()
                );
                if (!rgbdVideoStream.isOpened()) { return 1; }
                rgbdVideoStream.loadThreaded();
                while (rgbdVideoStream.isLoadThreadRunning()) { };
                if (!rgbdVideoStream.getLoadThreadResult()) { return 1; }

                float[] depth_sim_input = new float[disparity.getLength()];
                depth.CopyTo(depth_sim_input, 0);

                for (int i = 0; i < disparity.getRows(); i++)
                {
                    for (int j = 0; j < disparity.getColumns(); j++)
                    {
                        float val = depth_sim_input[i * disparity.getColumns() + j];
                        val *= 6553.5f;
                        // TODO replace Math.Round here as it is very slow
                        ushort sval = (ushort)(Math.Round(val));
                        float fval = (float)sval;
                        fval *= (1.0f / 6553.5f);
                        depth_sim_input[i * disparity.getColumns() + j] = fval;
                    }
                }

                float min_resolv = 10.0f / 65535.0f;

                Console.WriteLine("Streaming video...");
                while (!rgbdVideoStream.isFinished())
                {
                    RGBDVideoFrame frame = rgbdVideoStream.read();
                    for (int i = 0; i < disparity.getRows(); i++)
                    {
                        for (int j = 0; j < disparity.getColumns(); j++)
                        {
                            float in_val = depth_sim_input[i * disparity.getColumns() + j];
                            float out_val = frame.depth[i * disparity.getColumns() + j];
                            float diff = Math.Abs(in_val - out_val);
                            if (diff > min_resolv) {
                                Console.WriteLine(String.Format("RGBD video depth value difference from origional is {0} which is greater miniumum {1}", diff, min_resolv));
                                return 1;
                            }
                        }
                    }
                    if (!Utils.cvMatIsEqual(frame.depth, depth_sim_input, image_width, image_height, 1)){
                        Console.WriteLine(String.Format("Loaded RGBD video depth image differs from origional"));
                        rgbdVideoStream.close();
                        return 1;
                    }
                }
                Console.WriteLine("Closing video stream...");
                rgbdVideoStream.close();

                Console.WriteLine("Done.");

                rgbdVideoWriter.dispose();
                rgbdVideoStream.dispose();

                return 0;
            }
        }
    }
}