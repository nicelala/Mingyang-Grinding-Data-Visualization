namespace NetworkServiceNotifyExample
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.設定初始參數ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.研磨輪其他功能ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.LB_detail = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chartCurrentWave = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.LBWheelStatus = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.LBPeakIntegral = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.LBCycleTime = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LBPeakTime = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LBPeakValue = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chartPeakRecord = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chartPTimeRecord = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.chartCTimeRecord = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.chartIntegralRecord = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCurrentWave)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPeakRecord)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPTimeRecord)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCTimeRecord)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartIntegralRecord)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.設定初始參數ToolStripMenuItem,
            this.研磨輪其他功能ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1164, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 設定初始參數ToolStripMenuItem
            // 
            this.設定初始參數ToolStripMenuItem.Name = "設定初始參數ToolStripMenuItem";
            this.設定初始參數ToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.設定初始參數ToolStripMenuItem.Text = "設定初始參數";
            this.設定初始參數ToolStripMenuItem.Click += new System.EventHandler(this.設定初始參數ToolStripMenuItem_Click);
            // 
            // 研磨輪其他功能ToolStripMenuItem
            // 
            this.研磨輪其他功能ToolStripMenuItem.Name = "研磨輪其他功能ToolStripMenuItem";
            this.研磨輪其他功能ToolStripMenuItem.Size = new System.Drawing.Size(103, 20);
            this.研磨輪其他功能ToolStripMenuItem.Text = "研磨輪其他功能";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.34636F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.94849F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.79396F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.chartCurrentWave, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 27);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1126, 301);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.22663F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.77337F));
            this.tableLayoutPanel3.Controls.Add(this.LB_detail, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(770, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(353, 295);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // LB_detail
            // 
            this.LB_detail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LB_detail.AutoSize = true;
            this.LB_detail.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_detail.Location = new System.Drawing.Point(234, 16);
            this.LB_detail.Name = "LB_detail";
            this.LB_detail.Size = new System.Drawing.Size(26, 26);
            this.LB_detail.TabIndex = 10;
            this.LB_detail.Text = "--";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 26);
            this.label1.TabIndex = 9;
            this.label1.Text = "欄位數";
            // 
            // chartCurrentWave
            // 
            chartArea6.Name = "ChartArea1";
            this.chartCurrentWave.ChartAreas.Add(chartArea6);
            this.chartCurrentWave.Location = new System.Drawing.Point(3, 3);
            this.chartCurrentWave.Name = "chartCurrentWave";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Name = "Series1";
            this.chartCurrentWave.Series.Add(series6);
            this.chartCurrentWave.Size = new System.Drawing.Size(391, 295);
            this.chartCurrentWave.TabIndex = 1;
            this.chartCurrentWave.Text = "chartCurrentWave";
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "Title1";
            title2.Text = "Current";
            this.chartCurrentWave.Titles.Add(title2);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.16053F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.83947F));
            this.tableLayoutPanel1.Controls.Add(this.LBWheelStatus, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.LBPeakIntegral, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.LBCycleTime, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.LBPeakTime, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.LBPeakValue, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(400, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(364, 295);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // LBWheelStatus
            // 
            this.LBWheelStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LBWheelStatus.AutoSize = true;
            this.LBWheelStatus.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBWheelStatus.Location = new System.Drawing.Point(256, 252);
            this.LBWheelStatus.Name = "LBWheelStatus";
            this.LBWheelStatus.Size = new System.Drawing.Size(26, 26);
            this.LBWheelStatus.TabIndex = 13;
            this.LBWheelStatus.Text = "--";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(24, 252);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(127, 26);
            this.label10.TabIndex = 12;
            this.label10.Text = "研磨輪狀態";
            // 
            // LBPeakIntegral
            // 
            this.LBPeakIntegral.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LBPeakIntegral.AutoSize = true;
            this.LBPeakIntegral.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBPeakIntegral.Location = new System.Drawing.Point(256, 193);
            this.LBPeakIntegral.Name = "LBPeakIntegral";
            this.LBPeakIntegral.Size = new System.Drawing.Size(26, 26);
            this.LBPeakIntegral.TabIndex = 11;
            this.LBPeakIntegral.Text = "--";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(24, 193);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 26);
            this.label8.TabIndex = 10;
            this.label8.Text = "波形積分值";
            // 
            // LBCycleTime
            // 
            this.LBCycleTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LBCycleTime.AutoSize = true;
            this.LBCycleTime.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBCycleTime.Location = new System.Drawing.Point(256, 134);
            this.LBCycleTime.Name = "LBCycleTime";
            this.LBCycleTime.Size = new System.Drawing.Size(26, 26);
            this.LBCycleTime.TabIndex = 9;
            this.LBCycleTime.Text = "--";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(35, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 26);
            this.label6.TabIndex = 8;
            this.label6.Text = "週期時間";
            // 
            // LBPeakTime
            // 
            this.LBPeakTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LBPeakTime.AutoSize = true;
            this.LBPeakTime.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBPeakTime.Location = new System.Drawing.Point(256, 75);
            this.LBPeakTime.Name = "LBPeakTime";
            this.LBPeakTime.Size = new System.Drawing.Size(26, 26);
            this.LBPeakTime.TabIndex = 7;
            this.LBPeakTime.Text = "--";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(35, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 26);
            this.label4.TabIndex = 6;
            this.label4.Text = "波峰時間";
            // 
            // LBPeakValue
            // 
            this.LBPeakValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LBPeakValue.AutoSize = true;
            this.LBPeakValue.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBPeakValue.Location = new System.Drawing.Point(256, 16);
            this.LBPeakValue.Name = "LBPeakValue";
            this.LBPeakValue.Size = new System.Drawing.Size(26, 26);
            this.LBPeakValue.TabIndex = 5;
            this.LBPeakValue.Text = "--";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(47, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 26);
            this.label2.TabIndex = 4;
            this.label2.Text = "波峰值";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(3, 334);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1126, 254);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chartPeakRecord);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1118, 221);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "波峰值";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chartPeakRecord
            // 
            chartArea7.Name = "ChartArea1";
            this.chartPeakRecord.ChartAreas.Add(chartArea7);
            this.chartPeakRecord.Location = new System.Drawing.Point(0, 0);
            this.chartPeakRecord.Name = "chartPeakRecord";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series7.Name = "Series1";
            this.chartPeakRecord.Series.Add(series7);
            this.chartPeakRecord.Size = new System.Drawing.Size(1118, 225);
            this.chartPeakRecord.TabIndex = 1;
            this.chartPeakRecord.Text = "chartPeakRecord";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chartPTimeRecord);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1118, 221);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "波峰時間";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chartPTimeRecord
            // 
            chartArea8.Name = "ChartArea1";
            this.chartPTimeRecord.ChartAreas.Add(chartArea8);
            this.chartPTimeRecord.Location = new System.Drawing.Point(0, -2);
            this.chartPTimeRecord.Name = "chartPTimeRecord";
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series8.Name = "Series1";
            this.chartPTimeRecord.Series.Add(series8);
            this.chartPTimeRecord.Size = new System.Drawing.Size(1118, 225);
            this.chartPTimeRecord.TabIndex = 2;
            this.chartPTimeRecord.Text = "chartPTimeRecord";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.chartCTimeRecord);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1118, 221);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "週期時間";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // chartCTimeRecord
            // 
            chartArea9.Name = "ChartArea1";
            this.chartCTimeRecord.ChartAreas.Add(chartArea9);
            this.chartCTimeRecord.Location = new System.Drawing.Point(0, -2);
            this.chartCTimeRecord.Name = "chartCTimeRecord";
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series9.Name = "Series1";
            this.chartCTimeRecord.Series.Add(series9);
            this.chartCTimeRecord.Size = new System.Drawing.Size(1118, 225);
            this.chartCTimeRecord.TabIndex = 2;
            this.chartCTimeRecord.Text = "chart3";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.chartIntegralRecord);
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1118, 221);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "積分值";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // chartIntegralRecord
            // 
            chartArea10.Name = "ChartArea1";
            this.chartIntegralRecord.ChartAreas.Add(chartArea10);
            this.chartIntegralRecord.Location = new System.Drawing.Point(0, -2);
            this.chartIntegralRecord.Name = "chartIntegralRecord";
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series10.Name = "Series1";
            this.chartIntegralRecord.Series.Add(series10);
            this.chartIntegralRecord.Size = new System.Drawing.Size(1118, 225);
            this.chartIntegralRecord.TabIndex = 2;
            this.chartIntegralRecord.Text = "chart4";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 593);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Network Service Notify Example Ver.1.0.0.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCurrentWave)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartPeakRecord)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartPTimeRecord)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartCTimeRecord)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartIntegralRecord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 研磨輪其他功能ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 設定初始參數ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label LBWheelStatus;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label LBPeakIntegral;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label LBCycleTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LBPeakTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LBPeakValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPeakRecord;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCurrentWave;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPTimeRecord;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCTimeRecord;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartIntegralRecord;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label LB_detail;
        private System.Windows.Forms.Label label1;
    }
}

