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
using I3DR.Phase.Types;

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
            int r = 10;
            int c = 10;
            int l = 2;
            MatrixFloat mat = new MatrixFloat(r, c, l);
            Assert.Equal(r, mat.getRows());
            Assert.Equal(c, mat.getColumns());
            Assert.Equal(l, mat.getLayers());
        }

        [Fact]
        public void test_MatrixUInt8Create()
        {
            // Test MatrixUInt8 created with 10 rows, 10 columns, 2 layers
            // has specified number of rows, columns, and layers
            int r = 10;
            int c = 10;
            int l = 2;
            MatrixUInt8 mat = new MatrixUInt8(r, c, l);
            Assert.Equal(r, mat.getRows());
            Assert.Equal(c, mat.getColumns());
            Assert.Equal(l, mat.getLayers());
        }

        [Fact]
        public void test_MatrixFloatElementSetting()
        {
            // Test MatrixFloat element can be set to specific value
            // and value can be read back and responds with new value 
            MatrixFloat mat = new MatrixFloat(10, 10, 2);
            int r = 1;
            int c = 2;
            int l = 1;
            float value = 100;
            mat.setAt(r, c, l, value);
            Assert.Equal(value, mat.getAt(r,c,l));
        }

        [Fact]
        public void test_MatrixUInt8ElementSetting()
        {
            // Test MatrixUInt8 element can be set to specific value
            // and value can be read back and responds with new value 
            MatrixUInt8 mat = new MatrixUInt8(10, 10, 2);
            int r = 1;
            int c = 2;
            int l = 1;
            byte value = 100;
            mat.setAt(r, c, l, value);
            Assert.Equal(value, mat.getAt(r,c,l));
        }
    }
}
