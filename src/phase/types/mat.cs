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
using I3DR.CPhase;

namespace I3DR.Phase
{
    //!  Matrix Float class
    /*!
    Matrix float data storage. Targeted towards storing image data in floatin point precision. 
    */
    public class MatrixFloat
    {
        private float[] m_data; //!< stored matrix data

        private IntPtr m_MatrixFloat_ptr; //!< pointer to MatrixFloat C API instance

        /*!
        * Matrix pointer constructor \n
        * Initalise matrix with reference to existing matrix pointer
        * 
        * @param MatrixFloat_ptr matrix instance pointer
        */
        public MatrixFloat(IntPtr MatrixFloat_ptr){
            m_MatrixFloat_ptr = MatrixFloat_ptr;
        }

        /*!
        * Matrix assignment contructor
        * 
        * @param rows number of rows to create in matrix
        * @param columns number of columns to create in matrix
        * @param layers number of layers to create in matrix
        */
        public MatrixFloat(int rows, int columns, int layers){
            m_MatrixFloat_ptr = PhaseMatrixFloatCreate(rows, columns, layers);
        }

        /*!
        * Matrix data assignment contructor
        * 
        * @param rows number of rows in matrix
        * @param columns number of columns in matrix
        * @param layers number of layers in matrix
        * @param data pointer to data to fill matrix with
        * @param copy if true, copy data, otherwise just point to data
        */
        public MatrixFloat(int rows, int columns, int layers, float[] data, bool copy){
            m_MatrixFloat_ptr = PhaseMatrixFloatCreateData(rows, columns, layers, data, copy);
        }

        /*!
        * Get C API instance reference
        * 
        */
        public IntPtr getInstancePtr(){
            return m_MatrixFloat_ptr;
        }

        /*!
        * Get number of rows in Matrix
        * 
        * @return number of rows in Matrix
        */
        public int getRows()
        {
            return PhaseMatrixFloatGetRows(m_MatrixFloat_ptr);
        }

        /*!
        * Get number of columns in Matrix
        * 
        * @return number of columns in Matrix
        */
        public int getColumns()
        {
            return PhaseMatrixFloatGetColumns(m_MatrixFloat_ptr);
        }

        /*!
        * Get number of layers in Matrix
        * 
        * @return number of layers in Matrix
        */
        public int getLayers()
        {
            return PhaseMatrixFloatGetLayers(m_MatrixFloat_ptr);
        }

        /*!
        * Check if Matrix is empty
        * 
        * @return true if Matrix is empty, false otherwise
        */
        public bool isEmpty()
        {
            return PhaseMatrixFloatIsEmpty(m_MatrixFloat_ptr);
        }

        /*!
        * Get length of Matrix \n
        * (rows * columns * layers)
        * 
        * @return length of Matrix
        */
        public int getLength()
        {
            return PhaseMatrixFloatGetLength(m_MatrixFloat_ptr);
        }

        /*!
        * Get size of Matrix in bytes \n
        * (element_byte_size * matrix_length)
        * 
        * @return size of Matix in bytes
        */
        public int getSize()
        {
            return PhaseMatrixFloatGetSize(m_MatrixFloat_ptr);
        }

        /*!
        * Set element in matrix to specified value
        * 
        * @param row row of element to set
        * @param column column of element to set
        * @param layer layer of element to set
        * @param value value to set element to
        */
        public void setAt(int row, int column, int layer, float value){
            PhaseMatrixFloatSetAt(m_MatrixFloat_ptr, row, column, layer, value);
        }

        /*!
        * Get value of element in matrix
        * 
        * @param row row of element to set
        * @param column column of element to set
        * @param layer layer of element to set
        * @return value of element
        */
        public float getAt(int row, int column, int layer){
            return PhaseMatrixFloatGetAt(m_MatrixFloat_ptr, row, column, layer);
        }

        /*!
        * Get data in Matrix
        * 
        * @return pointer to data in Matrix
        */
        public float[] getData(){
            m_data = new float[getLength()];
            PhaseMatrixFloatGetData(m_MatrixFloat_ptr, m_data);
            return m_data;
        }

        /*!
        * Manually dispose instance of Matrix class
        * 
        */
        // [HandleProcessCorruptedStateExceptions]
        public void dispose(){
            if (m_MatrixFloat_ptr != IntPtr.Zero){
                try {
                    PhaseMatrixFloatDispose(m_MatrixFloat_ptr);
                }
                catch (AccessViolationException e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine("Please call 'dispose()' to make sure library memory is freed.");
                }
                m_MatrixFloat_ptr = IntPtr.Zero;
            }
        }

        ~MatrixFloat()
        {
            dispose();
        }
    }

    //!  Matrix UInt8 class
    /*!
    Matrix uint8 data storage. Targeted towards storing image data in unsigned 8-bit integer precision. 
    */
    public class MatrixUInt8
    {
        private byte[] m_data; //!< stores matrix data

        private IntPtr m_MatrixUInt8_ptr; //!< pointer to MatrixUInt8 C API instance

        /*!
        * Matrix pointer constructor \n
        * Initalise matrix with reference to existing matrix pointer
        * 
        * @param MatrixUInt8_ptr matrix instance pointer
        */
        public MatrixUInt8(IntPtr MatrixUInt8_ptr){
            m_MatrixUInt8_ptr = MatrixUInt8_ptr;
        }

        /*!
        * Matrix assignment contructor
        * 
        * @param rows number of rows to create in matrix
        * @param columns number of columns to create in matrix
        * @param layers number of layers to create in matrix
        */
        public MatrixUInt8(int rows, int columns, int layers){
            m_MatrixUInt8_ptr = PhaseMatrixUInt8Create(rows, columns, layers);
        }

        /*!
        * Matrix data assignment contructor
        * 
        * @param rows number of rows in matrix
        * @param columns number of columns in matrix
        * @param layers number of layers in matrix
        * @param data pointer to data to fill matrix with
        * @param copy if true, copy data, otherwise just point to data
        */
        public MatrixUInt8(int rows, int columns, int layers, byte[] data, bool copy){
            m_MatrixUInt8_ptr = PhaseMatrixUInt8CreateData(rows, columns, layers, data, copy);
        }

        /*!
        * Get C API instance reference
        * 
        */
        public IntPtr getInstancePtr(){
            return m_MatrixUInt8_ptr;
        }

        /*!
        * Get number of rows in Matrix
        * 
        * @return number of rows in Matrix
        */
        public int getRows()
        {
            return PhaseMatrixUInt8GetRows(m_MatrixUInt8_ptr);
        }

        /*!
        * Get number of columns in Matrix
        * 
        * @return number of columns in Matrix
        */
        public int getColumns()
        {
            return PhaseMatrixUInt8GetColumns(m_MatrixUInt8_ptr);
        }

        /*!
        * Get number of layers in Matrix
        * 
        * @return number of layers in Matrix
        */
        public int getLayers()
        {
            return PhaseMatrixUInt8GetLayers(m_MatrixUInt8_ptr);
        }

        /*!
        * Check if Matrix is empty
        * 
        * @return true if Matrix is empty, false otherwise
        */
        public bool isEmpty()
        {
            return PhaseMatrixUInt8IsEmpty(m_MatrixUInt8_ptr);
        }

        /*!
        * Get length of Matrix \n
        * (rows * columns * layers)
        * 
        * @return length of Matrix
        */
        public int getLength()
        {
            return PhaseMatrixUInt8GetLength(m_MatrixUInt8_ptr);
        }

        /*!
        * Get size of Matrix in bytes \n
        * (element_byte_size * matrix_length)
        * 
        * @return size of Matix in bytes
        */
        public int getSize()
        {
            return PhaseMatrixUInt8GetSize(m_MatrixUInt8_ptr);
        }

        /*!
        * Set element in matrix to specified value
        * 
        * @param row row of element to set
        * @param column column of element to set
        * @param layer layer of element to set
        * @param value value to set element to
        */
        public void setAt(int row, int column, int layer, byte value){
            PhaseMatrixUInt8SetAt(m_MatrixUInt8_ptr, row, column, layer, value);
        }

        /*!
        * Get value of element in matrix
        * 
        * @param row row of element to set
        * @param column column of element to set
        * @param layer layer of element to set
        * @return value of element
        */
        public byte getAt(int row, int column, int layer){
            return PhaseMatrixUInt8GetAt(m_MatrixUInt8_ptr, row, column, layer);
        }

        /*!
        * Get data in Matrix
        * 
        * @return pointer to data in Matrix
        */
        public byte[] getData(){
            m_data = new byte[getLength()];
            PhaseMatrixUInt8GetData(m_MatrixUInt8_ptr, m_data);
            return m_data;
        }

        /*!
        * Manually dispose instance of Matrix class
        * 
        */
        // [HandleProcessCorruptedStateExceptions]
        public void dispose(){
            if (m_MatrixUInt8_ptr != IntPtr.Zero){
                try {
                    PhaseMatrixUInt8Dispose(m_MatrixUInt8_ptr);
                }
                catch (AccessViolationException e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine("Please call 'dispose()' to make sure library memory is freed.");
                }
                m_MatrixUInt8_ptr = IntPtr.Zero;
            }
        }

        ~MatrixUInt8()
        {
            dispose();
        }
    }
}