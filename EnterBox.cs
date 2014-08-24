using System;
using System.Drawing;
using System.Windows.Forms;

namespace LearnByError
{
    public class EnterBox : Panel
    {
        private Label l = new Label();
        private TextBox t = new TextBox();

        public Image Image { set { this.BackgroundImage = value; } get { return this.BackgroundImage; } }
        public Image ImageLabel { set { l.BackgroundImage = value; } get { return l.BackgroundImage; } }
        public Image ImageInput { set { t.BackgroundImage = value; } get { return t.BackgroundImage; } }
        public int TextBoxHeight
        {
            set
            {
                if (value > 0)
                {
                    t.Multiline = true;
                    t.Height = value;
                }
            }
            get
            {
                return t.Height;
            }
        }
        public String Caption
        {
            get
            {
                return l.Text;
            }
            set
            {
                l.Text = (String)value;
            }
        }

        public String Value
        {
            get
            {
                return t.Text;
            }
            set
            {
                t.Text = (String)value;
            }
        }

        public bool DoubleValidation
        {
            get;
            set;
        }

        public bool IntValidation
        {
            get;
            set;
        }

        public bool DateValidation
        {
            get;
            set;
        }

        public EnterBox()
        {
            l.Dock = DockStyle.Top;
            t.Dock = DockStyle.Top;
            t.Enter += new EventHandler(t_Enter);
            t.Leave += new EventHandler(t_Leave);
            l.MouseEnter += new EventHandler(l_MouseEnter);
            l.MouseLeave += new EventHandler(l_MouseLeave);
            t.MouseEnter += new EventHandler(t_Enter);
            t.MouseLeave += new EventHandler(t_Leave);
            
            this.Controls.Add(t);
            this.Controls.Add(l);


            this.Height = l.Height + t.Height;
            t.KeyDown += (a, b) => {
                if (DoubleValidation)
                {
                    double val = 0;
                    if (double.TryParse(t.Text, out val))
                    {
                        t.BackColor = Color.MistyRose;
                    }
                    else
                    {
                        t.BackColor = Color.White;
                    }
                }
                else if (IntValidation)
                {
                    int val = 0;
                    if (int.TryParse(t.Text, out val))
                    {
                        t.BackColor = Color.MistyRose;
                    }
                    else
                    {
                        t.BackColor = Color.White;
                    }
                }
                else if (DateValidation)
                {
                    DateTime val;
                    if (DateTime.TryParse(t.Text, out val))
                    {
                        t.BackColor = Color.MistyRose;
                    }
                    else
                    {
                        t.BackColor = Color.White;
                    }
                }
            };
        }

        private void l_MouseLeave(object sender, EventArgs e)
        {
            t.BackColor = Color.White;
        }

        private void l_MouseEnter(object sender, EventArgs e)
        {
            t.BackColor = Color.Cornsilk;
        }

        private void t_Leave(object sender, EventArgs e)
        {
            l.ForeColor = Color.Black;
            t.BackColor = Color.White;
        }

        private void t_Enter(object sender, EventArgs e)
        {
            l.ForeColor = Color.Green;
            t.BackColor = Color.Cornsilk;
        }
    }
}
