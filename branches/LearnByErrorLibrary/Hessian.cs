/*
Author:  Marek Bar 33808
Contact: marekbar1985@gmail.com
Wyższa Szkoła Informatyki i Zarządzania w Rzeszowie
 */
namespace LearnByErrorLibrary
{
    /// <summary>
    /// Computes Hessian matrix
    /// </summary>
    public class Hessian
    {
        #region FIELDS
        /// <summary>
        /// MatrixMB of gradient
        /// </summary>
        public MatrixMB GradientMat;

        /// <summary>
        /// Resulting Hessian matrix - must call Compute before retrieving
        /// </summary>
        public MatrixMB HessianMat;

        /// <summary>
        /// Ratio value
        /// </summary>
        private double ratio = 2;

        /// <summary>
        /// Temporarary variables
        /// </summary>
        private int p, n, k, s, i, j, o;

        /// <summary>
        /// Temporary matrixes
        /// </summary>
        private MatrixMB J, delo;
        private double error, net;

        /// <summary>
        /// Node
        /// </summary>
        private System.Collections.Generic.List<double> node = new System.Collections.Generic.List<double>();

        /// <summary>
        /// Derivates
        /// </summary>
        private System.Collections.Generic.List<double> derivates = new System.Collections.Generic.List<double>();

        /// <summary>
        /// Zeros array
        /// </summary>
        private double[] zeros = null;

        private int np, ni, no, nw, nn, nio;
        #endregion

        #region CONSTRUCTOR

        /// <summary>
        /// Computes Hessian matrix - outputs from computin can be accessed by GradientMat and HessianMat properties
        /// </summary>
        /// <param name="info">NetworkInfo - info about network</param>
        public Hessian(ref NetworkInfo info)
        {

        }

        #endregion

        #region COMPUTING
        /// <summary>
        /// Compute psudo hessian matrix and its gradient
        /// </summary>
        /// <param name="info">NetworkInfo - information about neural network</param>
        /// <param name="inp">Input - input data patterns used for learn</param>
        /// <param name="dout">Output - output data patterns used for learn</param>
        /// <param name="topo">Topography - neural network topography</param>
        /// <param name="ww">Weights - weights</param>
        /// <param name="act">Activation - activation function selection</param>
        /// <param name="gain">Gain - neuron gain</param>
        /// <param name="iw">Index - topography indexes</param>
        public void Compute(ref NetworkInfo info, ref Input inp, ref Output dout, ref Topography topo,
                   Weights ww, ref Activation act, ref Gain gain, ref Index iw)
        {
            GradientMat = MatrixMB.Zeros(info.nw, 1);
            HessianMat = MatrixMB.Zeros(info.nw, info.nw);
            np = info.np;//number of patterns
            ni = info.ni;//number of inputs
            no = info.no;//number of outputs
            nw = info.nw;//number of weights
            nn = info.nn;//number of neurons
            nio = nn + ni - no;
            zeros = ni.Zeros();
            delo = MatrixMB.Zeros(1, nio + 1);
            J = MatrixMB.Zeros(1, nw);

            for (p = 0; p < np; p++)
            {
                node.Clear();
                node.AddRange(inp.Data[p]);
               
                CalculateFunctionValuesAndDerivates(ref ww, ref iw, ref topo, ref act, ref gain);

                for (k = 0; k < no; k++)
                {
                    o = nio + k;
                    error = dout.Data[p][k] - node[o];
                    J.ClearWithZeros();
                    s = iw.Pos(o - ni);
                    J.Data[0][s] = -derivates[o];
                    delo.ClearWithZeros();

                    CalculateJacobian(ref ww, ref iw, ref topo);

                    CalculateForHiddenLayer(ref iw, ref topo, ref ww);

                    if (dout[p, 0] > 0.5) J = J * ratio;
                    var JT = J.Transposed;
                    GradientMat = GradientMat + JT * error;
                    HessianMat = HessianMat + JT * J;
                }
            }
        }

        private void CalculateForHiddenLayer(ref Index iw, ref Topography topo, ref Weights ww)
        {
            for (n = 0; n < nn - no; n++)
            {
                j = nio - n - 1;
                s = iw[j - ni];
                J[0, s] = -derivates[j] * delo[0, j];

                for (i = s + 1; i <= iw[j - ni + 1] - 1; i++)
                {
                    J[0, i] = node[topo[i]] * J[0, s];
                    delo[0, topo[i]] -= ww[i] * J[0, s];
                }
            }           
        }

        private void CalculateJacobian(ref Weights ww, ref Index iw, ref Topography topo)
        {
            for (i = s + 1; i <= iw[o + 1 - ni] - 1; i++)
            {
                J[0, i] = node[topo[i]] * J[0, s];
                delo[0, topo[i]] -= ww[i] * J[0, s];
            }
        }

        private void CalculateFunctionValuesAndDerivates(ref Weights ww, ref Index iw, ref Topography topo, ref Activation act, ref Gain gain)
        {
            derivates.Clear();
            derivates.AddRange(node.Count.Zeros());

            for (int n = 0; n < nn; n++)//for each neuron in network
            {                
                net = ww[iw[n]];//calculate net sum

                for (i = iw[n] + 1; i <= iw[n + 1] - 1; i++)
                {
                    net += (node[topo[i]] * ww[i]);
                }

                var res = ActivationFunction.computeFunctionDervative(ref n, ref net, ref act, ref gain);//and function value and its derivative                
                node.Add(res.FunctionResult);//save function value for output signal from neuron
                derivates.Add(res.FunctionDerivative);//save function derivative value for output signal from neuron
            }
        }
        #endregion
    }//class
}//ns
