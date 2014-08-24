/*
Author:  Marek Bar 33808
Contact: marekbar1985@gmail.com
Wyższa Szkoła Informatyki i Zarządzania w Rzeszowie
 */
namespace LearnByErrorLibrary
{
    /// <summary>
    /// Activation function
    /// </summary>
    public class Activation : VectorHorizontal
    {
        /// <summary>
        /// Activation function constructor
        /// </summary>
        /// <param name="size">int - size of activation funciton vector</param>
        public Activation(int size)
            : base(size)
        { }

        /// <summary>
        /// Gets activation text representation
        /// </summary>
        /// <returns>string - text</returns>
        public override string ToString()
        {
            var sb = new System.Text.StringBuilder();

            sb.AppendLine();
            sb.AppendLine("------------------------------------------------------------");
            sb.AppendLine("Activation");
            string tmp = "";
            for (int i = 0; i < Length; i++)
            {
                tmp += this.Data[0][i].ToString() + (i == Length-1 ? "" : ", ");
            }
            sb.AppendLine(tmp);
            sb.AppendLine("------------------------------------------------------------");
            return sb.ToString();
        }
    }
}
