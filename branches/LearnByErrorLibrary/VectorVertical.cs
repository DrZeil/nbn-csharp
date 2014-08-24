/*
Author:  Marek Bar 33808
Contact: marekbar1985@gmail.com
Wyższa Szkoła Informatyki i Zarządzania w Rzeszowie
 */
namespace LearnByErrorLibrary
{
    /// <summary>
    /// Vertical vector, eg. double[n, 1] where n means size
    /// </summary>
    public class VectorVertical : MatrixMB
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="size">int - size</param>
        public VectorVertical(int size)
            : base(size, 1)
        {
        }

        /// <summary>
        /// Set vector value
        /// </summary>
        /// <param name="index">int - index of row at vector</param>
        /// <param name="value">double - new value</param>
        public void setValue(int index, double value)
        {
            this.Data[index][0] = value;
        }

        /// <summary>
        /// Gets vector value
        /// </summary>
        /// <param name="index">int - index of vector column</param>
        /// <returns>double - value from vector</returns>
        public double getValue(int index)
        {
            return this.Data[index][0];
        }

        /// <summary>
        /// Get vector length
        /// </summary>
        public int Length
        {
            get
            {
                return this.Rows;
            }
        }

        /// <summary>
        /// Easy access to data
        /// </summary>
        /// <param name="index">int - index</param>
        /// <returns>double - value</returns>
        public double this[int index]
        {
            get { return Data[index][0]; }
            set { Data[index][0] = value; }
        }

    }

    
}
