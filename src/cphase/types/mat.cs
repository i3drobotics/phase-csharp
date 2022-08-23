/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file mat.cs
 * @brief Matrix class
 * @brief Matrix data storage
 */

using System;
using System.Runtime.InteropServices;

namespace I3DR.CPhase
{
    //!  Matrix Float class
    /*!
    Matrix float data storage. Targeted towards storing image data in floatin point precision. 
    */
    public class CMatrixFloat
    {
        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseMatrixFloatCreate", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create(int rows, int columns, int layers);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseMatrixFloatCreateData", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr createData(int rows, int columns, int layers, [In] float[] data, bool copy);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseMatrixFloatDispose", CallingConvention = CallingConvention.Cdecl)]
        public static extern void dispose(IntPtr MatrixFloat_ptr);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseMatrixFloatGetRows", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getRows(IntPtr mat);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseMatrixFloatGetColumns", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getColumns(IntPtr mat);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseMatrixFloatGetLayers", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getLayers(IntPtr mat);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseMatrixFloatIsEmpty", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool isEmpty(IntPtr mat);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseMatrixFloatGetLength", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getLength(IntPtr mat);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseMatrixFloatGetSize", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getSize(IntPtr mat);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseMatrixFloatGetAt", CallingConvention = CallingConvention.Cdecl)]
        public static extern float getAt(IntPtr mat, int row, int column, int layer);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseMatrixFloatSetAt", CallingConvention = CallingConvention.Cdecl)]
        public static extern void setAt(IntPtr mat, int row, int column, int layer, float value);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseMatrixFloatGetData", CallingConvention = CallingConvention.Cdecl)]
        public static extern void getData(IntPtr mat, [Out] float[] data);
    }

    //!  Matrix UInt8 class
    /*!
    Matrix uint8 data storage. Targeted towards storing image data in unsigned 8-bit integer precision. 
    */
    public class CMatrixUInt8
    {
        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseMatrixUInt8Create", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create(int rows, int columns, int layers);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseMatrixUInt8CreateData", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr createData(int rows, int columns, int layers, [In] byte[] data, bool copy);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseMatrixUInt8Dispose", CallingConvention = CallingConvention.Cdecl)]
        public static extern void dispose(IntPtr MatrixUInt8_ptr);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseMatrixUInt8GetRows", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getRows(IntPtr mat);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseMatrixUInt8GetColumns", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getColumns(IntPtr mat);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseMatrixUInt8GetLayers", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getLayers(IntPtr mat);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseMatrixUInt8IsEmpty", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool isEmpty(IntPtr mat);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseMatrixUInt8GetLength", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getLength(IntPtr mat);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseMatrixUInt8GetSize", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getSize(IntPtr mat);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseMatrixUInt8GetAt", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte getAt(IntPtr mat, int row, int column, int layer);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseMatrixUInt8SetAt", CallingConvention = CallingConvention.Cdecl)]
        public static extern void setAt(IntPtr mat, int row, int column, int layer, byte value);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseMatrixUInt8GetData", CallingConvention = CallingConvention.Cdecl)]
        public static extern void getData(IntPtr mat, [Out] byte[] data);
    }
}