/*!
 * @authors Ben Knight (bknight@i3drobotics.com)
 * @date 2021-05-26
 * @copyright Copyright (c) I3D Robotics Ltd, 2021
 * 
 * @file test_mat.cs
 * @brief Unit tests for Matrix class
 * @details Unit tests generated using MSTest
 */

using Xunit;

namespace I3DR.PhaseTest
{
    // Tests for Matrix
    [Collection("PhaseSequentialTests")]
    public class MatTests
    {
        [Fact]
        public void test_MatrixFloatCreate()
        {
            // Test MatrixFloat created with 10 rows, 10 columns, 2 layers
            // has specified number of rows, columns, and layers
            // TOTEST
        }

        [Fact]
        public void test_MatrixUInt8Create()
        {
            // Test MatrixUInt8 created with 10 rows, 10 columns, 2 layers
            // has specified number of rows, columns, and layers
            // TOTEST
        }

        [Fact]
        public void test_MatrixFloatElementSetting()
        {
            // Test MatrixFloat element can be set to specific value
            // and value can be read back and responds with new value 
            // TOTEST
        }

        [Fact]
        public void test_MatrixUInt8ElementSetting()
        {
            // Test MatrixUInt8 element can be set to specific value
            // and value can be read back and responds with new value 
            // TOTEST
        }

        [Fact]
        public void test_MatrixFloatEmpty()
        {
            // Test a MatrixFloat that is empty reports as empty using ‘isEmpty’ function
            // TOTEST
        }

        [Fact]
        public void test_MatrixUInt8Empty()
        {
            // Test a MatrixUInt8 that is empty reports as empty using ‘isEmpty’ function
            // TOTEST
        }
    }
}
