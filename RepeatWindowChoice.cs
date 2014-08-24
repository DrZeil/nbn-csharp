using System;
using System.Windows.Forms;

namespace LearnByError
{
    public partial class RepeatWindowChoice : Form
    {
        public RepeatWindowChoice()
        {
            InitializeComponent();
        }

        public int NumberOfRepeats = 0;
        public bool Repeat = false;

        public void SetRepeat(object sender, EventArgs args)
        {
            var button = (Button)sender;
            NumberOfRepeats = int.Parse(button.Text);
            Repeat = true;
            Close();
        }

        public void Cancel(object sender, EventArgs args)
        {
            var button = (Button)sender;
            Repeat = false;
            Close();
        }

        private void RepeatWindowChoice_Load(object sender, EventArgs e)
        {
            this.label1.Text = LearnByError.Internazional.Resource.Inst.Get("r250");
            this.Text = LearnByError.Internazional.Resource.Inst.Get("r251");
            this.button21.Text = LearnByError.Internazional.Resource.Inst.Get("r248");
        }
    }
}
