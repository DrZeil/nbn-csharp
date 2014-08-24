/*
Author:  Marek Bar 33808
Contact: marekbar1985@gmail.com
Wyższa Szkoła Informatyki i Zarządzania w Rzeszowie
 */
namespace LearnByErrorLibrary
{
    /// <summary>
    /// Horizontal vector eg double[1, n]
    /// </summary>
    public class VectorHorizontal : MatrixMB
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="size">int - size of vector</param>
        public VectorHorizontal(int size)
            : base(1, size)
        { }

        /// <summary>
        /// Sets vector value
        /// </summary>
        /// <param name="index">int - index of value</param>
        /// <param name="value">double - new value</param>
        public void setValue(int index, double value)
        {
            this.Data[0][index] = value;
        }

        /// <summary>
        /// Gets vector value
        /// </summary>
        /// <param name="index">int - vector value index</param>
        /// <returns>double - value at index</returns>
        public double getValue(int index)
        {
            return this.Data[0][index];
        }

        /// <summary>
        /// Gets vector value
        /// </summary>
        /// <param name="index">int - vector value index</param>
        /// <returns>double - value at index</returns>
        public double At(int index)
        {
            return this.Data[0][index];
        }

        /// <summary>
        /// Get value at position as index value
        /// </summary>
        /// <param name="index">int - value index</param>
        /// <returns>int - read value to be used as index</returns>
        public int Pos(int index)
        {
            return (int)this.Data[0][index];
        }

        /// <summary>
        /// Get value at index position
        /// </summary>
        /// <param name="index">int - index</param>
        /// <returns>double - read value</returns>
        public double Val(int index)
        {
            return this.Data[0][index];
        }
        /// <summary>
        /// Get vector length
        /// </summary>
        public int Length
        {
            get
            {
                return this.Cols;
            }
        }

        /// <summary>
        /// Sum elements
        /// </summary>
        /// <param name="fromIndex">int - startindex - including</param>
        /// <param name="toIndex">int - stop index - including</param>
        /// <returns>double - sum</returns>
        public double Sum(int fromIndex, int toIndex)
        {
            double sum = 0;
            for (int i = fromIndex; i <= toIndex; i++)
            {
                sum += this.Data[0][i];
            }
            return sum;
        }

        /// <summary>
        /// Gets values from range
        /// </summary>
        /// <param name="fromIndex">int - startindex - including</param>
        /// <param name="toIndex">int - stop index - including</param>
        /// <returns>double[] - values from given range</returns>
        public double[] GetRange(int fromIndex, int toIndex)
        {
            System.Collections.Generic.List<double> values = new System.Collections.Generic.List<double>();
            for (int i = fromIndex; i <= toIndex; i++)
            {
                values.Add(this.Data[0][i]);
            }
            return values.ToArray();
        }

        /// <summary>
        /// Easy access to data
        /// </summary>
        /// <param name="index">int - index</param>
        /// <returns>double  - value at position</returns>
        public double this[int index]
        {
            get { return Data[0][index]; }
            set { Data[0][index] = value; }
        }
    }
}
