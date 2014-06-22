/*
Author:  Marek Bar 33808
Contact: marekbar1985@gmail.com
Wyższa Szkoła Informatyki i Zarządzania w Rzeszowie
 */
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LearnByError.Database.Tables;
using System.Threading;
using System.Globalization;
using LearnByErrorLibrary;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
namespace LearnByError
{
    /// <summary>
    /// Learning history window
    /// </summary>
    public partial class HistoryWindow : Form
    {
        /// <summary>
        /// Ids from table
        /// </summary>
        private List<int> items = new List<int>();

        /// <summary>
        /// Current result
        /// </summary>
        private LearnResult result = null;

        /// <summary>
        /// Default constructort
        /// </summary>
        public HistoryWindow()
        {
            InitializeComponent();
            chart.Series.Clear();
            weightsList.Items.Clear();
            this.toolOptions.Text = LearnByError.Internazional.Resource.Inst.Get("r39");
            this.tSave.Text = LearnByError.Internazional.Resource.Inst.Get("r40");
            this.menuSaveWeights.Text = LearnByError.Internazional.Resource.Inst.Get("r41");
            this.menuPDF.Text = LearnByError.Internazional.Resource.Inst.Get("r42");
            this.previous.Text = LearnByError.Internazional.Resource.Inst.Get("r43");
            this.next.Text = LearnByError.Internazional.Resource.Inst.Get("r44");
            this.exit.Text = LearnByError.Internazional.Resource.Inst.Get("r45");
            this.label1.Text = LearnByError.Internazional.Resource.Inst.Get("r46");
            this.label2.Text = LearnByError.Internazional.Resource.Inst.Get("r47");
            this.cmwSave.Text = LearnByError.Internazional.Resource.Inst.Get("r48");
            this.cmhDelete.Text = LearnByError.Internazional.Resource.Inst.Get("r49");
            this.label3.Text = LearnByError.Internazional.Resource.Inst.Get("r50");
            this.cmcSave.Text = LearnByError.Internazional.Resource.Inst.Get("r51");
            this.Text = LearnByError.Internazional.Resource.Inst.Get("r52");
            this.menuPDF2.Text = LearnByError.Internazional.Resource.Inst.Get("r162");
            this.contextMenuHistory.Text = LearnByError.Internazional.Resource.Inst.Get("r178");
            this.nnText.Text = LearnByError.Internazional.Resource.Inst.Get("r211");
            this.nn10.Text = LearnByError.Internazional.Resource.Inst.Get("r212");
            this.nn9.Text = LearnByError.Internazional.Resource.Inst.Get("r213");
            this.nn8.Text = LearnByError.Internazional.Resource.Inst.Get("r214");
            this.nn7.Text = LearnByError.Internazional.Resource.Inst.Get("r215");
            this.nn6.Text = LearnByError.Internazional.Resource.Inst.Get("r216");
            this.nn5.Text = LearnByError.Internazional.Resource.Inst.Get("r217");
            this.nn4.Text = LearnByError.Internazional.Resource.Inst.Get("r218");
            this.nn3.Text = LearnByError.Internazional.Resource.Inst.Get("r219");
            this.nn2.Text = LearnByError.Internazional.Resource.Inst.Get("r220");
            this.nnAll.Text = LearnByError.Internazional.Resource.Inst.Get("r221");
            this.rmseText.Text = LearnByError.Internazional.Resource.Inst.Get("r222");
            this.rmse00001.Text = LearnByError.Internazional.Resource.Inst.Get("r223");
            this.rmse0001.Text = LearnByError.Internazional.Resource.Inst.Get("r224");
            this.rmse001.Text = LearnByError.Internazional.Resource.Inst.Get("r225");
            this.rmse01.Text = LearnByError.Internazional.Resource.Inst.Get("r226");
            this.rmse0.Text = LearnByError.Internazional.Resource.Inst.Get("r227");
            this.rmseAll.Text = LearnByError.Internazional.Resource.Inst.Get("r228");

        }

        #region INTERFACE_BLOCKER
        /// <summary>
        /// Blocks interface
        /// </summary>
        private void blockInterface()
        {
            interfaceBlock(false);
            progress.Enabled = true;
            progress.Style = ProgressBarStyle.Marquee;
            progress.Visible = true;
        }

        /// <summary>
        /// Unblock interface
        /// </summary>
        private void unblockInterface()
        {
            interfaceBlock(true);
            progress.Enabled = false;
            progress.Visible = false;
        }

        /// <summary>
        /// Interface blocker/unblocker
        /// </summary>
        /// <param name="isEnabled">true - block or false - unblock</param>
        private void interfaceBlock(bool isEnabled)
        {
            try
            {
                for (int i = 0; i < this.Controls.Count; i++)
                {
                    this.Controls[i].Enabled = isEnabled;
                }
                chart.Enabled = true;
            }
            catch (Exception ex)
            {
                ex.ToLog();
            }
        }

        #endregion

        /// <summary>
        /// Window loading event and some initialize actions
        /// </summary>
        /// <param name="sender">who</param>
        /// <param name="e">arguments</param>
        private void HistoryWindow_Load(object sender, EventArgs e)
        {
            loadHistory();
        }

        /// <summary>
        /// Load dat filtered by neuron number
        /// </summary>
        /// <param name="numberOfNeurons">int - neuron number - if 0 then all</param>
        private void loadHistory(int numberOfNeurons = 0)
        {
            try
            {
                rmseAll.Checked = true;
                rmse0.Checked = false;
                rmse01.Checked = false;
                rmse001.Checked = false;
                rmse0001.Checked = false;
                history.Items.Clear();
                var all = LearnByError.Database.Tables.History.ReadAll();
                if (numberOfNeurons == 0)
                {
                    foreach (var item in all)
                    {
                        items.Add(item.Id);
                        history.Items.Add(item.Name);
                    }
                    nnAll.Checked = true;
                    nn2.Checked = false;
                    nn3.Checked = false;
                    nn4.Checked = false;
                    nn5.Checked = false;
                    nn6.Checked = false;
                    nn7.Checked = false;
                    nn8.Checked = false;
                    nn9.Checked = false;
                    nn10.Checked = false;
                }
                else if (numberOfNeurons >= 10)
                {
                    foreach (var his in all)
                    {
                        var result = marekbar.Xml.Deserialize<LearnResult>(his.Data);
                        if (result.Info != null && result.Info.nn >= numberOfNeurons)
                        {
                            items.Add(his.Id);
                            history.Items.Add(his.Name);
                        }
                    }
                    nnAll.Checked = false;
                    nn2.Checked = false;
                    nn3.Checked = false;
                    nn4.Checked = false;
                    nn5.Checked = false;
                    nn6.Checked = false;
                    nn7.Checked = false;
                    nn8.Checked = false;
                    nn9.Checked = false;
                    nn10.Checked = true;
                }
                else
                {
                    foreach (var his in all)
                    {
                        var result = marekbar.Xml.Deserialize<LearnResult>(his.Data);
                        if (result.Info != null && result.Info.nn == numberOfNeurons)
                        {
                            items.Add(his.Id);
                            history.Items.Add(his.Name);
                        }
                    }
                    switch (numberOfNeurons)
                    {
                        case 2:
                            {
                                nnAll.Checked = false;
                                nn2.Checked = true;
                                nn3.Checked = false;
                                nn4.Checked = false;
                                nn5.Checked = false;
                                nn6.Checked = false;
                                nn7.Checked = false;
                                nn8.Checked = false;
                                nn9.Checked = false;
                                nn10.Checked = false;
                            } break;
                        case 3:
                            {
                                nnAll.Checked = false;
                                nn2.Checked = false;
                                nn3.Checked = true;
                                nn4.Checked = false;
                                nn5.Checked = false;
                                nn6.Checked = false;
                                nn7.Checked = false;
                                nn8.Checked = false;
                                nn9.Checked = false;
                                nn10.Checked = false;
                            } break;
                        case 4:
                            {
                                nnAll.Checked = false;
                                nn2.Checked = false;
                                nn3.Checked = false;
                                nn4.Checked = true;
                                nn5.Checked = false;
                                nn6.Checked = false;
                                nn7.Checked = false;
                                nn8.Checked = false;
                                nn9.Checked = false;
                                nn10.Checked = false;
                            } break;
                        case 5:
                            {
                                nnAll.Checked = false;
                                nn2.Checked = false;
                                nn3.Checked = false;
                                nn4.Checked = false;
                                nn5.Checked = true;
                                nn6.Checked = false;
                                nn7.Checked = false;
                                nn8.Checked = false;
                                nn9.Checked = false;
                                nn10.Checked = false;
                            } break;
                        case 6:
                            {
                                nnAll.Checked = false;
                                nn2.Checked = false;
                                nn3.Checked = false;
                                nn4.Checked = false;
                                nn5.Checked = false;
                                nn6.Checked = true;
                                nn7.Checked = false;
                                nn8.Checked = false;
                                nn9.Checked = false;
                                nn10.Checked = false;
                            } break;
                        case 7:
                            {
                                nnAll.Checked = false;
                                nn2.Checked = false;
                                nn3.Checked = false;
                                nn4.Checked = false;
                                nn5.Checked = false;
                                nn6.Checked = false;
                                nn7.Checked = true;
                                nn8.Checked = false;
                                nn9.Checked = false;
                                nn10.Checked = false;
                            } break;
                        case 8:
                            {
                                nnAll.Checked = false;
                                nn2.Checked = false;
                                nn3.Checked = false;
                                nn4.Checked = false;
                                nn5.Checked = false;
                                nn6.Checked = false;
                                nn7.Checked = false;
                                nn8.Checked = true;
                                nn9.Checked = false;
                                nn10.Checked = false;
                            } break;
                        case 9:
                            {
                                nnAll.Checked = false;
                                nn2.Checked = false;
                                nn3.Checked = false;
                                nn4.Checked = false;
                                nn5.Checked = false;
                                nn6.Checked = false;
                                nn7.Checked = false;
                                nn8.Checked = false;
                                nn9.Checked = true;
                                nn10.Checked = false;
                            } break;
                        default: { } break;
                    }
                }

                if (history.Items.Count > 0)
                {
                    history.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                status.Text = ex.Message;
            }
            finally
            {
                this.Text = String.Format(LearnByError.Internazional.Resource.Inst.Get("r229"), history.Items.Count);
            }
        }

        /// <summary>
        /// Selection action - selecting learning result
        /// </summary>
        /// <param name="sender">who</param>
        /// <param name="e">arguments</param>
        private void list_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                History h = new History();
                h.Id = items[history.SelectedIndex];
                h.Read();
                result = marekbar.Xml.Deserialize<LearnResult>(h.Data);
                loadIntoInterface(result);
            }
            catch (Exception ex)
            {
                ex.ToLog();
            }

        }

        /// <summary>
        /// Load learning result into interface
        /// </summary>
        /// <param name="lr">LearnResult</param>
        private void loadIntoInterface(LearnResult lr)
        {
            try
            {
                status.Text = "";
                int trial = 1;

                weightsList.Items.Clear();
                chart.Series.Clear();
                foreach (var weights in lr.ResultWeights)
                {
                    String name = LearnByError.Internazional.Resource.Inst.Get("r53") + trial.ToString();
                    weightsList.Items.Add(name);
                    for (int i = 0; i < weights.Length; i++)
                    {
                        weightsList.Items.Add(weights[i].ToString());
                    }
                    weightsList.Items.Add("");

                    if (lr.Info.np == 0) throw new Exception(LearnByError.Internazional.Resource.Inst.Get("r54"));

                    int jj = 1;
                    foreach (var rmse in lr.RMSE)
                    {
                        for (int j = 0; j < rmse.Length; j++)
                        {
                            SetChart(LearnByError.Internazional.Resource.Inst.Get("r53") + jj.ToString(), j + 1, rmse[j]);
                        }
                        jj++;
                    }
                    trial++;                    
                }
                chart.Update();
                status.Text = LearnByError.Internazional.Resource.Inst.Get("r55");
                learnRMSE.Text = string.Format(LearnByError.Internazional.Resource.Inst.Get("r230"), result.AverageLearnRMSE);
                testRMSE.Text = string.Format(LearnByError.Internazional.Resource.Inst.Get("r231"), result.AverageTestRMSE);
                times.Text = string.Format(LearnByError.Internazional.Resource.Inst.Get("r232"), result.AverageLearnTime, result.AverageTestTime);
                neuronNumber.Text = string.Format(LearnByError.Internazional.Resource.Inst.Get("r233"), result.Filename, result.Info != null ? result.Info.nn : 0);
            }
            catch (Exception ex)
            {
                ex.ToLog();
                status.Text = ex.Message;
            }
            finally
            {
                this.Text = String.Format(LearnByError.Internazional.Resource.Inst.Get("r229"), history.Items.Count);
            }
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
            }
            catch
            {
                chart.Series.Add(title);
                chart.Series[title].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chart.Series[title].Points.AddXY(x, y);
                chart.ChartAreas[0].AxisX.Title = LearnByError.Internazional.Resource.Inst.Get("r57");
                chart.ChartAreas[0].AxisX.TitleForeColor = System.Drawing.Color.Black;
                chart.ChartAreas[0].AxisX.Minimum = 1;
                chart.ChartAreas[0].AxisY.Title = LearnByError.Internazional.Resource.Inst.Get("r56");
                chart.ChartAreas[0].AxisY.TitleForeColor = System.Drawing.Color.Black;
            }
        }

        /// <summary>
        /// Save chart to file
        /// </summary>
        private void saveChart()
        {
            try
            {
                String filename = Common.Dialog.Save(LearnByError.Internazional.Resource.Inst.Get("r58"), "bmp",
                    "", LearnByError.Internazional.Resource.Inst.Get("r59"));
                if (!String.IsNullOrEmpty(filename))
                {
                    chart.SaveImage(filename, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Bmp);
                    status.Text = LearnByError.Internazional.Resource.Inst.Get("r60") + filename;
                }
                else
                {
                    status.Text = LearnByError.Internazional.Resource.Inst.Get("r61");
                }

            }
            catch (Exception ex)
            {
                ex.ToLog();
                status.Text = LearnByError.Internazional.Resource.Inst.Get("r61");
            }
        }

        /// <summary>
        /// Save chart menu action
        /// </summary>
        /// <param name="sender">who</param>
        /// <param name="e">arguments</param>
        private void tSave_Click(object sender, EventArgs e)
        {
            saveChart();
        }

        /// <summary>
        /// Save chart - context menu
        /// </summary>
        /// <param name="sender">who</param>
        /// <param name="e">arguments</param>
        private void cmcSave_Click(object sender, EventArgs e)
        {
            saveChart();
        }

        /// <summary>
        /// Save weights to file
        /// </summary>
        private void saveWeights()
        {
            try
            {
                String filename = Common.Dialog.Save(LearnByError.Internazional.Resource.Inst.Get("r62"), "txt",
                    "", LearnByError.Internazional.Resource.Inst.Get("r63"));
                var sb = new System.Text.StringBuilder();
                foreach (var item in weightsList.Items)
                {
                    sb.AppendLine((String)item);
                }

                if (Common.File.WriteToTextFile(filename, sb.ToString()))
                {
                    status.Text = LearnByError.Internazional.Resource.Inst.Get("r64") + filename;
                }
                else
                {
                    status.Text = LearnByError.Internazional.Resource.Inst.Get("r65");
                }
            }
            catch (Exception ex)
            {
                ex.ToLog();
                status.Text = LearnByError.Internazional.Resource.Inst.Get("r65");
            }
        }

        /// <summary>
        /// Save weights context menu button
        /// </summary>
        /// <param name="sender">who</param>
        /// <param name="e">arguments</param>
        private void cmwSave_Click(object sender, EventArgs e)
        {
            saveWeights();
        }

        /// <summary>
        /// Save weights menu button
        /// </summary>
        /// <param name="sender">who</param>
        /// <param name="e">arguments</param>
        private void menuSaveWeights_Click(object sender, EventArgs e)
        {
            saveWeights();
        }

        /// <summary>
        /// Load previous learing results
        /// </summary>
        /// <param name="sender">who</param>
        /// <param name="e">arguments</param>
        private void previous_Click(object sender, EventArgs e)
        {
            try
            {
                history.SelectedIndex = history.SelectedIndex - 1;
                list_SelectedIndexChanged(sender, e);
            }
            catch { }
        }

        /// <summary>
        /// Load next learning results
        /// </summary>
        /// <param name="sender">who</param>
        /// <param name="e">arguments</param>
        private void next_Click(object sender, EventArgs e)
        {
            try
            {
                history.SelectedIndex = history.SelectedIndex + 1;
                list_SelectedIndexChanged(sender, e);
            }
            catch { }
        }

        /// <summary>
        /// Close window button
        /// </summary>
        /// <param name="sender">who</param>
        /// <param name="e">arguments</param>
        private void exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Delete learing history for position
        /// </summary>
        /// <param name="sender">who</param>
        /// <param name="e">arguments</param>
        private void cmhDelete_Click(object sender, EventArgs e)
        {
            status.Text = "";
            if (MessageBox.Show(LearnByError.Internazional.Resource.Inst.Get("r66"), LearnByError.Internazional.Resource.Inst.Get("r67"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly) == System.Windows.Forms.DialogResult.Yes)
            {
                blockInterface();
                History h = new History();
                int index = history.SelectedIndex;
                h.Id = items[index];
                h.Delete();
                history.Items.RemoveAt(index);
                items.RemoveAt(index);
                history.SelectedIndex = 0;
                unblockInterface();
                this.BringToFront();
            }
            else
            {
                status.Text = "";
                this.BringToFront();
            }
        }

        private void menuPDF_Click(object sender, EventArgs e)
        {
            saveToPDF();
        }

        private void saveToPDF()
        {
            saveToPdfSimple(false);
        }

        private void menuPDF2_Click(object sender, EventArgs e)
        {
            saveToPdfSimple(true);
        }

        private void saveToPdfSimple(bool flag)
        {
            try
            {
                String filename = Common.Dialog.Save(LearnByError.Internazional.Resource.Inst.Get("r68"), "pdf");
                if (filename != "" && result != null)
                {
                    String chartFilename = Common.Folder.Data + "\\" +
                                DateTime.Now.ToString().Replace(':', '_').Replace(' ', '_').Replace('-', '_') + ".bmp";
                    chart.SaveImage(chartFilename, System.Drawing.Imaging.ImageFormat.Bmp);

                    PDFGenerate tmp = new PDFGenerate();
                    tmp.Filename = filename;
                    tmp.Result = result;
                    tmp.ChartFilename = chartFilename;

                    var bw = new System.ComponentModel.BackgroundWorker();
                    bw.DoWork += (a, b) =>
                    {
                        var data = (PDFGenerate)b.Argument;
                        HistoryPDF pdf = new HistoryPDF(data.Result, data.ChartFilename, flag);

                        if (pdf.Save(data.Filename))
                        {
                            pdf.Open();

                            b.Result = LearnByError.Internazional.Resource.Inst.Get("r69") + data.Filename;
                        }
                        else
                        {
                            b.Result = LearnByError.Internazional.Resource.Inst.Get("r70");
                        }
                    };
                    bw.RunWorkerCompleted += (a, b) =>
                    {
                        status.Text = (String)b.Result;
                        progress.Visible = false;
                    };
                    progress.Visible = true;
                    bw.RunWorkerAsync(tmp);
                }
            }
            catch (Exception ex)
            {
                ex.ToLog();
                status.Text = ex.Message;
            }
        }

        private void nnAll_Click(object sender, EventArgs e)
        {
            loadHistory();
        }

        private void nn2_Click(object sender, EventArgs e)
        {
            loadHistory(2);
        }

        private void nn3_Click(object sender, EventArgs e)
        {
            loadHistory(3);
        }

        private void nn4_Click(object sender, EventArgs e)
        {
            loadHistory(4);
        }

        private void nn5_Click(object sender, EventArgs e)
        {
            loadHistory(5);
        }

        private void nn6_Click(object sender, EventArgs e)
        {
            loadHistory(6);
        }

        private void nn7_Click(object sender, EventArgs e)
        {
            loadHistory(7);
        }

        private void nn8_Click(object sender, EventArgs e)
        {
            loadHistory(8);
        }

        private void nn9_Click(object sender, EventArgs e)
        {
            loadHistory(9);
        }

        private void nn10_Click(object sender, EventArgs e)
        {
            loadHistory(10);
        }

        private void rmseAll_Click(object sender, EventArgs e)
        {
            loadHistoryRMSE(-1);
        }

        private void rmse0_Click(object sender, EventArgs e)
        {
            loadHistoryRMSE(0);
        }

        private void rmse01_Click(object sender, EventArgs e)
        {
            loadHistoryRMSE(0.1);
        }

        private void rmse001_Click(object sender, EventArgs e)
        {
            loadHistoryRMSE(0.01);
        }

        private void rmse0001_Click(object sender, EventArgs e)
        {
            loadHistoryRMSE(0.001);
        }

        private void loadHistoryRMSE(double p)
        {
            try
            {
                nnAll.Checked = true;
                nn2.Checked = false;
                nn3.Checked = false;
                nn4.Checked = false;
                nn5.Checked = false;
                nn6.Checked = false;
                nn7.Checked = false;
                nn8.Checked = false;
                nn9.Checked = false;
                nn10.Checked = false;
                history.Items.Clear();
                var all = LearnByError.Database.Tables.History.ReadAll();
                if (p == -1)
                {
                    rmseAll.Checked = true;
                    rmse0.Checked = false;
                    rmse01.Checked = false;
                    rmse001.Checked = false;
                    rmse0001.Checked = false;
                    rmse00001.Checked = false;
                    foreach (var his in all)
                    {
                        var result = marekbar.Xml.Deserialize<LearnResult>(his.Data);
                        items.Add(his.Id);
                        history.Items.Add(his.Name);
                    }

                }
                else if (p == 0)
                {
                    rmseAll.Checked = false;
                    rmse0.Checked = true;
                    rmse01.Checked = false;
                    rmse001.Checked = false;
                    rmse0001.Checked = false;
                    rmse00001.Checked = false;
                    foreach (var his in all)
                    {
                        var result = marekbar.Xml.Deserialize<LearnResult>(his.Data);
                        if (result.Info != null && result.AverageLearnRMSE <= 0)
                        {
                            items.Add(his.Id);
                            history.Items.Add(his.Name);
                        }
                    }
                }
                else if (p == 0.1)
                {
                    rmseAll.Checked = false;
                    rmse0.Checked = false;
                    rmse01.Checked = true;
                    rmse001.Checked = false;
                    rmse0001.Checked = false;
                    rmse00001.Checked = false;
                    foreach (var his in all)
                    {
                        var result = marekbar.Xml.Deserialize<LearnResult>(his.Data);
                        if (result.Info != null && result.AverageLearnRMSE <= 0.1)
                        {
                            items.Add(his.Id);
                            history.Items.Add(his.Name);
                        }
                    }
                }
                else if (p == 0.01)
                {
                    rmseAll.Checked = false;
                    rmse0.Checked = false;
                    rmse01.Checked = false;
                    rmse001.Checked = true;
                    rmse0001.Checked = false;
                    rmse00001.Checked = false;
                    foreach (var his in all)
                    {
                        var result = marekbar.Xml.Deserialize<LearnResult>(his.Data);
                        if (result.Info != null && result.AverageLearnRMSE <= 0.01)
                        {
                            items.Add(his.Id);
                            history.Items.Add(his.Name);
                        }
                    }
                }
                else if (p == 0.001)
                {
                    rmseAll.Checked = false;
                    rmse0.Checked = false;
                    rmse01.Checked = false;
                    rmse001.Checked = false;
                    rmse0001.Checked = true;
                    rmse00001.Checked = false;
                    foreach (var his in all)
                    {
                        var result = marekbar.Xml.Deserialize<LearnResult>(his.Data);
                        if (result.Info != null && result.AverageLearnRMSE <= 0.001)
                        {
                            items.Add(his.Id);
                            history.Items.Add(his.Name);
                        }
                    }
                }
                else if (p == 0.0001)
                {
                    rmseAll.Checked = false;
                    rmse0.Checked = false;
                    rmse01.Checked = false;
                    rmse001.Checked = false;
                    rmse0001.Checked = false;
                    rmse00001.Checked = true;
                    foreach (var his in all)
                    {
                        var result = marekbar.Xml.Deserialize<LearnResult>(his.Data);
                        if (result.Info != null && result.AverageLearnRMSE <= 0.0001)
                        {
                            items.Add(his.Id);
                            history.Items.Add(his.Name);
                        }
                    }
                }
                if (history.Items.Count > 0)
                {
                    history.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                ex.ToLog();
            }
        }

        private void rmse00001_Click(object sender, EventArgs e)
        {
            loadHistoryRMSE(0.0001);
        }
    }

}
