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
            GradientMat = MatrixMB.Zeros(info.nw, 1);//gradient = zeros(nw,1);
            HessianMat = MatrixMB.Zeros(info.nw, info.nw);//hessian = zeros(nw,nw);
            np = info.np;//number of patterns
            ni = info.ni;//number of inputs
            no = info.no;//number of outputs
            nw = info.nw;//number of weights
            nn = info.nn;//number of neurons
            nio = nn + ni - no;
            zeros = ni.Zeros();

            for (p = 0; p < np; p++)//for each pattern do following calculations
            {
                node.Clear();
                node.AddRange(inp.Data[p]);//get row
                derivates.AddRange(zeros);//and prepare for derivates from function

                CalculateFunctionValuesAndDerivates(ref ww, ref iw, ref topo, ref act, ref gain);

                for (k = 0; k < no; k++)//for each output do the following  for k = 1:no           % for each output
                {
                    o = nio + k;//o = nn + ni - no + k;
                    error = dout.Data[p][k] - node[o];//error = dout(p,k) - node(nn+ni-no+k);
                    J = MatrixMB.Zeros(1, nw);//Jacobian row J = zeros(1, nw);  % Jacobian row
                    s = iw.Pos(o - ni);//  s = iw(o-ni);
                    J.Data[0][s] = -derivates[o];//J(s) = -de(o);   %%% modify de depending on sign of error and net 
                    delo = MatrixMB.Zeros(1, nio + 1);//delo=zeros(1,nn+ni-no+1);

                    CalculateJacobian(ref ww, ref iw, ref topo);

                    CalculateForHiddenLayer(ref iw, ref topo, ref ww);

                    if (dout[p, 0] > 0.5) J = J * ratio;//  if dout(p)>0.5, J=J*ratio; end;
                    var JT = J.Transposed;
                    GradientMat = GradientMat + JT * error;//gradient = gradient + J'*error;
                    HessianMat = HessianMat + JT * J;//hessian = hessian + J'*J;
                }
            }
        }

        private void CalculateForHiddenLayer(ref Index iw, ref Topography topo, ref Weights ww)
        {
            for (n = 0; n < nn - no; n++)//for n = 1:(nn-no)                 %hidden neurons in the reverse order
            {
                j = nio - n - 1;//j = nn+ni-no + 1 - n;   %node number
                s = iw[j - ni];//s = iw(j-ni);
                J[0, s] = -derivates[j] * delo[0, j];//J(s) = -de(j)*delo(j);                    %for bias of hidden neurons

                for (i = s + 1; i <= iw[j - ni + 1] - 1; i++)//for i = (s+1):(iw(j-ni+1)-1)        %for weights of hidden neurons
                {
                    J[0, i] = node[topo[i]] * J[0, s];//J(i) = node(topo(i))*J(s);
                    delo[0, topo[i]] -= ww[i] * J[0, s];//delo(topo(i)) = delo(topo(i)) - ww(i)*J(s);
                }
            }
        }

        private void CalculateJacobian(ref Weights ww, ref Index iw, ref Topography topo)
        {
            for (i = s + 1; i < iw[o + 1 - ni]; i++)//from 10 to 18 inclusive - was <= for i = (s+1):(iw(o+1-ni)-1)
            {
                J[0, i] = node[topo[i]] * J[0, s];//J(i) = node(topo(i))*J(s);
                delo[0, topo[i]] -= ww[i] * J[0, s];//delo(topo(i)) = delo(topo(i))-ww(i)*J(s);
            }
        }

        private void CalculateFunctionValuesAndDerivates(ref Weights ww, ref Index iw, ref Topography topo, ref Activation act, ref Gain gain)
        {
            for (int n = 0; n < nn; n++)//for each neuron in network for n = 1:nn
            {
                j = ni + n;//  j = ni + n;
                net = ww[iw[n]];//calculate net sum net = ww(iw(n));

                for (i = iw[n] + 1; i <= iw[n + 1] - 1; i++)//in this loop   for i = (iw(n)+1):(iw(n+1)-1)
                {
                    net += node[topo[i]] * ww[i];//net = net + node(topo(i))*ww(i);
                }

                //[out,de(j)]=actFuncDer(n,net,act,gain);
                var res = ActivationFunction.computeFunctionDervative(ref n, ref net, ref act, ref gain);//and function value and its derivative
                //node(j) = out;
                node.Add(res.FunctionResult);//save function value for output signal from neuron
                derivates.Add(res.FunctionDerivative);//save function derivative value for output signal from neuron
            }
        }
        #endregion
    }//class
}//ns
