/*
Author:  Marek Bar 33808
Contact: marekbar1985@gmail.com
Wyższa Szkoła Informatyki i Zarządzania w Rzeszowie
 */
namespace LearnByErrorLibrary
{
    /// <summary>
    /// Input data patterns
    /// </summary>
    public class Input : MatrixMB
    {
        /// <summary>
        /// Input constructor
        /// </summary>
        /// <param name="rows">int - number of rows</param>
        /// <param name="cols">int - number of columns</param>
        public Input(int rows, int cols)
            : base(rows, cols)
        {
        }

        /// <summary>
        /// Normalize input data to the values in common range
        /// </summary>
        public void Normalize()
        {
            /*
             Ti = Ti/max(max(abs(Ti)));                
             */

            MatrixMB mb = new MatrixMB(Rows, Cols, Data);
            mb.Operation(MatrixAction.Abs, 0);
            double max = mb.MaxValue;
            this.Operation(MatrixAction.Divide, max);

            //stare
            //this.Operation(MatrixAction.Abs, 0);
            //double max = this.MaxValue;
            //this.Operation(MatrixAction.Divide, max);
        }
    }
}
