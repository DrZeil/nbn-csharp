/*
Author:  Marek Bar 33808
Contact: marekbar1985@gmail.com
Wyższa Szkoła Informatyki i Zarządzania w Rzeszowie
 */
namespace LearnByErrorLibrary
{
    /// <summary>
    /// Activation function computing class
    /// </summary>
    public static class ActivationFunction
    {
        /// <summary>
        /// Computes activation function
        /// </summary>
        /// <param name="n">int</param>
        /// <param name="net">double - net</param>
        /// <param name="acct">VectorHorizontal - activation matrix</param>
        /// <param name="gain">VectorHorizontal - gain matrix</param>
        /// <returns>double - function result</returns>
        /// <remarks>Remember that values are passed by ref to speed up</remarks>
        public static double computeFunction(ref int n,ref double net, ref Activation acct, ref Gain gain)
        {
            try
            {
                FunctionChoice function = (FunctionChoice)(int)acct.Data[0][n];
                switch (function)
                {
                    case FunctionChoice.LinearNeuron:
                        {
                            return gain.Data[0][n] * net;
                        }

                    case FunctionChoice.UnipolarNeuron:
                        {
                            return 1 / (1 + System.Math.Exp(-gain.Data[0][n] * net));
                        }

                    case FunctionChoice.BipolarNeuron:
                        {
                            return System.Math.Tanh(gain.Data[0][n] * net);
                        }

                    case FunctionChoice.BipolarElliotNeuron:
                        {
                            return gain.Data[0][n] * net / (1 + gain.Data[0][n] * System.Math.Abs(net));
                        }

                    case FunctionChoice.UnipolarElliotNeuron:
                        {
                            return 2 * gain.Data[0][n] * net / (1 + gain.Data[0][n] * System.Math.Abs(net)) - 1;
                        }
                    default:
                        {
                            throw new System.Exception(Properties.Settings.Default.FE1);
                        }
                }
            }
            catch (System.Exception ex)
            {
                throw new NeuralNetworkError("Błąd obliczania funkcji aktywacji.", ex);
            }
        }

        /// <summary>
        /// Computes activation function and its derivative
        /// </summary>
        /// <param name="n">int</param>
        /// <param name="net">double - net</param>
        /// <param name="acct">VectorHorizontal - activation matrix</param>
        /// <param name="gain">VectorHorizontal - gain matrix</param>
        /// <returns>FunctionRD - function result</returns>
        /// <remarks>Remember that values are passed by ref to speed up</remarks>
        public static FunctionRD computeFunctionDervative(ref int n, ref double net, ref Activation acct, ref Gain gain)
        {
            FunctionChoice function = (FunctionChoice)(int)acct.Data[0][n];
            FunctionRD rd = new FunctionRD();
            switch (function)
            {
                case FunctionChoice.LinearNeuron://for output layer
                    {
                        rd.FunctionResult = gain.Data[0][n] * net;
                        rd.FunctionDerivative = gain.Data[0][n];
                    }break;

                case FunctionChoice.UnipolarNeuron:
                    {
                        rd.FunctionResult = 1 / (1 + System.Math.Exp(-gain.Data[0][n] * net));
                        rd.FunctionDerivative = gain.Data[0][n] * (1 - rd.FunctionResult) * rd.FunctionResult;
                    }break;

                case FunctionChoice.BipolarNeuron://for hidden layer
                    {
                        rd.FunctionResult = System.Math.Tanh(gain.Data[0][n] * net);
                        rd.FunctionDerivative = gain.Data[0][n] * (1 - System.Math.Pow(rd.FunctionResult,2));
                    }break;

                case FunctionChoice.BipolarElliotNeuron:
                    {
                        rd.FunctionResult = gain.Data[0][n] * net / (1 + gain.Data[0][n] * System.Math.Abs(net));
                        rd.FunctionDerivative = 1 / System.Math.Pow((gain.Data[0][n] * System.Math.Abs(net) + 1), 2);
                    }break;

                case FunctionChoice.UnipolarElliotNeuron:
                    {
                        rd.FunctionResult = 2 * gain.Data[0][n] * net / (1 + gain.Data[0][n] * System.Math.Abs(net)) - 1;
                        rd.FunctionDerivative = 2 * gain.Data[0][n] / System.Math.Pow((gain.Data[0][n] * System.Math.Abs(net) + 1), 2);
                    }break;

                default:
                    {
                        throw new NeuralNetworkError(Properties.Settings.Default.FE1);
                    }
            }
            return rd;
        } 
    }
}

