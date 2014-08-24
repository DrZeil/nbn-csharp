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
            var gradient = new MatrixMB(7, 1);
            //gradient = [-0.839948683228052; 2.319597374905329; 2.319597374905329; -2.000000000000000; 5.523188311911530; 5.523188311911531; 6.889667569278484];
            gradient[0,0] = -0.839948683228052;
            gradient[1,0] = 2.319597374905329;
            gradient[2,0] = 2.319597374905329;
            gradient[3,0] = -2.000000000000000;
            gradient[4,0] =  5.523188311911530;
            gradient[5,0] =  5.523188311911531;
            gradient[6,0] =  6.889667569278484;

            /*
              hessian = [
    1.058270685684809  -0.705513790456539  -0.705513790456539 2.519846049684157  -1.679897366456105  -1.679897366456105 -0.639700008449225;
   -0.705513790456539   1.058270685684809   0.352756895228269  -1.679897366456105   2.519846049684157   0.839948683228052 1.279400016898449;
   -0.705513790456539   0.352756895228269   1.058270685684809  -1.679897366456105   0.839948683228052   2.519846049684157 1.279400016898449;
    2.519846049684157  -1.679897366456105 -1.679897366456105   6.000000000000000  -4.000000000000000  -4.000000000000000 -1.523188311911530;
   -1.679897366456105   2.519846049684157   0.839948683228052  -4.000000000000000   6.000000000000000   2.000000000000000 3.046376623823059;
   -1.679897366456105   0.839948683228052   2.519846049684157  -4.000000000000000   2.000000000000000   6.000000000000000 3.046376623823059;
   -0.639700008449225   1.279400016898449   1.279400016898449  -1.523188311911530   3.046376623823059   3.046376623823059 3.480153950315843
];  
  */

            MatrixMB hessian = new MatrixMB(7, 7);
            //col 1
            hessian[0, 0] = 1.058270685684809;
            hessian[1, 0] = -0.705513790456539;
            hessian[2, 0] = -0.705513790456539;
            hessian[3, 0] = 2.519846049684157;
            hessian[4, 0] = -1.679897366456105;
            hessian[5, 0] = -1.679897366456105;
            hessian[6, 0] = -0.639700008449225;

            //col 2
            hessian[0, 1] = -0.705513790456539;
            hessian[1, 1] = 1.058270685684809;
            hessian[2, 1] = 0.352756895228269;
            hessian[3, 1] = -1.679897366456105;
            hessian[4, 1] = 2.519846049684157;
            hessian[5, 1] = 0.839948683228052;
            hessian[6, 1] = 1.279400016898449;

            //col 3
            hessian[0, 2] = -0.705513790456539;
            hessian[1, 2] = 0.352756895228269;
            hessian[2, 2] = 1.058270685684809;
            hessian[3, 2] = -1.679897366456105;
            hessian[4, 2] = 0.839948683228052;
            hessian[5, 2] = 2.519846049684157;
            hessian[6, 2] = 1.279400016898449;

            //col 4
            hessian[0, 3] = 2.519846049684157;
            hessian[1, 3] = -1.679897366456105;
            hessian[2, 3] = -1.679897366456105;
            hessian[3, 3] = 6.000000000000000;
            hessian[4, 3] = -4.000000000000000;
            hessian[5, 3] = -4.000000000000000;
            hessian[6, 3] = -1.523188311911530;

            //col 5
            hessian[0, 4] = -1.679897366456105;
            hessian[1, 4] = 2.519846049684157;
            hessian[2, 4] = 0.839948683228052;
            hessian[3, 4] = -4.000000000000000;
            hessian[4, 4] = 6.000000000000000;
            hessian[5, 4] = 2.000000000000000;
            hessian[6, 4] = 3.046376623823059;

            //col 6
            hessian[0, 5] = -1.679897366456105;
            hessian[1, 5] = 0.839948683228052;
            hessian[2, 5] = 2.519846049684157;
            hessian[3, 5] = -4.000000000000000;
            hessian[4, 5] = 2.000000000000000;
            hessian[5, 5] = 6.000000000000000;
            hessian[6, 5] = 3.046376623823059;

            //col 7
            hessian[0, 6] = -0.639700008449225;
            hessian[1, 6] = 1.279400016898449;
            hessian[2, 6] = 1.279400016898449;
            hessian[3, 6] = -1.523188311911530;
            hessian[4, 6] = 3.046376623823059;
            hessian[5, 6] = 3.046376623823059;
            hessian[6, 6] = 3.480153950315843;


            Weights weights = new Weights(7);
            weights.FillWithNumber(1);

            double mu = 0.01;
            var I = MatrixMB.Eye(weights.Length);


            Console.WriteLine("Testowanie obliczania korekty wag");
            Console.WriteLine("Hesjan:");
            Console.WriteLine(hessian.MatrixToString());
            Console.WriteLine("Gradient:");
            Console.WriteLine(gradient.MatrixToString());
            Console.WriteLine("Wagi początkowe:");
            Console.WriteLine(weights.MatrixToString());
            Console.WriteLine("MU = " + mu.ToString());
            Console.WriteLine("Macierz I");
            Console.WriteLine(I.MatrixToString());

            //korekta_wag =  ((hessian+mu*I)\gradient)';
            /*
             Lewa strona
              Columns 1 through 6

               1.068270685684809  -0.705513790456539  -0.705513790456539   2.519846049684157  -1.679897366456105  -1.679897366456105
              -0.705513790456539   1.068270685684809   0.352756895228269  -1.679897366456105   2.519846049684157   0.839948683228052
              -0.705513790456539   0.352756895228269   1.068270685684809  -1.679897366456105   0.839948683228052   2.519846049684157
               2.519846049684157  -1.679897366456105  -1.679897366456105   6.010000000000000  -4.000000000000000  -4.000000000000000
              -1.679897366456105   2.519846049684157   0.839948683228052  -4.000000000000000   6.010000000000000   2.000000000000000
              -1.679897366456105   0.839948683228052   2.519846049684157  -4.000000000000000   2.000000000000000   6.010000000000000
              -0.639700008449225   1.279400016898449   1.279400016898449  -1.523188311911530   3.046376623823059   3.046376623823059

              Column 7

              -0.639700008449225
               1.279400016898449
               1.279400016898449
              -1.523188311911530
               3.046376623823059
               3.046376623823059
               3.490153950315843
             */
            var lewa_strona_matlab = new MatrixMB(7, 7);
            lewa_strona_matlab[0, 0] = 1.06827068568480900000;
            lewa_strona_matlab[0, 1] = -0.70551379045653895000;
            lewa_strona_matlab[0, 2] = -0.70551379045653895000;
            lewa_strona_matlab[0, 3] = 2.51984604968415700000;
            lewa_strona_matlab[0, 4] = -1.67989736645610500000;
            lewa_strona_matlab[0, 5] = -1.67989736645610500000;
            lewa_strona_matlab[0, 6] = -0.63970000844922503000;
            lewa_strona_matlab[1, 0] = -0.70551379045653895000;
            lewa_strona_matlab[1, 1] = 1.06827068568480900000;
            lewa_strona_matlab[1, 2] = 0.35275689522826897000;
            lewa_strona_matlab[1, 3] = -1.67989736645610500000;
            lewa_strona_matlab[1, 4] = 2.51984604968415700000;
            lewa_strona_matlab[1, 5] = 0.83994868322805205000;
            lewa_strona_matlab[1, 6] = 1.27940001689844900000;
            lewa_strona_matlab[2, 0] = -0.70551379045653895000;
            lewa_strona_matlab[2, 1] = 0.35275689522826897000;
            lewa_strona_matlab[2, 2] = 1.06827068568480900000;
            lewa_strona_matlab[2, 3] = -1.67989736645610500000;
            lewa_strona_matlab[2, 4] = 0.83994868322805205000;
            lewa_strona_matlab[2, 5] = 2.51984604968415700000;
            lewa_strona_matlab[2, 6] = 1.27940001689844900000;
            lewa_strona_matlab[3, 0] = 2.51984604968415700000;
            lewa_strona_matlab[3, 1] = -1.67989736645610500000;
            lewa_strona_matlab[3, 2] = -1.67989736645610500000;
            lewa_strona_matlab[3, 3] = 6.00999999999999980000;
            lewa_strona_matlab[3, 4] = -4.00000000000000000000;
            lewa_strona_matlab[3, 5] = -4.00000000000000000000;
            lewa_strona_matlab[3, 6] = -1.52318831191152990000;
            lewa_strona_matlab[4, 0] = -1.67989736645610500000;
            lewa_strona_matlab[4, 1] = 2.51984604968415700000;
            lewa_strona_matlab[4, 2] = 0.83994868322805205000;
            lewa_strona_matlab[4, 3] = -4.00000000000000000000;
            lewa_strona_matlab[4, 4] = 6.00999999999999980000;
            lewa_strona_matlab[4, 5] = 2.00000000000000000000;
            lewa_strona_matlab[4, 6] = 3.04637662382305900000;
            lewa_strona_matlab[5, 0] = -1.67989736645610500000;
            lewa_strona_matlab[5, 1] = 0.83994868322805205000;
            lewa_strona_matlab[5, 2] = 2.51984604968415700000;
            lewa_strona_matlab[5, 3] = -4.00000000000000000000;
            lewa_strona_matlab[5, 4] = 2.00000000000000000000;
            lewa_strona_matlab[5, 5] = 6.00999999999999980000;
            lewa_strona_matlab[5, 6] = 3.04637662382305900000;
            lewa_strona_matlab[6, 0] = -0.63970000844922503000;
            lewa_strona_matlab[6, 1] = 1.27940001689844900000;
            lewa_strona_matlab[6, 2] = 1.27940001689844900000;
            lewa_strona_matlab[6, 3] = -1.52318831191152990000;
            lewa_strona_matlab[6, 4] = 3.04637662382305900000;
            lewa_strona_matlab[6, 5] = 3.04637662382305900000;
            lewa_strona_matlab[6, 6] = 3.49015395031584270000;

            var lewa_strona_csharp = hessian + (I * mu);

            Console.WriteLine("Lewa strona dzielenia - obliczanie korekty wag => (hessian+mu*I)");
            for (int i = 0; i < lewa_strona_csharp.Rows; i++)
            {
                for (int j = 0; j < lewa_strona_csharp.Cols; j++)
                {
                    var result = Math.Round(((decimal)lewa_strona_csharp[i, j]), 15);
                    var expected = Math.Round(((decimal)lewa_strona_matlab[i, j]), 15);
                    Console.WriteLine(string.Format("Poz[{0},{1}] => NBN C#: {2}\tMatLab NBN: {3}\t{4}", i,j,result, expected, result == expected ? "OK" : "źle"));
                }
            }

            for (int i = 0; i < lewa_strona_csharp.Rows; i++)
            {
                for (int j = 0; j < lewa_strona_csharp.Cols; j++)
                {
                    var result = Math.Round(((decimal)lewa_strona_csharp[i, j]), 15);
                    var expected = Math.Round(((decimal)lewa_strona_matlab[i, j]), 15);
                    Assert.AreEqual(expected, result);
                }
            }

            var diff = ((hessian + (I * mu)).Inverted * gradient).Transposed;
            /*
             Expected weights diff
             % Otrzymana korekta wag:
            % 
            % 0.27954017281149085000
            % 0.21238647096009383000
            % 0.21238647096010940000
            % 0.66561250322368737000
            % 0.50571296842532187000
            % 0.50571296842531543000
            % 1.27722267527372440000
            % Koniec
             * 
             */

            var diffMatLab = new double[] 
            {
             0.27954017281149085000,
             0.21238647096009383000,
             0.21238647096010940000,
             0.66561250322368737000,
             0.50571296842532187000,
             0.50571296842531543000,
             1.27722267527372440000
            };

            /*
             Test matlabowy
             function obliczanie_korekty_wag()
%ww = ww_backup - ((hessian+mu*I)\gradient)';
clear();
ww = [1 1 1 1 1 1 1];
mu = 0.01;
I = eye(size(ww,2));%tyle co wag
format long;
gradient = [-0.839948683228052; 2.319597374905329; 2.319597374905329; -2.000000000000000; 5.523188311911530; 5.523188311911531; 6.889667569278484];
hessian = [
    1.058270685684809  -0.705513790456539  -0.705513790456539 2.519846049684157  -1.679897366456105  -1.679897366456105 -0.639700008449225;
   -0.705513790456539   1.058270685684809   0.352756895228269  -1.679897366456105   2.519846049684157   0.839948683228052 1.279400016898449;
   -0.705513790456539   0.352756895228269   1.058270685684809  -1.679897366456105   0.839948683228052   2.519846049684157 1.279400016898449;
    2.519846049684157  -1.679897366456105 -1.679897366456105   6.000000000000000  -4.000000000000000  -4.000000000000000 -1.523188311911530;
   -1.679897366456105   2.519846049684157   0.839948683228052  -4.000000000000000   6.000000000000000   2.000000000000000 3.046376623823059;
   -1.679897366456105   0.839948683228052   2.519846049684157  -4.000000000000000   2.000000000000000   6.000000000000000 3.046376623823059;
   -0.639700008449225   1.279400016898449   1.279400016898449  -1.523188311911530   3.046376623823059   3.046376623823059 3.480153950315843
];
   
korekta_wag =  ((hessian+mu*I)\gradient)';
fprintf('\nOtrzymana korekta wag:\n');
for i=1:size(ww,2)
    fprintf('\n%.20f',korekta_wag(i));
end
fprintf('\nKoniec\n');
end

% Otrzymana korekta wag:
% 
% 0.27954017281149085000
% 0.21238647096009383000
% 0.21238647096010940000
% 0.66561250322368737000
% 0.50571296842532187000
% 0.50571296842531543000
% 1.27722267527372440000
% Koniec
             
             */

            Console.WriteLine("Korekta wag:");

            int accuracy = 15;
            for (int i = 0; i < diffMatLab.Length; i++)
            {
                decimal result = (decimal)diff[0, i];
                decimal expected = (decimal)diffMatLab[i];
                result = Math.Round(result, accuracy);
                expected = Math.Round(expected, accuracy);
                Console.WriteLine(string.Format("NBN C#: {0}\tMatLab NBN: {1}\t {2}", result, expected, result == expected ? "OK" : "źle"));
            }

            for (int i = 0; i < diffMatLab.Length; i++)
            {
                decimal result = (decimal)diff[0, i];
                decimal expected = (decimal)diffMatLab[i];
                result = Math.Round(result, accuracy);
                expected = Math.Round(expected, accuracy);
                Assert.AreEqual(expected, result);
            }
        }
    }
}
