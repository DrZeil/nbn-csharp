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
