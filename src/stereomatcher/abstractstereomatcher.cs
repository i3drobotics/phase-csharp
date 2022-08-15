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
        public StereoMatcherType matcherType; //!< Stereo matcher type
        public int windowSize; //!< Window size
        public int minDisparity; //!< Minimum disparity
        public int numDisparities; //!< Number of disparities
        public bool interpolation; //!< Enable/disable interpolation

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
        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoMatcher_CCompute", CallingConvention = CallingConvention.Cdecl)]
        protected static extern bool AbstractStereoMatcher_CCompute(IntPtr matcher, [In] byte[] left_image, [In] byte[] right_image, int in_width, int in_height, [Out] float[] disparity);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoMatcher_CStartComputeThread", CallingConvention = CallingConvention.Cdecl)]
        protected static extern void AbstractStereoMatcher_CStartComputeThread(IntPtr matcher, [In] byte[] left_image, [In] byte[] right_image, int in_width, int in_height);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoMatcher_CIsComputeThreadRunning", CallingConvention = CallingConvention.Cdecl)]
        protected static extern bool AbstractStereoMatcher_CIsComputeThreadRunning(IntPtr matcher);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoMatcher_CGetComputeThreadResult", CallingConvention = CallingConvention.Cdecl)]
        protected static extern bool AbstractStereoMatcher_CGetComputeThreadResult(IntPtr matcher, int width, int height, [Out] float[] disparity);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "I3DR_AbstractStereoMatcher_dispose", CallingConvention = CallingConvention.Cdecl)]
        protected static extern void AbstractStereoMatcher_dispose(IntPtr matcher);
        
        protected IntPtr m_AbstractStereoMatcher_instance; //!< pointer to AbstractStereoMatcher C API instance
        private float[] disparity; //!< store disparity image

        /*!
        * AbstractStereoMatcher constructor \n
        * Initalise Stereo matcher and set default matching parameters.
        * 
        */
        public AbstractStereoMatcher(){}

        /*!
        * Initalise class using C API class instance reference
        * 
        * @IntPtr stereoCameraCalibration_instance
        */
        public AbstractStereoMatcher(IntPtr abstractStereoMatcher_instance){
            m_AbstractStereoMatcher_instance = abstractStereoMatcher_instance;
        }

        /*!
        * Get C API instance reference
        * 
        */
        public IntPtr getInstancePtr(){
            return m_AbstractStereoMatcher_instance;
        }

        /*!
        * Initalise stereo matcher
        * Should be implemented in derived classes.
        * 
        */
        protected virtual void init(){}

        /*!
        * Compute stereo match \n
        * Generates disparity from stereo image pair. \n
        * Should be implemented in derived classes.
        * 
        * @param left_image left image
        * @param right_image right image
        * @return results from stereo matching compute 
        */
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

        /*!
        * Format compute result
        * 
        * @param valid validity of compute result
        */
        private StereoMatcherComputeResult processComputeResult(bool valid)
        {
            StereoMatcherComputeResult result = new StereoMatcherComputeResult(valid, disparity);
            return result;
        }

        /*!
        * Start threaded compute of stereo match \n
        * Generates disparity from stereo image pair. \n
        * Use getComputeThreadResult() to get results of compute.
        * 
        * @param left_image left image
        * @param right_image right image
        */
        public void startComputeThread(byte[] left_image, byte[] right_image, int width, int height)
        {
            AbstractStereoMatcher_CStartComputeThread(
                m_AbstractStereoMatcher_instance,
                left_image,
                right_image,
                width, height
            );
        }

        /*!
        * Check if compute thread running \n
        * Should be used with startComputeThread()
        * 
        * @return compute thread running status
        */
        public bool isComputeThreadRunning(){
            return AbstractStereoMatcher_CIsComputeThreadRunning(m_AbstractStereoMatcher_instance);
        }

        /*!
        * Get results from threaded compute process \n
        * Should be used with startComputeThread()
        * 
        * @param width width of image
        * @param height height of image
        * @return results from compute process
        */
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

        /*!
        * Remove C API instance reference
        * 
        */
        public void markDisposed()
        {
            m_AbstractStereoMatcher_instance = IntPtr.Zero;
        }

        /*!
        * Manually dispose instance of RGBD Video Writer class
        * 
        */
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