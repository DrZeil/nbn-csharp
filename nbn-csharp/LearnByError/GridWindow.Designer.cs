namespace LearnByError
{
    partial class GridWindow
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
            this.grid = new System.Windows.Forms.DataGridView();
            this.learnDataDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.neuronNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trialsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.learnRMSEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.testRMSEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.kopiujDoSchowkaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kopiujDoNotatnikaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportDataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AutoGenerateColumns = false;
            this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.learnDataDataGridViewTextBoxColumn,
            this.neuronNumberDataGridViewTextBoxColumn,
            this.trialsDataGridViewTextBoxColumn,
            this.learnRMSEDataGridViewTextBoxColumn,
            this.testRMSEDataGridViewTextBoxColumn,
            this.Column1,
            this.Column2});
            this.grid.ContextMenuStrip = this.contextMenuStrip1;
            this.grid.DataSource = this.reportDataBindingSource;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.ShowCellErrors = false;
            this.grid.ShowCellToolTips = false;
            this.grid.ShowEditingIcon = false;
            this.grid.ShowRowErrors = false;
            this.grid.Size = new System.Drawing.Size(934, 396);
            this.grid.TabIndex = 0;
            this.grid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GridWindow_KeyDown);
            // 
            // learnDataDataGridViewTextBoxColumn
            // 
            this.learnDataDataGridViewTextBoxColumn.DataPropertyName = "LearnData";
 
            this.learnDataDataGridViewTextBoxColumn.Name = "learnDataDataGridViewTextBoxColumn";
            this.learnDataDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // neuronNumberDataGridViewTextBoxColumn
            // 
            this.neuronNumberDataGridViewTextBoxColumn.DataPropertyName = "NeuronNumber";
   
            this.neuronNumberDataGridViewTextBoxColumn.Name = "neuronNumberDataGridViewTextBoxColumn";
            this.neuronNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // trialsDataGridViewTextBoxColumn
            // 
            this.trialsDataGridViewTextBoxColumn.DataPropertyName = "Trials";
            
            this.trialsDataGridViewTextBoxColumn.Name = "trialsDataGridViewTextBoxColumn";
            this.trialsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // learnRMSEDataGridViewTextBoxColumn
            // 
            this.learnRMSEDataGridViewTextBoxColumn.DataPropertyName = "LearnRMSE";
           
            this.learnRMSEDataGridViewTextBoxColumn.Name = "learnRMSEDataGridViewTextBoxColumn";
            this.learnRMSEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // testRMSEDataGridViewTextBoxColumn
            // 
            this.testRMSEDataGridViewTextBoxColumn.DataPropertyName = "TestRMSE";
           
            this.testRMSEDataGridViewTextBoxColumn.Name = "testRMSEDataGridViewTextBoxColumn";
            this.testRMSEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "LearnTime";
            
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "TestTime";
           
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kopiujDoSchowkaToolStripMenuItem,
            this.kopiujDoNotatnikaToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(179, 48);
            // 
            // kopiujDoSchowkaToolStripMenuItem
            // 
            this.kopiujDoSchowkaToolStripMenuItem.Name = "kopiujDoSchowkaToolStripMenuItem";
            this.kopiujDoSchowkaToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.kopiujDoSchowkaToolStripMenuItem.Click += new System.EventHandler(this.copyToClipboard);
            // 
            // kopiujDoNotatnikaToolStripMenuItem
            // 
            this.kopiujDoNotatnikaToolStripMenuItem.Name = "kopiujDoNotatnikaToolStripMenuItem";
            this.kopiujDoNotatnikaToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
           
            this.kopiujDoNotatnikaToolStripMenuItem.Click += new System.EventHandler(this.kopiujDoNotatnikaToolStripMenuItem_Click);
            // 
            // reportDataBindingSource
            // 
            this.reportDataBindingSource.DataSource = typeof(LearnByError.ReportData);
            // 
            // GridWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(934, 396);
            this.Controls.Add(this.grid);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "GridWindow";
            this.ShowIcon = false;
            this.Text = "GridWindow";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.GridWindow_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GridWindow_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.reportDataBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.BindingSource reportDataBindingSource;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem kopiujDoSchowkaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kopiujDoNotatnikaToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn learnDataDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn neuronNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn trialsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn learnRMSEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn testRMSEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}