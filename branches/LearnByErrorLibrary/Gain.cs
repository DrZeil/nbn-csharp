/*
Author:  Marek Bar 33808
Contact: marekbar1985@gmail.com
Wyższa Szkoła Informatyki i Zarządzania w Rzeszowie
 */
namespace LearnByErrorLibrary
{
    /// <summary>
    /// Gain - strengthening the activation function
    /// </summary>
    public class Gain : VectorHorizontal
    {
        /// <summary>
        /// Gain constructor
        /// </summary>
        /// <param name="size">int - size of gain vector</param>
        public Gain(int size)
            : base(size)
        {
        }

        /// <summary>
        /// Gets gain text representation
        /// </summary>
        /// <returns>string - text</returns>
        public override string ToString()
        {
            var sb = new System.Text.StringBuilder();

            sb.AppendLine();
            sb.AppendLine("------------------------------------------------------------");
            sb.AppendLine("Gain");
            string tmp = "";
            for (int i = 0; i < Length; i++)
            {
                tmp += this.Data[0][i].ToString() + (i == Length - 1 ? "" : ", ");
            }
            sb.AppendLine(tmp);
            sb.AppendLine("------------------------------------------------------------");
            return sb.ToString();
        }
    }
}
