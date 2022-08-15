/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-06-28
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file rgbdvideostream.cs
 * @brief RGBD Video Stream class
 * @details Stream RGBD video from an mp4 file
 */

using System;
using System.Runtime.InteropServices;
using System.Runtime.ExceptionServices;

namespace I3DR.Phase
{
    //!  RGBD Video Stream class
    /*!
    Stream RGBD video from an mp4 file
    */
    public class RGBDVideoStream
    {
        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_RGBDVideoStream_create", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr RGBDVideoStream_create(string rgb_video_filepath, string depth_video_filepath, int width, int height);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_RGBDVideoStream_CGetWidth", CallingConvention = CallingConvention.Cdecl)]
        private static extern int RGBDVideoStream_getWidth(IntPtr stream);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_RGBDVideoStream_CGetHeight", CallingConvention = CallingConvention.Cdecl)]
        private static extern int RGBDVideoStream_getHeight(IntPtr stream);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_RGBDVideoStream_CLoad", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool RGBDVideoStream_load(IntPtr stream);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_RGBDVideoStream_CLoadThreaded", CallingConvention = CallingConvention.Cdecl)]
        private static extern void RGBDVideoStream_loadThreaded(IntPtr stream);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_RGBDVideoStream_CIsLoadThreadRunning", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool RGBDVideoStream_isLoadThreadRunning(IntPtr stream);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_RGBDVideoStream_CGetLoadThreadResult", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool RGBDVideoStream_getLoadThreadResult(IntPtr stream);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_RGBDVideoStream_CRestart", CallingConvention = CallingConvention.Cdecl)]
        private static extern void RGBDVideoStream_restart(IntPtr stream);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_RGBDVideoStream_CRead", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool RGBDVideoStream_read(IntPtr stream, [Out] byte[] rgb, [Out] float[] depth);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_RGBDVideoStream_CGetReadThreadResult", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool RGBDVideoStream_getReadThreadResult(IntPtr stream, [Out] byte[] rgb, [Out] float[] depth);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_RGBDVideoStream_CReadThreaded", CallingConvention = CallingConvention.Cdecl)]
        private static extern void RGBDVideoStream_readThreaded(IntPtr stream);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_RGBDVideoStream_CIsReadThreadRunning", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool RGBDVideoStream_isReadThreadRunning(IntPtr stream);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_RGBDVideoStream_CIsOpened", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool RGBDVideoStream_isOpened(IntPtr stream);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_RGBDVideoStream_CIsLoaded", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool RGBDVideoStream_isLoaded(IntPtr stream);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_RGBDVideoStream_CIsFinished", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool RGBDVideoStream_isFinished(IntPtr stream);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_RGBDVideoStream_CGetHFOV", CallingConvention = CallingConvention.Cdecl)]
        private static extern float RGBDVideoStream_getHFOV(IntPtr stream);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_RGBDVideoStream_CGetDownsampleFactor", CallingConvention = CallingConvention.Cdecl)]
        private static extern float RGBDVideoStream_getDownsampleFactor(IntPtr stream);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_RGBDVideoStream_CSetDownsampleFactor", CallingConvention = CallingConvention.Cdecl)]
        private static extern void RGBDVideoStream_setDownsampleFactor(IntPtr stream, float value);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_RGBDVideoStream_CClose", CallingConvention = CallingConvention.Cdecl)]
        private static extern void RGBDVideoStream_close(IntPtr stream);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_RGBDVideoStream_dispose", CallingConvention = CallingConvention.Cdecl)]
        private static extern void RGBDVideoStream_dispose(IntPtr stream);

        private IntPtr m_RGBDVideoStream_instance; //!< pointer to RGBDVideoStream C API instance
        private byte[] rgb; //!< stores rgb image
        private float[] depth; //!< store depth image

        /*!
        * RGBD Video Stream constructor \n
        * Initalise RGBD Video Stream with provided rgb and depth video file paths.
        * 
        * @param rgb_video_filepath filepath of rgb video file
        * @param depth_video_filepath filepath of depth video file
        * @param width width of images in video stream
        * @param height height of images in video stream
        */
        public RGBDVideoStream(string rgb_video_filepath, string depth_video_filepath, int width, int height)
        {
            m_RGBDVideoStream_instance = RGBDVideoStream_create(rgb_video_filepath, depth_video_filepath, width, height);
        }

        /*!
        * Get width of image in RGBD video stream
        * 
        * @return image width
        */
        public int getWidth(){
            return RGBDVideoStream_getWidth(m_RGBDVideoStream_instance);
        }

        /*!
        * Get height of image in RGBD video stream
        * 
        * @return image height
        */
        public int getHeight(){
            return RGBDVideoStream_getHeight(m_RGBDVideoStream_instance);
        }

        /*!
        * Load frames from video files (both and rgb and depth)
        * 
        * @return success of loading
        */
        public bool load(){
            return RGBDVideoStream_load(m_RGBDVideoStream_instance);
        }

        /*!
        * Load frames from video files (both and rgb and depth) in threaded process \n
        * Get success of loading process from getLoadThreadResult()
        * 
        */
        public void loadThreaded(){
            RGBDVideoStream_loadThreaded(m_RGBDVideoStream_instance);
        }

        /*!
        * Check if load thread process is running \n
        * Use with loadThreaded()
        * 
        * @return true if load thread is running
        */
        public bool isLoadThreadRunning(){
            return RGBDVideoStream_isLoadThreadRunning(m_RGBDVideoStream_instance);
        }

        /*!
        * Get success of load when run in thread \n
        * Use with loadThreaded()
        * 
        * @return success of load
        */
        public bool getLoadThreadResult(){
            return RGBDVideoStream_getLoadThreadResult(m_RGBDVideoStream_instance);
        }

        /*!
        * Restart video stream to first frame
        * 
        */
        public void restart(){
            RGBDVideoStream_restart(m_RGBDVideoStream_instance);
        }

        /*!
        * Read next frame from video stream
        * 
        * @return data from next RGBD video frame
        */
        public RGBDVideoFrame read()
        {
            int image_size = getWidth() * getHeight();
            if (rgb == null){
                rgb = new byte[image_size * 3];
            }
            if (depth == null){
                depth = new float[image_size];
            }
            bool valid = RGBDVideoStream_read(
                m_RGBDVideoStream_instance, rgb, depth
            );
            RGBDVideoFrame frame = new RGBDVideoFrame(valid, rgb, depth);
            return frame;
        }

        /*!
        * Get RGBD video frame data from read when run in thread \n
        * Use with readThreaded()
        * 
        * @return RGBD video frame
        */
        public RGBDVideoFrame getReadThreadResult()
        {
            int image_size = getWidth() * getHeight();
            if (rgb == null){
                rgb = new byte[image_size * 3];
            }
            if (depth == null){
                depth = new float[image_size];
            }
            bool valid = RGBDVideoStream_getReadThreadResult(
                m_RGBDVideoStream_instance, rgb, depth
            );
            RGBDVideoFrame frame = new RGBDVideoFrame(valid, rgb, depth);
            return frame;
        }

        /*!
        * Read next frame from video stream in threaded process \n
        * Get data from next RGBD video frame from getReadThreadResult()
        * 
        */
        public void readThreaded(){
            RGBDVideoStream_readThreaded(m_RGBDVideoStream_instance);
        }

        /*!
        * Get success of read when run in thread \n
        * Use with readThreaded()
        * 
        * @return success of read
        */
        public bool isReadThreadRunning(){
            return RGBDVideoStream_isReadThreadRunning(m_RGBDVideoStream_instance);
        }

        /*!
        * Check if RGBD video stream is open
        * 
        * @return true if open
        */
        public bool isOpened(){
            return RGBDVideoStream_isOpened(m_RGBDVideoStream_instance);
        }

        /*!
        * Check if RGBD video stream data has been loaded
        * 
        * @return true if loaded
        */
        public bool isLoaded(){
            return RGBDVideoStream_isLoaded(m_RGBDVideoStream_instance);
        }

        /*!
        * Check if at the end of the RGBD video stream
        * 
        * @return true if RGBD video stream is at end
        */
        public bool isFinished(){
            return RGBDVideoStream_isFinished(m_RGBDVideoStream_instance);
        }

        /*!
        * Get camera horizontal FOV that captured RGBD video stream
        * 
        * @return camera horizontal FOV
        */
        public float getHFOV(){
            return RGBDVideoStream_getHFOV(m_RGBDVideoStream_instance);
        }

        /*!
        * Get current downsample factor applied to RGBD video stream
        * 
        * @return downsample factor
        */
        public float getDownsampleFactor(){
            return RGBDVideoStream_getDownsampleFactor(m_RGBDVideoStream_instance);
        }

        /*!
        * Set downsample factor to apply to RGBD video stream
        * 
        * @param value downsample factor value
        */
        public void setDownsampleFactor(float value){
            RGBDVideoStream_setDownsampleFactor(m_RGBDVideoStream_instance, value);
        }

        /*!
        * Close RGBD video stream
        * 
        */
        public void close(){
            RGBDVideoStream_close(m_RGBDVideoStream_instance);
        }

        /*!
        * Manually dispose instance of RGBD Video Writer class
        * 
        */
        // [HandleProcessCorruptedStateExceptions]
        public void dispose(){
            
            if (m_RGBDVideoStream_instance != IntPtr.Zero)
            {
                try
                {
                    RGBDVideoStream_dispose(m_RGBDVideoStream_instance);
                }
                catch (AccessViolationException e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine("Please call 'dispose()' to make sure memory is freed.");
                }
                m_RGBDVideoStream_instance = IntPtr.Zero;
            }
        }

        ~RGBDVideoStream()
        {
            dispose();
        }
    }
}