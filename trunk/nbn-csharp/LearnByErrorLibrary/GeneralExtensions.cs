/*
Author:  Marek Bar 33808
Contact: marekbar1985@gmail.com
Wyższa Szkoła Informatyki i Zarządzania w Rzeszowie
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace LearnByErrorLibrary
{
    /// <summary>
    /// Extension methods for library
    /// </summary>
    public static class GeneralExtensions
    {
        /// <summary>
        /// Gets full error message
        /// </summary>
        /// <param name="ex">Exception - ex</param>
        /// <returns>String - error message</returns>
        public static String GetError(this Exception ex)
        {
            return ex.Message + (ex.InnerException!= null ? ex.InnerException.Message : "");            
        }

        /// <summary>
        /// Gets permutation array
        /// </summary>
        /// <param name="n">int - size of array</param>
        /// <returns>int[] - permutation array</returns>
        public static int[] RandomPermutation(this int n)
        {

            List<int> numbers = new List<int>();
            for (int i = 1; i <= n; i++) numbers.Add(i);

            Random rnd = new Random();
            return numbers.ToArray().OrderBy(x => rnd.Next()).ToArray();
        }

        /// <summary>
        /// Check if noise
        /// </summary>
        /// <param name="val">double</param>
        /// <returns>bool</returns>
        public static bool NoNoise(this double val)
        {
            return val != 0;
        }

        /// <summary>
        /// Gets RMSE
        /// </summary>
        /// <param name="SSE">System.Collections.Hashtable - sse list</param>
        /// <param name="iteration">int - current iteration</param>
        /// <param name="patternsNumber">int - number of patterns</param>
        /// <returns>double - RMSE</returns>
        [Obsolete("Should not to be used any more")]
        public static double getRMSE(this System.Collections.Hashtable SSE, int iteration, int patternsNumber)
        {
            return System.Math.Sqrt((((double)SSE[iteration - 1] - (double)SSE[iteration]) / (double)SSE[iteration - 1])/patternsNumber);
        }

        /// <summary>
        /// Gets SSE
        /// </summary>
        /// <param name="SSE">System.Collections.Hashtable - sse list</param>
        /// <param name="iteration">int - current iteration</param>
        /// <returns>double - RMSE</returns>
        [Obsolete("Should not to be used any more")]
        public static double getSSE(this System.Collections.Hashtable SSE, int iteration)
        {
            return ((double)SSE[iteration - 1] - (double)SSE[iteration]) / (double)SSE[iteration - 1];
        }

        public static double PreviousSSE(this System.Collections.Hashtable SSE, int iteration)
        {
            return (double)SSE[iteration - 1];
        }
        /// <summary>
        /// Get vector filled with zeroes
        /// </summary>
        /// <param name="size">int - size of vector</param>
        /// <returns>double[]</returns>
        public static double[] Zeros(this int size)
        {
            var row = new double[size];
            for (int i = 0; i < size; i++)
            {
                row[i] = 0;
            }
            return row;
        }
    }

}
