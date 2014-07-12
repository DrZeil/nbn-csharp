using System;
using LearnByErrorLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class HessianGradientTest
    {

        [TestMethod]
        public void Hessian___Gradient___Calculation___Test()
        {
            int accuracy = 15;
            /*
             function obliczanie_hesjan_gradient()
clear();
inp = [-1 -1;-1 1; 1 -1];
dout = [1;0;0];
topo = [3 1 2 4 1 2 3];
ww = [1 1 1 1 1 1 1];
act = [2 0];
gain = [1 1];
param = [3 2 1 7 2];
iw = [1 4 8];
format long;

[gradient,hessian] = Hessian(inp,dout,topo,ww,act,gain,param,iw);
fprintf('Otrzymany gradient:\n');
disp(gradient);
fprintf('\nOtrzymany hesjan:\n');
disp(hessian);

% To jest otrzymywane
% Otrzymany gradient:
%   -0.839948683228052
%    2.319597374905329
%    2.319597374905329
%   -2.000000000000000
%    5.523188311911530
%    5.523188311911531
%    6.889667569278484
% 
% 
% Otrzymany hesjan:
%   Columns 1 through 6
% 
%    1.058270685684809  -0.705513790456539  -0.705513790456539   2.519846049684157  -1.679897366456105  -1.679897366456105
%   -0.705513790456539   1.058270685684809   0.352756895228269  -1.679897366456105   2.519846049684157   0.839948683228052
%   -0.705513790456539   0.352756895228269   1.058270685684809  -1.679897366456105   0.839948683228052   2.519846049684157
%    2.519846049684157  -1.679897366456105  -1.679897366456105   6.000000000000000  -4.000000000000000  -4.000000000000000
%   -1.679897366456105   2.519846049684157   0.839948683228052  -4.000000000000000   6.000000000000000   2.000000000000000
%   -1.679897366456105   0.839948683228052   2.519846049684157  -4.000000000000000   2.000000000000000   6.000000000000000
%   -0.639700008449225   1.279400016898449   1.279400016898449  -1.523188311911530   3.046376623823059   3.046376623823059
% 
%   Column 7
% 
%   -0.639700008449225
%    1.279400016898449
%    1.279400016898449
%   -1.523188311911530
%    3.046376623823059
%    3.046376623823059
%    3.480153950315843
end
             */
            Input input = new Input(3, 2);//inp = [-1 -1;-1 1; 1 -1];
            input[0, 0] = -1;
            input[0, 1] = -1;
            input[1, 0] = -1;
            input[1, 1] = 1;
            input[2, 0] = 1;
            input[2, 1] = -1;

            Output output = new Output(3, 1);//dout = [1;0;0];
            output[0, 0] = 1;
            output[1, 0] = 0;
            output[2, 0] = 0;

            NetworkInfo info = new NetworkInfo();//param = [3 2 1 7 2];
            info.ni = 2;
            info.nn = 2;
            info.no = 1;
            info.np = 3;
            info.nw = 7;

            VectorHorizontal vh = new VectorHorizontal(3);
            vh[0, 0] = 2;
            vh[0, 1] = 1;
            vh[0, 2] = 1;

            Topography topo = Topography.Generate(TopographyType.BMLP, vh);//topo = [3 1 2 4 1 2 3];
            //w C# indeksy są od zera a nie od 1 więc wszystko o 1 w dół przestawione jest
            Assert.AreEqual(2, topo[0]);
            Assert.AreEqual(0, topo[1]);
            Assert.AreEqual(1, topo[2]);
            Assert.AreEqual(3, topo[3]);
            Assert.AreEqual(0, topo[4]);
            Assert.AreEqual(1, topo[5]);
            Assert.AreEqual(2, topo[6]);

            Weights weights = new Weights(info.nw);//w = [1 1 1 1 1 1 1];
            weights.FillWithNumber(1);//załatwione

            Activation act = new Activation(2);//act = [2 0];
            act[0] = 2;
            act[1] = 0;

            Gain gain = new Gain(2);//gain = [1 1];
            gain[0] = 1;
            gain[1] = 1;

            Index iw = Index.Find(ref topo);//iw = [1 4 8];
            //ta sama sytuacja, indeksy od 0 startują
            Assert.AreEqual(0, iw[0]);
            Assert.AreEqual(3, iw[1]);
            Assert.AreEqual(7, iw[2]);
            Console.WriteLine("Testowanie obliczania gradientu i macierzy hesjana");
            Console.WriteLine("Użyte dane:");
            Console.WriteLine("\nDane wejściowe:");
            Console.WriteLine(input.MatrixToString());
            Console.WriteLine("\nDane wyjściowe:");
            Console.WriteLine(output.MatrixToString());
            Console.WriteLine("\nWagi;");
            Console.WriteLine(weights.MatrixToString());
            Console.WriteLine("\nTopologia:");
            Console.WriteLine(topo.MatrixToString());
            Console.WriteLine("\nIndeksy topologii:");
            Console.WriteLine(iw.MatrixToString());
            Console.WriteLine("\nFunkcje aktywacji:");
            Console.WriteLine(act.MatrixToString());
            Console.WriteLine("\nWzmocnienia (gains):");
            Console.WriteLine(gain.MatrixToString());
            Console.WriteLine("\nParametry (param):");
            Console.WriteLine(info.ToString());
            Hessian hess = new Hessian(ref info);
            hess.Compute(ref info, ref input, ref output, ref topo, weights, ref act, ref gain, ref iw);
            var g = hess.GradientMat;
            var h = hess.HessianMat;

            Console.WriteLine("\nSprawdzanie gradientu z dokładnością do 15 miejsc po przecinku");
            var matG = new double[] { -0.839948683228052, 2.319597374905329, 2.319597374905329, -2.000000000000000, 5.523188311911530, 5.523188311911531, 6.889667569278484 };
            /*
% Otrzymany gradient:
%   -0.839948683228052
%    2.319597374905329
%    2.319597374905329
%   -2.000000000000000
%    5.523188311911530
%    5.523188311911531
%    6.889667569278484
             */
            for (int i = 0; i < matG.Length; i++)
            {
                Console.WriteLine(string.Format("NBN C#: {0}\tMatLab NBN: {1}\t{2}", Math.Round(g[i, 0], accuracy), matG[i], Math.Round(g[i, 0], accuracy) == matG[i] ? "OK" : "źle"));
            }

            Assert.AreEqual(-0.839948683228052, Math.Round(g[0, 0], accuracy));
            Assert.AreEqual(2.319597374905329, Math.Round(g[1, 0], accuracy));
            Assert.AreEqual(2.319597374905329, Math.Round(g[2, 0], accuracy));
            Assert.AreEqual(-2.000000000000000, Math.Round(g[3, 0], accuracy));
            Assert.AreEqual(5.523188311911530, Math.Round(g[4, 0], accuracy));
            Assert.AreEqual(5.523188311911531, Math.Round(g[5, 0], accuracy));
            Assert.AreEqual(6.889667569278484, Math.Round(g[6, 0], accuracy));

            Console.WriteLine("\nSprawdzanie macierzy hesjana\nPorównania z dokładnością do 15 miejsc po przecinku");
            MatrixMB matH = new MatrixMB(7, 7);
            //col 1
            matH[0, 0] = 1.058270685684809;
            matH[1, 0] = -0.705513790456539;
            matH[2, 0] = -0.705513790456539;
            matH[3, 0] = 2.519846049684157;
            matH[4, 0] = -1.679897366456105;
            matH[5, 0] = -1.679897366456105;
            matH[6, 0] = -0.639700008449225;

            //col 2
            matH[0, 1] = -0.705513790456539;
            matH[1, 1] = 1.058270685684809;
            matH[2, 1] = 0.352756895228269;
            matH[3, 1] = -1.679897366456105;
            matH[4, 1] = 2.519846049684157;
            matH[5, 1] = 0.839948683228052;
            matH[6, 1] = 1.279400016898449;

            //col 3
            matH[0, 2] = -0.705513790456539;
            matH[1, 2] = 0.352756895228269;
            matH[2, 2] = 1.058270685684809;
            matH[3, 2] = -1.679897366456105;
            matH[4, 2] = 0.839948683228052;
            matH[5, 2] = 2.519846049684157;
            matH[6, 2] = 1.279400016898449;

            //col 4
            matH[0, 3] = 2.519846049684157;
            matH[1, 3] = -1.679897366456105;
            matH[2, 3] = -1.679897366456105;
            matH[3, 3] = 6.000000000000000;
            matH[4, 3] = -4.000000000000000;
            matH[5, 3] = -4.000000000000000;
            matH[6, 3] = -1.523188311911530;

            //col 5
            matH[0, 4] = -1.679897366456105;
            matH[1, 4] = 2.519846049684157;
            matH[2, 4] = 0.839948683228052;
            matH[3, 4] = -4.000000000000000;
            matH[4, 4] = 6.000000000000000;
            matH[5, 4] = 2.000000000000000;
            matH[6, 4] = 3.046376623823059;

            //col 6
            matH[0, 5] = -1.679897366456105;
            matH[1, 5] = 0.839948683228052;
            matH[2, 5] = 2.519846049684157;
            matH[3, 5] = -4.000000000000000;
            matH[4, 5] = 2.000000000000000;
            matH[5, 5] = 6.000000000000000;
            matH[6, 5] = 3.046376623823059;

            //col 7
            matH[0, 6] = -0.639700008449225;
            matH[1, 6] = 1.279400016898449;
            matH[2, 6] = 1.279400016898449;
            matH[3, 6] = -1.523188311911530;
            matH[4, 6] = 3.046376623823059;
            matH[5, 6] = 3.046376623823059;
            matH[6, 6] = 3.480153950315843;

            for (int k = 0; k < h.Cols; k++)
            {
                Console.WriteLine(string.Format("Kolumna {0}", k + 1));
                for (int w = 0; w < h.Rows; w++)
                {
                    decimal dh = Math.Round((decimal)h[w, k], accuracy);
                    decimal dmh = Math.Round((decimal)matH[w, k], accuracy);
                    Console.WriteLine(string.Format("NBN C#: {0}\tMatLab NBN: {1}\t{2}", dh, dmh, dh == dmh ? "OK" : "źle"));
                }
                Console.WriteLine("");
            }

            for (int k = 0; k < h.Cols; k++)
            {                
                for (int w = 0; w < h.Rows; w++)
                {
                    decimal dh = Math.Round((decimal)h[w, k], accuracy);
                    decimal dmh = Math.Round((decimal)matH[w, k], accuracy);
                    Assert.AreEqual(dmh, dh);   
                }             
            }
            /*
% Otrzymany hesjan:
%   Columns 1 through 6
% 
%    1.058270685684809  -0.705513790456539  -0.705513790456539   2.519846049684157  -1.679897366456105  -1.679897366456105
%   -0.705513790456539   1.058270685684809   0.352756895228269  -1.679897366456105   2.519846049684157   0.839948683228052
%   -0.705513790456539   0.352756895228269   1.058270685684809  -1.679897366456105   0.839948683228052   2.519846049684157
%    2.519846049684157  -1.679897366456105  -1.679897366456105   6.000000000000000  -4.000000000000000  -4.000000000000000
%   -1.679897366456105   2.519846049684157   0.839948683228052  -4.000000000000000   6.000000000000000   2.000000000000000
%   -1.679897366456105   0.839948683228052   2.519846049684157  -4.000000000000000   2.000000000000000   6.000000000000000
%   -0.639700008449225   1.279400016898449   1.279400016898449  -1.523188311911530   3.046376623823059   3.046376623823059
% 
%   Column 7
% 
%   -0.639700008449225
%    1.279400016898449
%    1.279400016898449
%   -1.523188311911530
%    3.046376623823059
%    3.046376623823059
%    3.480153950315843
             */
        }
    }
}
