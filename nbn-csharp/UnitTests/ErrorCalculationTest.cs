using System;
using LearnByErrorLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class ErrorCalculationTest
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
            try
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

        [TestMethod]
        public void Test___Error___Calculation___Test()
        {
            /*
             Testing on parity 2 problem
             *  -1 -1  1
                -1  1 -1
                 1 -1 -1
                 1  1  1

             */

            Input input = new Input(3, 2);
            input[0, 0] = -1;
            input[0, 1] = -1;
            input[1, 0] = -1;
            input[1, 1] = 1;
            input[2, 0] = 1;
            input[2, 1] = -1;

            Output output = new Output(3, 1);
            output[0, 0] = 1;
            output[1, 0] = 0;
            output[2, 0] = 0;

            NetworkInfo info = new NetworkInfo();
            info.ni = 2;
            info.nn = 2;
            info.no = 1;
            info.np = 3;
            info.nw = 7;//było 6 i powodowało rozbieżność w obliczaniu błędu sieci
          
            VectorHorizontal vh = new VectorHorizontal(3);            
            vh[0, 0] = 2;
            vh[0, 1] = 1;
            vh[0, 2] = 1;

            //Topography topo = Topography.Generate(TopographyType.BMLP, vh);
            //topo[0] = 2;//2
            //topo[1] = 1;
            //topo[2] = 2;
            //topo[3] = 3;//3
            //topo[4] = 1;
            //topo[5] = 2;
            //topo[6] = 3;
            Topography topo = Topography.Generate(TopographyType.BMLP, vh);
            //topo[0] = 2;//2
            //topo[1] = 0;
            //topo[2] = 1;
            //topo[3] = 3;//3
            //topo[4] = 0;
            //topo[5] = 1;
            //topo[6] = 2;
            Weights weights = new Weights(info.nw);
            for (int i = 0; i < info.nw; i++)
            {
                weights[0, i] = 1;
            }

            Activation act = new Activation(2);
            act[0] = 2;
            act[1] = 0;

            Gain gain = new Gain(2);
            gain[0] = 1;
            gain[1] = 1;

            Index iw = Index.Find(ref topo);
            //iw[0] = 0;
            //iw[1] = 3;
            //iw[2] = 7;

            var error = CalculateError(ref info, ref input, ref output, ref topo, weights, ref act, ref gain, ref iw);
            error = Math.Round(error, 4);
            double errorFromMatLab = 13.8328;

            Assert.AreEqual(errorFromMatLab, error);
        }
    }
}
