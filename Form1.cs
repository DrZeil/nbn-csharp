using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ResourceBuilder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<String> k = new List<string>();
            List<String> v = new List<string>();
            foreach (var line in klucze.Text.Split('\r', '\n'))
            {
                k.Add(line);
            }
            foreach (var line in wartosci.Text.Split('\r', '\n'))
            {
                v.Add(line);
            }

            System.Text.StringBuilder sb = new StringBuilder();
            for (int i = 0; i < k.Count; i++)
            {
                String tmp = "Resource[\"" + k[i] + "\"] = \"" + v[i] + "\";//" + k[i] + " --> " + v[i];
                sb.AppendLine(tmp);
            }
            klucze.Text = "";
            wartosci.Text = "";
            klucze.Text = sb.ToString();
            klucze.Width *= 2;
            wartosci.Visible = false;
            button1.Visible = false;
            klucze.Dock = DockStyle.Fill;
        }
    }
}
