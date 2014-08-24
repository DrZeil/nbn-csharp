/*
Author:  Marek Bar 33808
Contact: marekbar1985@gmail.com
Wyższa Szkoła Informatyki i Zarządzania w Rzeszowie
 */
using LearnByErrorLibrary;
namespace LearnByError
{
    /// <summary>
    /// Display debug information if debugging enabled
    /// </summary>
    public partial class DebugConsole : System.Windows.Forms.Form
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public DebugConsole()
        {
            InitializeComponent();
            this.saveToFileToolStripMenuItem.Text = LearnByError.Internazional.Resource.Inst.Get("r30");
            this.postSend.Text = LearnByError.Internazional.Resource.Inst.Get("r31");
            this.Text = LearnByError.Internazional.Resource.Inst.Get("r32");
        }

        /// <summary>
        /// Add text to console or get whole text from console
        /// </summary>
        public System.String Console
        {
            get
            {
                return output.Text;
            }

            set
            {
                output.Text += value;
                this.Refresh();
            }
        }

        /// <summary>
        /// Initialize console
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void DebugConsole_Load(object sender, System.EventArgs e)
        {
            output.Text = "";
        }

        /// <summary>
        /// Saves console text to specified file
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void saveToFileToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var filename = Common.Dialog.Save(LearnByError.Internazional.Resource.Inst.Get("r33"), "txt");
            using (var sw = new System.IO.StreamWriter(filename))
            {
                sw.Write(output.Text.Replace("\n","\r\n"));               
            }
        }

        private void postSend_Click(object sender, System.EventArgs e)
        {
            string address = "";
            if (LearnByError.Common.Dialog.InputBox(LearnByError.Internazional.Resource.Inst.Get("r34"), 
                LearnByError.Internazional.Resource.Inst.Get("r37"),
                ref address, LearnByError.Internazional.Resource.Inst.Get("r36")) == System.Windows.Forms.DialogResult.OK)
            {
                Gmail.Send(LearnByError.Internazional.Resource.Inst.Get("r35"), Console, address);                
            }
        }
    }
}
