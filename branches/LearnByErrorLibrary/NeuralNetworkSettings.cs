/*
Author:  Marek Bar 33808
Contact: marekbar1985@gmail.com
Wyższa Szkoła Informatyki i Zarządzania w Rzeszowie
 */
namespace LearnByErrorLibrary
{
    /// <summary>
    /// Settings used by neural network trainer
    /// </summary>
    public class NeuralNetworkSettings
    {
        /// <summary>
        ///  MU controls how much the weights are changed on each iteration.
        /// </summary>
        public double MU;

        /// <summary>
        /// High bound of MU
        /// </summary>
        public double MUH;

        /// <summary>
        /// Low bound of MU
        /// </summary>
        public double MUL;

        /// <summary>
        /// Scale
        /// </summary>
        public double Scale;

        /// <summary>
        /// Max required error
        /// </summary>
        public double MaxError;

        /// <summary>
        /// Maximum number of iteration that can be perforemed during learning process
        /// </summary>
        public int MaxIterations;

        /// <summary>
        /// Default constructor - need to set parameters manually
        /// </summary>
        public NeuralNetworkSettings()
        {
        }

        /// <summary>
        /// Secondary contructor setting its properties
        /// </summary>
        /// <param name="maxIter">int - maximum number of iterations</param>
        /// <param name="mu">double - MU controls how much the weights are changed on each iteration</param>
        /// <param name="muL">double - Low bound of MU</param>
        /// <param name="muH">double - High bound of MU</param>
        /// <param name="scale">double - scale</param>
        /// <param name="maxError">double - max error</param>
        public NeuralNetworkSettings(int maxIter, double mu, double muL, double muH, double scale, double maxError)
        {
            this.MaxIterations = maxIter;
            this.MU = mu;
            this.MUL = muL;
            this.MUH = muH;
            this.Scale = scale;
            this.MaxError = maxError;
        }

        /// <summary>
        /// Creates default settings with predefined values
        /// </summary>
        /// <returns></returns>
        public static NeuralNetworkSettings Default()
        {
            NeuralNetworkSettings nns = new NeuralNetworkSettings();
            nns.MU = 0.01;           
            nns.MUH = 1e15;
            nns.MUL = 1e-15;
            nns.Scale = 10;
            nns.MaxError = 0.001;
            nns.MaxIterations = 10;
            return nns;
        }

        /// <summary>
        /// Settings of neural network as string
        /// </summary>
        /// <returns>String</returns>
        public override string ToString()
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine();
            sb.AppendLine("------------------------------------------------------------");
            sb.AppendLine("Neural network settings");
            sb.AppendLine("MU = " + MU.ToString() + " (MU controls how much the weights are changed on each iteration)");
            sb.AppendLine("MUH = " + MUH.ToString() + " (high bound of MU)");
            sb.AppendLine("MUL = " + MUL.ToString() + " (low bound of MU)");
            sb.AppendLine("Scale = " + Scale.ToString());
            sb.AppendLine("Max error = " + MaxError.ToString());
            sb.AppendLine("Maximum number of iterations: " + MaxIterations.ToString());
            sb.AppendLine("------------------------------------------------------------");
            return sb.ToString();
        }
    }
}
