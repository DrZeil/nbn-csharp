using System;
using LearnByErrorLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class WeightsCorrectionTest
    {
        [TestMethod]
        public void Weigths___Correction___Test()
        {
            int nw = 7;
            var I = MatrixMB.Eye(nw);
            double mu = 0.01;
            var info = new NetworkInfo();
            var hessian = new Hessian(ref info);
            hessian.HessianMat = MatrixMB.Ones(7, 7);
            hessian.GradientMat = MatrixMB.Ones(7, 1);
            hessian.GradientMat[0, 0] = 1;
            hessian.GradientMat[1, 0] = 2;
            hessian.GradientMat[2, 0] = 3;
            hessian.GradientMat[3, 0] = 4;
            hessian.GradientMat[4, 0] = 5;
            hessian.GradientMat[5, 0] = 6;
            hessian.GradientMat[6, 0] = 7;

            var ww_backup = new Weights(nw);
            for (int i = 0; i < nw; i++) ww_backup[i] = 1;

            var diff = ((hessian.HessianMat + (I * mu)).Inverted * hessian.GradientMat).Transposed;
            var weights = ww_backup - diff.ToWeights();

            var ew = new Weights(nw);
            ew[0] = 300.43;
            ew[1] = 200.43;
            ew[2] = 100.43;
            ew[3] = 0.4294;
            ew[4] = -99.571;
            ew[5] = -199.57;
            ew[6] = -299.57;

            int accuracy = 2;
            for (int i = 0; i < nw; i++)
            {
                Assert.AreEqual(Math.Round(ew[i], accuracy), Math.Round(weights[i], accuracy));
            }
        }
    }
}
/*MatLab test
 clear;
nw = 7;
I = eye(nw);
ww_backup = ones(1,7);
hessian = ones(7,7);
mu = 0.01;
gradient = [1;2;3;4;5;6;7];
ww = ww_backup - ((hessian+mu*I)\gradient)';
disp('Nowe wagi to:');
disp(ww);
 * 
 Result:
 * 
Nowe wagi to:
       300.43       200.43       100.43      0.42939      -99.571      -199.57      -299.57
 */