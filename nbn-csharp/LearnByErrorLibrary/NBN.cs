/*
Author:  Marek Bar 33808
Contact: marekbar1985@gmail.com
Wyższa Szkoła Informatyki i Zarządzania w Rzeszowie
 */
using System;
using System.Collections.Generic;
using System.IO;

namespace LearnByErrorLibrary
{
    /// <summary>
    /// NBN version
    /// </summary>
    public enum VersionNBN
    {
        /// <summary>
        /// First version of NBN
        /// </summary>
        First = 1
    }

    /// <summary>
    /// Train result
    /// </summary>
    public class TrainResult
    {        
        /// <summary>
        /// Weigths - trained weights
        /// </summary>
        public Weights weights { get; set; }

        /// <summary>
        /// Number of iterations
        /// </summary>
        public int iterations { get; set; }

        /// <summary>
        /// Received SSE
        /// </summary>
        public double sse { get; set; }
    }

    /// <summary>
    /// Neuron by neuron in C#
    /// </summary>
    public class NBN
    {
        #region FIELDS
        /// <summary>
        /// Basic information about neural network structure
        /// </summary>
        private NetworkInfo info = new NetworkInfo();

        /// <summary>
        /// Learning error
        /// </summary>
        private NetworkError error = new NetworkError();

        /// <summary>
        /// Topography indexes
        /// </summary>
        private Index indexes;

        /// <summary>
        /// All input data
        /// </summary>
        private Input input;

        /// <summary>
        /// All output data
        /// </summary>
        private Output output;

        /// <summary>
        /// Input data to tests
        /// </summary>
        private Input inputTest;

        /// <summary>
        /// Input data for learning
        /// </summary>
        private Input inputLearn;

        /// <summary>
        /// Output data for test
        /// </summary>
        private Output outputTest;

        /// <summary>
        /// Output data for learning
        /// </summary>
        private Output outputLearn;

        /// <summary>
        /// Network topography
        /// </summary>
        private Topography topo;

        /// <summary>
        /// Sum square error history
        /// </summary>
        private System.Collections.Hashtable SSE = new System.Collections.Hashtable();

        /// <summary>
        /// Root mean sum square error history
        /// </summary>
        private System.Collections.Hashtable RMSE = new System.Collections.Hashtable();

        /// <summary>
        /// Hessian history
        /// </summary>
        private List<MatrixMB> hessians = new List<MatrixMB>();

        /// <summary>
        /// Network settings
        /// </summary>
        public NeuralNetworkSettings settings = NeuralNetworkSettings.Default();

        /// <summary>
        /// Number of trials - reado only
        /// </summary>
        public int Trials
        {
            get;
            private set;
        }

        private string _reasearch_folder = "";

        /// <summary>
        /// extract learn or train data
        /// </summary>
        public bool IsResearchMode = false;
        private string extractionFolder = "";
       
        #endregion

        #region STATISTICS
        /// <summary>
        /// Learn RMSE history
        /// </summary>
        private List<double> LearnRMSE = new List<double>();

        /// <summary>
        /// Test RMSE history
        /// </summary>
        private List<double> TestRMSE = new List<double>();

        /// <summary>
        /// Learn time measures
        /// </summary>
        private List<long> LearnTime = new List<long>();

        /// <summary>
        /// Test time measures
        /// </summary>
        private List<long> TestTime = new List<long>();

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
                sum += item;
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
                sum += item;
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
                return AverageRMSE(LearnRMSE, Trials);
            }
        }

        /// <summary>
        /// Average test RMSE
        /// </summary>
        public double AverageTestRMSE
        {
            get
            {
                return AverageRMSE(TestRMSE, Trials);
            }
        }

        /// <summary>
        /// Average learn time
        /// </summary>
        public String AverageLearnTime
        {
            get
            {
                TimeSpan ts = TimeSpan.FromMilliseconds(AverageTime(LearnTime, Trials));
                return ts.ToString();
            }
        }

        /// <summary>
        /// Average test time
        /// </summary>
        public String AverageTestTime
        {
            get
            {
                TimeSpan ts = TimeSpan.FromMilliseconds(AverageTime(TestTime, Trials));
                return ts.ToString();
            }
        }

        /// <summary>
        /// Save learn RMSE for trial
        /// </summary>
        private double LearnRmseList
        {
            set
            {
                if (double.IsInfinity(value) || double.IsNaN(value) || double.IsNegativeInfinity(value) || double.IsPositiveInfinity(value))
                {
                    debug("");
                }
                LearnRMSE.Add(value);
            }
        }

        /// <summary>
        /// Save test RMSE for trial
        /// </summary>
        private double TestRmseList
        {
            set
            {
                TestRMSE.Add(value);
            }
        }

        /// <summary>
        /// Save learn time measure
        /// </summary>
        private long LearnTimeList
        {
            set
            {
                LearnTime.Add(value);
            }
        }

        /// <summary>
        /// Save test time measure
        /// </summary>
        private long TestTimeList
        {
            set
            {
                TestTime.Add(value);
            }
        }

        /// <summary>
        /// Threashold level
        /// </summary>
        public double Threshold = 1.0;

        /// <summary>
        /// Is neural network training correct
        /// </summary>
        private int IsTrainOK = 0;

        /// <summary>
        /// Success rate
        /// </summary>
        public double SuccessRate
        {
            get
            {
                return IsTrainOK / Trials;
            }
        }
        #endregion

        #region PROPERTIES
        /// <summary>
        /// NBN handle
        /// </summary>
        public int Handle { get; private set; }

        /// <summary>
        /// NBN error
        /// </summary>
        public String ErrorMessage { get; private set; }

        /// <summary>
        /// Check error presence
        /// </summary>
        public bool HasError { get { return ErrorMessage.Length > 0; } }

        /// <summary>
        /// Filename with data used for training
        /// </summary>
        public String Filename { get; private set; }

        private int trial = 0;
        #endregion

        #region TIME_MEASURE
        /// <summary>
        /// Execution code measure tool
        /// </summary>
        private System.Diagnostics.Stopwatch time = new System.Diagnostics.Stopwatch();

        /// <summary>
        /// Begin new time measure of code execution
        /// </summary>
        private void tic()
        {
            time = new System.Diagnostics.Stopwatch();
            time.Start();
        }

        /// <summary>
        /// End time measure of code execution
        /// </summary>
        /// <returns>String - hours.minutes.seconds.miliseconds - eg. 00.10.01.500409</returns>
        private String toc()
        {
            time.Stop();
            return time.Elapsed.ToString();//"hh:mm:ss.ffff"
            
        }
        #endregion

        #region DELEGATES
        /// <summary>
        /// Method pattern to notify error change
        /// </summary>
        /// <param name="sender">object - error notifying object</param>
        /// <param name="error">double - error value</param>
        public delegate void ErrorChanged(object sender, double error);

        /// <summary>
        /// Method pattern to notify about NBN error occurance to listener
        /// </summary>
        /// <param name="sender">object - error notifying object</param>
        /// <param name="error">String - error information</param>
        public delegate void NbnErrorChange(object sender, String error);

        /// <summary>
        /// Debugging event - do not attach if not testing algorithm
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="message">string</param>
        public delegate void DebugMessage(object sender, String message);

        /// <summary>
        /// Chart update event method pattern
        /// </summary>
        /// <param name="sender">object - sender</param>
        /// <param name="name">string - name for series</param>
        /// <param name="x">double - x coordinate</param>
        /// <param name="y">double - y coordinate</param>
        public delegate void ChartUpdate(object sender, String name, double x, double y);
        #endregion

        #region EVENTS
        /// <summary>
        /// Error change event - provides neural networ error
        /// </summary>
        public event ErrorChanged OnErrorChange;

        /// <summary>
        /// Error change event for NBN - general execution errors
        /// </summary>
        public event NbnErrorChange OnErrorChangeNBN;

        /// <summary>
        /// Debug event - do not attach if not testing alorithm
        /// </summary>
        public event DebugMessage OnDebug;

        /// <summary>
        /// Chart update event
        /// </summary>
        public event ChartUpdate OnChartUpdate;
        #endregion

        #region EVENT_UPDATERS
        private double LastRMSE;
        private void updateChart(double x, double y)
        {
            LastRMSE = y;
            if (OnChartUpdate != null)
            {
                OnChartUpdate(this, Path.GetFileNameWithoutExtension(Filename) + " - próba nr " + (trial + 1).ToString(), x, y);
            }
        }

        /// <summary>
        /// Update error
        /// </summary>
        private void updateError(double err)
        {
            if (OnErrorChange != null)
            {
                OnErrorChange(this, err);
            }
        }

        /// <summary>
        /// Update NBN general execution error
        /// </summary>
        /// <param name="ex">Exception</param>
        private void updateErrorNBN(Exception ex)
        {
            ErrorMessage = ex.GetError();
            if (OnErrorChangeNBN != null)
            {
                OnErrorChangeNBN(this, ErrorMessage);
            }
        }

        /// <summary>
        /// Pass error message to event
        /// </summary>
        /// <param name="msg">String</param>
        private void updateErrorNBN(String msg)
        {
            ErrorMessage = msg;
            if (OnErrorChangeNBN != null)
            {
                OnErrorChangeNBN(this, ErrorMessage);
            }
        }

        /// <summary>
        /// Pass mesage to debug event
        /// </summary>
        /// <param name="message">String</param>
        private void debug(String message)
        {
            if (OnDebug != null)
            {
                OnDebug(this, message);
            }
        }
        #endregion

        #region CONSTRUCTOR
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="h">int - handle</param>
        /// <param name="filename">String - filename with path</param>
        public NBN(int h, String filename)
        {
            Handle = h;
            Filename = filename;
        }
        #endregion

        #region PRIVATES
        /// <summary>
        /// Initialize NBN with data from specified file
        /// </summary>
        /// <param name="filename">String - filename</param>
        /// <returns>bool - success flag</returns>
        private bool loadInputData(String filename)
        {           
            try
            {
                if (!File.Exists(filename))
                {
                    throw new NeuralNetworkError(String.Format(Properties.Settings.Default.NBN1, filename));
                }

                try
                {
                    var data = MatrixMB.Load(filename);

                    input = data.CopyColumnsWithoutLast().ToInput();
                    input.Normalize();

                    output = data.LastColumn.ToOutput();
                    output.Normalize();

                    int[] ind = data.Rows.RandomPermutation();
                    int Tnp = Math.Round(data.Rows * 0.7).ToInt();

        
                    //inputLearn = MatrixMB.Load("C:\\Users\\marekbar1985\\Desktop\\parity3\\uczenie_wejscie_parity3.dat").ToInput();
                    //inputTest = MatrixMB.Load("C:\\Users\\marekbar1985\\Desktop\\parity3\\testowanie_wejscie_parity3.dat").ToInput();
                    //outputLearn = MatrixMB.Load("C:\\Users\\marekbar1985\\Desktop\\parity3\\uczenie_wyjscie_parity3.dat").ToOutput();
                    //outputTest = MatrixMB.Load("C:\\Users\\marekbar1985\\Desktop\\parity3\\testowanie_wyjscie_parity3.dat").ToOutput();

                    inputTest = input.CopyRows(Tnp, input.Rows - 1).ToInput();
                    inputLearn = input.CopyRows(Tnp - 1).ToInput();
                    outputTest = output.CopyRows(Tnp, input.Rows - 1).ToOutput();
                    outputLearn = output.CopyRows(Tnp - 1).ToOutput();

                    try
                    {
                        if (IsResearchMode)
                        {
                            string name = Path.GetFileNameWithoutExtension(filename);
                            DateTime d = DateTime.Now;

                            string dir = String.Format("{0}\\Executed research\\{1}\\{2}_{3}_{4}_{5}_{6}_{7}",
                                Path.GetDirectoryName(filename), name,
                                d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second);

                            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

                            extractionFolder = dir;
                            _reasearch_folder = dir;
                            string learn_input = String.Format("{0}\\{1}_learn_input.dat", dir, name);
                            string test_input = String.Format("{0}\\{1}_test_input.dat", dir, name);
                            string learn_output = String.Format("{0}\\{1}_learn_output.dat", dir, name);
                            string test_output = String.Format("{0}\\{1}_test_output.dat", dir, name);
                            string initialWweights = String.Format("{0}\\{1}_initial_weights.dat", dir, name);

                            inputTest.Store(test_input);
                            inputLearn.Store(learn_input);
                            outputTest.Store(test_output);
                            outputLearn.Store(learn_output);
                        }
                    }
                    catch (Exception)
                    { }
                }
                catch (Exception iex)
                {
                    throw new NeuralNetworkError(String.Format(Properties.Settings.Default.NBN2, filename), iex);
                }
                return true;
            }
            catch (Exception ex)
            {
                updateErrorNBN(ex);
                return false;
            }
        }      

        /// <summary>
        /// Checks data
        /// </summary>
        /// <param name="inp">Input - input patterns</param>
        /// <param name="dout">Output</param>
        /// <param name="topo">Topology</param>
        /// <param name="iw">Index</param>
        /// <returns>NetworkInfo</returns>
        private NetworkInfo checkInputs(ref Input inp, ref Output dout, ref Topography topo, out Index iw)
        {
            if (topo.Length == 0) throw new NeuralNetworkError(Properties.Settings.Default.FE4);
            if (!topo.IsCorrect) throw new NeuralNetworkError(Properties.Settings.Default.FE3);
            if (inp.Rows != dout.Rows) throw new NeuralNetworkError(Properties.Settings.Default.FE2);

            NetworkInfo info = new NetworkInfo();
            iw = Index.Find(ref topo);
            info.np = inp.Rows;
            info.ni = inp.Cols;
            info.no = dout.Cols;
            info.nw = topo.Length;
            info.nn = iw.Length - 1;

            return info;
        }

        /// <summary>
        /// Train neural netowrk
        /// </summary>
        /// <param name="setting">NeuralNetworkSettings</param>
        /// <param name="info">NetworkInfo</param>
        /// <param name="inp">Input</param>
        /// <param name="dout">Output</param>
        /// <param name="topo">Topography</param>
        /// <param name="initialWeights">Weights</param>
        /// <param name="act">Activation</param>
        /// <param name="gain">Gain</param>
        /// <param name="iw">Index</param>   
        public TrainResult Train(ref NeuralNetworkSettings setting, ref NetworkInfo info, ref Input inp, ref Output dout,
                          ref Topography topo, Weights initialWeights, ref Activation act, ref Gain gain, ref Index iw)
        {
            TrainResult result = new TrainResult();
            result.weights = new Weights(initialWeights.Length);
            result.iterations = 0;
            result.sse = 0;
            try
            {
                if (OnDebug != null)
                {
                    debug(setting.ToString());
                    debug(act.ToString());
                    debug(gain.ToString());
                }

                result.weights = initialWeights.Backup();   

                error.CalculateError(ref info, ref inp, ref dout, ref topo, result.weights, ref act, ref gain, ref iw);

                if (OnDebug != null)
                {
                    debug("\r\nFirst error value: " + error.Error.ToString() + "\r\n");
                }

                SSE.Clear();
                RMSE.Clear();
                SSE[0] = result.sse = error.Error;
                
                var I = MatrixMB.Eye(info.nw);

                hessians.Clear();
                var hessian = new Hessian(ref info);

                for (result.iterations = 1; result.iterations < setting.MaxIterations; result.iterations++)
                {                                        
                    hessian.Compute(ref info, ref inp, ref dout, ref topo, result.weights, ref act, ref gain, ref iw);

                    if (OnDebug != null) debug(hessian.ToString());

                    hessians.Add(hessian.HessianMat);
                    Weights ww_backup = result.weights.Backup();

                    for(int jw = 0; jw < 30; jw++)
                    {
                        //ww = ww_backup - ((hessian+mu*I)\gradient)';
                        var diff = ((hessian.HessianMat + (I * setting.MU)).Inverted * hessian.GradientMat).Transposed;

                        if (OnDebug != null)
                        {
                            debug("\r\nOdejmuję");
                            debug(diff.MatrixToString());
                        }
                        result.weights = ww_backup - diff.ToWeights();
                        result.weights.Name = "Weights nr " + jw.ToString();
                       
                        if (OnDebug != null)
                        {
                            bool areSame = result.weights.IsEqual(ww_backup);
                            debug("\r\nWeights are same as previously backed up");
                            debug(result.weights.ToString());
                        }

                        SSE[result.iterations] = result.sse = error.CalculateError(ref info, ref inp, ref dout, ref topo, result.weights, ref act, ref gain, ref iw);

                        if (OnDebug != null) debug("\r\nSSE[" + result.iterations.ToString() + "] = " + error.Error.ToString());

                        if (error.Error <= SSE.PreviousSSE(result.iterations))
                        {
                            if (setting.MU > setting.MUL)
                            {
                                setting.MU /= setting.Scale;
                            }
                            break;
                        }

                        if (setting.MU < setting.MUH)
                        {
                            setting.MU *= setting.Scale;
                        }

                    }

                    double rmse = Math.Sqrt(((double)SSE[result.iterations]) / inp.Rows);

                    RMSE[result.iterations] = rmse;
                    updateChart(result.iterations, rmse);

                    if ((double)SSE[result.iterations] < setting.MaxError)
                    {
                        break;
                    }

                                        
                    if (OnDebug != null) debug("Błąd: " + rmse.ToString());

                    if(
                        (SSE.PreviousSSE(result.iterations)-((double)SSE[result.iterations]))
                        /
                        SSE.PreviousSSE(result.iterations)
                        <
                        NetworkError.DesiredError//0.000000000000001
                      )
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new NeuralNetworkError("Błąd uczenia sieci. " + ex.Message, ex);
            }

            return result;
        }//trainer end
        #endregion

        #region PUBLIC
        /// <summary>
        /// Run NBN train and its test
        /// </summary>
        /// <param name="trials">int - number of learning trials</param>
        /// <param name="version">VersionNBN - version of nbn algorithm</param>
        /// <returns>LearnResult</returns>
        public LearnResult Run(int trials = 1, VersionNBN version = VersionNBN.First)
        {
            switch (version)
            {
                case VersionNBN.First:
                    {
                        return RunFirstVersion(trials);
                    }
                default: throw new NotImplementedException("Nie ma takiej funkcjonalności jeszcze zaimplementowanej.");
            }
        }

        /// <summary>
        /// Run NBN training and its test - this is the first version
        /// </summary>
        /// <param name="trials">int - number of learning trials</param>
        /// <returns>LearnResult</returns>
        private LearnResult RunFirstVersion(int trials)
        {
            Trials = trials;
            LearnResult result = new LearnResult();
            result.Filename = Filename;
            if (!loadInputData(Filename))
            {
                updateErrorNBN("Dane nie zostały wczytane.");
                return result;
            }
            if (OnDebug != null) debug("Data loaded from file: " + Filename);

            var tmp = new System.Collections.Generic.List<int>();
            tmp.Add(inputLearn.Cols);

            //setting number of hidden neurons
            for (int i = 0; i < Handle; i++)
            {
                tmp.Add(1); 
            }
            tmp.Add(1);

            var vh = new VectorHorizontal(tmp.Count);
            for (int i = 0; i < vh.Length; i++)
            {
                vh[i] = tmp[i];
            }

            topo = Topography.Generate(TopographyType.BMLP, vh);
            result.Topo = topo.Data[0];
            if (OnDebug != null) debug(topo.ToString());

            if (topo == null)
            {
                updateErrorNBN("Topologia sieci nie została utworzona.");
                return result;
            }

            info = this.checkInputs(ref inputLearn, ref outputLearn, ref topo, out indexes);//here are set indexes

            result.TopoIndex = indexes.Data[0];
            result.Info = info;
            if (OnDebug != null)
            {
                debug(indexes.ToString());
                debug(info.ToString());
            }

            Activation act = new Activation(info.nn);
            act.FillWithNumber(2);
            act.setValue(info.nn - 1, 0);
            result.ActivationFunction = act.Data[0];

            Gain gain = new Gain(info.nn);
            gain.FillWithNumber(1);
            result.GainValue = gain.Data[0];

            result.Settings = this.settings;

            for (trial = 0; trial < trials; trial++)
            {
                var initialWeights = Weights.Generate(info.nw);
                //var initialWeights = MatrixMB.Load("C:\\Users\\marekbar1985\\Desktop\\parity3\\uzyte_wagi_proba_" + (trial + 1).ToString() + "parity3.dat").ToWeights();
                if (IsResearchMode)
                {                    
                    string initialWeightsFile = String.Format("{0}\\{1}{2}_initial_weights.dat", _reasearch_folder, trial, Path.GetFileNameWithoutExtension(result.Filename));
                    initialWeights.Store(initialWeightsFile);                    
                }

                initialWeights.Name = "Initial";
                if (OnDebug != null)
                {
                    debug(String.Format("\r\nTrial {0} from {1}\r\n", trial + 1, trials));
                    debug(initialWeights.ToString());
                }

                tic();//learn time measure start

                var tr = Train(ref this.settings, ref this.info, ref this.inputLearn, ref this.outputLearn,
                               ref this.topo, initialWeights, ref act, ref gain, ref indexes);

                String LearnExecutionTime = toc();//learn time measure stop
                LearnTimeList = time.ElapsedTicks;//learn time measure save

                result.Add(tr.weights.Data[0], SSE.ToDoubleArray(), RMSE.ToDoubleArray());

                result.LearnRMSE = (double)RMSE[RMSE.Count];
                LearnRmseList = LastRMSE;
                
                if (OnDebug != null)
                {
                    debug(tr.weights.ToString());
                    debug("\r\nLearn execution time: " + LearnExecutionTime + "(hours:minutes:seconds:miliseconds)\r\n");
                    debug("\r\nLearn SSE: " + tr.sse.ToString() + "\r\n");
                    debug("\r\nLearn RMSE: " + result.LearnRMSE.ToString() + "\r\n");
                }

                updateError(result.LearnRMSE);

                NetworkInfo infoTest = info.Copy();
                infoTest.np = inputTest.Rows;

                tic();//test time measure start

                //potem usunąć
                //tr.weights = MatrixMB.Load("C:\\Users\\marekbar1985\\Desktop\\parity3\\wytrenowane_wagi_dla_parity3.dat").ToWeights();
                error.CalculateError(ref infoTest, ref inputTest, ref outputTest, ref topo, tr.weights, ref act, ref gain, ref indexes);

                var TestExecutionTime = toc();//test time measure stop
                TestTimeList = time.ElapsedTicks;//test time measure save

                result.TestRMSE = Math.Sqrt(error.Error / infoTest.np);
                TestRmseList = result.TestRMSE;//save test rmse from this trial

                if (OnDebug != null)
                {
                    debug("\r\nTest execution time: " + TestExecutionTime + "(hours:minutes:seconds:miliseconds)\r\n");
                    debug("\r\nTest SSE: " + error.Error.ToString() + "\r\n");
                    debug("\r\nTest RMSE: " + result.TestRMSE.ToString() + "\r\n");
                }

                if (result.LearnRMSE < Threshold) IsTrainOK++;
            }

            result.LearnRMSE = AverageLearnRMSE;
            result.TestRMSE = AverageTestRMSE;
            result.setStatisticsData(LearnRMSE, TestRMSE, LearnTime, TestTime, Trials);
            result.SuccessRate = IsTrainOK / Trials;

            if (IsResearchMode)//save research
            {
                try
                {
                    string filename = extractionFolder + "\\research result.pdf";

                    PDFGenerate data = new PDFGenerate();
                    data.Filename = filename;
                    data.Result = result;
                    data.ChartFilename = GeneratePlot(result.RMSE, Path.GetFileNameWithoutExtension(result.Filename));
                    HistoryPDF pdf = new HistoryPDF(data.Result, data.ChartFilename, true);
                    pdf.Save(data.Filename);
                }
                catch { }
            }

            return result;
        }

        private System.Windows.Forms.DataVisualization.Charting.Chart chart = null;

        public static String ApplicationFolder
        {
            get
            {
                String dir = "";
                dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\NBN";
                if (!Directory.Exists(dir)) { Directory.CreateDirectory(dir); }
                return dir;
            }
        }
        private string GeneratePlot(List<double[]> data, string title)
        {
            string file = "";
            chart = new System.Windows.Forms.DataVisualization.Charting.Chart();

            chart.ChartAreas.Add(new System.Windows.Forms.DataVisualization.Charting.ChartArea());
            foreach (var items in data)
            {
                int i = 1;
                foreach (var item in items)
                {
                    SetChart(title, i, item);
                    i++;
                }
            }

            DateTime d = DateTime.Now;
            var xxx = String.Format("{0}_{1}_{2}_{3}_{4}_{5}_{6}", d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second, d.Millisecond);
            String chartFilename = ApplicationFolder + "\\" + xxx + ".bmp";
            chart.Update();
            chart.SaveImage(chartFilename, System.Drawing.Imaging.ImageFormat.Bmp);
            file = chartFilename;


            return file;
        }

        /// <summary>
        /// Display in chart - mainly designed for SSE
        /// </summary>
        /// <param name="title">String - training session name</param>
        /// <param name="x">double - trial number</param>
        /// <param name="y">double - sse error value</param>
        private void SetChart(string title, double x, double y)
        {
            try
            {
                chart.Series[title].Points.AddXY(x, y);
                chart.Update();
            }
            catch
            {
                chart.Series.Add(title);
                chart.Series[title].BorderWidth = 1;
                chart.Series[title].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chart.Series[title].Points.AddXY(x, y);
                chart.Series[title].Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.BrightPastel;
                chart.Series[title].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Diamond;
                
                chart.ChartAreas[0].AxisX.Title = "Epoka";
                chart.ChartAreas[0].AxisX.TitleForeColor = System.Drawing.Color.LightGray;
                chart.ChartAreas[0].AxisX.Minimum = 1;
                chart.ChartAreas[0].AxisY.Title = "RMSE";
                chart.ChartAreas[0].AxisY.TitleForeColor = System.Drawing.Color.LightGray;
                chart.ChartAreas[0].AxisY.IsLogarithmic = true;
                chart.ChartAreas[0].AxisY2.IsLogarithmic = true;
            }
        }
        #endregion
    }
}