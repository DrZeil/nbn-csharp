namespace LearnByError
{
    partial class MailBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MailBox));
            this.bs = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.subject = new LearnByError.EnterBox();
            this.message = new LearnByError.EnterBox();
            this.SuspendLayout();
            // 
            // bs
            // 
            this.bs.BackgroundImage = global::LearnByError.Properties.Resources.send;
            this.bs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bs.Location = new System.Drawing.Point(461, 390);
            this.bs.Name = "bs";
            this.bs.Size = new System.Drawing.Size(66, 75);
            this.bs.TabIndex = 2;
            this.bs.UseVisualStyleBackColor = true;
            this.bs.Click += new System.EventHandler(this.bs_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::LearnByError.Properties.Resources.logout;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(533, 390);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(77, 75);
            this.button2.TabIndex = 3;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // subject
            // 

            this.subject.DateValidation = false;
            this.subject.DoubleValidation = false;
            this.subject.ForeColor = System.Drawing.Color.Black;
            this.subject.Image = null;
            this.subject.ImageInput = null;
            this.subject.ImageLabel = global::LearnByError.Properties.Resources.background;
            this.subject.IntValidation = false;
            this.subject.Location = new System.Drawing.Point(12, 12);
            this.subject.Name = "subject";
            this.subject.Size = new System.Drawing.Size(598, 43);
            this.subject.TabIndex = 4;
            this.subject.TextBoxHeight = 20;
            this.subject.Value = "";
            // 
            // message
            // 
            this.message.BackgroundImage = global::LearnByError.Properties.Resources.background2;

            this.message.DateValidation = false;
            this.message.DoubleValidation = false;
            this.message.ForeColor = System.Drawing.Color.Black;
            this.message.Image = global::LearnByError.Properties.Resources.background2;
            this.message.ImageInput = null;
            this.message.ImageLabel = global::LearnByError.Properties.Resources.background;
            this.message.IntValidation = false;
            this.message.Location = new System.Drawing.Point(12, 61);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(598, 323);
            this.message.TabIndex = 5;
            this.message.TextBoxHeight = 300;
            this.message.Value = "";
            // 
            // MailBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LearnByError.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(621, 484);
            this.Controls.Add(this.message);
            this.Controls.Add(this.subject);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.bs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MailBox";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bs;
        private System.Windows.Forms.Button button2;
        private EnterBox subject;
        private EnterBox message;
    }
}