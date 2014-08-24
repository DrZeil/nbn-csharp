using System;
using System.Windows.Forms;

namespace LearnByError
{
    /// <summary>
    /// Message sender
    /// </summary>
    public partial class MailBox : Form
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public MailBox()
        {
            InitializeComponent();
            this.subject.Caption = LearnByError.Internazional.Resource.Inst.Get("r75");
            this.message.Caption = LearnByError.Internazional.Resource.Inst.Get("r76");
            this.Text = LearnByError.Internazional.Resource.Inst.Get("r77");
        }

        /// <summary>
        /// Send button
        /// </summary>
        /// <param name="sender">who</param>
        /// <param name="e">arguments</param>
        private void bs_Click(object sender, EventArgs e)
        {
            LearnByErrorLibrary.Gmail.Send(subject.Value, message.Value, "marekbar1985@gmail.com");
            MessageBox.Show(LearnByError.Internazional.Resource.Inst.Get("r78"));
        }

        /// <summary>
        /// Close window button
        /// </summary>
        /// <param name="sender">who</param>
        /// <param name="e">arguments</param>
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
