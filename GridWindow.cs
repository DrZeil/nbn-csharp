/*
Author:  Marek Bar 33808
Contact: marekbar1985@gmail.com
Wyższa Szkoła Informatyki i Zarządzania w Rzeszowie
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace LearnByError
{
    public partial class GridWindow : Form
    {
        public GridWindow()
        {
            InitializeComponent();

        }

        private List<ReportData> data;
        string filename = "";
        public void SetData(string title, List<ReportData> data)
        {
            this.Text = title;
            this.data = data;
            grid.DataSource = this.data;
            grid.Invalidate();
        }

        private void copyToClipboard(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var i in data)
            {
                sb.AppendLine(i.ToString());
            }
            System.Windows.Forms.Clipboard.SetText(sb.ToString());
        }

        private void GridWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C && e.Control)
            {
                copyToClipboard(sender, e);
            }
        }

        private void kopiujDoNotatnikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var i in data)
            {
                sb.AppendLine(i.ToString());
            }
            string file = Path.GetTempFileName();
            using (StreamWriter w = new StreamWriter(file))
            {
                w.Write(sb.ToString());
                w.Close();
            }
            Process.Start("notepad.exe", file);
        }

        private void SaveResult()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                foreach (var i in data)
                {
                    sb.AppendLine(i.ToString());
                }
                DateTime d = DateTime.Now;
                filename = String.Format("{0}\\{1}_powtorzenia{2}_maxneurony{3}_{4}_{5}_{6}_{7}_{8}_{9}_{10}.txt", Common.Folder.LearnHistory,
                    Path.GetFileNameWithoutExtension(data[0].LearnData),
                    data[0].Trials,
                    data.Max(q => q.NeuronNumber).First(),
                    d.Year, d.Month, d.Day,
                    d.Hour, d.Minute, d.Second, d.Millisecond
                    );

                var best = data.Where(q => q.LearnRMSE == data.Min(m => m.LearnRMSE)).ToList().First().ToString();
                using (StreamWriter w = new StreamWriter(filename))
                {
                    w.Write(sb.ToString());
                    w.WriteLine("Najlepszy wynik:");
                    w.WriteLine(best);
                    
                    w.Close();
                }
            }
            catch (Exception ex)
            {
                ex.ToLog();
            }
        }

        private void GridWindow_Load(object sender, EventArgs e)
        {
            this.kopiujDoSchowkaToolStripMenuItem.Text = LearnByError.Internazional.Resource.Inst.Get("r202");
            this.learnDataDataGridViewTextBoxColumn.HeaderText = LearnByError.Internazional.Resource.Inst.Get("r203");
            this.neuronNumberDataGridViewTextBoxColumn.HeaderText = LearnByError.Internazional.Resource.Inst.Get("r204");
            this.trialsDataGridViewTextBoxColumn.HeaderText = LearnByError.Internazional.Resource.Inst.Get("r205");
            this.testRMSEDataGridViewTextBoxColumn.HeaderText = LearnByError.Internazional.Resource.Inst.Get("r206");
            this.Column1.HeaderText = LearnByError.Internazional.Resource.Inst.Get("r207");
            this.Column2.HeaderText = LearnByError.Internazional.Resource.Inst.Get("r208");
            this.kopiujDoNotatnikaToolStripMenuItem.Text = LearnByError.Internazional.Resource.Inst.Get("r209");
            this.learnRMSEDataGridViewTextBoxColumn.HeaderText = LearnByError.Internazional.Resource.Inst.Get("r210");
            SaveResult();
        }
    }
}
