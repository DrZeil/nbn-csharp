using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using LearnByError.Database.Tables;
using LearnByErrorLibrary;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;
using LearnByError.Internazional;

namespace LearnByError
{
    public class ResearchNBN
    {
        public static int RepeatForEachFile = 5;
        public static int NeuronNumber = 10;
        public static bool PDF = false;        
        public int Total = 0;
        public delegate void Update(int number);
        public event Update OnUpdate;
        public List<string> Items = new List<string>();

        private Chart chart = null;
        public ResearchNBN()
        {
            Total = Items.Count * RepeatForEachFile * NeuronNumber;
        }

        public string GeneratePlot(double[] items, string title)
        {
            string file = "";
            chart = new Chart();

            chart.ChartAreas.Add(new ChartArea());
            int i = 1;
            foreach (var item in items)
            {
                SetChart(title, i, item);
                i++;
            }

            DateTime d = DateTime.Now;
            var xxx = String.Format("{0}_{1}_{2}_{3}_{4}_{5}_{6}", d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second, d.Millisecond);
            String chartFilename = Common.Folder.Data + "\\" + xxx + ".bmp";
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
                chart.Series[title].BorderWidth = 3;
                chart.Series[title].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chart.Series[title].Points.AddXY(x, y);
                chart.ChartAreas[0].AxisX.Title = Resource.Inst.Get("r23");
                chart.ChartAreas[0].AxisX.TitleForeColor = System.Drawing.Color.LightGray;
                chart.ChartAreas[0].AxisX.Minimum = 1;
                chart.ChartAreas[0].AxisY.Title = Resource.Inst.Get("r24");
                chart.ChartAreas[0].AxisY.TitleForeColor = System.Drawing.Color.LightGray;                
            }
        }

        public void Run()
        {
            int counter = 0;

            Parallel.ForEach(Items, file =>
                 {
                     for (int nn = 1; nn < NeuronNumber; nn++)//neuron number
                     {
                         for (int i = 0; i < RepeatForEachFile; i++)//learning tests for file with x neurons in network
                         {
                             try
                             {
                                 NBN nbn = new NBN(nn, file);
                                 var result = nbn.Run(1);

                                 DateTime d = DateTime.Now;
                                 History h = new History();
                                 h.Name = String.Format("{0}_{1}_{2}_{3}_{4}_{5}_{6}_{7}", Path.GetFileNameWithoutExtension(result.Filename),
                                     d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second, d.Millisecond);
                                 h.Data = marekbar.Xml.Serialize<LearnResult>(result);
                                 h.Insert();

                                 if (PDF)
                                 {
                                     try
                                     {
                                         string filename = Common.Folder.Data + "\\" + h.Name + ".pdf";

                                         PDFGenerate data = new PDFGenerate();
                                         data.Filename = filename;
                                         data.Result = result;
                                         data.ChartFilename = GeneratePlot(result.RMSE[0], Path.GetFileNameWithoutExtension(result.Filename));
                                         HistoryPDF pdf = new HistoryPDF(data.Result, data.ChartFilename, true);
                                         pdf.Save(data.Filename);
                                     }
                                     catch
                                     { //don't care about it
                                     }
                                 }
                             }
                             catch (Exception ex)
                             {
                                 ex.GetError();
                             }
                             finally
                             {
                                 counter++;
                                 if (OnUpdate != null)
                                 {
                                     OnUpdate(counter);
                                 }
                             }
                         }
                     }
                 });
        }
    }
}
