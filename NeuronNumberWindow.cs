/*
Author:  Marek Bar 33808
Contact: marekbar1985@gmail.com
Wyższa Szkoła Informatyki i Zarządzania w Rzeszowie
 */
using System;
using System.Windows.Forms;

namespace LearnByError
{
    public partial class NeuronNumberWindow : Form
    {
        public NeuronNumberWindow()
        {
            InitializeComponent();
        }

        public bool IsSelected = false;
        public int NumberOfNeurons = 2;


        private void button7_Click(object sender, EventArgs e)
        {
            IsSelected = false;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NumberOfNeurons = 2;
            IsSelected = true;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NumberOfNeurons = 3;
            IsSelected = true;
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NumberOfNeurons = 4;
            IsSelected = true;
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            NumberOfNeurons = 5;
            IsSelected = true;
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            NumberOfNeurons = 6;
            IsSelected = true;
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NumberOfNeurons = 7;
            IsSelected = true;
            Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            NumberOfNeurons = 8;
            IsSelected = true;
            Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            NumberOfNeurons = 9;
            IsSelected = true;
            Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            NumberOfNeurons = 10;
            IsSelected = true;
            Close();
        }

        private void NeuronNumberWindow_Load(object sender, EventArgs e)
        {
            this.button1.Text = LearnByError.Internazional.Resource.Inst.Get("r238");
            this.label1.Text = LearnByError.Internazional.Resource.Inst.Get("r239");
            this.button2.Text = LearnByError.Internazional.Resource.Inst.Get("r240");
            this.button3.Text = LearnByError.Internazional.Resource.Inst.Get("r241");
            this.button4.Text = LearnByError.Internazional.Resource.Inst.Get("r242");
            this.button5.Text = LearnByError.Internazional.Resource.Inst.Get("r243");
            this.button6.Text = LearnByError.Internazional.Resource.Inst.Get("r244");
            this.button10.Text = LearnByError.Internazional.Resource.Inst.Get("r245");
            this.button11.Text = LearnByError.Internazional.Resource.Inst.Get("r246");
            this.button12.Text = LearnByError.Internazional.Resource.Inst.Get("r247");
            this.button7.Text = LearnByError.Internazional.Resource.Inst.Get("r248");
            this.Text = LearnByError.Internazional.Resource.Inst.Get("r249");

        }
    }
}
