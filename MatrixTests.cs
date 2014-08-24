/*
Author:  Marek Bar 33808
Contact: marekbar1985@gmail.com
Wyższa Szkoła Informatyki i Zarządzania w Rzeszowie
 */
using System;
using System.Diagnostics;
using LearnByErrorLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    /// <summary>
    /// MatrixMB tests - written with a little help of Matlab
    /// </summary>
    /// <remarks>The most helpfull website about matrices: http://www.mathsisfun.com</remarks>
    [TestClass]
    public class MatrixTests
    {
        /// <summary>
        /// Filling matrix with number
        /// </summary>
        [TestMethod]
        [TestCategory("Matrix")]
        public void FillMatrix()
        {
            MatrixMB mat = new MatrixMB(3, 3);
            mat.Data[0][0] = 1;
            mat.Data[0][1] = 2;
            mat.Data[0][2] = 3;

            mat.Data[1][0] = 4;
            mat.Data[1][1] = 5;
            mat.Data[1][2] = 6;

            mat.Data[2][0] = 7;
            mat.Data[2][1] = 8;
            mat.Data[2][2] = 9;
            Assert.AreEqual(1, mat[0, 0]);
            Assert.AreEqual(2, mat[0, 1]);
            Assert.AreEqual(3, mat[0, 2]);

            Assert.AreEqual(4, mat[1, 0]);
            Assert.AreEqual(5, mat[1, 1]);
            Assert.AreEqual(6, mat[1, 2]);

            Assert.AreEqual(7, mat[2, 0]);
            Assert.AreEqual(8, mat[2, 1]);
            Assert.AreEqual(9, mat[2, 2]);
        }

        /// <summary>
        /// Creating new matrix
        /// </summary>
        [TestMethod]
        [TestCategory("Matrix")]
        public void Creation()
        {
            MatrixMB mat = new MatrixMB(5, 5);
            mat.FillWithNumber(1);
            Assert.AreEqual(25, mat.SumAllValues());
        }

        /// <summary>
        /// Summing two matrices
        /// </summary>
        [TestMethod]
        [TestCategory("Matrix")]
        public void SumTwoMatrices()
        {
            MatrixMB mat1 = new MatrixMB(5, 5);
            MatrixMB mat2 = new MatrixMB(5, 5);
            mat1.FillWithNumber(1);
            mat2.FillWithNumber(2);
            var mat = mat1 + mat2;
            Assert.AreEqual(75, mat.SumAllValues());
        }

        /// <summary>
        /// Substracting matrix from matrix
        /// </summary>
        [TestMethod]
        [TestCategory("Matrix")]
        public void SubstractTwoMatrices()
        {
            MatrixMB mat1 = new MatrixMB(5, 5);
            MatrixMB mat2 = new MatrixMB(5, 5);
            mat1.FillWithNumber(4);
            mat2.FillWithNumber(2);
            var mat = mat1 - mat2;
            Assert.AreEqual(50, mat.SumAllValues());
        }

        /// <summary>
        /// Matrix multiplication test
        /// </summary>
        [TestMethod]
        [TestCategory("Matrix")]
        public void MultiplyTwoMatrices()
        {
            MatrixMB mat1 = new MatrixMB(2, 3);
            mat1.Data[0][0] = 1;
            mat1.Data[0][1] = 2;
            mat1.Data[0][2] = 3;
            mat1.Data[1][0] = 4;
            mat1.Data[1][1] = 5;
            mat1.Data[1][2] = 6;

            MatrixMB mat2 = new MatrixMB(3, 2);
            mat2.Data[0][0] = 7;
            mat2.Data[0][1] = 8;
            mat2.Data[1][0] = 9;
            mat2.Data[1][1] = 10;
            mat2.Data[2][0] = 11;
            mat2.Data[2][1] = 12;
                        
            var mat = mat1 * mat2;
            Assert.AreEqual(58, mat[0,0]);
            Assert.AreEqual(64, mat[0, 1]);
            Assert.AreEqual(139,mat[1, 0]);
            Assert.AreEqual(154, mat[1, 1]);
        }

        /// <summary>
        /// Matrix dividing test
        /// </summary>
        [TestMethod]
        [TestCategory("Matrix")]
        public void DivideMatrixByMatrix()
        {
            MatrixMB mat = new MatrixMB(2, 2);
            mat.Data[0][0] = 4;
            mat.Data[0][1] = 7;
            mat.Data[1][0] = 2;
            mat.Data[1][1] = 6;

            MatrixMB b = new MatrixMB(2, 1);
            b[0, 0] = 1;
            b[1, 0] = 2;

            var divided = mat.Inverted * b;

            Assert.AreEqual(-0.8, Math.Round(divided[0, 0], 4));
            Assert.AreEqual(0.6, Math.Round(divided[1, 0], 4));
        }

        /// <summary>
        /// Calculating matrix determinant test
        /// </summary>
        [TestMethod]
        [TestCategory("Matrix")]
        public void MatrixDeterminant()
        {
            MatrixMB mat = new MatrixMB(3, 3);
            mat.Data[0][0] = 1;
            mat.Data[0][1] = 9;
            mat.Data[0][2] = 1;
            mat.Data[1][0] = 9;
            mat.Data[1][1] = 1;
            mat.Data[1][2] = 9;
            mat.Data[2][0] = 1;
            mat.Data[2][1] = 9;
            mat.Data[2][2] = 1;
            double det = mat.Determinant;
            Assert.AreEqual(det, 0); 
            Assert.AreEqual(1, mat.Data[0][0]);
            Assert.AreEqual(9, mat.Data[0][1]);
            Assert.AreEqual(1, mat.Data[0][2]);

            Assert.AreEqual(9, mat.Data[1][0]);
            Assert.AreEqual(1, mat.Data[1][1]);
            Assert.AreEqual(9, mat.Data[1][2]);

            Assert.AreEqual(1, mat.Data[2][0]);
            Assert.AreEqual(9, mat.Data[2][1]);
            Assert.AreEqual(1, mat.Data[2][2]);
            
        }

        /// <summary>
        /// Calculating matrix LU test
        /// </summary>
        [TestMethod]
        [TestCategory("Matrix")]
        public void CalculatingLowerUpperMatrices()
        {
            MatrixMB mat = new MatrixMB(2, 2);
            mat.Data[0][0] = 4;
            mat.Data[0][1] = 7;
            mat.Data[1][0] = 2;
            mat.Data[1][1] = 6;

            mat.MakeLU();
            Assert.AreEqual(4, mat.Data[0][0]);
            Assert.AreEqual(7, mat.Data[0][1]);
            Assert.AreEqual(2, mat.Data[1][0]);
            Assert.AreEqual(6, mat.Data[1][1]);

            var L = mat.L;
            Assert.AreEqual(1, L.Data[0][0]);
            Assert.AreEqual(0, L.Data[0][1]);
            Assert.AreEqual(0.5, L.Data[1][0]);
            Assert.AreEqual(1, L.Data[1][1]);

            var U = mat.U;
            Assert.AreEqual(4, U.Data[0][0]);
            Assert.AreEqual(7, U.Data[0][1]);
            Assert.AreEqual(0, U.Data[1][0]);
            Assert.AreEqual(2.5, U.Data[1][1]);
        }

        /// <summary>
        /// Invert matrix calculation test
        /// </summary>
        [TestMethod]
        [TestCategory("Matrix")]
        public void InvertMatrix()
        {
            Console.WriteLine("Testowanie odwracania macierzy");
            //mat.Inverted * mat = mat.Identity            
            //Jeśli A ma odwrotną A to odwrotna A jest równa A
            MatrixMB mat = new MatrixMB(2,2);
            mat.Data[0][0] = 4;
            mat.Data[0][1] = 7;
            mat.Data[1][0] = 2;
            mat.Data[1][1] = 6;
            Console.WriteLine("Macierz odwracana");
            Console.WriteLine(mat.MatrixToString());

            double det = mat.Determinant;
            Assert.AreNotEqual(0, det);
            Assert.AreEqual(10, det);

            var inv = mat.Inverted;
            Console.WriteLine("Macierz odwrócona");
            Console.WriteLine(inv.MatrixToString());

            Assert.AreEqual(0.6000, Math.Round(inv.Data[0][0],4));
            Assert.AreEqual(-0.7000, Math.Round(inv.Data[0][1],4));
            Assert.AreEqual(-0.2000, Math.Round(inv.Data[1][0],4));
            Assert.AreEqual(0.4000, Math.Round(inv.Data[1][1],4));

            var A = inv.Inverted;
            Console.WriteLine("Odwrócenie macierzy odwróconej");
            Console.WriteLine(inv.MatrixToString());

            int accuracy = 15;
            for (int i = 0; i < A.Rows; i++)
            {
                for (int j = 0; j < A.Cols; j++)
                {
                    decimal o = Math.Round((decimal)mat[i, j], accuracy);
                    decimal a = Math.Round((decimal)A[i, j], accuracy);
                    Console.WriteLine(string.Format("Orginał: {0}\tPorównywana: {1}", o, a));
                }
            }

            for (int i = 0; i < A.Rows; i++)
            {
                for (int j = 0; j < A.Cols; j++) 
                {
                    decimal o = Math.Round((decimal)mat[i, j], accuracy);
                    decimal a = Math.Round((decimal)A[i, j], accuracy);
                    Assert.AreEqual(o, a);
                }
            }

            var identity = inv * mat;
            Assert.AreEqual(1, Math.Round(identity.Data[0][0], accuracy));
            Assert.AreEqual(0, Math.Round(identity.Data[0][1], accuracy));
            Assert.AreEqual(0, Math.Round(identity.Data[1][0], accuracy));
            Assert.AreEqual(1, Math.Round(identity.Data[1][1], accuracy));
        }

        /// <summary>
        /// Matrix transposition
        /// </summary>
        [TestMethod]
        [TestCategory("Matrix")]
        public void TransposeMatrix()
        {
            MatrixMB mat = new MatrixMB(3, 3);
            mat[0, 0] = 1;
            mat[0, 1] = 2;
            mat[0, 2] = 3;
            mat[1, 0] = 4;
            mat[1, 1] = 5;
            mat[1, 2] = 6;
            mat[2, 0] = 7;
            mat[2, 1] = 8;
            mat[2, 2] = 9;

            var t = mat.Transposed;
            Assert.AreEqual(1, t[0, 0]);
            Assert.AreEqual(2, t[1, 0]);
            Assert.AreEqual(3, t[2, 0]);

            Assert.AreEqual(4, t[0, 1]);
            Assert.AreEqual(5, t[1, 1]);
            Assert.AreEqual(6, t[2, 1]);

            Assert.AreEqual(7, t[0, 2]);
            Assert.AreEqual(8, t[1, 2]);
            Assert.AreEqual(9, t[2, 2]);


        }
    }
}
