/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file abstractstereomatcher.cs
 * @brief Abstract Stereo Matcher  class
 * @details C#  class for Abstract Stereo Matcher class export.
 * DllImports for using C type exports. Pointer to class instance
 * is passed between functions.
 */

using System;
using System.Runtime.InteropServices;
using System.Runtime.ExceptionServices;

namespace I3DR.Phase
{

    public struct StereoParams {
        public StereoMatcherType matcherType;
        public int windowSize;
        public int minDisparity;
        public int numDisparities;
        public bool interpolation;

        public StereoParams(StereoMatcherType matcherType, int windowSize, int minDisparity, int numDisparities, bool interpolation) {
            this.matcherType = matcherType;
            this.windowSize = windowSize;
            this.minDisparity = minDisparity;
            this.numDisparities = numDisparities;
            this.interpolation = interpolation;
        }
    };

    public class AbstractStereoMatcher
    {
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoMatcher_CCompute", CallingConvention = CallingConvention.Cdecl)]
        protected static extern bool AbstractStereoMatcher_CCompute(IntPtr matcher, [In] byte[] left_image, [In] byte[] right_image, int in_width, int in_height, [Out] float[] disparity);

        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoMatcher_CStartComputeThread", CallingConvention = CallingConvention.Cdecl)]
        protected static extern void AbstractStereoMatcher_CStartComputeThread(IntPtr matcher, [In] byte[] left_image, [In] byte[] right_image, int in_width, int in_height);

        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoMatcher_CIsComputeThreadRunning", CallingConvention = CallingConvention.Cdecl)]
        protected static extern bool AbstractStereoMatcher_CIsComputeThreadRunning(IntPtr matcher);

        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoMatcher_CGetComputeThreadResult", CallingConvention = CallingConvention.Cdecl)]
        protected static extern bool AbstractStereoMatcher_CGetComputeThreadResult(IntPtr matcher, int width, int height, [Out] float[] disparity);

        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoMatcher_dispose", CallingConvention = CallingConvention.Cdecl)]
        protected static extern void AbstractStereoMatcher_dispose(IntPtr matcher);
        
        protected IntPtr m_AbstractStereoMatcher_instance;
        private float[] disparity;

        public AbstractStereoMatcher(){}

        public AbstractStereoMatcher(IntPtr abstractStereoMatcher_instance){
            m_AbstractStereoMatcher_instance = abstractStereoMatcher_instance;
        }

        public IntPtr getInstancePtr(){
            return m_AbstractStereoMatcher_instance;
        }

        protected virtual void init(){}
        
        public StereoMatcherComputeResult compute(byte[] left_image, byte[] right_image, int width, int height)
        {
            disparity = new float[width * height];
            bool valid = AbstractStereoMatcher_CCompute(
                m_AbstractStereoMatcher_instance,
                left_image,
                right_image,
                width, height,
                disparity
            );
            return processComputeResult(valid);
        }

        private StereoMatcherComputeResult processComputeResult(bool valid)
        {
            StereoMatcherComputeResult result = new StereoMatcherComputeResult(valid, disparity);
            return result;
        }

        public void startComputeThread(byte[] left_image, byte[] right_image, int width, int height)
        {
            AbstractStereoMatcher_CStartComputeThread(
                m_AbstractStereoMatcher_instance,
                left_image,
                right_image,
                width, height
            );
        }

        public bool isComputeThreadRunning(){
            return AbstractStereoMatcher_CIsComputeThreadRunning(m_AbstractStereoMatcher_instance);
        }

        public StereoMatcherComputeResult getComputeThreadResult(int width, int height)
        {
            disparity = new float[width * height];
            bool valid = AbstractStereoMatcher_CGetComputeThreadResult(
                m_AbstractStereoMatcher_instance,
                width, height,
                disparity
            );
            return processComputeResult(valid);
        }

        public void markDisposed()
        {
            m_AbstractStereoMatcher_instance = IntPtr.Zero;
        }

        // [HandleProcessCorruptedStateExceptions]
        public void dispose(){
            if (m_AbstractStereoMatcher_instance != IntPtr.Zero){
                try { 
                    AbstractStereoMatcher_dispose(m_AbstractStereoMatcher_instance);
                }
                catch (AccessViolationException e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine("Please call 'dispose()' to make sure library memory is freed.");
                }
                m_AbstractStereoMatcher_instance = IntPtr.Zero;
            }
        }

        ~AbstractStereoMatcher()
        {
            dispose();
        }
    }
}