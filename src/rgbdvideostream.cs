/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-06-28
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file rgbdvideostream.cs
 * @brief RGBD Video Stream class
 * @details TODOC
 */

using System;
using System.Runtime.InteropServices;
using System.Runtime.ExceptionServices;

namespace I3DR.Phase
{
    // TODOC: Class definition
    public class RGBDVideoStream
    {
        // Import Phase functions from C API
        [DllImport("phase", EntryPoint = "I3DR_RGBDVideoStream_create", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr RGBDVideoStream_create(string rgb_video_filepath, string depth_video_filepath, int width, int height);

        [DllImport("phase", EntryPoint = "I3DR_RGBDVideoStream_CGetWidth", CallingConvention = CallingConvention.Cdecl)]
        private static extern int RGBDVideoStream_getWidth(IntPtr stream);

        [DllImport("phase", EntryPoint = "I3DR_RGBDVideoStream_CGetHeight", CallingConvention = CallingConvention.Cdecl)]
        private static extern int RGBDVideoStream_getHeight(IntPtr stream);

        [DllImport("phase", EntryPoint = "I3DR_RGBDVideoStream_CLoad", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool RGBDVideoStream_load(IntPtr stream);

        [DllImport("phase", EntryPoint = "I3DR_RGBDVideoStream_CLoadThreaded", CallingConvention = CallingConvention.Cdecl)]
        private static extern void RGBDVideoStream_loadThreaded(IntPtr stream);

        [DllImport("phase", EntryPoint = "I3DR_RGBDVideoStream_CIsLoadThreadRunning", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool RGBDVideoStream_isLoadThreadRunning(IntPtr stream);

        [DllImport("phase", EntryPoint = "I3DR_RGBDVideoStream_CGetLoadThreadResult", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool RGBDVideoStream_getLoadThreadResult(IntPtr stream);

        [DllImport("phase", EntryPoint = "I3DR_RGBDVideoStream_CRestart", CallingConvention = CallingConvention.Cdecl)]
        private static extern void RGBDVideoStream_restart(IntPtr stream);

        [DllImport("phase", EntryPoint = "I3DR_RGBDVideoStream_CRead", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool RGBDVideoStream_read(IntPtr stream, [Out] byte[] rgb, [Out] float[] depth);

        [DllImport("phase", EntryPoint = "I3DR_RGBDVideoStream_CGetReadThreadResult", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool RGBDVideoStream_getReadThreadResult(IntPtr stream, [Out] byte[] rgb, [Out] float[] depth);

        [DllImport("phase", EntryPoint = "I3DR_RGBDVideoStream_CReadThreaded", CallingConvention = CallingConvention.Cdecl)]
        private static extern void RGBDVideoStream_readThreaded(IntPtr stream);

        [DllImport("phase", EntryPoint = "I3DR_RGBDVideoStream_CIsReadThreadRunning", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool RGBDVideoStream_isReadThreadRunning(IntPtr stream);

        [DllImport("phase", EntryPoint = "I3DR_RGBDVideoStream_CIsOpened", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool RGBDVideoStream_isOpened(IntPtr stream);

        [DllImport("phase", EntryPoint = "I3DR_RGBDVideoStream_CIsLoaded", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool RGBDVideoStream_isLoaded(IntPtr stream);

        [DllImport("phase", EntryPoint = "I3DR_RGBDVideoStream_CIsFinished", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool RGBDVideoStream_isFinished(IntPtr stream);

        [DllImport("phase", EntryPoint = "I3DR_RGBDVideoStream_CGetHFOV", CallingConvention = CallingConvention.Cdecl)]
        private static extern float RGBDVideoStream_getHFOV(IntPtr stream);

        [DllImport("phase", EntryPoint = "I3DR_RGBDVideoStream_CGetDownsampleFactor", CallingConvention = CallingConvention.Cdecl)]
        private static extern float RGBDVideoStream_getDownsampleFactor(IntPtr stream);

        [DllImport("phase", EntryPoint = "I3DR_RGBDVideoStream_CSetDownsampleFactor", CallingConvention = CallingConvention.Cdecl)]
        private static extern void RGBDVideoStream_setDownsampleFactor(IntPtr stream, float value);

        [DllImport("phase", EntryPoint = "I3DR_RGBDVideoStream_CClose", CallingConvention = CallingConvention.Cdecl)]
        private static extern void RGBDVideoStream_close(IntPtr stream);

        [DllImport("phase", EntryPoint = "I3DR_RGBDVideoStream_dispose", CallingConvention = CallingConvention.Cdecl)]
        private static extern void RGBDVideoStream_dispose(IntPtr stream);

        private IntPtr m_RGBDVideoStream_instance; // TODOC
        private byte[] rgb; // TODOC
        private float[] depth; // TODOC

        // TODOC
        public RGBDVideoStream(string rgb_video_filepath, string depth_video_filepath, int width, int height)
        {
            m_RGBDVideoStream_instance = RGBDVideoStream_create(rgb_video_filepath, depth_video_filepath, width, height);
        }

        // TODOC
        public int getWidth(){
            return RGBDVideoStream_getWidth(m_RGBDVideoStream_instance);
        }

        // TODOC
        public int getHeight(){
            return RGBDVideoStream_getHeight(m_RGBDVideoStream_instance);
        }

        // TODOC
        public bool load(){
            return RGBDVideoStream_load(m_RGBDVideoStream_instance);
        }

        // TODOC
        public void loadThreaded(){
            RGBDVideoStream_loadThreaded(m_RGBDVideoStream_instance);
        }

        // TODOC
        public bool isLoadThreadRunning(){
            return RGBDVideoStream_isLoadThreadRunning(m_RGBDVideoStream_instance);
        }

        // TODOC
        public bool getLoadThreadResult(){
            return RGBDVideoStream_getLoadThreadResult(m_RGBDVideoStream_instance);
        }

        // TODOC
        public void restart(){
            RGBDVideoStream_restart(m_RGBDVideoStream_instance);
        }

        // TODOC
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

        // TODOC
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

        // TODOC
        public void readThreaded(){
            RGBDVideoStream_readThreaded(m_RGBDVideoStream_instance);
        }

        // TODOC
        public bool isReadThreadRunning(){
            return RGBDVideoStream_isReadThreadRunning(m_RGBDVideoStream_instance);
        }

        // TODOC
        public bool isOpened(){
            return RGBDVideoStream_isOpened(m_RGBDVideoStream_instance);
        }

        // TODOC
        public bool isLoaded(){
            return RGBDVideoStream_isLoaded(m_RGBDVideoStream_instance);
        }

        // TODOC
        public bool isFinished(){
            return RGBDVideoStream_isFinished(m_RGBDVideoStream_instance);
        }

        // TODOC
        public float getHFOV(){
            return RGBDVideoStream_getHFOV(m_RGBDVideoStream_instance);
        }

        // TODOC
        public float getDownsampleFactor(){
            return RGBDVideoStream_getDownsampleFactor(m_RGBDVideoStream_instance);
        }

        // TODOC
        public void setDownsampleFactor(float value){
            RGBDVideoStream_setDownsampleFactor(m_RGBDVideoStream_instance, value);
        }

        // TODOC
        public void close(){
            RGBDVideoStream_close(m_RGBDVideoStream_instance);
        }

        // TODOC
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

        // TODOC
        ~RGBDVideoStream()
        {
            dispose();
        }
    }
}