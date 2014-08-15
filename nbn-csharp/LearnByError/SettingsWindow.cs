using System;
using System.Windows.Forms;

namespace LearnByError
{
    /// <summary>
    /// Settings window
    /// </summary>
    public partial class SettingsWindow : Form
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public SettingsWindow()
        {
            InitializeComponent();
            this.tabPage1.Text = LearnByError.Internazional.Resource.Inst.Get("r79");
            this.groupBox1.Text = LearnByError.Internazional.Resource.Inst.Get("r80");
            this.buttonRemoveLearnHistory.Text = LearnByError.Internazional.Resource.Inst.Get("r81");
            this.buttonRemoveLogs.Text = LearnByError.Internazional.Resource.Inst.Get("r82");
            this.label3.Text = LearnByError.Internazional.Resource.Inst.Get("r83");
            this.cbAutoSave.Items.AddRange(new object[] {
            LearnByError.Internazional.Resource.Inst.Get("r158"),
            LearnByError.Internazional.Resource.Inst.Get("r159")});
            this.label2.Text = LearnByError.Internazional.Resource.Inst.Get("r84");
            this.cbConsole.Items.AddRange(new object[] {
            LearnByError.Internazional.Resource.Inst.Get("r160"),
            LearnByError.Internazional.Resource.Inst.Get("r161")});
            this.label1.Text = LearnByError.Internazional.Resource.Inst.Get("r85");
            this.ebFolder.Caption = LearnByError.Internazional.Resource.Inst.Get("r86");
            this.tabPage2.Text = LearnByError.Internazional.Resource.Inst.Get("r87");
            this.ebScale.Caption = LearnByError.Internazional.Resource.Inst.Get("r88");
            this.ebME.Caption = LearnByError.Internazional.Resource.Inst.Get("r89");
            this.ebMI.Caption = LearnByError.Internazional.Resource.Inst.Get("r90");
            this.ebMUH.Caption = LearnByError.Internazional.Resource.Inst.Get("r91");
            this.ebMUL.Caption = LearnByError.Internazional.Resource.Inst.Get("r92");
            this.ebMU.Caption = LearnByError.Internazional.Resource.Inst.Get("r93");
            this.toolSave.Text = LearnByError.Internazional.Resource.Inst.Get("r94");
            this.toolDefaults.Text = LearnByError.Internazional.Resource.Inst.Get("r95");
            this.toolExit.Text = LearnByError.Internazional.Resource.Inst.Get("r96");
            this.label4.Text = LearnByError.Internazional.Resource.Inst.Get("r97");
            this.Text = LearnByError.Internazional.Resource.Inst.Get("r98");
            this.nnLabel.Text = LearnByError.Internazional.Resource.Inst.Get("r176");
            this.nnLabel.Text = LearnByError.Internazional.Resource.Inst.Get("r181");
        }

        /// <summary>
        /// Save button
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void toolSave_Click(object sender, EventArgs e)
        {
            try
            {
                AppSetting s = new AppSetting();
                s.MU = double.Parse(ebMU.Value.Replace('.', ','));
                s.MUH = double.Parse(ebMUH.Value.Replace('.', ','));
                s.MUL = double.Parse(ebMUL.Value.Replace('.', ','));
                s.MaxIterations = int.Parse(ebMI.Value.Replace('.', ','));
                s.MaxError = double.Parse(ebME.Value.Replace('.', ','));
                s.Scale = int.Parse(ebScale.Value.Replace('.', ','));
                s.ShowConsole = cbConsole.SelectedIndex == 1;
                s.AutoSaveLearningResults = cbAutoSave.SelectedIndex == 1;
                s.LearnTrials = cbTrials.SelectedIndex + 1;
                s.Language = (Internazional.Languages)cbLang.SelectedIndex;
                s.NeuronNumber = nn.SelectedIndex + 1;
                s.TopologyType = cbTopo.SelectedIndex;
                s.ActivationFunction = cbFA.SelectedIndex;
                s.Gain = double.Parse(tbGain.Text);
            }
            catch (Exception ex)
            {
                ex.ToLog();
                status.Text = ex.Message;
            }
        }

        /// <summary>
        /// Loading settings window event
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void SettingsWindow_Load(object sender, EventArgs e)
        {
            try
            {
                for (int i = 1; i < 1000; i++) cbTrials.Items.Add(i);
                AppSetting s = new AppSetting();
                ebMU.Value = s.MU.ToString();
                ebMUH.Value = s.MUH.ToString();
                ebMUL.Value = s.MUL.ToString();
                ebScale.Value = s.Scale.ToString();
                ebME.Value = s.MaxError.ToString();
                ebMI.Value = s.MaxIterations.ToString();
                ebFolder.Value = Common.Folder.Application;
                cbConsole.SelectedIndex = s.ShowConsole ? 1 : 0;
                cbAutoSave.SelectedIndex = s.AutoSaveLearningResults ? 1 : 0;
                cbTrials.SelectedIndex = s.LearnTrials - 1;
                cbLang.SelectedIndex = (int)s.Language;
                nn.SelectedIndex = s.NeuronNumber - 1;
                cbTopo.SelectedIndex = s.TopologyType;
                tbGain.Text = s.Gain.ToString().Replace(",", ".");
                cbFA.SelectedIndex = s.ActivationFunction;
                logsStat();
                learnStat();
            }
            catch (Exception ex)
            {
                cbConsole.SelectedIndex = 0;
                cbAutoSave.SelectedIndex = 1;
                cbTrials.SelectedIndex = 0;
                ex.ToLog();
            }
        }

        private void logsStat()
        {
            int logsCount = 0;
            logsCount = (new Database.Tables.Log()).Total;
            if (logsCount > 0)
            {
                buttonRemoveLogs.Text = String.Format("{0} ({1})", LearnByError.Internazional.Resource.Inst.Get("r99"), logsCount);
                buttonRemoveLogs.Enabled = true;
            }
            else
            {
                buttonRemoveLogs.Text = LearnByError.Internazional.Resource.Inst.Get("r99");
                buttonRemoveLogs.Enabled = false;
            }
        }

        private void learnStat()
        {
            int learnsCount = 0;
            learnsCount = (new Database.Tables.History()).Total;
            if (learnsCount > 0)
            {
                buttonRemoveLearnHistory.Text = String.Format("{0} ({1})", LearnByError.Internazional.Resource.Inst.Get("r100"), learnsCount);
                buttonRemoveLearnHistory.Enabled = true;
            }
            else
            {
                buttonRemoveLearnHistory.Text = LearnByError.Internazional.Resource.Inst.Get("r100");
                buttonRemoveLearnHistory.Enabled = false;
            }
        }
        /// <summary>
        /// Close button
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void toolExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// App folder choose button
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void buttonFolder_Click(object sender, EventArgs e)
        {
            ebFolder.Value = Common.Dialog.SelectFolder(ebFolder.Value);
        }

        private void buttonRemoveLogs_Click(object sender, EventArgs e)
        {
            if ((new Database.Tables.Log()).DeleteAll())
            {
                logsStat();
                status.Text = LearnByError.Internazional.Resource.Inst.Get("r101");
            }
            else
            {
                status.Text = LearnByError.Internazional.Resource.Inst.Get("r102");
            }
        }

        private void buttonRemoveLearnHistory_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(LearnByError.Internazional.Resource.Inst.Get("r105"), LearnByError.Internazional.Resource.Inst.Get("r106"),
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                if ((new Database.Tables.History()).DeleteAll())
                {
                    learnStat();
                    status.Text = LearnByError.Internazional.Resource.Inst.Get("r103");
                }
                else
                {
                    status.Text = LearnByError.Internazional.Resource.Inst.Get("r104");
                }
            }
        }

        private void toolDefaults_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(LearnByError.Internazional.Resource.Inst.Get("r107"), LearnByError.Internazional.Resource.Inst.Get("r108"),
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                cbConsole.SelectedIndex = 0;
                cbTrials.SelectedIndex = 0;
                cbAutoSave.SelectedIndex = 1;
                ebMU.Value = "0.01";
                ebMUL.Value = "1E-15";
                ebMUH.Value = "1E15";
                ebScale.Value = "10";
                ebME.Value = "0.001";
                ebMI.Value = "10";
                cbTopo.SelectedIndex = 0;
                tbGain.Text = "1";
                toolSave_Click(sender, e);
            }
        }

        private void buttonExportLang_Click(object sender, EventArgs e)
        {
            try
            {
                status.Text = "Writing...";
                String filename = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\nbn_polish_resource.txt";
                var polish = new LearnByError.Internazional.Lang.Polish();
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                foreach (System.Collections.DictionaryEntry de in polish.Resource)
                {
                    sb.AppendLine((String)de.Key + ";" +(String)de.Value);
                }
                Common.File.WriteToTextFile(filename, sb.ToString(), false);
                status.Text = "Done";
                System.Diagnostics.Process.Start(filename);
            }
            catch { }
        }

        private void tbGain_TextChanged(object sender, EventArgs e)
        {
            double d = 1;
            if (!double.TryParse(tbGain.Text, out d)) tbGain.Text = "";
        }
    }
}
