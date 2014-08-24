namespace LearnByError
{
    partial class SettingsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsWindow));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonExportLang = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbLang = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonRemoveLearnHistory = new System.Windows.Forms.Button();
            this.buttonRemoveLogs = new System.Windows.Forms.Button();
            this.cbTrials = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbAutoSave = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbConsole = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ebFolder = new LearnByError.EnterBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cbFA = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbGain = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbTopo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.nn = new System.Windows.Forms.ComboBox();
            this.nnLabel = new System.Windows.Forms.Label();
            this.ebScale = new LearnByError.EnterBox();
            this.ebME = new LearnByError.EnterBox();
            this.ebMI = new LearnByError.EnterBox();
            this.ebMUH = new LearnByError.EnterBox();
            this.ebMUL = new LearnByError.EnterBox();
            this.ebMU = new LearnByError.EnterBox();
            this.menu = new System.Windows.Forms.ToolStrip();
            this.toolSave = new System.Windows.Forms.ToolStripButton();
            this.toolDefaults = new System.Windows.Forms.ToolStripButton();
            this.toolExit = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.thresh = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.menu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(16, 34);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(740, 558);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonExportLang);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.cbLang);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.cbTrials);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.cbAutoSave);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.cbConsole);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.ebFolder);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(732, 529);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonExportLang
            // 
            this.buttonExportLang.Location = new System.Drawing.Point(17, 345);
            this.buttonExportLang.Name = "buttonExportLang";
            this.buttonExportLang.Size = new System.Drawing.Size(269, 53);
            this.buttonExportLang.TabIndex = 12;
            this.buttonExportLang.Text = "Export language resources";
            this.buttonExportLang.UseVisualStyleBackColor = true;
            this.buttonExportLang.Click += new System.EventHandler(this.buttonExportLang_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(336, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 16);
            this.label4.TabIndex = 11;
            // 
            // cbLang
            // 
            this.cbLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLang.FormattingEnabled = true;
            this.cbLang.Items.AddRange(new object[] {
            "English",
            "Polish"});
            this.cbLang.Location = new System.Drawing.Point(474, 120);
            this.cbLang.Name = "cbLang";
            this.cbLang.Size = new System.Drawing.Size(166, 24);
            this.cbLang.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonRemoveLearnHistory);
            this.groupBox1.Controls.Add(this.buttonRemoveLogs);
            this.groupBox1.Location = new System.Drawing.Point(10, 163);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 166);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // buttonRemoveLearnHistory
            // 
            this.buttonRemoveLearnHistory.Location = new System.Drawing.Point(7, 101);
            this.buttonRemoveLearnHistory.Name = "buttonRemoveLearnHistory";
            this.buttonRemoveLearnHistory.Size = new System.Drawing.Size(270, 49);
            this.buttonRemoveLearnHistory.TabIndex = 9;
            this.buttonRemoveLearnHistory.UseVisualStyleBackColor = true;
            this.buttonRemoveLearnHistory.Click += new System.EventHandler(this.buttonRemoveLearnHistory_Click);
            // 
            // buttonRemoveLogs
            // 
            this.buttonRemoveLogs.Location = new System.Drawing.Point(6, 35);
            this.buttonRemoveLogs.Name = "buttonRemoveLogs";
            this.buttonRemoveLogs.Size = new System.Drawing.Size(270, 49);
            this.buttonRemoveLogs.TabIndex = 8;
            this.buttonRemoveLogs.UseVisualStyleBackColor = true;
            this.buttonRemoveLogs.Click += new System.EventHandler(this.buttonRemoveLogs_Click);
            // 
            // cbTrials
            // 
            this.cbTrials.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTrials.FormattingEnabled = true;
            this.cbTrials.Location = new System.Drawing.Point(151, 123);
            this.cbTrials.Name = "cbTrials";
            this.cbTrials.Size = new System.Drawing.Size(179, 24);
            this.cbTrials.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 16);
            this.label3.TabIndex = 6;
            // 
            // cbAutoSave
            // 
            this.cbAutoSave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAutoSave.FormattingEnabled = true;
            this.cbAutoSave.Location = new System.Drawing.Point(474, 71);
            this.cbAutoSave.Name = "cbAutoSave";
            this.cbAutoSave.Size = new System.Drawing.Size(166, 24);
            this.cbAutoSave.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(336, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 16);
            this.label2.TabIndex = 4;
            // 
            // cbConsole
            // 
            this.cbConsole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbConsole.FormattingEnabled = true;
            this.cbConsole.Location = new System.Drawing.Point(151, 71);
            this.cbConsole.Name = "cbConsole";
            this.cbConsole.Size = new System.Drawing.Size(179, 24);
            this.cbConsole.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 2;
            // 
            // ebFolder
            // 
            this.ebFolder.Caption = "";
            this.ebFolder.DateValidation = false;
            this.ebFolder.DoubleValidation = false;
            this.ebFolder.Enabled = false;
            this.ebFolder.Image = null;
            this.ebFolder.ImageInput = null;
            this.ebFolder.ImageLabel = null;
            this.ebFolder.IntValidation = false;
            this.ebFolder.Location = new System.Drawing.Point(7, 7);
            this.ebFolder.Name = "ebFolder";
            this.ebFolder.Size = new System.Drawing.Size(718, 43);
            this.ebFolder.TabIndex = 0;
            this.ebFolder.TextBoxHeight = 22;
            this.ebFolder.Value = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.thresh);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.cbFA);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.tbGain);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.cbTopo);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.nn);
            this.tabPage2.Controls.Add(this.nnLabel);
            this.tabPage2.Controls.Add(this.ebScale);
            this.tabPage2.Controls.Add(this.ebME);
            this.tabPage2.Controls.Add(this.ebMI);
            this.tabPage2.Controls.Add(this.ebMUH);
            this.tabPage2.Controls.Add(this.ebMUL);
            this.tabPage2.Controls.Add(this.ebMU);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(732, 529);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cbFA
            // 
            this.cbFA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFA.FormattingEnabled = true;
            this.cbFA.Items.AddRange(new object[] {
            "Liniowa",
            "Miękka jednostronna",
            "Miękka obustronna",
            "Miękka II jednostronna",
            "Miękka || obustronna"});
            this.cbFA.Location = new System.Drawing.Point(466, 148);
            this.cbFA.Name = "cbFA";
            this.cbFA.Size = new System.Drawing.Size(244, 24);
            this.cbFA.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(463, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "Funkcja aktywacji:";
            // 
            // tbGain
            // 
            this.tbGain.Location = new System.Drawing.Point(466, 88);
            this.tbGain.Name = "tbGain";
            this.tbGain.Size = new System.Drawing.Size(244, 22);
            this.tbGain.TabIndex = 14;
            this.tbGain.TextChanged += new System.EventHandler(this.tbGain_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(463, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Wzmocnienie sygnału:";
            // 
            // cbTopo
            // 
            this.cbTopo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTopo.FormattingEnabled = true;
            this.cbTopo.Items.AddRange(new object[] {
            "BMLP - mostkowany wielowarstwowy perceptron",
            "MLP - wielowarstwowy perceptron"});
            this.cbTopo.Location = new System.Drawing.Point(466, 26);
            this.cbTopo.Name = "cbTopo";
            this.cbTopo.Size = new System.Drawing.Size(244, 24);
            this.cbTopo.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(463, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Topologia sieci:";
            // 
            // nn
            // 
            this.nn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nn.FormattingEnabled = true;
            this.nn.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50"});
            this.nn.Location = new System.Drawing.Point(124, 382);
            this.nn.Name = "nn";
            this.nn.Size = new System.Drawing.Size(316, 24);
            this.nn.TabIndex = 10;
            // 
            // nnLabel
            // 
            this.nnLabel.AutoSize = true;
            this.nnLabel.Location = new System.Drawing.Point(7, 385);
            this.nnLabel.Name = "nnLabel";
            this.nnLabel.Size = new System.Drawing.Size(0, 16);
            this.nnLabel.TabIndex = 9;
            // 
            // ebScale
            // 
            this.ebScale.Caption = "";
            this.ebScale.DateValidation = false;
            this.ebScale.DoubleValidation = false;
            this.ebScale.Image = null;
            this.ebScale.ImageInput = null;
            this.ebScale.ImageLabel = null;
            this.ebScale.IntValidation = true;
            this.ebScale.Location = new System.Drawing.Point(8, 251);
            this.ebScale.Margin = new System.Windows.Forms.Padding(4);
            this.ebScale.Name = "ebScale";
            this.ebScale.Size = new System.Drawing.Size(432, 53);
            this.ebScale.TabIndex = 8;
            this.ebScale.TextBoxHeight = 22;
            this.ebScale.Value = "";
            // 
            // ebME
            // 
            this.ebME.Caption = "";
            this.ebME.DateValidation = false;
            this.ebME.DoubleValidation = false;
            this.ebME.Image = null;
            this.ebME.ImageInput = null;
            this.ebME.ImageLabel = null;
            this.ebME.IntValidation = true;
            this.ebME.Location = new System.Drawing.Point(8, 190);
            this.ebME.Margin = new System.Windows.Forms.Padding(4);
            this.ebME.Name = "ebME";
            this.ebME.Size = new System.Drawing.Size(432, 53);
            this.ebME.TabIndex = 7;
            this.ebME.TextBoxHeight = 22;
            this.ebME.Value = "";
            // 
            // ebMI
            // 
            this.ebMI.Caption = "";
            this.ebMI.DateValidation = false;
            this.ebMI.DoubleValidation = false;
            this.ebMI.Image = null;
            this.ebMI.ImageInput = null;
            this.ebMI.ImageLabel = null;
            this.ebMI.IntValidation = true;
            this.ebMI.Location = new System.Drawing.Point(8, 312);
            this.ebMI.Margin = new System.Windows.Forms.Padding(4);
            this.ebMI.Name = "ebMI";
            this.ebMI.Size = new System.Drawing.Size(432, 53);
            this.ebMI.TabIndex = 6;
            this.ebMI.TextBoxHeight = 22;
            this.ebMI.Value = "";
            // 
            // ebMUH
            // 
            this.ebMUH.Caption = "";
            this.ebMUH.DateValidation = false;
            this.ebMUH.DoubleValidation = true;
            this.ebMUH.Image = null;
            this.ebMUH.ImageInput = null;
            this.ebMUH.ImageLabel = null;
            this.ebMUH.IntValidation = false;
            this.ebMUH.Location = new System.Drawing.Point(8, 129);
            this.ebMUH.Margin = new System.Windows.Forms.Padding(4);
            this.ebMUH.Name = "ebMUH";
            this.ebMUH.Size = new System.Drawing.Size(432, 53);
            this.ebMUH.TabIndex = 5;
            this.ebMUH.TextBoxHeight = 22;
            this.ebMUH.Value = "";
            // 
            // ebMUL
            // 
            this.ebMUL.Caption = "";
            this.ebMUL.DateValidation = false;
            this.ebMUL.DoubleValidation = true;
            this.ebMUL.Image = null;
            this.ebMUL.ImageInput = null;
            this.ebMUL.ImageLabel = null;
            this.ebMUL.IntValidation = false;
            this.ebMUL.Location = new System.Drawing.Point(8, 68);
            this.ebMUL.Margin = new System.Windows.Forms.Padding(4);
            this.ebMUL.Name = "ebMUL";
            this.ebMUL.Size = new System.Drawing.Size(432, 53);
            this.ebMUL.TabIndex = 4;
            this.ebMUL.TextBoxHeight = 22;
            this.ebMUL.Value = "";
            // 
            // ebMU
            // 
            this.ebMU.Caption = "";
            this.ebMU.DateValidation = false;
            this.ebMU.DoubleValidation = true;
            this.ebMU.Image = null;
            this.ebMU.ImageInput = null;
            this.ebMU.ImageLabel = null;
            this.ebMU.IntValidation = false;
            this.ebMU.Location = new System.Drawing.Point(8, 7);
            this.ebMU.Margin = new System.Windows.Forms.Padding(4);
            this.ebMU.Name = "ebMU";
            this.ebMU.Size = new System.Drawing.Size(432, 53);
            this.ebMU.TabIndex = 3;
            this.ebMU.TextBoxHeight = 22;
            this.ebMU.Value = "";
            // 
            // menu
            // 
            this.menu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSave,
            this.toolDefaults,
            this.toolExit});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(769, 25);
            this.menu.TabIndex = 1;
            // 
            // toolSave
            // 
            this.toolSave.Image = global::LearnByError.Properties.Resources.save;
            this.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSave.Name = "toolSave";
            this.toolSave.Size = new System.Drawing.Size(23, 22);
            this.toolSave.Click += new System.EventHandler(this.toolSave_Click);
            // 
            // toolDefaults
            // 
            this.toolDefaults.Image = global::LearnByError.Properties.Resources.settings;
            this.toolDefaults.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDefaults.Name = "toolDefaults";
            this.toolDefaults.Size = new System.Drawing.Size(23, 22);
            this.toolDefaults.Click += new System.EventHandler(this.toolDefaults_Click);
            // 
            // toolExit
            // 
            this.toolExit.Image = global::LearnByError.Properties.Resources.logout;
            this.toolExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolExit.Name = "toolExit";
            this.toolExit.Size = new System.Drawing.Size(23, 22);
            this.toolExit.Click += new System.EventHandler(this.toolExit_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 562);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(769, 22);
            this.statusStrip1.TabIndex = 2;
            // 
            // status
            // 
            this.status.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(0, 17);
            // 
            // thresh
            // 
            this.thresh.Location = new System.Drawing.Point(466, 210);
            this.thresh.Name = "thresh";
            this.thresh.Size = new System.Drawing.Size(244, 22);
            this.thresh.TabIndex = 18;
            this.thresh.TextChanged += new System.EventHandler(this.thresh_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(463, 190);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 16);
            this.label8.TabIndex = 17;
            this.label8.Text = "Threshold:";
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(769, 584);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SettingsWindow";
            this.Load += new System.EventHandler(this.SettingsWindow_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStrip menu;
        private System.Windows.Forms.ToolStripButton toolSave;
        private System.Windows.Forms.ToolStripButton toolExit;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel status;
        private EnterBox ebMUH;
        private EnterBox ebMUL;
        private EnterBox ebMU;
        private EnterBox ebMI;
        private EnterBox ebME;
        private EnterBox ebScale;
        private EnterBox ebFolder;
        private System.Windows.Forms.ComboBox cbConsole;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbAutoSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbTrials;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonRemoveLearnHistory;
        private System.Windows.Forms.Button buttonRemoveLogs;
        private System.Windows.Forms.ToolStripButton toolDefaults;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbLang;
        private System.Windows.Forms.Button buttonExportLang;
        private System.Windows.Forms.ComboBox nn;
        private System.Windows.Forms.Label nnLabel;
        private System.Windows.Forms.ComboBox cbTopo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbGain;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbFA;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox thresh;
        private System.Windows.Forms.Label label8;
    }
}