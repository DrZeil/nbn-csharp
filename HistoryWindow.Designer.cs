namespace LearnByError
{
    partial class HistoryWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistoryWindow));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.progress = new System.Windows.Forms.ToolStripProgressBar();
            this.nnText = new System.Windows.Forms.ToolStripDropDownButton();
            this.nn10 = new System.Windows.Forms.ToolStripMenuItem();
            this.nn9 = new System.Windows.Forms.ToolStripMenuItem();
            this.nn8 = new System.Windows.Forms.ToolStripMenuItem();
            this.nn7 = new System.Windows.Forms.ToolStripMenuItem();
            this.nn6 = new System.Windows.Forms.ToolStripMenuItem();
            this.nn5 = new System.Windows.Forms.ToolStripMenuItem();
            this.nn4 = new System.Windows.Forms.ToolStripMenuItem();
            this.nn3 = new System.Windows.Forms.ToolStripMenuItem();
            this.nn2 = new System.Windows.Forms.ToolStripMenuItem();
            this.nnAll = new System.Windows.Forms.ToolStripMenuItem();
            this.rmseText = new System.Windows.Forms.ToolStripDropDownButton();
            this.rmse00001 = new System.Windows.Forms.ToolStripMenuItem();
            this.rmse0001 = new System.Windows.Forms.ToolStripMenuItem();
            this.rmse001 = new System.Windows.Forms.ToolStripMenuItem();
            this.rmse01 = new System.Windows.Forms.ToolStripMenuItem();
            this.rmse0 = new System.Windows.Forms.ToolStripMenuItem();
            this.rmseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.learnRMSE = new System.Windows.Forms.ToolStripStatusLabel();
            this.testRMSE = new System.Windows.Forms.ToolStripStatusLabel();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.toolOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.tSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveWeights = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPDF = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPDF2 = new System.Windows.Forms.ToolStripMenuItem();
            this.previous = new System.Windows.Forms.ToolStripMenuItem();
            this.next = new System.Windows.Forms.ToolStripMenuItem();
            this.exit = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.weightsList = new System.Windows.Forms.ListBox();
            this.contextMenuWeights = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmwSave = new System.Windows.Forms.ToolStripMenuItem();
            this.history = new System.Windows.Forms.ListBox();
            this.contextMenuHistory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmhDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.neuronNumber = new System.Windows.Forms.Label();
            this.times = new System.Windows.Forms.Label();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.contextMenuChart = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmcSave = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.contextMenuWeights.SuspendLayout();
            this.contextMenuHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.contextMenuChart.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status,
            this.progress,
            this.nnText,
            this.rmseText,
            this.learnRMSE,
            this.testRMSE});
            this.statusStrip1.Location = new System.Drawing.Point(0, 685);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1146, 22);
            this.statusStrip1.TabIndex = 0;
            // 
            // status
            // 
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(0, 17);
            // 
            // progress
            // 
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(117, 19);
            this.progress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progress.Visible = false;
            // 
            // nnText
            // 
            this.nnText.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nn10,
            this.nn9,
            this.nn8,
            this.nn7,
            this.nn6,
            this.nn5,
            this.nn4,
            this.nn3,
            this.nn2,
            this.nnAll});
            this.nnText.Image = ((System.Drawing.Image)(resources.GetObject("nnText.Image")));
            this.nnText.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nnText.Name = "nnText";
            this.nnText.Size = new System.Drawing.Size(29, 20);
            // 
            // nn10
            // 
            this.nn10.Name = "nn10";
            this.nn10.Size = new System.Drawing.Size(67, 22);
            this.nn10.Click += new System.EventHandler(this.nn10_Click);
            // 
            // nn9
            // 
            this.nn9.Name = "nn9";
            this.nn9.Size = new System.Drawing.Size(67, 22);
            this.nn9.Click += new System.EventHandler(this.nn9_Click);
            // 
            // nn8
            // 
            this.nn8.Name = "nn8";
            this.nn8.Size = new System.Drawing.Size(67, 22);
            this.nn8.Click += new System.EventHandler(this.nn8_Click);
            // 
            // nn7
            // 
            this.nn7.Name = "nn7";
            this.nn7.Size = new System.Drawing.Size(67, 22);
            this.nn7.Click += new System.EventHandler(this.nn7_Click);
            // 
            // nn6
            // 
            this.nn6.Name = "nn6";
            this.nn6.Size = new System.Drawing.Size(67, 22);
            this.nn6.Click += new System.EventHandler(this.nn6_Click);
            // 
            // nn5
            // 
            this.nn5.Name = "nn5";
            this.nn5.Size = new System.Drawing.Size(67, 22);
            this.nn5.Click += new System.EventHandler(this.nn5_Click);
            // 
            // nn4
            // 
            this.nn4.Name = "nn4";
            this.nn4.Size = new System.Drawing.Size(67, 22);
            this.nn4.Click += new System.EventHandler(this.nn4_Click);
            // 
            // nn3
            // 
            this.nn3.Name = "nn3";
            this.nn3.Size = new System.Drawing.Size(67, 22);
            this.nn3.Click += new System.EventHandler(this.nn3_Click);
            // 
            // nn2
            // 
            this.nn2.Name = "nn2";
            this.nn2.Size = new System.Drawing.Size(67, 22);
            this.nn2.Click += new System.EventHandler(this.nn2_Click);
            // 
            // nnAll
            // 
            this.nnAll.Name = "nnAll";
            this.nnAll.Size = new System.Drawing.Size(67, 22);
            this.nnAll.Click += new System.EventHandler(this.nnAll_Click);
            // 
            // rmseText
            // 
            this.rmseText.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rmse00001,
            this.rmse0001,
            this.rmse001,
            this.rmse01,
            this.rmse0,
            this.rmseAll});
            this.rmseText.Image = ((System.Drawing.Image)(resources.GetObject("rmseText.Image")));
            this.rmseText.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rmseText.Name = "rmseText";
            this.rmseText.Size = new System.Drawing.Size(29, 20);
            // 
            // rmse00001
            // 
            this.rmse00001.Name = "rmse00001";
            this.rmse00001.Size = new System.Drawing.Size(67, 22);
            this.rmse00001.Click += new System.EventHandler(this.rmse00001_Click);
            // 
            // rmse0001
            // 
            this.rmse0001.Name = "rmse0001";
            this.rmse0001.Size = new System.Drawing.Size(67, 22);
            this.rmse0001.Click += new System.EventHandler(this.rmse0001_Click);
            // 
            // rmse001
            // 
            this.rmse001.Name = "rmse001";
            this.rmse001.Size = new System.Drawing.Size(67, 22);
            this.rmse001.Click += new System.EventHandler(this.rmse001_Click);
            // 
            // rmse01
            // 
            this.rmse01.Name = "rmse01";
            this.rmse01.Size = new System.Drawing.Size(67, 22);
            this.rmse01.Click += new System.EventHandler(this.rmse01_Click);
            // 
            // rmse0
            // 
            this.rmse0.Name = "rmse0";
            this.rmse0.Size = new System.Drawing.Size(67, 22);
            this.rmse0.Click += new System.EventHandler(this.rmse0_Click);
            // 
            // rmseAll
            // 
            this.rmseAll.Name = "rmseAll";
            this.rmseAll.Size = new System.Drawing.Size(67, 22);
            this.rmseAll.Click += new System.EventHandler(this.rmseAll_Click);
            // 
            // learnRMSE
            // 
            this.learnRMSE.Name = "learnRMSE";
            this.learnRMSE.Size = new System.Drawing.Size(0, 17);
            // 
            // testRMSE
            // 
            this.testRMSE.Name = "testRMSE";
            this.testRMSE.Size = new System.Drawing.Size(0, 17);
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.Transparent;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolOptions,
            this.previous,
            this.next,
            this.exit});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menu.Size = new System.Drawing.Size(1146, 24);
            this.menu.TabIndex = 1;
            // 
            // toolOptions
            // 
            this.toolOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSave,
            this.menuSaveWeights,
            this.menuPDF,
            this.menuPDF2});
            this.toolOptions.Name = "toolOptions";
            this.toolOptions.Size = new System.Drawing.Size(12, 20);
            // 
            // tSave
            // 
            this.tSave.Image = global::LearnByError.Properties.Resources.save;
            this.tSave.Name = "tSave";
            this.tSave.Size = new System.Drawing.Size(67, 22);
            this.tSave.Click += new System.EventHandler(this.tSave_Click);
            // 
            // menuSaveWeights
            // 
            this.menuSaveWeights.Image = global::LearnByError.Properties.Resources.save;
            this.menuSaveWeights.Name = "menuSaveWeights";
            this.menuSaveWeights.Size = new System.Drawing.Size(67, 22);
            this.menuSaveWeights.Click += new System.EventHandler(this.menuSaveWeights_Click);
            // 
            // menuPDF
            // 
            this.menuPDF.Image = global::LearnByError.Properties.Resources.pdfpdf;
            this.menuPDF.Name = "menuPDF";
            this.menuPDF.Size = new System.Drawing.Size(67, 22);
            this.menuPDF.Click += new System.EventHandler(this.menuPDF_Click);
            // 
            // menuPDF2
            // 
            this.menuPDF2.Image = global::LearnByError.Properties.Resources.pdfpdf;
            this.menuPDF2.Name = "menuPDF2";
            this.menuPDF2.Size = new System.Drawing.Size(67, 22);
            this.menuPDF2.Click += new System.EventHandler(this.menuPDF2_Click);
            // 
            // previous
            // 
            this.previous.Image = global::LearnByError.Properties.Resources.left;
            this.previous.Name = "previous";
            this.previous.Size = new System.Drawing.Size(28, 20);
            this.previous.Click += new System.EventHandler(this.previous_Click);
            // 
            // next
            // 
            this.next.Image = global::LearnByError.Properties.Resources.right;
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(28, 20);
            this.next.Click += new System.EventHandler(this.next_Click);
            // 
            // exit
            // 
            this.exit.Image = global::LearnByError.Properties.Resources.logout;
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(28, 20);
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(1146, 661);
            this.splitContainer1.SplitterDistance = 30;
            this.splitContainer1.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer2.Panel2.Controls.Add(this.label2);
            this.splitContainer2.Size = new System.Drawing.Size(1146, 30);
            this.splitContainer2.SplitterDistance = 299;
            this.splitContainer2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5);
            this.label1.Size = new System.Drawing.Size(10, 25);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(5);
            this.label2.Size = new System.Drawing.Size(10, 25);
            this.label2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.neuronNumber);
            this.splitContainer3.Panel2.Controls.Add(this.times);
            this.splitContainer3.Panel2.Controls.Add(this.chart);
            this.splitContainer3.Size = new System.Drawing.Size(1146, 627);
            this.splitContainer3.SplitterDistance = 300;
            this.splitContainer3.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.weightsList);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.history);
            this.splitContainer4.Panel2.Controls.Add(this.label3);
            this.splitContainer4.Size = new System.Drawing.Size(300, 627);
            this.splitContainer4.SplitterDistance = 303;
            this.splitContainer4.TabIndex = 0;
            // 
            // weightsList
            // 
            this.weightsList.ContextMenuStrip = this.contextMenuWeights;
            this.weightsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.weightsList.FormattingEnabled = true;
            this.weightsList.ItemHeight = 15;
            this.weightsList.Location = new System.Drawing.Point(0, 0);
            this.weightsList.Name = "weightsList";
            this.weightsList.Size = new System.Drawing.Size(300, 303);
            this.weightsList.TabIndex = 0;
            // 
            // contextMenuWeights
            // 
            this.contextMenuWeights.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmwSave});
            this.contextMenuWeights.Name = "contextMenuWeights";
            this.contextMenuWeights.Size = new System.Drawing.Size(68, 26);
            // 
            // cmwSave
            // 
            this.cmwSave.Image = global::LearnByError.Properties.Resources.save;
            this.cmwSave.Name = "cmwSave";
            this.cmwSave.Size = new System.Drawing.Size(67, 22);
            this.cmwSave.Click += new System.EventHandler(this.cmwSave_Click);
            // 
            // history
            // 
            this.history.ContextMenuStrip = this.contextMenuHistory;
            this.history.Dock = System.Windows.Forms.DockStyle.Fill;
            this.history.FormattingEnabled = true;
            this.history.ItemHeight = 15;
            this.history.Location = new System.Drawing.Point(0, 25);
            this.history.Name = "history";
            this.history.Size = new System.Drawing.Size(300, 295);
            this.history.TabIndex = 1;
            this.history.SelectedIndexChanged += new System.EventHandler(this.list_SelectedIndexChanged);
            // 
            // contextMenuHistory
            // 
            this.contextMenuHistory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmhDelete});
            this.contextMenuHistory.Name = "contextMenuHistory";
            this.contextMenuHistory.Size = new System.Drawing.Size(68, 26);
            // 
            // cmhDelete
            // 
            this.cmhDelete.Image = global::LearnByError.Properties.Resources.delete;
            this.cmhDelete.Name = "cmhDelete";
            this.cmhDelete.Size = new System.Drawing.Size(67, 22);
            this.cmhDelete.Click += new System.EventHandler(this.cmhDelete_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(5);
            this.label3.Size = new System.Drawing.Size(10, 25);
            this.label3.TabIndex = 0;
            // 
            // neuronNumber
            // 
            this.neuronNumber.AutoSize = true;
            this.neuronNumber.BackColor = System.Drawing.Color.White;
            this.neuronNumber.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuronNumber.Location = new System.Drawing.Point(0, 0);
            this.neuronNumber.Name = "neuronNumber";
            this.neuronNumber.Size = new System.Drawing.Size(0, 15);
            this.neuronNumber.TabIndex = 2;
            // 
            // times
            // 
            this.times.AutoSize = true;
            this.times.BackColor = System.Drawing.Color.White;
            this.times.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.times.Location = new System.Drawing.Point(0, 612);
            this.times.Name = "times";
            this.times.Size = new System.Drawing.Size(0, 15);
            this.times.TabIndex = 1;
            // 
            // chart
            // 
            chartArea1.AxisY.IsLogarithmic = true;
            chartArea1.AxisY.MajorGrid.Interval = 0D;
            chartArea1.AxisY.MajorGrid.IntervalOffset = 0D;
            chartArea1.AxisY.MinorGrid.IntervalOffset = 0.001D;
            chartArea1.AxisY.ScaleBreakStyle.MaxNumberOfBreaks = 5;
            chartArea1.AxisY2.IsLogarithmic = true;
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            this.chart.ContextMenuStrip = this.contextMenuChart;
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(0, 0);
            this.chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(842, 627);
            this.chart.TabIndex = 0;
            this.chart.Text = "chart1";
            // 
            // contextMenuChart
            // 
            this.contextMenuChart.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmcSave});
            this.contextMenuChart.Name = "contextMenuChart";
            this.contextMenuChart.Size = new System.Drawing.Size(68, 26);
            // 
            // cmcSave
            // 
            this.cmcSave.Image = global::LearnByError.Properties.Resources.save;
            this.cmcSave.Name = "cmcSave";
            this.cmcSave.Size = new System.Drawing.Size(67, 22);
            this.cmcSave.Click += new System.EventHandler(this.cmcSave_Click);
            // 
            // HistoryWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LearnByError.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(1146, 707);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menu);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(1162, 746);
            this.Name = "HistoryWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.HistoryWindow_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.contextMenuWeights.ResumeLayout(false);
            this.contextMenuHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.contextMenuChart.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel status;
        private System.Windows.Forms.ToolStripProgressBar progress;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ToolStripMenuItem toolOptions;
        private System.Windows.Forms.ToolStripMenuItem tSave;
        private System.Windows.Forms.ContextMenuStrip contextMenuChart;
        private System.Windows.Forms.ToolStripMenuItem cmcSave;
        private System.Windows.Forms.ContextMenuStrip contextMenuWeights;
        private System.Windows.Forms.ToolStripMenuItem cmwSave;
        private System.Windows.Forms.ToolStripMenuItem menuSaveWeights;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.ListBox weightsList;
        private System.Windows.Forms.ListBox history;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem previous;
        private System.Windows.Forms.ToolStripMenuItem next;
        private System.Windows.Forms.ToolStripMenuItem exit;
        private System.Windows.Forms.ContextMenuStrip contextMenuHistory;
        private System.Windows.Forms.ToolStripMenuItem cmhDelete;
        private System.Windows.Forms.ToolStripMenuItem menuPDF;
        private System.Windows.Forms.ToolStripMenuItem menuPDF2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.ToolStripDropDownButton nnText;
        private System.Windows.Forms.ToolStripMenuItem nn10;
        private System.Windows.Forms.ToolStripMenuItem nn9;
        private System.Windows.Forms.ToolStripMenuItem nn8;
        private System.Windows.Forms.ToolStripMenuItem nn7;
        private System.Windows.Forms.ToolStripMenuItem nn6;
        private System.Windows.Forms.ToolStripMenuItem nn5;
        private System.Windows.Forms.ToolStripMenuItem nn4;
        private System.Windows.Forms.ToolStripMenuItem nn3;
        private System.Windows.Forms.ToolStripMenuItem nn2;
        private System.Windows.Forms.ToolStripMenuItem nnAll;
        private System.Windows.Forms.ToolStripDropDownButton rmseText;
        private System.Windows.Forms.ToolStripMenuItem rmse0001;
        private System.Windows.Forms.ToolStripMenuItem rmse001;
        private System.Windows.Forms.ToolStripMenuItem rmse01;
        private System.Windows.Forms.ToolStripMenuItem rmse0;
        private System.Windows.Forms.ToolStripMenuItem rmseAll;
        private System.Windows.Forms.ToolStripMenuItem rmse00001;
        private System.Windows.Forms.ToolStripStatusLabel learnRMSE;
        private System.Windows.Forms.ToolStripStatusLabel testRMSE;
        private System.Windows.Forms.Label times;
        private System.Windows.Forms.Label neuronNumber;
    }
}