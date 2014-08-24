namespace LearnByError
{
    partial class ResearchWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.repeats = new System.Windows.Forms.NumericUpDown();
            this.neurons = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pdf = new System.Windows.Forms.CheckBox();
            this.list = new System.Windows.Forms.CheckedListBox();
            this.buttonFolder = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.buttonSamples = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.repeats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neurons)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(16, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 17);
            this.label1.TabIndex = 0;
            
            // 
            // repeats
            // 
            this.repeats.BackColor = System.Drawing.Color.WhiteSmoke;
            this.repeats.Location = new System.Drawing.Point(263, 9);
            this.repeats.Margin = new System.Windows.Forms.Padding(4);
            this.repeats.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.repeats.Name = "repeats";
            this.repeats.Size = new System.Drawing.Size(92, 23);
            this.repeats.TabIndex = 1;
            this.repeats.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.repeats.ValueChanged += new System.EventHandler(this.repeats_ValueChanged);
            // 
            // neurons
            // 
            this.neurons.BackColor = System.Drawing.Color.WhiteSmoke;
            this.neurons.Location = new System.Drawing.Point(263, 70);
            this.neurons.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.neurons.Name = "neurons";
            this.neurons.Size = new System.Drawing.Size(92, 23);
            this.neurons.TabIndex = 2;
            this.neurons.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.neurons.ValueChanged += new System.EventHandler(this.neurons_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(16, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(196, 17);
            this.label3.TabIndex = 4;
            
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(16, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(223, 17);
            this.label4.TabIndex = 5;
            
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(16, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(258, 17);
            this.label2.TabIndex = 6;
            
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::LearnByError.Properties.Resources.logout;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(530, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 51);
            this.button1.TabIndex = 8;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(414, 9);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 51);
            this.button2.TabIndex = 9;
            
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pdf
            // 
            this.pdf.AutoSize = true;
            this.pdf.BackColor = System.Drawing.Color.Transparent;
            this.pdf.Location = new System.Drawing.Point(19, 98);
            this.pdf.Name = "pdf";
            this.pdf.Size = new System.Drawing.Size(246, 21);
            this.pdf.TabIndex = 10;
            
            this.pdf.UseVisualStyleBackColor = false;
            this.pdf.CheckedChanged += new System.EventHandler(this.pdf_CheckedChanged);
            // 
            // list
            // 
            this.list.BackColor = System.Drawing.Color.WhiteSmoke;
            this.list.FormattingEnabled = true;
            this.list.Location = new System.Drawing.Point(12, 151);
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(569, 436);
            this.list.TabIndex = 11;
            this.list.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.list_ItemCheck);
            // 
            // buttonFolder
            // 
            this.buttonFolder.Location = new System.Drawing.Point(414, 102);
            this.buttonFolder.Name = "buttonFolder";
            this.buttonFolder.Size = new System.Drawing.Size(167, 40);
            this.buttonFolder.TabIndex = 12;
            
            this.buttonFolder.UseVisualStyleBackColor = true;
            this.buttonFolder.Click += new System.EventHandler(this.buttonFolder_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 598);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(589, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // status
            // 
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(0, 17);
            // 
            // buttonSamples
            // 
            this.buttonSamples.Location = new System.Drawing.Point(414, 62);
            this.buttonSamples.Name = "buttonSamples";
            this.buttonSamples.Size = new System.Drawing.Size(167, 37);
            this.buttonSamples.TabIndex = 14;
           
            this.buttonSamples.UseVisualStyleBackColor = true;
            this.buttonSamples.Click += new System.EventHandler(this.buttonSamples_Click);
            // 
            // ResearchWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LearnByError.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(589, 620);
            this.ControlBox = false;
            this.Controls.Add(this.buttonSamples);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.buttonFolder);
            this.Controls.Add(this.list);
            this.Controls.Add(this.pdf);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.neurons);
            this.Controls.Add(this.repeats);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ResearchWindow";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
           
            this.Load += new System.EventHandler(this.ResearchWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.repeats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neurons)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown repeats;
        private System.Windows.Forms.NumericUpDown neurons;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox pdf;
        private System.Windows.Forms.CheckedListBox list;
        private System.Windows.Forms.Button buttonFolder;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel status;
        private System.Windows.Forms.Button buttonSamples;
    }
}