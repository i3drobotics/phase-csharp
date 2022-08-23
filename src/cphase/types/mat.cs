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
using System.Runtime.ExceptionServices;

namespace I3DR.CPhase
{
    //!  Matrix Float class
    /*!
    Matrix float data storage. Targeted towards storing image data in floatin point precision. 
    */
    public class MatrixFloat
    {
        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseMatrixFloatCreate", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr PhaseMatrixFloatCreate(int rows, int columns, int layers);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseMatrixFloatCreateData", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr PhaseMatrixFloatCreateData(int rows, int columns, int layers, [In] float[] data, bool copy);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseMatrixFloatDispose", CallingConvention = CallingConvention.Cdecl)]
        private static extern void PhaseMatrixFloatDispose(IntPtr MatrixFloat_ptr);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseMatrixFloatGetRows", CallingConvention = CallingConvention.Cdecl)]
        private static extern int PhaseMatrixFloatGetRows(IntPtr mat);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseMatrixFloatGetColumns", CallingConvention = CallingConvention.Cdecl)]
        private static extern int PhaseMatrixFloatGetColumns(IntPtr mat);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseMatrixFloatGetLayers", CallingConvention = CallingConvention.Cdecl)]
        private static extern int PhaseMatrixFloatGetLayers(IntPtr mat);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseMatrixFloatIsEmpty", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool PhaseMatrixFloatIsEmpty(IntPtr mat);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseMatrixFloatGetLength", CallingConvention = CallingConvention.Cdecl)]
        private static extern int PhaseMatrixFloatGetLength(IntPtr mat);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseMatrixFloatGetSize", CallingConvention = CallingConvention.Cdecl)]
        private static extern int PhaseMatrixFloatGetSize(IntPtr mat);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseMatrixFloatGetAt", CallingConvention = CallingConvention.Cdecl)]
        private static extern float PhaseMatrixFloatGetAt(IntPtr mat, int row, int column, int layer);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseMatrixFloatSetAt", CallingConvention = CallingConvention.Cdecl)]
        private static extern void PhaseMatrixFloatSetAt(IntPtr mat, int row, int column, int layer, float value);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseMatrixFloatGetData", CallingConvention = CallingConvention.Cdecl)]
        private static extern void PhaseMatrixFloatGetData(IntPtr mat, [Out] float[] data);
    }

    //!  Matrix UInt8 class
    /*!
    Matrix uint8 data storage. Targeted towards storing image data in unsigned 8-bit integer precision. 
    */
    public class MatrixUInt8
    {
        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseMatrixUInt8Create", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr PhaseMatrixUInt8Create(int rows, int columns, int layers);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseMatrixUInt8CreateData", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr PhaseMatrixUInt8CreateData(int rows, int columns, int layers, [In] byte[] data, bool copy);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseMatrixUInt8Dispose", CallingConvention = CallingConvention.Cdecl)]
        private static extern void PhaseMatrixUInt8Dispose(IntPtr MatrixUInt8_ptr);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseMatrixUInt8GetRows", CallingConvention = CallingConvention.Cdecl)]
        private static extern int PhaseMatrixUInt8GetRows(IntPtr mat);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseMatrixUInt8GetColumns", CallingConvention = CallingConvention.Cdecl)]
        private static extern int PhaseMatrixUInt8GetColumns(IntPtr mat);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseMatrixUInt8GetLayers", CallingConvention = CallingConvention.Cdecl)]
        private static extern int PhaseMatrixUInt8GetLayers(IntPtr mat);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseMatrixUInt8IsEmpty", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool PhaseMatrixUInt8IsEmpty(IntPtr mat);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseMatrixUInt8GetLength", CallingConvention = CallingConvention.Cdecl)]
        private static extern int PhaseMatrixUInt8GetLength(IntPtr mat);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseMatrixUInt8GetSize", CallingConvention = CallingConvention.Cdecl)]
        private static extern int PhaseMatrixUInt8GetSize(IntPtr mat);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseMatrixUInt8GetAt", CallingConvention = CallingConvention.Cdecl)]
        private static extern byte PhaseMatrixUInt8GetAt(IntPtr mat, int row, int column, int layer);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseMatrixUInt8SetAt", CallingConvention = CallingConvention.Cdecl)]
        private static extern void PhaseMatrixUInt8SetAt(IntPtr mat, int row, int column, int layer, byte value);

        //! Imported from Phase C API
        [DllImport("phase", EntryPoint = "PhaseMatrixUInt8GetData", CallingConvention = CallingConvention.Cdecl)]
        private static extern void PhaseMatrixUInt8GetData(IntPtr mat, [Out] byte[] data);
    }
}