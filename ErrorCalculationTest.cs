using System;
using LearnByErrorLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class ErrorCalculationTest
    {        
        /// <summary>
        /// Testowanie obliczania błędu SSE, oraz porównanie go z błędem otrzymanym w MatLabie. Wewnątrz testu znajduje się w komentarzu kod MatLaba użyty do obliczenia błędu.
        /// Użyte dane do obliczenia błędu są identyczne - patrz wnętrze funkcji.
        /// </summary>
        [TestMethod]        
        public void Test___Error___Calculation___Test()
        {            
            /*
             * 
             * 
             Kod testowy matlaba
             * 
function obliczanie_bledu()
inp = [-1 -1;-1 1; 1 -1];
dout = [1;0;0];
topo = [3 1 2 4 1 2 3];
w = [1 1 1 1 1 1 1];
act = [2 0];
gain = [1 1];
param = [3 2 1 7 2];
iw = [1 4 8];
format long;
error = calculate_error(inp,dout,topo,w,act,gain,param,iw);
fprintf('Obliczanie błędu uczenia sieci\nBłąd wynosi: %.20f\n', error);
%Otrzymany wynik
%Obliczanie błędu uczenia sieci
%Błąd wynosi: 13.83283022280404000000             
end
             * 
             * 
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

            NetworkError ne = new NetworkError();
            var error = ne.CalculateError(ref info, ref input, ref output, ref topo, weights, ref act, ref gain, ref iw);
            
            double errorFromMatLab = 13.83283022280404000000;

            Console.WriteLine("Testowanie obliczania błędu");
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

            Assert.AreEqual(errorFromMatLab, error);
            Console.WriteLine(string.Format("{0} - wynik NBN C#",error));
            Console.WriteLine(string.Format("{0} - wynik NBN w MatLabie",errorFromMatLab));
        }
    }
}
