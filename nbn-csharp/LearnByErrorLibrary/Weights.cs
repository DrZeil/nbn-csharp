/*
Author:  Marek Bar 33808
Contact: marekbar1985@gmail.com
Wyższa Szkoła Informatyki i Zarządzania w Rzeszowie
 */
namespace LearnByErrorLibrary
{
    /// <summary>
    /// Neural network weights
    /// </summary>
    public class Weights : VectorHorizontal
    {        
        /// <summary>
        /// Weights constructor
        /// </summary>
        /// <param name="numberOfWeights">int - number of weights - must match inputs number</param>
        /// <see cref="Input"/>
        public Weights(int numberOfWeights) : base(numberOfWeights)
        {

        }

        /// <summary>
        /// Generatesrandom weights from range
        /// </summary>
        /// <param name="leftRangeSide">int - left range border</param>
        /// <param name="rightRangeSide">int - rigth range border</param>
        public void Random(int leftRangeSide, int rightRangeSide)
        {
            System.Random rand = new System.Random();
            int rl = (rightRangeSide - leftRangeSide);
            for (int i = 0; i < Cols; i++) 
            {
                this.Data[0][i] = rand.NextDouble() * rl + leftRangeSide;
            }
        }

        /// <summary>
        /// Creates random weights
        /// </summary>
        /// <param name="numberOfWeights">int - number of weights - must match inputs number</param>
        /// <param name="leftRangeSide">int - left range border</param>
        /// <param name="rightRangeSide">int - rigth range border</param>
        /// <returns>Weights - random weights</returns>
        public static Weights RandomVector(int numberOfWeights, int leftRangeSide, int rightRangeSide)
        {
            Weights w = new Weights(numberOfWeights);
            w.Random(leftRangeSide, rightRangeSide);
            return w;
        }

        /// <summary>
        /// Generates weights vector from -1 to 1 range
        /// </summary>
        /// <param name="size">int - number of weights</param>
        /// <returns>Weights</returns>
        public static Weights Generate(int size)
        {
            Weights w = new Weights(size);
            w.Random(-1, 1);
            return w;
        }

        /// <summary>
        /// Create copy of weights vector
        /// </summary>
        /// <returns>Weights copy</returns>
        public Weights Backup()
        {
            Weights www = new Weights(Cols);
            for (int col = 0; col < Cols; col++)
            {
                www.Data[0][col] = this.Data[0][col];
            }
            return www;        
        }

        /// <summary>
        /// Weigths vector as string
        /// </summary>
        /// <returns>String</returns>
        public override string ToString()
        {
            var sb = new System.Text.StringBuilder();

            sb.AppendLine();
            sb.AppendLine(Name + " Weights");
            sb.AppendLine("------------------------------------------------------------");
            for (int i = 0; i < Length; i++)
            {
                sb.AppendLine("[" + (i + 1).ToString() + "] => " + this.Data[0][i].ToString());
            }
            sb.AppendLine("------------------------------------------------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Check if weights are equal
        /// </summary>
        /// <param name="ww">Weights</param>
        /// <returns>bool</returns>
        public bool IsEqual(Weights ww)
        {
            int counter = 0;
            for (int i = 0; i < this.Length; i++)
            {
                if (this.Data[0][i] == ww.Data[0][i]) counter++;
            }
            return counter == ww.Length;
        }

        /// <summary>
        /// Substraction of weights
        /// </summary>
        /// <param name="one">Weights - first</param>
        /// <param name="two">Weights - second</param>
        /// <returns>Weights - new Weights as a result of substraction</returns>
        public static Weights operator -(Weights one, Weights two)
        {
            try
            {
                if (one.Cols == two.Cols && one.Rows == 1 && two.Rows == 1)
                {
                    var result = new Weights(one.Cols);
                    
                    for (int col = 0; col < one.Cols; col++)
                    {
                        result.Data[0][col] = one.Data[0][col] - two.Data[0][col];
                    }
  
                    return result;
                }
                else
                {
                    throw new System.Exception(System.String.Format("Cannot substract weights. Weights size doesn't match. Weights one: {0}x{1}, Weights two: {2}x{3}", one.Cols, one.Rows, two.Cols, two.Rows));
                }
            }
            catch (System.Exception ex)
            {
                throw new MatrixException("Weights substraction error", ex);
            }
        }
    }
}
