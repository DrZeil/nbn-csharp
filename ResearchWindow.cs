/*
Author:  Marek Bar 33808
Contact: marekbar1985@gmail.com
Wyższa Szkoła Informatyki i Zarządzania w Rzeszowie
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace LearnByError
{
    public partial class ResearchWindow : Form
    {
        public ResearchWindow()
        {
            InitializeComponent();
        }

        public int MaxNeurons = 5;
        public int MaxTrials = 5;
        public bool GeneratePDF = false;
        public bool CanRun = false;
        public List<String> Items = new List<string>();
        private BackgroundWorker bw = new BackgroundWorker();
        private int max = (new LearnByErrorLibrary.TrainerResource()).Resources.Length;

        private void ResearchWindow_Load(object sender, EventArgs e)
        {
            list.Items.AddRange(System.IO.Directory.GetFiles(Common.Folder.Samples));
            status.Text = Common.Folder.Samples;
            this.label1.Text = LearnByError.Internazional.Resource.Inst.Get("r252");
            this.label3.Text = LearnByError.Internazional.Resource.Inst.Get("r253");
            this.label4.Text = LearnByError.Internazional.Resource.Inst.Get("r254");
            this.label2.Text = LearnByError.Internazional.Resource.Inst.Get("r255");
            this.button2.Text = LearnByError.Internazional.Resource.Inst.Get("r256");
            this.pdf.Text = LearnByError.Internazional.Resource.Inst.Get("r257");
            this.buttonFolder.Text = LearnByError.Internazional.Resource.Inst.Get("r258");
            this.buttonSamples.Text = LearnByError.Internazional.Resource.Inst.Get("r259");
            this.Text = LearnByError.Internazional.Resource.Inst.Get("r260");

        }

        private void repeats_ValueChanged(object sender, EventArgs e)
        {
            MaxTrials = (int)repeats.Value;
        }

        private void neurons_ValueChanged(object sender, EventArgs e)
        {
            MaxNeurons = (int)neurons.Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CanRun = true;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CanRun = false;
            Close();
        }

        private void pdf_CheckedChanged(object sender, EventArgs e)
        {
            GeneratePDF = pdf.Checked;
        }

        private void list_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                Items.Add((string)list.Items[e.Index]);
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                Items.Remove((string)list.Items[e.Index]);
            }
        }

        private void buttonFolder_Click(object sender, EventArgs e)
        {
            var folder = Common.Dialog.SelectFolder();
            if (folder != "")
            {
                status.Text = folder;
                list.Items.Clear();
                list.Items.AddRange(System.IO.Directory.GetFiles(folder));
            }
        }

        private void buttonSamples_Click(object sender, EventArgs e)
        {
            if (!bw.IsBusy)
            {
                bw.WorkerReportsProgress = true;
                bw.WorkerSupportsCancellation = true;
                bw.DoWork += (a, b) =>
                {
                    int counter = 0;
                    List<string> list = (new LearnByErrorLibrary.TrainerResource()).ResourceList;
                    foreach (var item in list)
                    {
                        LearnByErrorLibrary.TrainerResource.loadSample(item);
                        counter++;
                        ((BackgroundWorker)a).ReportProgress(counter);
                    }
                };
                bw.RunWorkerCompleted += (a, b) =>
                {
                    list.Items.Clear();
                    list.Items.AddRange(System.IO.Directory.GetFiles(Common.Folder.Samples));
                };
                bw.ProgressChanged += (a, b) =>
                {
                    status.Text = String.Format(LearnByError.Internazional.Resource.Inst.Get("r261"), b.ProgressPercentage, max);
                };
                bw.RunWorkerAsync();
                status.Text = LearnByError.Internazional.Resource.Inst.Get("r262");
            }
            else
            {
                status.Text = LearnByError.Internazional.Resource.Inst.Get("r263");
            }
        }
    }
}
