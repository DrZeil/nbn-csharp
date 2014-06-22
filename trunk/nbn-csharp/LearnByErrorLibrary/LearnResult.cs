/*
Author:  Marek Bar 33808
Contact: marekbar1985@gmail.com
Wyższa Szkoła Informatyki i Zarządzania w Rzeszowie
 */
using System;
using System.Collections.Generic;
using marekbar;

namespace LearnByErrorLibrary
{
    /// <summary>
    /// Learn result of learing neural network
    /// </summary>
    public class LearnResult
    {
        #region PROPERTIES
        /// <summary>
        /// File with data
        /// </summary>
        public String Filename { get; set; }

        /// <summary>
        /// Network settings
        /// </summary>
        public NeuralNetworkSettings Settings { get; set; }

        /// <summary>
        /// Basic information about neural network
        /// </summary>
        public NetworkInfo Info { get; set; }

        /// <summary>
        /// Network topography
        /// </summary>
        public double[] Topo { get; set; }

        /// <summary>
        /// Topography indexes
        /// </summary>
        public double[] TopoIndex { get; set; }

        /// <summary>
        /// Weights
        /// </summary>
        public List<double[]> ResultWeights { get; set; }

        /// <summary>
        /// Sum square errors
        /// </summary>
        public List<double[]> SSE { get; set; }

        /// <summary>
        /// Root mean square errors
        /// </summary>
        public List<double[]> RMSE { get; set; }

        /// <summary>
        /// Activation function
        /// </summary>
        public double[] ActivationFunction { get; set; }

        /// <summary>
        /// Gain values
        /// </summary>
        public double[] GainValue { get; set; }

        /// <summary>
        /// Learn RMSE
        /// </summary>
        public double LearnRMSE { get; set; }

        /// <summary>
        /// Test RMSE
        /// </summary>
        public double TestRMSE { get; set; }

        /// <summary>
        /// Last RMSE from learning process
        /// </summary>
        public double FinalRMSE
        {
            get
            {
                try
                {
                    double sum = 0;
                    foreach (var item in RMSE)
                    {
                        sum += item[item.Length - 1];
                    }
                    return sum / RMSE.Count;
                }
                catch
                {                    
                    return 0;
                }
            }
        }

        /// <summary>
        /// Gets information about learning neural network process
        /// </summary>
        /// <returns>List of string array</returns>
        public List<String[]> GetInformation()
        {
            List<String[]> list = new List<String[]>();

            list.Add(new String[] { "Liczba wejść", Info.ni.ToString() });
            list.Add(new String[]{"Liczba wyjść",Info.no.ToString()});
            list.Add(new String[]{"Liczba neuronów", Info.nn.ToString()});
            list.Add(new String[]{"Liczba wzorców", Info.np.ToString()});
            list.Add(new String[] { "Liczba wag", Info.nw.ToString() });
            list.Add(new String[]{"MU - wielkość o jaką mogą się zmieniać wagi", Settings.MU.ToString()});
            list.Add(new String[]{"Dolna granica MU", Settings.MUL.ToString()});
            list.Add(new String[]{"Górna granica MU", Settings.MUH.ToString()});
            list.Add(new String[]{"Skala", Settings.Scale.ToString()});
            list.Add(new String[]{"Maksymalna liczba iteracji", Settings.MaxIterations.ToString()});
            list.Add(new String[]{"Maksymalny błąd uczenia", Settings.MaxError.ToString()});
            String tmp = "";
            foreach (var t in Topo) tmp += t.ToString() + ", ";
            tmp = tmp.TrimEnd(new char[]{' ', ','});
            list.Add(new String[] { "Topografia sieci", tmp });
            
            tmp = "";
            foreach (var t in TopoIndex) tmp += t.ToString() + ", ";
            tmp = tmp.TrimEnd(new char[] { ' ', ',' });
            list.Add(new String[] { "Indeksy topografii sieci", tmp });

            tmp = "";
            FunctionChoice fc = (FunctionChoice)ActivationFunction[0];
            switch (fc)
            {
                case FunctionChoice.BipolarElliotNeuron: tmp = "dwubiegunowa Elliota"; break;
                case FunctionChoice.BipolarNeuron: tmp = "dwubiegunowa"; break;
                case FunctionChoice.LinearNeuron: tmp = "liniowa"; break;
                case FunctionChoice.UnipolarElliotNeuron: tmp = "jednobiegunowa Elliota"; break;
                case FunctionChoice.UnipolarNeuron: tmp = "jednobiegunowa"; break;
                default: tmp = ""; break;
            }
            list.Add(new String[] { "Funkcja aktywacji", tmp });
            list.Add(new String[] { "Liczba prób uczenia/testowania", Trials.ToString() });
            list.Add(new String[]{"Średnia błędów uczenia (RMSE)", FinalRMSE.ToString()});
            list.Add(new String[] { "Średnia błędów testowania (RMSE)", TestRMSE.ToString() });
            list.Add(new String[] { "Średni czas uczenia", AverageLearnTime });
            list.Add(new String[] { "Średni czas testowania", AverageTestTime });
            return list;
        }
        #endregion

        #region ACTIONS
        /// <summary>
        /// Add to result
        /// </summary>
        /// <param name="weights">double[] - weights</param>
        /// <param name="sse">double[] - sum square errors</param>
        /// <param name="rmse">double[] - rmse's</param>
        public void Add(double[] weights, double[] sse, double[] rmse)
        {
            if (ResultWeights == null)
            {
                ResultWeights = new List<double[]>();
            }
            ResultWeights.Add(weights);

            if (SSE == null)
            {
                SSE = new List<double[]>();
            }
            SSE.Add(sse);

            if (RMSE == null)
            {
                RMSE = new List<double[]>();
            }
            RMSE.Add(rmse);
        }

        /// <summary>
        /// Convert to xml string
        /// </summary>
        /// <returns>String</returns>
        public string ToXML()
        {
            try
            {
                String xml = Xml.Serialize<LearnResult>(this);
                if (Xml.Error != XmlSerializeError.NONE)
                {
                    return "";
                }
                else
                {
                    return xml;
                }
            }
            catch (Exception)
            {                
                return "";
            }
        }

        /// <summary>
        /// Load from xml string
        /// </summary>
        /// <param name="xmlText">String - xml</param>
        /// <returns>LearnResult</returns>
        public static LearnResult LoadFromXMLString(string xmlText)
        {
            try
            {
                LearnResult lr = Xml.Deserialize<LearnResult>(xmlText);
                if (Xml.Error != XmlSerializeError.NONE)
                {
                    return null;
                }
                else
                {
                    return lr;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region STATISTICS

        /// <summary>
        /// Sets data statistics from learn and test process
        /// </summary>
        /// <param name="learnRMSE">learn history of RMSE</param>
        /// <param name="testRMSE">test history of RMSE</param>
        /// <param name="learnTimes">learn time measure history</param>
        /// <param name="testTimes">test time measure history</param>
        /// <param name="trials">number of trials</param>
        public void setStatisticsData(List<double> learnRMSE, List<double> testRMSE, List<long> learnTimes, List<long> testTimes, int trials)
        {
            LearnRMSEHistory = learnRMSE;
            TestRMSEHistory = testRMSE;
            LearnTimeHistory = learnTimes;
            TestTimeHistory = testTimes;
            Trials = trials;
        }

        /// <summary>
        /// Success rate
        /// </summary>
        public double SuccessRate { get; set; }

        /// <summary>
        /// Number of trials
        /// </summary>
        public int Trials { get; set; }

        /// <summary>
        /// Learn RMSE history
        /// </summary>
        public List<double> LearnRMSEHistory { get; set; }

        /// <summary>
        /// Test RMSE history
        /// </summary>
        public List<double> TestRMSEHistory { get; set; }

        /// <summary>
        /// Learn time measures
        /// </summary>
        public List<long> LearnTimeHistory { get; set; }

        /// <summary>
        /// Test time measures
        /// </summary>
        public List<long> TestTimeHistory { get; set; }

        /// <summary>
        /// Average RMSE calculator
        /// </summary>
        /// <param name="data">RMSE history</param>
        /// <param name="trials">int - number of trials</param>
        /// <returns>double</returns>
        private double AverageRMSE(List<double> data, int trials)
        {
            double sum = 0;
            foreach (var item in data)
            {
                if (double.IsNaN(item))
                {
                }
                else
                {
                    sum += item;
                }
            }
            return sum / trials;
        }

        /// <summary>
        /// Average time calculator
        /// </summary>
        /// <param name="data">time history</param>
        /// <param name="trials">int - number of trials</param>
        /// <returns>double</returns>
        private double AverageTime(List<long> data, int trials)
        {
            long sum = 0;
            foreach (var item in data)
            {
                if (double.IsNaN(item))
                {
                }
                else
                {
                    sum += item;
                }
            }
            return sum / trials;
        }

        /// <summary>
        /// Average learn RMSE
        /// </summary>
        public double AverageLearnRMSE
        {
            get
            {
                return AverageRMSE(LearnRMSEHistory, Trials);
            }
        }

        /// <summary>
        /// Average test RMSE
        /// </summary>
        public double AverageTestRMSE
        {
            get
            {
                return AverageRMSE(TestRMSEHistory, Trials);
            }
        }

        /// <summary>
        /// Average learn time
        /// </summary>
        public String AverageLearnTime
        {
            get
            {
                var date = new DateTime((long)AverageTime(LearnTimeHistory, Trials));
                return date.TimeOfDay.ToString();
            }
        }

        /// <summary>
        /// Average test time
        /// </summary>
        public String AverageTestTime
        {
            get
            {
                var date = new DateTime((long)AverageTime(TestTimeHistory, Trials));
                return date.TimeOfDay.ToString();
            }
        }       
        #endregion
    }
}
