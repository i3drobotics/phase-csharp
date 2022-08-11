/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file abstractstereomatcher.cs
 * @brief Abstract Stereo Matcher class
 * @details Parent class for building stereo matcher
 * classes. Includes functions/structures common across
 * all stereo matchers. A stereo matcher takes a two images
 * (left and right) and calculates to pixel disparity of features.
 * The produces a disparity value for each pixel which can be
 * used to generate depth. 
 */

using System;
using System.Runtime.InteropServices;
using System.Runtime.ExceptionServices;

namespace I3DR.Phase
{
    //!  Stereo Params structure
    /*!
    Struture to store stereo parameters
    */
    public struct StereoParams {
        public StereoMatcherType matcherType; // TODOC
        public int windowSize; // TODOC
        public int minDisparity; // TODOC
        public int numDisparities; // TODOC
        public bool interpolation; // TODOC

        // TODOC
        public StereoParams(StereoMatcherType matcherType, int windowSize, int minDisparity, int numDisparities, bool interpolation) {
            this.matcherType = matcherType;
            this.windowSize = windowSize;
            this.minDisparity = minDisparity;
            this.numDisparities = numDisparities;
            this.interpolation = interpolation;
        }
    };

    //!  Abstract Stereo Matcher class
    /*!
    Abstract base class for building stereo matcher
    classes. Includes functions/structures common across
    all stereo matchers. A stereo matcher takes a two images
    (left and right) and calculates to pixel disparity of features.
    The produces a disparity value for each pixel which can be
    used to generate depth. 
    */
    public class AbstractStereoMatcher
    {
        // Import Phase functions from C API
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
        
        protected IntPtr m_AbstractStereoMatcher_instance; // TODOC
        private float[] disparity; // TODOC

        // TODOC
        public AbstractStereoMatcher(){}

        // TODOC
        public AbstractStereoMatcher(IntPtr abstractStereoMatcher_instance){
            m_AbstractStereoMatcher_instance = abstractStereoMatcher_instance;
        }

        // TODOC
        public IntPtr getInstancePtr(){
            return m_AbstractStereoMatcher_instance;
        }

        // TODOC
        protected virtual void init(){}

        // TODOC
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

        // TODOC
        private StereoMatcherComputeResult processComputeResult(bool valid)
        {
            StereoMatcherComputeResult result = new StereoMatcherComputeResult(valid, disparity);
            return result;
        }

        // TODOC
        public void startComputeThread(byte[] left_image, byte[] right_image, int width, int height)
        {
            AbstractStereoMatcher_CStartComputeThread(
                m_AbstractStereoMatcher_instance,
                left_image,
                right_image,
                width, height
            );
        }

        // TODOC
        public bool isComputeThreadRunning(){
            return AbstractStereoMatcher_CIsComputeThreadRunning(m_AbstractStereoMatcher_instance);
        }

        // TODOC
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

        // TODOC
        public void markDisposed()
        {
            m_AbstractStereoMatcher_instance = IntPtr.Zero;
        }

        // TODOC
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

        // TODOC
        ~AbstractStereoMatcher()
        {
            dispose();
        }
    }
}