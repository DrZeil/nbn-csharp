using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearnByError
{
    public partial class LogWindow : Form
    {
        #region INTERFACE_BLOCKER
        private void blockInterface()
        {
            interfaceBlock(false);
            progress.Enabled = true;
            progress.Style = ProgressBarStyle.Marquee;
            progress.Visible = true;
            canClose = false;
        }

        private void unblockInterface()
        {
            interfaceBlock(true);
            progress.Enabled = false;
            progress.Visible = false;
            canClose = true;
        }

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
                ex.ToLog();
            }
        }

        #endregion

        private bool canClose = true;
        private BackgroundWorker bw = new BackgroundWorker();
        public LogWindow()
        {
            InitializeComponent();
            this.zgłośBłędyToolStripMenuItem.Text = LearnByError.Internazional.Resource.Inst.Get("r72");
            this.status.Text = LearnByError.Internazional.Resource.Inst.Get("r71");
            this.Text = LearnByError.Internazional.Resource.Inst.Get("r71");
            toolRemove.Text = LearnByError.Internazional.Resource.Inst.Get("r173");
        }

        private void LogWindow_Load(object sender, EventArgs e)
        {
            bw.DoWork += (a, b) => 
            {
                try
                {                    
                    var logs = LearnByError.Database.Tables.Log.ReadAll().OrderByDescending(q => q.When).ToList();
                    var sb = new System.Text.StringBuilder();
                    
                    foreach (var log in logs)
                    {
                        sb.AppendLine(String.Format("[{0}]\r\n[Błąd] {1}\r\n[Stos] {2}\r\n", 
                            ((DateTime)log.When).ToString("yyyy-MM-dd HH:MM:ss"),
                            log.Message,
                            log.Stacktrace
                        ));
                    }

                    b.Result = sb.ToString();
                }
                catch (Exception)
                {
                    b.Result = "";
                }
            };

            bw.RunWorkerCompleted += (a, b) =>
            {
                log.Text = (String)b.Result;
                unblockInterface();
            };

            blockInterface();
            bw.RunWorkerAsync();            
        }

        private void zgłośBłędyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var bw = new BackgroundWorker();
            bw.DoWork += (a, b) =>
            {                
                StringBuilder sb = new StringBuilder();
                foreach (var log in LearnByError.Database.Tables.Log.ReadAll())
                {
                    sb.AppendLine(String.Format("[{0}]\r\n{1}\r\n{2}\r\n", log.When.ToString(), log.Message, log.Stacktrace));
                }
                LearnByErrorLibrary.Gmail.Send(LearnByError.Internazional.Resource.Inst.Get("r74"), sb.ToString(), "marekbar1985@gmail.com");
            };
            bw.RunWorkerCompleted += (a, b) =>
            {
                unblockInterface();
                status.Text = LearnByError.Internazional.Resource.Inst.Get("r73");
            };
            blockInterface();
            bw.RunWorkerAsync();
        }

        private void LogWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (canClose == false)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void toolRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(LearnByError.Internazional.Resource.Inst.Get("r175"), LearnByError.Internazional.Resource.Inst.Get("r174"),
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly) == System.Windows.Forms.DialogResult.Yes)
            {
                if ((new Database.Tables.Log()).DeleteAll())
                {
                    status.Text = LearnByError.Internazional.Resource.Inst.Get("r101");
                }
                else
                {
                    status.Text = LearnByError.Internazional.Resource.Inst.Get("r102");
                }
            }            
            this.TopMost = true;
            this.BringToFront();
            this.TopMost = false;
        }
    }
}
