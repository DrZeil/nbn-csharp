using System;
using LearnByErrorLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class HessianGradientTest
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

        [TestMethod]
        public void Hessian___Gradient___Calculation___Test()
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

            Topography topo = Topography.Generate(TopographyType.BMLP, vh);

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

            Compute(ref info, ref input, ref output, ref topo, weights, ref act, ref gain, ref iw);//compute hessian and its gradient for above data

            var eh = new MatrixMB(7, 7);//expected hessian
            var eg = new MatrixMB(7, 1);//expected gradient

            eh[0, 0] = 1.0583;
            eh[1, 0] = -0.70551;
            eh[2, 0] = -0.70551;
            eh[3, 0] = 2.5198;
            eh[4, 0] = -1.6799;
            eh[5, 0] = -1.6799;
            eh[6, 0] = -0.6397;

            eh[0, 1] = -0.70551;
            eh[1, 1] = 1.0583;
            eh[2, 1] = 0.35276;
            eh[3, 1] = -1.6799;
            eh[4, 1] = 2.5198;
            eh[5, 1] = 0.83995;
            eh[6, 1] = 1.2794;

            eh[0, 2] = -0.70551;
            eh[1, 2] = 0.35276;
            eh[2, 2] = 1.0583;
            eh[3, 2] = -1.6799;
            eh[4, 2] = 0.83995;
            eh[5, 2] = 2.5198;
            eh[6, 2] = 1.2794;

            eh[0, 3] = 2.5198;
            eh[1, 3] = -1.6799;
            eh[2, 3] = -1.6799;
            eh[3, 3] = 6;
            eh[4, 3] = -4;
            eh[5, 3] = -4;
            eh[6, 3] = -1.5232;

            eh[0, 4] = -1.6799;
            eh[1, 4] = 2.5198;
            eh[2, 4] = 0.83995;
            eh[3, 4] = -4;
            eh[4, 4] = 6;
            eh[5, 4] = 2;
            eh[6, 4] = 3.0464;

            eh[0, 5] = -1.6799;
            eh[1, 5] = 0.83995;
            eh[2, 5] = 2.5198;
            eh[3, 5] = -4;
            eh[4, 5] = 2;
            eh[5, 5] = 6;
            eh[6, 5] = 3.0464;

            eh[0, 6] = -0.6397;
            eh[1, 6] = 1.2794;
            eh[2, 6] = 1.2794;
            eh[3, 6] = -1.5232;
            eh[4, 6] = 3.0464;
            eh[5, 6] = 3.0464;
            eh[6, 6] = 3.4802;

            /*expected result
             HESIAN:
               1.0583     -0.70551     -0.70551       2.5198      -1.6799      -1.6799      -0.6397
             -0.70551       1.0583      0.35276      -1.6799       2.5198      0.83995       1.2794
             -0.70551      0.35276       1.0583      -1.6799      0.83995       2.5198       1.2794
               2.5198      -1.6799      -1.6799            6           -4           -4      -1.5232
              -1.6799       2.5198      0.83995           -4            6            2       3.0464
              -1.6799      0.83995       2.5198           -4            2            6       3.0464
              -0.6397       1.2794       1.2794      -1.5232       3.0464       3.0464       3.4802
             * 
             *
            GRADIENT:
             -0.83995
               2.3196
               2.3196
                   -2
               5.5232
               5.5232
               6.8897
             */
            eg[0, 0] = -0.83995;
            eg[1, 0] = 2.3196;
            eg[2, 0] = 2.3196;
            eg[3, 0] = -2;
            eg[4, 0] = 5.5232;
            eg[5, 0] = 5.5232;
            eg[6, 0] = 6.8897;

            /*MatLab test code
                function [] = hessian_gradient_test()
                fprintf('\n----------------------------------------------------\n');
                clear;
                inp = [-1 -1;-1 1; 1 -1];
                dout = [1;0;0];
                topo = [3 1 2 4 1 2 3];%[2 0 1 3 0 1 2]; - in c#
                ww = [1 1 1 1 1 1 1];
                act = [2 0];
                gain = [1 1];
                param = [3 2 1 7 2];
                iw = [1 4 8];%[0 3 7]; - in c#

                [gradient, hessian] = Hessian(inp, dout, topo, ww, act, gain, param, iw);

                disp('HESIAN:');
                disp(hessian);
                disp('GRADIENT:');
                disp(gradient);
                end
             */

            int decimalAccuracy = 2;
            for (int i = 0; i < eh.Rows; i++)//check hessian
            {
                for (int j = 0; j < eh.Cols; j++)
                {
                    Assert.AreEqual(Math.Round(eh[i, j], decimalAccuracy), Math.Round(HessianMat[i, j], decimalAccuracy));
                }
            }

            for (int i = 0; i < eg.Rows; i++)//check gradient
            {
                Assert.AreEqual(Math.Round(eg[i, 0], decimalAccuracy), Math.Round(GradientMat[i, 0], decimalAccuracy));
            }
        }
    }
}
