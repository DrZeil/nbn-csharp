using LearnByError.Internazional;

namespace LearnByError
{
    partial class LearnByErrorMainWindow
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LearnByErrorMainWindow));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.programToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolFolderMain = new System.Windows.Forms.ToolStripMenuItem();
            this.toolFolderLogs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolFolderSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolFolderData = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuData = new System.Windows.Forms.ToolStripMenuItem();
            this.pomocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpLogs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuContact = new System.Windows.Forms.ToolStripMenuItem();
            this.toolInstruction = new System.Windows.Forms.ToolStripMenuItem();
            this.reasearch = new System.Windows.Forms.ToolStripMenuItem();
            this.runReasearch = new System.Windows.Forms.ToolStripMenuItem();
            this.testForData = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.progress = new System.Windows.Forms.ToolStripProgressBar();
            this.stopReasearch = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsOpen = new System.Windows.Forms.ToolStripButton();
            this.tsStart = new System.Windows.Forms.ToolStripButton();
            this.toolSaveChart = new System.Windows.Forms.ToolStripButton();
            this.toolSettings = new System.Windows.Forms.ToolStripButton();
            this.tsHistory = new System.Windows.Forms.ToolStripButton();
            this.toolExit = new System.Windows.Forms.ToolStripButton();
            this.tsbReasearchLearn = new System.Windows.Forms.ToolStripButton();
            this.tEnglish = new System.Windows.Forms.ToolStripButton();
            this.tPolish = new System.Windows.Forms.ToolStripButton();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cmChart = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmChartSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolMainSSE = new System.Windows.Forms.ToolStripMenuItem();
            this.toolSSE = new System.Windows.Forms.ToolStripComboBox();
            this.toolMainRMSE = new System.Windows.Forms.ToolStripMenuItem();
            this.toolRMSE = new System.Windows.Forms.ToolStripComboBox();
            this.nnNumber = new System.Windows.Forms.ToolStripMenuItem();
            this.toolNN = new System.Windows.Forms.ToolStripComboBox();
            this.times = new System.Windows.Forms.Label();
            this.menu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.cmChart.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.BackgroundImage = global::LearnByError.Properties.Resources.background;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programToolStripMenuItem,
            this.menuData,
            this.pomocToolStripMenuItem,
            this.reasearch});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menu.Size = new System.Drawing.Size(779, 24);
            this.menu.TabIndex = 1;
            // 
            // programToolStripMenuItem
            // 
            this.programToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuInfo,
            this.toolFolder,
            this.menuSettings,
            this.toolHistory,
            this.menuExit});
            this.programToolStripMenuItem.Image = global::LearnByError.Properties.Resources.shamrock;
            this.programToolStripMenuItem.Name = "programToolStripMenuItem";
            this.programToolStripMenuItem.Size = new System.Drawing.Size(28, 20);
            // 
            // menuInfo
            // 
            this.menuInfo.Image = global::LearnByError.Properties.Resources.info;
            this.menuInfo.Name = "menuInfo";
            this.menuInfo.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.menuInfo.Size = new System.Drawing.Size(110, 22);
            this.menuInfo.Click += new System.EventHandler(this.menuInfo_Click);
            // 
            // toolFolder
            // 
            this.toolFolder.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolFolderMain,
            this.toolFolderLogs,
            this.toolFolderSettings,
            this.toolFolderData});
            this.toolFolder.Image = global::LearnByError.Properties.Resources.documents_folder_512;
            this.toolFolder.Name = "toolFolder";
            this.toolFolder.Size = new System.Drawing.Size(110, 22);
            // 
            // toolFolderMain
            // 
            this.toolFolderMain.Image = global::LearnByError.Properties.Resources.binders_folder_512;
            this.toolFolderMain.Name = "toolFolderMain";
            this.toolFolderMain.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.A)));
            this.toolFolderMain.Size = new System.Drawing.Size(132, 22);
            this.toolFolderMain.Click += new System.EventHandler(this.toolFolderMain_Click);
            // 
            // toolFolderLogs
            // 
            this.toolFolderLogs.Image = global::LearnByError.Properties.Resources.burn_folder_512;
            this.toolFolderLogs.Name = "toolFolderLogs";
            this.toolFolderLogs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.B)));
            this.toolFolderLogs.Size = new System.Drawing.Size(132, 22);
            this.toolFolderLogs.Click += new System.EventHandler(this.toolFolderLogs_Click);
            // 
            // toolFolderSettings
            // 
            this.toolFolderSettings.Image = global::LearnByError.Properties.Resources.dossier_folder_512;
            this.toolFolderSettings.Name = "toolFolderSettings";
            this.toolFolderSettings.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.C)));
            this.toolFolderSettings.Size = new System.Drawing.Size(132, 22);
            this.toolFolderSettings.Click += new System.EventHandler(this.toolFolderSettings_Click);
            // 
            // toolFolderData
            // 
            this.toolFolderData.Image = global::LearnByError.Properties.Resources.user_folder_512;
            this.toolFolderData.Name = "toolFolderData";
            this.toolFolderData.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.D)));
            this.toolFolderData.Size = new System.Drawing.Size(132, 22);
            this.toolFolderData.Click += new System.EventHandler(this.toolFolderData_Click);
            // 
            // menuSettings
            // 
            this.menuSettings.Image = global::LearnByError.Properties.Resources.settings;
            this.menuSettings.Name = "menuSettings";
            this.menuSettings.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.menuSettings.Size = new System.Drawing.Size(110, 22);
            this.menuSettings.Click += new System.EventHandler(this.menuSettings_Click);
            // 
            // toolHistory
            // 
            this.toolHistory.Image = global::LearnByError.Properties.Resources.history;
            this.toolHistory.Name = "toolHistory";
            this.toolHistory.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.toolHistory.Size = new System.Drawing.Size(110, 22);
            this.toolHistory.Click += new System.EventHandler(this.toolHistory_Click);
            // 
            // menuExit
            // 
            this.menuExit.Image = global::LearnByError.Properties.Resources.logout;
            this.menuExit.Name = "menuExit";
            this.menuExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.menuExit.Size = new System.Drawing.Size(110, 22);
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // menuData
            // 
            this.menuData.Image = global::LearnByError.Properties.Resources.down;
            this.menuData.Name = "menuData";
            this.menuData.Size = new System.Drawing.Size(28, 20);
            // 
            // pomocToolStripMenuItem
            // 
            this.pomocToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpLogs,
            this.menuContact,
            this.toolInstruction});
            this.pomocToolStripMenuItem.Image = global::LearnByError.Properties.Resources.info;
            this.pomocToolStripMenuItem.Name = "pomocToolStripMenuItem";
            this.pomocToolStripMenuItem.Size = new System.Drawing.Size(28, 20);
            // 
            // helpLogs
            // 
            this.helpLogs.Image = global::LearnByError.Properties.Resources.burn_folder_512;
            this.helpLogs.Name = "helpLogs";
            this.helpLogs.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.helpLogs.Size = new System.Drawing.Size(127, 22);
            this.helpLogs.Click += new System.EventHandler(this.helpLogs_Click);
            // 
            // menuContact
            // 
            this.menuContact.Image = global::LearnByError.Properties.Resources.send;
            this.menuContact.Name = "menuContact";
            this.menuContact.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.menuContact.Size = new System.Drawing.Size(127, 22);
            this.menuContact.Click += new System.EventHandler(this.menuContact_Click);
            // 
            // toolInstruction
            // 
            this.toolInstruction.Image = global::LearnByError.Properties.Resources.that;
            this.toolInstruction.Name = "toolInstruction";
            this.toolInstruction.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.I)));
            this.toolInstruction.Size = new System.Drawing.Size(127, 22);
            this.toolInstruction.Click += new System.EventHandler(this.toolInstruction_Click);
            // 
            // reasearch
            // 
            this.reasearch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runReasearch,
            this.testForData});
            this.reasearch.Image = global::LearnByError.Properties.Resources.reasearch;
            this.reasearch.Name = "reasearch";
            this.reasearch.Size = new System.Drawing.Size(28, 20);
            // 
            // runReasearch
            // 
            this.runReasearch.Image = global::LearnByError.Properties.Resources.start;
            this.runReasearch.Name = "runReasearch";
            this.runReasearch.Size = new System.Drawing.Size(67, 22);
            this.runReasearch.Click += new System.EventHandler(this.runReasearch_Click);
            // 
            // testForData
            // 
            this.testForData.Name = "testForData";
            this.testForData.Size = new System.Drawing.Size(67, 22);
            this.testForData.Click += new System.EventHandler(this.testForData_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackgroundImage = global::LearnByError.Properties.Resources.background;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status,
            this.progress,
            this.stopReasearch});
            this.statusStrip1.Location = new System.Drawing.Point(0, 661);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(779, 24);
            this.statusStrip1.TabIndex = 2;
            // 
            // status
            // 
            this.status.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(0, 19);
            // 
            // progress
            // 
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(117, 18);
            // 
            // stopReasearch
            // 
            this.stopReasearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.stopReasearch.ForeColor = System.Drawing.Color.Red;
            this.stopReasearch.Name = "stopReasearch";
            this.stopReasearch.Size = new System.Drawing.Size(0, 19);
            this.stopReasearch.Visible = false;
            this.stopReasearch.Click += new System.EventHandler(this.stopReasearch_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackgroundImage = global::LearnByError.Properties.Resources.lghtmesh;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsOpen,
            this.tsStart,
            this.toolSaveChart,
            this.toolSettings,
            this.tsHistory,
            this.toolExit,
            this.tsbReasearchLearn,
            this.tEnglish,
            this.tPolish});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(6);
            this.toolStrip1.Size = new System.Drawing.Size(779, 67);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 6;
            // 
            // tsOpen
            // 
            this.tsOpen.ForeColor = System.Drawing.Color.Black;
            this.tsOpen.Image = global::LearnByError.Properties.Resources.open_file;
            this.tsOpen.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsOpen.Name = "tsOpen";
            this.tsOpen.Size = new System.Drawing.Size(52, 52);
            this.tsOpen.Click += new System.EventHandler(this.tsOpen_Click);
            // 
            // tsStart
            // 
            this.tsStart.ForeColor = System.Drawing.Color.Black;
            this.tsStart.Image = global::LearnByError.Properties.Resources.start1;
            this.tsStart.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsStart.Name = "tsStart";
            this.tsStart.Size = new System.Drawing.Size(52, 52);
            this.tsStart.Click += new System.EventHandler(this.tsStart_Click);
            // 
            // toolSaveChart
            // 
            this.toolSaveChart.Image = global::LearnByError.Properties.Resources.save1;
            this.toolSaveChart.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolSaveChart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSaveChart.Name = "toolSaveChart";
            this.toolSaveChart.Size = new System.Drawing.Size(52, 52);
            this.toolSaveChart.Click += new System.EventHandler(this.toolSaveChart_Click);
            // 
            // toolSettings
            // 
            this.toolSettings.Image = global::LearnByError.Properties.Resources.settings1;
            this.toolSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSettings.Name = "toolSettings";
            this.toolSettings.Size = new System.Drawing.Size(52, 52);
            this.toolSettings.Click += new System.EventHandler(this.toolSettings_Click);
            // 
            // tsHistory
            // 
            this.tsHistory.Image = global::LearnByError.Properties.Resources.history1;
            this.tsHistory.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsHistory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsHistory.Name = "tsHistory";
            this.tsHistory.Size = new System.Drawing.Size(52, 52);
            this.tsHistory.Click += new System.EventHandler(this.tsHistory_Click);
            // 
            // toolExit
            // 
            this.toolExit.Image = global::LearnByError.Properties.Resources.exit;
            this.toolExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolExit.Name = "toolExit";
            this.toolExit.Size = new System.Drawing.Size(52, 52);
            this.toolExit.Click += new System.EventHandler(this.toolExit_Click);
            // 
            // tsbReasearchLearn
            // 
            this.tsbReasearchLearn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbReasearchLearn.Image = global::LearnByError.Properties.Resources.research;
            this.tsbReasearchLearn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbReasearchLearn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbReasearchLearn.Name = "tsbReasearchLearn";
            this.tsbReasearchLearn.Size = new System.Drawing.Size(52, 52);
            this.tsbReasearchLearn.Text = "Uruchom uczenie z zapisem";
            this.tsbReasearchLearn.Click += new System.EventHandler(this.tsbReasearchLearn_Click);
            // 
            // tEnglish
            // 
            this.tEnglish.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tEnglish.Image = global::LearnByError.Properties.Resources.britain;
            this.tEnglish.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tEnglish.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tEnglish.Name = "tEnglish";
            this.tEnglish.Size = new System.Drawing.Size(52, 52);
            this.tEnglish.Text = "English";
            this.tEnglish.Click += new System.EventHandler(this.tEnglish_Click);
            // 
            // tPolish
            // 
            this.tPolish.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tPolish.Image = global::LearnByError.Properties.Resources.poland1;
            this.tPolish.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tPolish.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tPolish.Name = "tPolish";
            this.tPolish.Size = new System.Drawing.Size(52, 52);
            this.tPolish.Text = "Polski";
            this.tPolish.Click += new System.EventHandler(this.tPolish_Click);
            // 
            // chart
            // 
            chartArea1.AxisY.IsLogarithmic = true;
            chartArea1.AxisY.ScaleBreakStyle.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.AxisY2.IsLogarithmic = true;
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            this.chart.ContextMenuStrip = this.cmChart;
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(0, 91);
            this.chart.Name = "chart";
            this.chart.Size = new System.Drawing.Size(779, 570);
            this.chart.TabIndex = 7;
            // 
            // cmChart
            // 
            this.cmChart.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmChartSave,
            this.toolMainSSE,
            this.toolMainRMSE,
            this.nnNumber});
            this.cmChart.Name = "cmChart";
            this.cmChart.Size = new System.Drawing.Size(105, 92);
            // 
            // cmChartSave
            // 
            this.cmChartSave.Image = global::LearnByError.Properties.Resources.save;
            this.cmChartSave.Name = "cmChartSave";
            this.cmChartSave.Size = new System.Drawing.Size(104, 22);
            this.cmChartSave.Click += new System.EventHandler(this.cmChartSave_Click);
            // 
            // toolMainSSE
            // 
            this.toolMainSSE.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSSE});
            this.toolMainSSE.Name = "toolMainSSE";
            this.toolMainSSE.Size = new System.Drawing.Size(104, 22);
            this.toolMainSSE.Text = "SSE";
            // 
            // toolSSE
            // 
            this.toolSSE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.toolSSE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.toolSSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.toolSSE.MaxDropDownItems = 50;
            this.toolSSE.Name = "toolSSE";
            this.toolSSE.Size = new System.Drawing.Size(250, 150);
            // 
            // toolMainRMSE
            // 
            this.toolMainRMSE.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolRMSE});
            this.toolMainRMSE.Name = "toolMainRMSE";
            this.toolMainRMSE.Size = new System.Drawing.Size(104, 22);
            this.toolMainRMSE.Text = "RMSE";
            // 
            // toolRMSE
            // 
            this.toolRMSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.toolRMSE.MaxDropDownItems = 50;
            this.toolRMSE.Name = "toolRMSE";
            this.toolRMSE.Size = new System.Drawing.Size(250, 150);
            // 
            // nnNumber
            // 
            this.nnNumber.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolNN});
            this.nnNumber.Name = "nnNumber";
            this.nnNumber.Size = new System.Drawing.Size(104, 22);
            // 
            // toolNN
            // 
            this.toolNN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolNN.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.toolNN.Name = "toolNN";
            this.toolNN.Size = new System.Drawing.Size(121, 23);
            this.toolNN.SelectedIndexChanged += new System.EventHandler(this.toolNN_SelectedIndexChanged);
            // 
            // times
            // 
            this.times.AutoSize = true;
            this.times.BackColor = System.Drawing.Color.White;
            this.times.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.times.ForeColor = System.Drawing.Color.Black;
            this.times.Location = new System.Drawing.Point(0, 641);
            this.times.Name = "times";
            this.times.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.times.Size = new System.Drawing.Size(0, 20);
            this.times.TabIndex = 8;
            // 
            // LearnByErrorMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LearnByError.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(779, 685);
            this.Controls.Add(this.times);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menu);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menu;
            this.MinimumSize = new System.Drawing.Size(795, 724);
            this.Name = "LearnByErrorMainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LearnByErrorMainWindow_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LearnByErrorMainWindow_KeyDown);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.cmChart.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel status;
        private System.Windows.Forms.ToolStripProgressBar progress;
        private System.Windows.Forms.ToolStripMenuItem programToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripMenuItem menuSettings;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuInfo;
        private System.Windows.Forms.ToolStripMenuItem toolFolder;
        private System.Windows.Forms.ToolStripMenuItem toolFolderMain;
        private System.Windows.Forms.ToolStripMenuItem toolFolderLogs;
        private System.Windows.Forms.ToolStripMenuItem toolFolderSettings;
        private System.Windows.Forms.ToolStripMenuItem toolFolderData;
        private System.Windows.Forms.ToolStripButton tsOpen;
        private System.Windows.Forms.ToolStripButton tsStart;
        private System.Windows.Forms.ToolStripMenuItem menuData;
        private System.Windows.Forms.ToolStripMenuItem pomocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpLogs;
        private System.Windows.Forms.ToolStripMenuItem menuContact;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.ToolStripButton toolSaveChart;
        private System.Windows.Forms.ToolStripButton toolSettings;
        private System.Windows.Forms.ToolStripButton toolExit;
        private System.Windows.Forms.ContextMenuStrip cmChart;
        private System.Windows.Forms.ToolStripMenuItem cmChartSave;
        private System.Windows.Forms.ToolStripMenuItem toolHistory;
        private System.Windows.Forms.ToolStripButton tsHistory;
        private System.Windows.Forms.ToolStripButton tPolish;
        private System.Windows.Forms.ToolStripButton tEnglish;
        private System.Windows.Forms.Label times;
        private System.Windows.Forms.ToolStripMenuItem toolMainSSE;
        private System.Windows.Forms.ToolStripComboBox toolSSE;
        private System.Windows.Forms.ToolStripMenuItem toolMainRMSE;
        private System.Windows.Forms.ToolStripComboBox toolRMSE;
        private System.Windows.Forms.ToolStripMenuItem toolInstruction;
        private System.Windows.Forms.ToolStripMenuItem nnNumber;
        private System.Windows.Forms.ToolStripComboBox toolNN;
        private System.Windows.Forms.ToolStripMenuItem reasearch;
        private System.Windows.Forms.ToolStripMenuItem runReasearch;
        private System.Windows.Forms.ToolStripStatusLabel stopReasearch;
        private System.Windows.Forms.ToolStripMenuItem testForData;
        private System.Windows.Forms.ToolStripButton tsbReasearchLearn;
    }
}

