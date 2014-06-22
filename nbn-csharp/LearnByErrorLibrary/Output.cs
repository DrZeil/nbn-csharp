/*
Author:  Marek Bar 33808
Contact: marekbar1985@gmail.com
Wyższa Szkoła Informatyki i Zarządzania w Rzeszowie
 */
namespace LearnByErrorLibrary
{
    /// <summary>
    /// Output data from network
    /// </summary>
    public class Output : MatrixMB
    {
        /// <summary>
        /// Output constructor
        /// </summary>
        /// <param name="rows">int - number of rows</param>
        /// <param name="cols">int - number of columns</param>
        public Output(int rows, int cols)
            : base(rows, cols)
        {
        }

        /// <summary>
        /// Normalize expected output
        /// </summary>
        public void Normalize()
        {
            /*
             
Td = Td-min(Td);
Td = Td/max(Td);
             */
            double min = this.MinValue;
            this.Operation(MatrixAction.Substract, min);
            double max = this.MaxValue;
            this.Operation(MatrixAction.Divide, max);
        }
    }
}
