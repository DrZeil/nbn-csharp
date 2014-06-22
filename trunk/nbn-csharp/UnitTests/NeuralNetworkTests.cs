/*
Author:  Marek Bar 33808
Contact: marekbar1985@gmail.com
Wyższa Szkoła Informatyki i Zarządzania w Rzeszowie
 */
using System;
using System.Diagnostics;
using LearnByErrorLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class NeuralNetworkTests
    {
        [TestMethod]
        public void Test__WeightCorrectionCalculation()
        {
            //this is just check of calculation: ((hessian+mu*I)\gradient)' if is correct
            /*
             >> %((hessian+mu*I)\gradient)'
>> hessian = [1 2; 3 4]
hessian =

     1     2
     3     4
>> mu = 2
mu =
     2
>> I = eye(2)
I =
     1     0
     0     1
>> gradient=[1;2]
gradient =
     1
     2
>> res=((hessian+mu*I)\gradient)'
res =
    0.1667    0.2500
             */
            var hessian = new MatrixMB(2, 2);
            //no matter if its hessian result or not
            hessian[0, 0] = 1;
            hessian[0, 1] = 2;
            hessian[1, 0] = 3;
            hessian[1, 1] = 4;

            double mu = 2;

            var I = MatrixMB.Eye(2);

            var gradient = new MatrixMB(2, 1);
            gradient[0, 0] = 1;
            gradient[1, 0] = 2;

            // var diff = ((hessian.HessianMat + (I * setting.MU)).Inverted * hessian.GradientMat).Transposed;
            var add = hessian + I * mu;
            var inv = add.Inverted;
            var div = inv * gradient;
            var res = div.Transposed;

            Assert.AreEqual(1, res.Rows);
            Assert.AreEqual(2, res.Cols);
            Assert.AreEqual(0.1667, Math.Round(res[0, 0],4));
            Assert.AreEqual(0.25, Math.Round(res[0, 1],4));

        }

        [TestMethod]
        public void Test__CalculateError()
        {
            //based on parity 2 example
            NetworkInfo info = new NetworkInfo();
            info.np = 3;
            info.ni = 2;
            info.no = 1;
            info.nn = 2;
            info.nw = 7;

            Input i = new Input(info.np, info.ni);
            i[0, 0] = -1;
            i[0, 1] = -1;

            i[1, 0] = -1;
            i[1, 1] = 1;

            i[2, 0] = 1;
            i[2, 1] = -1;

            Output o = new Output(info.np, info.no);
            o[0, 0] = 1;
            o[1, 0] = 0;
            o[2, 0] = 0;

            Topography topo = new Topography(new double[] { 2,1,2,3,1,2,3});
            Index iw = new Index(3);
            iw[0]=0;
            iw[1]=3;
            iw[2]=6;
            

            Weights w = new Weights(info.nw);
            w.FillWithNumber(0.1);

            Activation act = new Activation(info.nn);
            act[0] = 2;
            act[1] = 0;

            Gain g = new Gain(info.nn);
            g[0] = 1;
            g[1] = 1;

            NetworkError e = new NetworkError();
            e.CalculateError(ref info, ref i, ref o, ref topo, w, ref act, ref g, ref iw);
            Assert.AreEqual(1.23, Math.Round(e.Error,2));
        }

        [TestMethod]
        public void Test__NormalizeDataForInOut()
        {
            /*
             -1 -1  1; 
             -1  1 -1; 
              1 -1 -1; 
              1  1  1
             */
            Input i = new Input(4,3);
            i[0, 0] = -1;
            i[0, 1] = -1;
            i[0, 2] = 1;

            i[1, 0] = -1;
            i[1, 1] = 1;
            i[1, 2] = -1;

            i[2, 0] = 1;
            i[2, 1] = -1;
            i[2, 2] = -1;

            i[3, 0] = 1;
            i[3, 1] = 1;
            i[3, 2] = 1;

            var input = i.CopyColumns(i.Cols - 2).ToInput();
            Assert.AreEqual(2, input.Cols);
            Assert.AreEqual(4, input.Rows);
            input.Normalize();
            /*            
            -1    -1
            -1     1
             1    -1
             1     1
             */
            Assert.AreEqual(-1, input[0, 0]); Assert.AreEqual(-1, input[0, 1]);
            Assert.AreEqual(-1, input[1, 0]); Assert.AreEqual(1, input[1, 1]);
            Assert.AreEqual(1, input[2, 0]); Assert.AreEqual(-1, input[2, 1]);
            Assert.AreEqual(1, input[3, 0]); Assert.AreEqual(1, input[3, 1]);

            var output = i.LastColumn.ToOutput();
            Assert.AreEqual(1, output.Cols);
            Assert.AreEqual(4, output.Rows);
            output.Normalize();

            Assert.AreEqual(1, output[0, 0]);
            Assert.AreEqual(0, output[1, 0]);
            Assert.AreEqual(0, output[2, 0]);
            Assert.AreEqual(1, output[3, 0]);
            /*
             1
             0
             0
             1
             */
        }
    }
}
