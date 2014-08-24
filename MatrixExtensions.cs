/*
Author:  Marek Bar 33808
Contact: marekbar1985@gmail.com
Wyższa Szkoła Informatyki i Zarządzania w Rzeszowie
 */
using System;
using System.Collections.Generic;

namespace LearnByErrorLibrary
{
    /// <summary>
    /// Matrix additional methods
    /// </summary>
    public static class MatrixExtensions
    {
        public static double[,] ToMultidimensionalArray(this double[][] array, int rows, int cols)
        {
            double[,] tmp = new double[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    tmp[i, j] = array[i][j];
                }
            }

            return tmp;
        }

        public static double[][] ToJaggedArray(this double[,] array, int rows, int cols)
        {
            double[][]tmp = new double[rows][];

            for (int i = 0; i < rows; i++)
            {
                tmp[i] = new double[cols];
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    tmp[i][j] = array[i,j];
                }
            }

            return tmp;
        }


        /// <summary>
        /// Convert Matrix to string representation
        /// </summary>
        /// <param name="mat">MatrixMB</param>
        /// <returns>String</returns>
        public static String MatrixToString(this MatrixMB mat)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            for (var row = 0; row < mat.Rows; row++)
            {
                for (var col = 0; col < mat.Cols; col++)
                {
                    sb.Append(mat.Data[row][col]);
                    sb.Append(",    ");
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }

        /// <summary>
        /// Convert double to int
        /// </summary>
        /// <param name="value">double</param>
        /// <returns>int</returns>
        public static int ToInt(this double value)
        {
            return (int)value;
        }

        /// <summary>
        /// Convert MatrixMB to Input
        /// </summary>
        /// <param name="mat">MatrixMB</param>
        /// <returns>Input</returns>
        public static Input ToInput(this MatrixMB mat)
        {
            Input input = new Input(mat.Rows, mat.Cols);
            for (int col = 0; col < mat.Cols; col++)
            {
                for (int row = 0; row < mat.Rows; row++)
                {
                    input.Data[row][col] = mat.Data[row][col];
                }
            }
            return input;
        }

        /// <summary>
        /// Convert MatrixMB to Output
        /// </summary>
        /// <param name="mat">MatrixMB</param>
        /// <returns>Output</returns>
        public static Output ToOutput(this MatrixMB mat)
        {
            Output output = new Output(mat.Rows, mat.Cols);
            for (int col = 0; col < mat.Cols; col++)
            {
                for (int row = 0; row < mat.Rows; row++)
                {
                    output.Data[row][col] = mat.Data[row][col];
                }
            }
            return output;
        }

        /// <summary>
        /// Convert MatrixMB to Weights
        /// </summary>
        /// <param name="mat">MatrixMB</param>
        /// <returns>Weights</returns>
        public static Weights ToWeights(this MatrixMB mat)
        {
            Weights weights = new Weights(mat.Cols);
            for (int col = 0; col < mat.Cols; col++)
            {
                weights.Data[0][col] = mat.Data[0][col];
            }            
            return weights;
        }

        /// <summary>
        /// Convert MatrixMB to VectorHorizontal
        /// </summary>
        /// <param name="mat">MatrixMB</param>
        /// <returns>VectorHorizontal</returns>
        public static VectorHorizontal ToVectorHorizontal(this MatrixMB mat)
        {
            VectorHorizontal vh = new VectorHorizontal(mat.Cols);
            for (int col = 0; col < mat.Cols; col++)
            {
                vh.Data[0][col] = mat.Data[0][col];
            }            
            return vh;
        }

        /// <summary>
        /// Convert MatrixMB to VectorVertical
        /// </summary>
        /// <param name="mat">MatrixMB</param>
        /// <returns>VectorVertical</returns>
        public static VectorVertical ToVectorVertical(this MatrixMB mat)
        {
            VectorVertical vv = new VectorVertical(mat.Rows);
            for (int row = 0; row < mat.Cols; row++)
            {
                vv.Data[row][0] = mat.Data[row][0];
            }     
            return vv;
        }

        /// <summary>
        /// Convert VectorHorizontal to List
        /// </summary>
        /// <param name="vh">VectorHorizontal</param>
        /// <returns>List - generic</returns>
        public static List<double> ToList(this VectorHorizontal vh)
        {
            List<double> list = new List<double>();
            list.AddRange(vh.Data[0]);            
            return list;
        }

        /// <summary>
        /// Check if matrix is filled with zeros only
        /// </summary>
        /// <param name="mat">MatrixMB</param>
        /// <returns>bool</returns>
        public static bool IsZeroed(this MatrixMB mat)
        {
            int counter = mat.Rows * mat.Cols;
            for (int r = 0; r < mat.Rows; r++)
            {
                for (int c = 0; c < mat.Cols; c++)
                {
                    if (mat.Data[r][c] == 0) counter--;
                }
            }

            return counter == 0;
        }

        /// <summary>
        /// Converts Hastable to double array
        /// </summary>
        /// <param name="ht">Hashtable</param>
        /// <returns>double[]</returns>
        public static double[] ToDoubleArray(this System.Collections.Hashtable ht)
        {
            List<double> list = new List<double>();
            for (int i = 0; i < ht.Count; i++)
            {
                try
                {
                    list.Add((double)ht[i]);
                }
                catch { }
            }
            return list.ToArray();
        }

        /// <summary>
        /// Double value format
        /// </summary>
        /// <param name="value">double</param>
        /// <returns>string - value as text</returns>
        public static String Format(this double value)
        {
            return String.Format("{0,5:0.00000000000000000000}", value) + " ";
        }

        /// <summary>
        /// Get matrix data nice format
        /// </summary>
        /// <param name="mat">MatrixMB</param>
        /// <returns>string - matrix text representation</returns>
        public static String NiceMatrixFormat(this MatrixMB mat)
        {
            string s = "";
            for (int i = 0; i < mat.Rows; i++)
            {
                for (int j = 0; j < mat.Cols; j++) s += String.Format("{0,5:0.00}", mat.Data[i][j]) + " ";
                s += "\r\n";
            }
            return s;
        }
    }//class
}//ns
