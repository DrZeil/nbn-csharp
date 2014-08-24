namespace ResourceBuilder
{
    partial class Form1
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
            this.klucze = new System.Windows.Forms.RichTextBox();
            this.wartosci = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // klucze
            // 
            this.klucze.Location = new System.Drawing.Point(12, 12);
            this.klucze.Name = "klucze";
            this.klucze.Size = new System.Drawing.Size(294, 525);
            this.klucze.TabIndex = 0;
            this.klucze.Text = "";
            // 
            // wartosci
            // 
            this.wartosci.Location = new System.Drawing.Point(312, 12);
            this.wartosci.Name = "wartosci";
            this.wartosci.Size = new System.Drawing.Size(318, 525);
            this.wartosci.TabIndex = 1;
            this.wartosci.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(637, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Uruchom";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 549);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.wartosci);
            this.Controls.Add(this.klucze);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox klucze;
        private System.Windows.Forms.RichTextBox wartosci;
        private System.Windows.Forms.Button button1;
    }
}

