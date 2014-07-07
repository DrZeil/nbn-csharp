/*
Author:  Marek Bar 33808
Contact: marekbar1985@gmail.com
Wyższa Szkoła Informatyki i Zarządzania w Rzeszowie
 */
namespace LearnByErrorLibrary
{
    /// <summary>
    /// Neural network error object
    /// </summary>
    public class NetworkError
    {
        /// <summary>
        /// Netowrk desired error (0.000000000000001) for rmse sth
        /// </summary>
        public static double DesiredError = 0.000000000000001;
        
        /// <summary>
        /// Neural network error
        /// </summary>
        public double Error;

        /// <summary>
        /// Temporary variables used by loops
        /// </summary>
        private int n, i, k, p;

        /// <summary>
        /// Net sum
        /// </summary>
        private double net = 0;

        /// <summary>
        /// Nodes values
        /// </summary>
        private System.Collections.Generic.List<double> node = new System.Collections.Generic.List<double>();   

        /// <summary>
        /// Total error calculation
        /// </summary>
        /// <param name="info">NetworkInfo</param>
        /// <param name="inp">ref Input - input data patterns</param>
        /// <param name="dout">ref Output - output data</param>
        /// <param name="topo">ref Topography - topo is network topology in the form of one vector</param>
        /// <param name="ww">ref Weights  weights</param>
        /// <param name="act">ref Activation - type of activation function</param>
        /// <param name="gain">ref Gain - strengthening the activation function</param>
        /// <param name="iw">ref WeightsPointers - index pointers used for network topology stored in top in the form of one vector</param>
        /// <remarks>Network error will be overriden so please save it</remarks>
        public double CalculateError(ref NetworkInfo info, ref Input inp, ref Output dout, ref Topography topo, 
                                     Weights ww, ref Activation act, ref Gain gain, ref Index iw)
        {
            try//this is tested version - see unit test
            {
                Error = 0;
                for (p = 0; p < info.np; p++)
                {
                    node.Clear();
                    node.AddRange(inp.Data[p]);

                    for (n = 0; n < info.nn; n++)
                    {
                        net = ww[iw.Pos(n)];

                        int from = iw.Pos(n) + 1;
                        int to = iw.Pos(n + 1) - 1;

                        for (i = from; i <= to; i++)
                        {
                            net += node[(int)topo[i]] * ww[i];
                        }

                        node.Add(ActivationFunction.computeFunction(ref n, ref net, ref act, ref gain));

                    }

                    for (k = 0; k < info.no; k++)
                    {
                        Error += System.Math.Pow((dout.Data[p][k] - node[info.nio + k]), 2);
                    }
                }

                return Error;
            }
            catch (System.Exception ex)
            {
                throw new NeuralNetworkError("Błąd uaktualnienia błędu sieci neuronowej. " + ex.Message, ex);
            }
        }//update error method
    }//class
}//ns
