/*
Author:  Marek Bar 33808
Contact: marekbar1985@gmail.com
Wyższa Szkoła Informatyki i Zarządzania w Rzeszowie
 */
using System;
using System.Windows.Forms;

namespace LearnByError
{
    /// <summary>
    /// Application help viewer
    /// </summary>
    public partial class InstructionWindow : Form
    {
        /// <summary>
        /// Window initializer
        /// </summary>
        public InstructionWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Window loader events
        /// </summary>
        /// <param name="sender">object - sender</param>
        /// <param name="e">EventArgs - arguments</param>
        private void InstructionWindow_Load(object sender, EventArgs e)
        {
            try
            {
                web.Url = new Uri("https://sites.google.com/site/neuralnetworknbn/home/instrukcja-obslugi");
                this.Text = LearnByError.Internazional.Resource.Inst.Get("r237");
            }
            catch (Exception)
            {
                
            }

        }

        /// <summary>
        /// Web page loaded
        /// </summary>
        /// <param name="sender">object - sender</param>
        /// <param name="e">EventArgs - arguments</param>
        private void web_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            status.Text = LearnByError.Internazional.Resource.Inst.Get("r234");
        }

        /// <summary>
        /// Web page loading
        /// </summary>
        /// <param name="sender">object - sender</param>
        /// <param name="e">EventArgs - arguments</param>
        private void web_FileDownload(object sender, EventArgs e)
        {
            status.Text = LearnByError.Internazional.Resource.Inst.Get("r235");
        }

        /// <summary>
        /// Address change event
        /// </summary>
        /// <param name="sender">object - sender</param>
        /// <param name="e">EventArgs - arguments</param>
        private void web_LocationChanged(object sender, EventArgs e)
        {
            status.Text = LearnByError.Internazional.Resource.Inst.Get("r236");
        }
    }
}
