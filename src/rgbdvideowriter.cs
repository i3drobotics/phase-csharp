/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-06-28
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file rgbdvideowriter.cs
 * @brief RGBD Video Writer class
 * @details Write RGBD video from a mp4 file
 */

using System;
using System.Runtime.InteropServices;
using System.Runtime.ExceptionServices;

namespace I3DR.Phase
{
    //!  RGBD Video Writer class
    /*!
    Write RGBD video to mp4 file
    */
    public class RGBDVideoWriter
    {
        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_RGBDVideoWriter_create", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr RGBDVideoWriter_create(string rgb_video_filepath, string depth_video_filepath, int width, int height);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_RGBDVideoWriter_CGetWidth", CallingConvention = CallingConvention.Cdecl)]
        private static extern int RGBDVideoWriter_getWidth(IntPtr writer);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_RGBDVideoWriter_CGetHeight", CallingConvention = CallingConvention.Cdecl)]
        private static extern int RGBDVideoWriter_getHeight(IntPtr writer);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_RGBDVideoWriter_CAdd", CallingConvention = CallingConvention.Cdecl)]
        private static extern void RGBDVideoWriter_add(IntPtr writer, [In] byte[] rgb, [In] float[] depth);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_RGBDVideoWriter_CIsOpened", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool RGBDVideoWriter_isOpened(IntPtr writer);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_RGBDVideoWriter_CSave", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool RGBDVideoWriter_save(IntPtr writer);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_RGBDVideoWriter_CSaveThreaded", CallingConvention = CallingConvention.Cdecl)]
        private static extern void RGBDVideoWriter_saveThreaded(IntPtr writer);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_RGBDVideoWriter_CIsSaveThreadRunning", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool RGBDVideoWriter_isSaveThreadRunning(IntPtr writer);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_RGBDVideoWriter_CGetSaveThreadResult", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool RGBDVideoWriter_getSaveThreadResult(IntPtr writer);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_RGBDVideoWriter_CClose", CallingConvention = CallingConvention.Cdecl)]
        private static extern void RGBDVideoWriter_close(IntPtr writer);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_RGBDVideoWriter_dispose", CallingConvention = CallingConvention.Cdecl)]
        private static extern void RGBDVideoWriter_dispose(IntPtr writer);

        private IntPtr m_RGBDVideoWriter_instance; // TODOC

        // TODOC
        public RGBDVideoWriter(string rgb_video_filepath, string depth_video_filepath, int width, int height)
        {
            m_RGBDVideoWriter_instance = RGBDVideoWriter_create(rgb_video_filepath, depth_video_filepath, width, height);
        }

        // TODOC
        public int getWidth(){
            return RGBDVideoWriter_getWidth(m_RGBDVideoWriter_instance);
        }

        // TODOC
        public int getHeight(){
            return RGBDVideoWriter_getHeight(m_RGBDVideoWriter_instance);
        }

        // TODOC
        public void add(byte[] rgb, float[] depth)
        {
            RGBDVideoWriter_add(m_RGBDVideoWriter_instance, rgb, depth);
        }

        // TODOC
        public bool isOpened(){
            return RGBDVideoWriter_isOpened(m_RGBDVideoWriter_instance);
        }

        // TODOC
        public bool save(){
            return RGBDVideoWriter_save(m_RGBDVideoWriter_instance);
        }

        // TODOC
        public void saveThreaded(){
            RGBDVideoWriter_saveThreaded(m_RGBDVideoWriter_instance);
        }

        // TODOC
        public bool isSaveThreadRunning(){
            return RGBDVideoWriter_isSaveThreadRunning(m_RGBDVideoWriter_instance);
        }

        // TODOC
        public bool getSaveThreadResult(){
            return RGBDVideoWriter_getSaveThreadResult(m_RGBDVideoWriter_instance);
        }

        // TODOC
        public void close(){
            RGBDVideoWriter_close(m_RGBDVideoWriter_instance);
        }

        // TODOC
        // [HandleProcessCorruptedStateExceptions]
        public void dispose(){
            
            if (m_RGBDVideoWriter_instance != IntPtr.Zero)
            {
                try
                {
                    RGBDVideoWriter_dispose(m_RGBDVideoWriter_instance);
                }
                catch (AccessViolationException e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine("Please call 'dispose()' to make sure memory is freed.");
                }
                m_RGBDVideoWriter_instance = IntPtr.Zero;
            }
        }

        // TODOC
        ~RGBDVideoWriter()
        {
            dispose();
        }
    }
}