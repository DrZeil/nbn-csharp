/*
Author:  Marek Bar 33808
Contact: marekbar1985@gmail.com
Wyższa Szkoła Informatyki i Zarządzania w Rzeszowie
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using LearnByError.Database.Tables;
using LearnByError.Internazional;
using LearnByErrorLibrary;
using Form1_Res = global::LearnByError.Form1_Resources;
using System.Linq;
using System.Resources;
using System.Globalization;
using System.Collections;
using System.Reflection;

namespace LearnByError
{
    /// <summary>
    /// Application main window
    /// </summary>
    public partial class LearnByErrorMainWindow : Form
    {

        #region FIELDS
        /// <summary>
        /// Input data loaded from file
        /// </summary>
        private MatrixMB inputData = null;

        /// <summary>
        /// Data source - filename
        /// </summary>
        private String inputDataFilename = "";

        /// <summary>
        /// Watch and timer
        /// </summary>
        private System.Diagnostics.Stopwatch time = new System.Diagnostics.Stopwatch();

        /// <summary>
        /// Console window
        /// </summary>
        private DebugConsole console = null;

        private BackgroundWorker worker = null;

        private string maxTmp = "";
        #endregion

        #region WINDOW_BASIC

        /// <summary>
        /// Default constructor
        /// </summary>
        public LearnByErrorMainWindow()
        {
            try
            {
                InitializeComponent();
                progress.Visible = false;                
            }
            catch (Exception ex)
            {
                info = ex.ToLog().GetError();
            }
        }

        /// <summary>
        /// Loading window event
        /// </summary>
        /// <param name="sender">who</param>
        /// <param name="e">arguments</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                LearnByError.Database.Manager.Instance.Initialize();

                this.programToolStripMenuItem.Text = Resource.Inst.Get("r1");
                this.menuInfo.Text = Resource.Inst.Get("r2");
                this.toolFolder.Text = Resource.Inst.Get("r3");
                this.toolFolderMain.Text = Resource.Inst.Get("r4");
                this.toolFolderLogs.Text = Resource.Inst.Get("r5");
                this.toolFolderSettings.Text = Resource.Inst.Get("r6");
                this.toolFolderData.Text = Resource.Inst.Get("r7");
                this.menuSettings.Text = Resource.Inst.Get("r8");
                this.toolHistory.Text = Resource.Inst.Get("r9");
                this.menuExit.Text = Resource.Inst.Get("r10");
                this.menuData.Text = Resource.Inst.Get("r11");
                this.pomocToolStripMenuItem.Text = Resource.Inst.Get("r12");
                this.helpLogs.Text = Resource.Inst.Get("r13");
                this.menuContact.Text = Resource.Inst.Get("r14");
                this.tsOpen.Text = Resource.Inst.Get("r15");
                this.tsStart.Text = Resource.Inst.Get("r16");
                this.toolSaveChart.Text = Resource.Inst.Get("r17");
                this.toolSettings.Text = Resource.Inst.Get("r18");
                this.tsHistory.Text = Resource.Inst.Get("r19");
                this.toolExit.Text = Resource.Inst.Get("r20");
                this.cmChartSave.Text = Resource.Inst.Get("r21");
                this.nnNumber.Text = Resource.Inst.Get("r176");
                this.toolInstruction.Text = Resource.Inst.Get("r177");
                this.reasearch.Text = Resource.Inst.Get("r179");
                this.runReasearch.Text = Resource.Inst.Get("r180");
                this.reasearch.Text = Resource.Inst.Get("r197");
                this.runReasearch.Text = Resource.Inst.Get("r198");
                this.testForData.Text = Resource.Inst.Get("r199");
                this.stopReasearch.Text = Resource.Inst.Get("r200");
                this.nnNumber.Text = Resource.Inst.Get("r201");

                loadSamples();
                for (int x = 0, y = 10; x < 10; x++, y--) SetChart(Resource.Inst.Get("r22"), x, y);
                toolNN.SelectedIndex = (new AppSetting()).NeuronNumber - 1;
                extractor.DoWork += (a, b) => { extractFiles(); };
                extractor.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                info = ex.ToLog().GetError();
            }
        }

        #region TRAIN_FILES_EXTRACTOR
        private BackgroundWorker extractor = new BackgroundWorker();
        private void extractFiles()
        {
            try
            {
                List<string> list = (new LearnByErrorLibrary.TrainerResource()).ResourceList;
                foreach (var item in list)
                {
                    LearnByErrorLibrary.TrainerResource.loadSample(item);
                }
            }
            catch (Exception ex) { ex.ToLog(); }
        }

       
        #endregion

        #endregion

        #region OTHER
        /// <summary>
        /// Show informatino in status bar
        /// </summary>
        private String info
        {            
            set
            {
                status.Text = value;
            }
        }
        #endregion

        #region MAIN_MENU
        /// <summary>
        /// Show logs
        /// </summary>
        /// <param name="sender">who</param>
        /// <param name="e">arguments</param>
        private void helpLogs_Click(object sender, EventArgs e)
        {
            try
            {
                LogWindow lw = new LogWindow();
                lw.FormClosing += (s, a) =>
                {
                    this.BringToFront();
                };
                lw.ShowDialog();
            }
            catch (Exception ex)
            {
                info = ex.ToLog().GetError();
            }
        }

        /// <summary>
        /// Contact form
        /// </summary>
        /// <param name="sender">who</param>
        /// <param name="e">arguments</param>
        private void menuContact_Click(object sender, EventArgs e)
        {
            try
            {
                MailBox m = new MailBox();
                m.FormClosing += (s, a) =>
                {
                    this.BringToFront();
                };
                m.ShowDialog();
            }
            catch (Exception ex)
            {
                info = ex.ToLog().GetError();
            }
        }

        /// <summary>
        /// Show about application window
        /// </summary>
        /// <param name="sender">who</param>
        /// <param name="e">arguments</param>
        private void menuInfo_Click(object sender, EventArgs e)
        {
            try
            {
                AboutBox ab = new AboutBox();
                ab.FormClosing += (s, a) =>
                {
                    this.BringToFront();
                };
                ab.ShowDialog();
            }
            catch (Exception ex)
            {
                info = ex.ToLog().ToString();
            }
        }

        /// <summary>
        /// Show settings window
        /// </summary>
        private void showSettings()
        {
            try
            {
                var settings = new SettingsWindow();
                settings.FormClosing += (s, a) =>
                {
                    this.BringToFront();
                };
                settings.ShowDialog();
            }
            catch (Exception ex)
            {
                info = ex.ToLog().GetError();
            }
        }

        /// <summary>
        /// Show settings window button in menu
        /// </summary>
        /// <param name="sender">who</param>
        /// <param name="e">arguments</param>
        private void menuSettings_Click(object sender, EventArgs e)
        {
            showSettings();
        }

        /// <summary>
        /// Close application
        /// </summary>
        private void quit()
        {
            System.Windows.Forms.Application.Exit();
        }

        /// <summary>
        /// Close application button on menu
        /// </summary>
        /// <param name="sender">who</param>
        /// <param name="e">arguments</param>
        private void menuExit_Click(object sender, EventArgs e)
        {
            quit();    
        }

        /// <summary>
        /// Open main folder
        /// </summary>
        /// <param name="sender">who</param>
        /// <param name="e">arguments</param>
        private void toolFolderMain_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Common.Folder.Application);
            }
            catch (Exception ex)
            {
                info = ex.ToLog().GetError();
            }
        }

        /// <summary>
        /// Open text logs folder
        /// </summary>
        /// <param name="sender">who</param>
        /// <param name="e">arguments</param>
        private void toolFolderLogs_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Common.Folder.Log);
            }
            catch (Exception ex)
            {
                info = ex.ToLog().GetError();
            }
        }

        /// <summary>
        /// Open settings folder
        /// </summary>
        /// <param name="sender">who</param>
        /// <param name="e">arguments</param>
        private void toolFolderSettings_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Common.Folder.Settings);
            }
            catch (Exception ex)
            {
                info = ex.ToLog().GetError();
            }
        }

        /// <summary>
        /// Open data folder
        /// </summary>
        /// <param name="sender">who</param>
        /// <param name="e">arguments</param>
        private void toolFolderData_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Common.Folder.Data);
            }
            catch (Exception ex)
            {
                info = ex.ToLog().GetError();
            }
        }
        #endregion

        #region INTERFACE_BLOCKER
        /// <summary>
        /// Block interface
        /// </summary>
        private void blockInterface()
        {
            try
            {
                interfaceBlock(false);
                chart.Enabled = true;
                progress.Enabled = true;
                progress.Style = ProgressBarStyle.Marquee;
                progress.Visible = true;
            }
            catch (Exception ex)
            {
                info = ex.ToLog().GetError();
            }
        }

        /// <summary>
        /// Unblock interface
        /// </summary>
        private void unblockInterface()
        {
            try
            {
                interfaceBlock(true);
                progress.Enabled = false;
                progress.Visible = false;
            }
            catch (Exception ex)
            {
                info = ex.ToLog().GetError();
            }
        }

        /// <summary>
        /// Interface blocker
        /// </summary>
        /// <param name="isEnabled">true - block, false - unblock</param>
        private void interfaceBlock(bool isEnabled)
        {
            try
            {
                for (int i = 0; i < this.Controls.Count; i++)
                {
                    this.Controls[i].Enabled = isEnabled;
                }
            }
            catch (Exception ex)
            {
                info = ex.ToLog().GetError();
            }
        }

        #endregion

        #region TOOLBAR
        /// <summary>
        /// Load data file
        /// </summary>
        /// <param name="sender">who</param>
        /// <param name="e">arguments</param>
        private void tsOpen_Click(object sender, EventArgs e)
        {
            OpenDataFile();
        }

        private void OpenDataFile()
        {
            try
            {
                blockInterface();
                inputDataFilename = Common.Dialog.Open(LearnByError.Internazional.Resource.Inst.Get("r165"),
                    LearnByError.Internazional.Resource.Inst.Get("r166"), "dat");
                if (inputDataFilename == "") return;
                inputData = MatrixMB.Load(inputDataFilename);
                info = LearnByError.Internazional.Resource.Inst.Get("r164") + inputDataFilename;
            }
            catch (Exception ex)
            {
                ex.ToLog();
                info = LearnByError.Internazional.Resource.Inst.Get("r163");
            }
            finally
            {
                unblockInterface();
            }
        }
        #endregion

        #region RUNNERS
        /// <summary>
        /// Learn start
        /// </summary>
        /// <param name="sender">who</param>
        /// <param name="e">arguments</param>
        private void tsStart_Click(object sender, EventArgs e)
        {
            RunLearningProcess();
        }

        private void RunLearningProcess(bool IsResearch = false)
        {
            try
            {
                AppSetting app = new AppSetting();

                if (inputDataFilename == "")
                {
                    OpenDataFile();
                }
                if (inputDataFilename == "") return;
                blockInterface();
                NBN nbn = new NBN(app.NeuronNumber, inputDataFilename);
                nbn.IsResearchMode = IsResearch;
                nbn.OnErrorChange += (s, error) =>
                {
                    SetText(error.Format());
                };

                if (app.ShowConsole)
                {
                    nbn.OnDebug += (s, msg) =>
                    {
                        SetDebug(msg);
                    };
                }
                nbn.OnChartUpdate += (s, title, x, y) =>
                {

                    SetChart(title, x, y);
                };

                if (app.ShowConsole)
                {
                    console = new DebugConsole();
                    console.Show();
                    console.Hide();
                }
                chart.Series.Clear();
                var result = nbn.Run(app.LearnTrials);
                String runResult = String.Format(Resource.Inst.Get("r29"), 
                    result.AverageLearnRMSE, result.AverageTestRMSE, result.Settings.MaxError);

                runResult += " " + String.Format(Resource.Inst.Get("r167"),
                    (result.AverageLearnRMSE <= result.Settings.MaxError ? Resource.Inst.Get("r169") : Resource.Inst.Get("r170")));

                runResult += ", " + String.Format(Resource.Inst.Get("r168"),
                    (result.AverageTestRMSE <= result.Settings.MaxError ? Resource.Inst.Get("r169") : Resource.Inst.Get("r170")));

                try
                {
                    times.Text = String.Format(String.Format(Resource.Inst.Get("r172"), result.SuccessRate)) + ", " + String.Format(Resource.Inst.Get("r171"),
                            result.AverageLearnTime.TrimEnd(new char[] { '0', '.' }),
                            result.AverageTestTime.TrimEnd(new char[] { '0', '.' }));
                }
                catch (Exception ex)
                {
                    ex.ToLog();
                }
                status.Text = runResult;

                if (app.AutoSaveLearningResults)
                {
                    String file = Common.File.GetXmlFileNameForHistory();
                    DateTime d = DateTime.Now;
                    History h = new History();
                    h.Name = String.Format("{0}_{1}_{2}_{3}_{4}_{5}_{6}", Path.GetFileNameWithoutExtension(result.Filename),
                        d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second);
                    h.Data = marekbar.Xml.Serialize<LearnResult>(result);
                    h.Insert();
                }

                if (app.ShowConsole) { console.Show(); }

                toolSSE.Items.Clear();
                for (int i = 0; i < result.SSE.Count; i++)
                {
                    toolSSE.Items.Add(Resource.Inst.Get("r182") + (i + 1).ToString());
                    int position = 1;
                    foreach (var sse in result.SSE[i])
                    {
                        toolSSE.Items.Add(String.Format(Resource.Inst.Get("r183"), position, sse));
                        position++;
                    }
                }

                toolRMSE.Items.Clear();
                for (int i = 0; i < result.RMSE.Count; i++)
                {
                    toolRMSE.Items.Add(Resource.Inst.Get("r184") + (i + 1).ToString());
                    int position = 1;
                    foreach (var rmse in result.RMSE[i])
                    {
                        toolRMSE.Items.Add(String.Format(Resource.Inst.Get("r185"), position, rmse));
                        position++;
                    }
                }

                
            }
            catch (Exception ex)
            {
                info = ex.ToLog().Message;
            }
            finally
            {
                unblockInterface();
            }
        }
        #endregion

        #region SAMPLES
        /// <summary>
        /// Show available data samples in menu
        /// </summary>
        private void loadSamples()
        {
            try
            {
                TrainerResource tr = new TrainerResource();
                for (int i = 0; i < tr.Resources.Length - 1; i++)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem();
                    item.Text = System.IO.Path.GetFileNameWithoutExtension(tr.Resources[i]);
                    item.Tag = i.ToString();
                    item.Click += (a, b) =>
                    {
                        try
                        {
                            int index = int.Parse(((ToolStripMenuItem)a).Tag.ToString());
                            loadSample(tr.Resources[index]);
                        }
                        catch (Exception ex)
                        {
                            ex.ToLog();
                        }
                    };
                    menuData.DropDownItems.Add(item);
                }
            }
            catch (Exception ex)
            {
                info = ex.ToLog().GetError();
            }
        }

        /// <summary>
        /// Load netowrk data for specified position
        /// </summary>
        /// <param name="url">String - web address of data file</param>
        private void loadSample(String url)
        {
            try
            {
                String filename = Common.Folder.Samples + "\\" + System.IO.Path.GetFileName(url);
                if (!System.IO.File.Exists(filename))
                {
                    status.Text = Form1_Res.Pobieranie_pliku_z_sieci;
                    progress.Style = ProgressBarStyle.Marquee;
                    progress.Visible = true;

                    var bw = new BackgroundWorker();
                    bw.DoWork += (a, b) =>
                    {
                        try
                        {
                            String address = (String)b.Argument;
                            var request = WebRequest.Create(url);
                            request.Timeout = 60000;

                            using (var response = request.GetResponse())
                            {
                                using (var file = File.Create(filename))
                                {
                                    response.GetResponseStream().CopyTo(file);
                                }
                            }
                            b.Result = filename;
                        }
                        catch
                        {
                            b.Result = "";
                        }
                    };
                    bw.RunWorkerCompleted += (a, b) =>
                    {
                        try
                        {
                            inputDataFilename = (String)b.Result;
                            status.Text = Form1_Res.Plik_został_pobrany;
                            try
                            {
                                inputData = MatrixMB.Load(inputDataFilename);
                                var tmp = String.Format(Form1_Res.Dane_z_pliku_0_zostały_wczytane, inputDataFilename);
                                info = tmp;
                                Common.Log.Write(tmp);
                            }
                            catch
                            {
                                var tmp = String.Format(Form1_Res.Dane_z_pliku_0_nie_zostały_wczytane, inputDataFilename);
                                info = tmp;
                                Common.Log.Write(tmp);
                            }
                        }
                        catch
                        {
                            status.Text = Form1_Res.Plik_nie_został_pobrany;
                        }
                        finally
                        {
                            progress.Visible = false;
                            unblockInterface();
                        }
                    };
                    blockInterface();
                    progress.Style = ProgressBarStyle.Marquee;
                    progress.Visible = true;
                    progress.Enabled = true;
                    bw.RunWorkerAsync(url);
                }
                else
                {
                    try
                    {
                        inputDataFilename = filename;
                        inputData = MatrixMB.Load(inputDataFilename);
                        var tmp = String.Format(Form1_Res.Dane_z_pliku_0_zostały_wczytane, inputDataFilename);
                        info = tmp;
                        Common.Log.Write(tmp);
                    }
                    catch (Exception ex)
                    {
                        var tmp = String.Format(Form1_Res.Dane_z_pliku_0_nie_zostały_wczytane, inputDataFilename);
                        info = tmp;
                        Common.Log.Write(tmp, ex);
                    }
                }
            }
            catch (Exception ex)
            {
                info = ex.ToLog().GetError();
            }
        }
        #endregion
       
        #region INTER_THREAD_ACTIONS
        #region CALLBACKS
        /// <summary>
        /// Debugging message method template
        /// </summary>
        /// <param name="text">String - debug meesage</param>
        private delegate void SetDebugCallback(String text);

        /// <summary>
        /// Error drawing method template
        /// </summary>
        /// <param name="title">String - train title</param>
        /// <param name="x">double - trial</param>
        /// <param name="y">double - sse error value</param>
        private delegate void SetChartCallback(string title, double x, double y);

        /// <summary>
        /// Notification in status method template
        /// </summary>
        /// <param name="text">String - notification</param>
        private delegate void SetTextCallback(string text);
        #endregion

        #region SETTERS
        /// <summary>
        /// Set debug message in interface
        /// </summary>
        /// <param name="text">String - message</param>
        private void SetDebug(String text)
        {
            try
            {
                if (this.console.InvokeRequired)
                {
                    this.console.Invoke(new MethodInvoker(delegate { console.Console = text; }));
                }
                else
                {
                    console.Console = text;
                }
            }
            catch { }
        }

        /// <summary>
        /// Display in chart - mainly designed for SSE
        /// </summary>
        /// <param name="title">String - training session name</param>
        /// <param name="x">double - trial number</param>
        /// <param name="y">double - sse error value</param>
        private void SetChart(string title, double x, double y)
        {
            //if (y > 1000) return;
            if (this.chart.InvokeRequired)
            {
                this.chart.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        chart.Series[title].Points.AddXY(x, y);
                        chart.Update();
                    }
                    catch
                    {
                        chart.Series.Add(title);
                        chart.Series[title].Color = System.Drawing.Color.Red;
                        chart.Series[title].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                        chart.Series[title].Points.AddXY(x, y);
                        chart.Series[title].BorderWidth = 3;
                        chart.Update();
                    }
                }));
            }
            else
            {
                try
                {
                    chart.Series[title].Points.AddXY(x, y);
                    chart.Update();
                }
                catch
                {
                    chart.Series.Add(title);
                    chart.Series[title].BorderWidth = 3;
                    chart.Series[title].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    chart.Series[title].Points.AddXY(x, y);                    
                    chart.ChartAreas[0].AxisX.Title = Resource.Inst.Get("r23");
                    chart.ChartAreas[0].AxisX.TitleForeColor = System.Drawing.Color.LightGray;
                    chart.ChartAreas[0].AxisX.Minimum = 1;
                    chart.ChartAreas[0].AxisY.Title = Resource.Inst.Get("r24");
                    chart.ChartAreas[0].AxisY.TitleForeColor = System.Drawing.Color.LightGray;
                    chart.Update();
                }
            }
        }

        /// <summary>
        /// Sets notification by default, but...
        /// </summary>
        /// <param name="text">String - message</param>
        /// <param name="id">int - if 1 then status bar</param>
        private void SetText(string text, int id = 1)
        {
            try
            {
                switch (id)
                {
                    case 1:
                        {
                            if (this.status.GetCurrentParent().InvokeRequired)
                            {
                                this.status.GetCurrentParent().Invoke(new MethodInvoker(delegate { status.Text = text; }));
                            }
                            else
                            {
                                status.Text = text;
                            }
                        } break;
                }
            }
            catch { }
        }
        #endregion

        private void saveChart()
        {
            try
            {
                String filename = Common.Dialog.Save(Resource.Inst.Get("r25"), "bmp", "", Resource.Inst.Get("r26"));
                if (!String.IsNullOrEmpty(filename))
                {
                    chart.SaveImage(filename, ChartImageFormat.Bmp);
                    SetText(Resource.Inst.Get("r27") + filename);
                }
                else
                {
                    SetText(Resource.Inst.Get("r28"));
                }

            }
            catch (Exception ex)
            {
                ex.ToLog();
                SetText(Resource.Inst.Get("r28"));
            }
        }

        private void toolSaveChart_Click(object sender, EventArgs e)
        {
            saveChart();
        }
        #endregion

        #region OTHER2
        /// <summary>
        /// Show settings button
        /// </summary>
        /// <param name="sender">who</param>
        /// <param name="e">arguments</param>
        private void toolSettings_Click(object sender, EventArgs e)
        {
            showSettings();
        }

        /// <summary>
        /// Close application button on toolbar
        /// </summary>
        /// <param name="sender">who</param>
        /// <param name="e">arguments</param>
        private void toolExit_Click(object sender, EventArgs e)
        {
            quit();
        }

        /// <summary>
        /// Save chart context option
        /// </summary>
        /// <param name="sender">who</param>
        /// <param name="e">arguments</param>
        private void cmChartSave_Click(object sender, EventArgs e)
        {
            saveChart();
        }

        /// <summary>
        /// Show history of learning window
        /// </summary>
        private void showHistory()
        {
            try
            {
                HistoryWindow hw = new HistoryWindow();
                hw.FormClosing += (s, a) =>
                {
                    this.BringToFront();
                };
                hw.ShowDialog();
            }
            catch (Exception ex)
            {
                info = ex.ToLog().GetError();
            }
        }

        /// <summary>
        /// Show history window toolbar button
        /// </summary>
        /// <param name="sender">who</param>
        /// <param name="e">arguments</param>
        private void toolHistory_Click(object sender, EventArgs e)
        {
            showHistory();    
        }

        /// <summary>
        /// Show history window menu option
        /// </summary>
        /// <param name="sender">who</param>
        /// <param name="e">arguments</param>
        private void tsHistory_Click(object sender, EventArgs e)
        {
            showHistory();
        }

        /// <summary>
        /// Window closing event
        /// </summary>
        /// <param name="sender">who</param>
        /// <param name="e">arguments</param>
        private void LearnByErrorMainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
        #endregion

        #region LANG_CHANGE
        private void tPolish_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure about switching application to Polish language?", "Language change", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly) == System.Windows.Forms.DialogResult.Yes)
            {
                var app = new AppSetting();
                app.Language = Languages.pl;
                Application.Restart();
            }
            else
            {
                this.BringToFront();
            }
            
        }

        private void tEnglish_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Czy jesteś pewien, że chcesz przełączyć na język angielski?", "Zmiana języka", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly) == System.Windows.Forms.DialogResult.Yes)
            {
                var app = new AppSetting();
                app.Language = Languages.en;
                Application.Restart();
            }
            else
            {
                this.BringToFront();
            }
        }
        #endregion

        private void LearnByErrorMainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.O: 
                    {
                        if (e.Control)
                        {
                            OpenDataFile();
                        }
                    } break;
                case Keys.R:
                    {
                        RunLearningProcess();
                    }break;
                case Keys.F5:
                    {
                        RunLearningProcess();
                    }break;
                case Keys.H:
                    {
                        if (e.Control)
                        {
                            showHistory();
                        }
                    }break;
                case Keys.U:
                    {
                        if (e.Control)
                        {
                            showSettings();
                        }
                    } break;
                case Keys.Q:
                    {
                        if (e.Control) { Application.Exit(); }
                    }break;
            }
        }

        private void toolInstruction_Click(object sender, EventArgs e)
        {
            try
            {
                (new InstructionWindow()).ShowDialog();
            }
            catch { }
        }

        private void toolNN_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                (new AppSetting()).NeuronNumber = toolNN.SelectedIndex + 1;                
            }
            catch (Exception ex)
            {
                info = ex.GetError();
            }
        }

        private void runReasearch_Click(object sender, EventArgs e)
        {
            ResearchWindow rw = new ResearchWindow();
            rw.FormClosing += (obj, param) =>
            {
                var window = (ResearchWindow)obj;
                ResearchNBN.NeuronNumber = window.MaxNeurons;
                ResearchNBN.RepeatForEachFile = window.MaxTrials;
                ResearchNBN.PDF = window.GeneratePDF;
                bool flag = window.CanRun;                

                if (flag)
                {
                    if (window.Items.Count == 0)
                    {
                        info = Resource.Inst.Get("r186");
                        return;
                    }
                    worker = new BackgroundWorker();
                    worker.WorkerReportsProgress = true;
                    worker.WorkerSupportsCancellation = true;

                    worker.ProgressChanged += (a, b) =>
                    {
                        info = b.ProgressPercentage.ToString() + " z " + ((int)status.Tag).ToString();
                    };

                    worker.DoWork += (a, b) =>
                    {                        
                        ResearchNBN test = new ResearchNBN();
                        test.Items = (List<string>)b.Argument;
                        test.OnUpdate += (counter) =>
                        {
                            ((BackgroundWorker)a).ReportProgress(counter);
                        };
                        test.Run();
                    };

                    worker.RunWorkerCompleted += (a, b) =>
                    {
                        showHistory();
                        stopReasearch.Visible = false;
                        info = "";
                    };

                    int count = window.Items.Count * ResearchNBN.NeuronNumber * ResearchNBN.RepeatForEachFile;
                    status.Tag = count;
                    info = String.Format(Resource.Inst.Get("r187"), count.ToString());
                    worker.RunWorkerAsync(window.Items);                    
                }
            };
            rw.ShowDialog();           
        }

        private void stopReasearch_Click(object sender, EventArgs e)
        {
            if (worker != null)
            {
                worker.CancelAsync();
                info = Resource.Inst.Get("r188");
            }
        }

        private void testForData_Click(object sender, EventArgs e)
        {
            if (worker != null && worker.IsBusy)
            {
                info = Resource.Inst.Get("r189");
                return;
            }
            var file = Common.Dialog.Open(Resource.Inst.Get("r190"), Resource.Inst.Get("r191"), "dat");
            if (file.Length > 0 && File.Exists(file))
            {
                RepeatWindowChoice rwc = new RepeatWindowChoice();
                rwc.Text = Resource.Inst.Get("r192");
                rwc.FormClosing += (owner, args) =>
                {
                    var w = (RepeatWindowChoice)owner;
                    if (w.Repeat)
                    {
                        var repeats = w.NumberOfRepeats;
                        NeuronNumberWindow nnw = new NeuronNumberWindow();
                        nnw.FormClosing += (nnnwOwner, nnwArgs) => {
                            var nw = (NeuronNumberWindow)nnnwOwner;
                            if (nw.IsSelected)
                            {
                                var neurons = nw.NumberOfNeurons;

                                worker = new BackgroundWorker();
                                worker.WorkerReportsProgress = true;
                                worker.WorkerSupportsCancellation = true;
                                worker.DoWork += (a, b) => 
                                {
                                    var data = ((String)b.Argument).Split(";".ToCharArray());
                                    var inputFile = data[0];
                                    var numberRepeats = int.Parse(data[1]);
                                    var maxNeurons = int.Parse(data[2]);
                                    List<LearnResult> results = new List<LearnResult>();

                                    int counter = 0;
                                    for (int nn = 1; nn < maxNeurons; nn++)
                                    {                                        
                                        for (int r = 0; r < numberRepeats; r++)
                                        {
                                            NBN nbn = new NBN(nn, file);
                                            results.Add(nbn.Run(1));                                            
                                            ((BackgroundWorker)a).ReportProgress(++counter);
                                        }
                                    }

                                    List<ReportData> items = new List<ReportData>();
    
                                    for (int nn = 2; nn <= maxNeurons; nn++)
                                    {
                                        var list = results.Where(q => q.Info != null && q.Info.nn == nn).ToList();

                                        var avgLearnRMSE = list.Average(q => q.AverageLearnRMSE);
                                        var avgTestRMSE = list.Average(q => q.AverageTestRMSE);
                                        ReportData r = new ReportData();
                                        r.LearnData = file;
                                        r.LearnRMSE = avgLearnRMSE.ToString();
                                        r.NeuronNumber = nn.ToString();
                                        r.TestRMSE = avgTestRMSE.ToString();
                                        r.Trials = numberRepeats.ToString();
                                        r.LearnTime = list.GetLearnTime();
                                        r.TestTime = list.GetTestTime();
                                        items.Add(r);
                                    }
                                    b.Result = items;
                                };
                                worker.ProgressChanged += (a, b) => 
                                {
                                    info = b.ProgressPercentage.ToString() + " z " + maxTmp;
                                };
                                worker.RunWorkerCompleted += (a, b) => 
                                {
                                    info = Resource.Inst.Get("r193");
                                    var report = ((List<ReportData>)b.Result);
                                    GridWindow gw = new GridWindow();
                                    gw.SetData(Resource.Inst.Get("r194"), report);
                                    gw.ShowDialog();
                                };

                                var arguments = String.Format("{0};{1};{2}", file, repeats, neurons);
                                maxTmp = (repeats * neurons).ToString();
                                worker.RunWorkerAsync(arguments);

                            }
                            else
                            {
                                info = Resource.Inst.Get("r195");
                            }
                        };
                        nnw.ShowDialog();
                    }
                    else
                    {
                        info = Resource.Inst.Get("r195");
                    }
                };
                rwc.ShowDialog();
            }
            else
            {
                info = Resource.Inst.Get("r196");
            }
        }

        private void tsbReasearchLearn_Click(object sender, EventArgs e)
        {
            RunLearningProcess(true);
        }
    }
}
