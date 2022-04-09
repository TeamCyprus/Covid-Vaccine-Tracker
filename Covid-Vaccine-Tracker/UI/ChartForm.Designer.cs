
namespace Covid_Vaccine_Tracker.UI
{
    partial class ChartForm
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
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChartForm));
            this.VaxChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.DataBtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.RankingBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.TopDBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.RollOutBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.SeriesBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.CityBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.CountyBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.SexBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.RaceBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.EthnicityBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.manufacturerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TopMBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.BarBtn1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.BarBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.StackedBarBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.ColumnBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.StackedColumnBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.LineBtn1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.LineBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.StepLineBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.AreaBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.KagiBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.BubbleBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.PieBtn1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.PieBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.FunnelBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.PyrimidBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitBtn = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.TotalDoseTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TotalPatientTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.VarTxt = new System.Windows.Forms.TextBox();
            this.StdTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AvgTxt = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.MovingAvgTxt = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.LoadBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.VaxChart)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // VaxChart
            // 
            this.VaxChart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(85)))), ((int)(((byte)(35)))));
            this.VaxChart.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.HorizontalCenter;
            this.VaxChart.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            chartArea1.Name = "ChartArea1";
            this.VaxChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.VaxChart.Legends.Add(legend1);
            this.VaxChart.Location = new System.Drawing.Point(15, 14);
            this.VaxChart.Name = "VaxChart";
            this.VaxChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Chocolate;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.VaxChart.Series.Add(series1);
            this.VaxChart.Size = new System.Drawing.Size(703, 376);
            this.VaxChart.TabIndex = 9;
            this.VaxChart.Text = "chart1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DataBtn,
            this.toolStripSeparator4,
            this.BarBtn1,
            this.toolStripSeparator1,
            this.LineBtn1,
            this.toolStripSeparator2,
            this.PieBtn1,
            this.toolStripSeparator3,
            this.LoadBtn,
            this.toolStripSeparator5,
            this.ExitBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(985, 27);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "Data";
            // 
            // DataBtn
            // 
            this.DataBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RankingBtn,
            this.TopDBtn,
            this.RollOutBtn,
            this.SeriesBtn,
            this.CityBtn,
            this.CountyBtn,
            this.SexBtn,
            this.RaceBtn,
            this.EthnicityBtn,
            this.manufacturerToolStripMenuItem,
            this.TopMBtn});
            this.DataBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(85)))), ((int)(((byte)(35)))));
            this.DataBtn.Image = ((System.Drawing.Image)(resources.GetObject("DataBtn.Image")));
            this.DataBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DataBtn.Name = "DataBtn";
            this.DataBtn.Size = new System.Drawing.Size(70, 24);
            this.DataBtn.Text = "Data";
            this.DataBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // RankingBtn
            // 
            this.RankingBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            this.RankingBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(85)))), ((int)(((byte)(35)))));
            this.RankingBtn.Name = "RankingBtn";
            this.RankingBtn.Size = new System.Drawing.Size(213, 24);
            this.RankingBtn.Text = "Dose Ranking";
            this.RankingBtn.Click += new System.EventHandler(this.RankingBtn_Click);
            // 
            // TopDBtn
            // 
            this.TopDBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            this.TopDBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(85)))), ((int)(((byte)(35)))));
            this.TopDBtn.Name = "TopDBtn";
            this.TopDBtn.Size = new System.Drawing.Size(213, 24);
            this.TopDBtn.Text = "Top 3 Doses";
            this.TopDBtn.Click += new System.EventHandler(this.TopDBtn_Click);
            // 
            // RollOutBtn
            // 
            this.RollOutBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            this.RollOutBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(85)))), ((int)(((byte)(35)))));
            this.RollOutBtn.Name = "RollOutBtn";
            this.RollOutBtn.Size = new System.Drawing.Size(213, 24);
            this.RollOutBtn.Text = "Roll Out";
            this.RollOutBtn.Click += new System.EventHandler(this.RollOutBtn_Click);
            // 
            // SeriesBtn
            // 
            this.SeriesBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            this.SeriesBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(85)))), ((int)(((byte)(35)))));
            this.SeriesBtn.Name = "SeriesBtn";
            this.SeriesBtn.Size = new System.Drawing.Size(213, 24);
            this.SeriesBtn.Text = "Series Status";
            this.SeriesBtn.Click += new System.EventHandler(this.SeriesBtn_Click);
            // 
            // CityBtn
            // 
            this.CityBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            this.CityBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(85)))), ((int)(((byte)(35)))));
            this.CityBtn.Name = "CityBtn";
            this.CityBtn.Size = new System.Drawing.Size(213, 24);
            this.CityBtn.Text = "City";
            this.CityBtn.Click += new System.EventHandler(this.CityBtn_Click);
            // 
            // CountyBtn
            // 
            this.CountyBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            this.CountyBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(85)))), ((int)(((byte)(35)))));
            this.CountyBtn.Name = "CountyBtn";
            this.CountyBtn.Size = new System.Drawing.Size(213, 24);
            this.CountyBtn.Text = "County";
            this.CountyBtn.Click += new System.EventHandler(this.CountyBtn_Click);
            // 
            // SexBtn
            // 
            this.SexBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            this.SexBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(85)))), ((int)(((byte)(35)))));
            this.SexBtn.Name = "SexBtn";
            this.SexBtn.Size = new System.Drawing.Size(213, 24);
            this.SexBtn.Text = "Sex";
            this.SexBtn.Click += new System.EventHandler(this.SexBtn_Click);
            // 
            // RaceBtn
            // 
            this.RaceBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            this.RaceBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(85)))), ((int)(((byte)(35)))));
            this.RaceBtn.Name = "RaceBtn";
            this.RaceBtn.Size = new System.Drawing.Size(213, 24);
            this.RaceBtn.Text = "Race";
            this.RaceBtn.Click += new System.EventHandler(this.RaceBtn_Click);
            // 
            // EthnicityBtn
            // 
            this.EthnicityBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            this.EthnicityBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(85)))), ((int)(((byte)(35)))));
            this.EthnicityBtn.Name = "EthnicityBtn";
            this.EthnicityBtn.Size = new System.Drawing.Size(213, 24);
            this.EthnicityBtn.Text = "Ethnicity";
            this.EthnicityBtn.Click += new System.EventHandler(this.EthnicityBtn_Click);
            // 
            // manufacturerToolStripMenuItem
            // 
            this.manufacturerToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            this.manufacturerToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(85)))), ((int)(((byte)(35)))));
            this.manufacturerToolStripMenuItem.Name = "manufacturerToolStripMenuItem";
            this.manufacturerToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
            this.manufacturerToolStripMenuItem.Text = "Manufacturer";
            this.manufacturerToolStripMenuItem.Click += new System.EventHandler(this.manufacturerToolStripMenuItem_Click);
            // 
            // TopMBtn
            // 
            this.TopMBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            this.TopMBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(85)))), ((int)(((byte)(35)))));
            this.TopMBtn.Name = "TopMBtn";
            this.TopMBtn.Size = new System.Drawing.Size(213, 24);
            this.TopMBtn.Text = "Top 3 Manufacturers";
            this.TopMBtn.Click += new System.EventHandler(this.TopMBtn_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // BarBtn1
            // 
            this.BarBtn1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BarBtn,
            this.StackedBarBtn,
            this.ColumnBtn,
            this.StackedColumnBtn});
            this.BarBtn1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(104)))), ((int)(((byte)(89)))));
            this.BarBtn1.Image = ((System.Drawing.Image)(resources.GetObject("BarBtn1.Image")));
            this.BarBtn1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BarBtn1.Name = "BarBtn1";
            this.BarBtn1.Size = new System.Drawing.Size(29, 24);
            this.BarBtn1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.BarBtn1.ToolTipText = "Differnt bar chart types";
            // 
            // BarBtn
            // 
            this.BarBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            this.BarBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(104)))), ((int)(((byte)(89)))));
            this.BarBtn.Name = "BarBtn";
            this.BarBtn.Size = new System.Drawing.Size(224, 24);
            this.BarBtn.Text = "Bar Chart";
            this.BarBtn.Click += new System.EventHandler(this.BarBtn_Click);
            // 
            // StackedBarBtn
            // 
            this.StackedBarBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            this.StackedBarBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(104)))), ((int)(((byte)(89)))));
            this.StackedBarBtn.Name = "StackedBarBtn";
            this.StackedBarBtn.Size = new System.Drawing.Size(224, 24);
            this.StackedBarBtn.Text = "Stacked Bar Chart";
            this.StackedBarBtn.Click += new System.EventHandler(this.StackedBarBtn_Click);
            // 
            // ColumnBtn
            // 
            this.ColumnBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            this.ColumnBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(104)))), ((int)(((byte)(89)))));
            this.ColumnBtn.Name = "ColumnBtn";
            this.ColumnBtn.Size = new System.Drawing.Size(224, 24);
            this.ColumnBtn.Text = "Column Chart";
            this.ColumnBtn.Click += new System.EventHandler(this.ColumnBtn_Click);
            // 
            // StackedColumnBtn
            // 
            this.StackedColumnBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            this.StackedColumnBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(104)))), ((int)(((byte)(89)))));
            this.StackedColumnBtn.Name = "StackedColumnBtn";
            this.StackedColumnBtn.Size = new System.Drawing.Size(224, 24);
            this.StackedColumnBtn.Text = "Stacked Column Chart";
            this.StackedColumnBtn.Click += new System.EventHandler(this.StackedColumnBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // LineBtn1
            // 
            this.LineBtn1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LineBtn,
            this.StepLineBtn,
            this.AreaBtn,
            this.toolStripMenuItem1,
            this.KagiBtn,
            this.BubbleBtn});
            this.LineBtn1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(104)))), ((int)(((byte)(89)))));
            this.LineBtn1.Image = ((System.Drawing.Image)(resources.GetObject("LineBtn1.Image")));
            this.LineBtn1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LineBtn1.Name = "LineBtn1";
            this.LineBtn1.Size = new System.Drawing.Size(29, 24);
            this.LineBtn1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.LineBtn1.ToolTipText = "Different line and area graph types";
            // 
            // LineBtn
            // 
            this.LineBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            this.LineBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(104)))), ((int)(((byte)(89)))));
            this.LineBtn.Name = "LineBtn";
            this.LineBtn.Size = new System.Drawing.Size(204, 24);
            this.LineBtn.Text = "Line Graph";
            this.LineBtn.Click += new System.EventHandler(this.LineBtn_Click);
            // 
            // StepLineBtn
            // 
            this.StepLineBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            this.StepLineBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(104)))), ((int)(((byte)(89)))));
            this.StepLineBtn.Name = "StepLineBtn";
            this.StepLineBtn.Size = new System.Drawing.Size(204, 24);
            this.StepLineBtn.Text = "Step Line Graph";
            this.StepLineBtn.Click += new System.EventHandler(this.StepLineBtn_Click);
            // 
            // AreaBtn
            // 
            this.AreaBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            this.AreaBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(104)))), ((int)(((byte)(89)))));
            this.AreaBtn.Name = "AreaBtn";
            this.AreaBtn.Size = new System.Drawing.Size(204, 24);
            this.AreaBtn.Text = "Area Chart";
            this.AreaBtn.Click += new System.EventHandler(this.SplineAreaBtn_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            this.toolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(104)))), ((int)(((byte)(89)))));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(204, 24);
            this.toolStripMenuItem1.Text = "Stacked Area Chart";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.StackedAreaBtn_Click);
            // 
            // KagiBtn
            // 
            this.KagiBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            this.KagiBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(104)))), ((int)(((byte)(89)))));
            this.KagiBtn.Name = "KagiBtn";
            this.KagiBtn.Size = new System.Drawing.Size(204, 24);
            this.KagiBtn.Text = "Kagi Chart";
            this.KagiBtn.Click += new System.EventHandler(this.KagiBtn_Click);
            // 
            // BubbleBtn
            // 
            this.BubbleBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            this.BubbleBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(104)))), ((int)(((byte)(89)))));
            this.BubbleBtn.Name = "BubbleBtn";
            this.BubbleBtn.Size = new System.Drawing.Size(204, 24);
            this.BubbleBtn.Text = "Bubble Plot";
            this.BubbleBtn.Click += new System.EventHandler(this.BubbleBtn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // PieBtn1
            // 
            this.PieBtn1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PieBtn,
            this.FunnelBtn,
            this.PyrimidBtn});
            this.PieBtn1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(104)))), ((int)(((byte)(89)))));
            this.PieBtn1.Image = ((System.Drawing.Image)(resources.GetObject("PieBtn1.Image")));
            this.PieBtn1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PieBtn1.Name = "PieBtn1";
            this.PieBtn1.Size = new System.Drawing.Size(29, 24);
            this.PieBtn1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.PieBtn1.ToolTipText = "Different pie chart types";
            // 
            // PieBtn
            // 
            this.PieBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            this.PieBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(104)))), ((int)(((byte)(89)))));
            this.PieBtn.Name = "PieBtn";
            this.PieBtn.Size = new System.Drawing.Size(180, 24);
            this.PieBtn.Text = "Pie Chart";
            this.PieBtn.Click += new System.EventHandler(this.PieBtn_Click);
            // 
            // FunnelBtn
            // 
            this.FunnelBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            this.FunnelBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(104)))), ((int)(((byte)(89)))));
            this.FunnelBtn.Name = "FunnelBtn";
            this.FunnelBtn.Size = new System.Drawing.Size(180, 24);
            this.FunnelBtn.Text = "Funnel Chart";
            this.FunnelBtn.Click += new System.EventHandler(this.FunnelBtn_Click);
            // 
            // PyrimidBtn
            // 
            this.PyrimidBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            this.PyrimidBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(104)))), ((int)(((byte)(89)))));
            this.PyrimidBtn.Name = "PyrimidBtn";
            this.PyrimidBtn.Size = new System.Drawing.Size(180, 24);
            this.PyrimidBtn.Text = "Pyramid Chart";
            this.PyrimidBtn.Click += new System.EventHandler(this.PyrimidBtn_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // ExitBtn
            // 
            this.ExitBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(85)))), ((int)(((byte)(35)))));
            this.ExitBtn.Image = ((System.Drawing.Image)(resources.GetObject("ExitBtn.Image")));
            this.ExitBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(53, 24);
            this.ExitBtn.Text = "Exit";
            this.ExitBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(104)))), ((int)(((byte)(89)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.VaxChart);
            this.panel1.Location = new System.Drawing.Point(12, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(736, 409);
            this.panel1.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            this.label5.Location = new System.Drawing.Point(26, 236);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "Standard Dev";
            // 
            // TotalDoseTxt
            // 
            this.TotalDoseTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            this.TotalDoseTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalDoseTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(85)))), ((int)(((byte)(35)))));
            this.TotalDoseTxt.Location = new System.Drawing.Point(26, 48);
            this.TotalDoseTxt.Name = "TotalDoseTxt";
            this.TotalDoseTxt.ReadOnly = true;
            this.TotalDoseTxt.Size = new System.Drawing.Size(130, 24);
            this.TotalDoseTxt.TabIndex = 7;
            this.TotalDoseTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.TotalDoseTxt, "Total vaccined administered");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            this.label3.Location = new System.Drawing.Point(26, 287);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Varriance";
            // 
            // TotalPatientTxt
            // 
            this.TotalPatientTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            this.TotalPatientTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalPatientTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(85)))), ((int)(((byte)(35)))));
            this.TotalPatientTxt.Location = new System.Drawing.Point(26, 100);
            this.TotalPatientTxt.Name = "TotalPatientTxt";
            this.TotalPatientTxt.ReadOnly = true;
            this.TotalPatientTxt.Size = new System.Drawing.Size(130, 24);
            this.TotalPatientTxt.TabIndex = 6;
            this.TotalPatientTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.TotalPatientTxt, "Total count of people vaccinated");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            this.label4.Location = new System.Drawing.Point(26, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "Total Doses";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            this.label2.Location = new System.Drawing.Point(26, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "People Vaccinated";
            // 
            // VarTxt
            // 
            this.VarTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            this.VarTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VarTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(85)))), ((int)(((byte)(35)))));
            this.VarTxt.Location = new System.Drawing.Point(26, 308);
            this.VarTxt.Name = "VarTxt";
            this.VarTxt.ReadOnly = true;
            this.VarTxt.Size = new System.Drawing.Size(130, 24);
            this.VarTxt.TabIndex = 4;
            this.VarTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // StdTxt
            // 
            this.StdTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            this.StdTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StdTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(85)))), ((int)(((byte)(35)))));
            this.StdTxt.Location = new System.Drawing.Point(26, 256);
            this.StdTxt.Name = "StdTxt";
            this.StdTxt.ReadOnly = true;
            this.StdTxt.Size = new System.Drawing.Size(130, 24);
            this.StdTxt.TabIndex = 3;
            this.StdTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.StdTxt, "Standard deviation of the dose number");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            this.label1.Location = new System.Drawing.Point(26, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Average Dose";
            // 
            // AvgTxt
            // 
            this.AvgTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            this.AvgTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AvgTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(85)))), ((int)(((byte)(35)))));
            this.AvgTxt.Location = new System.Drawing.Point(26, 152);
            this.AvgTxt.Name = "AvgTxt";
            this.AvgTxt.ReadOnly = true;
            this.AvgTxt.Size = new System.Drawing.Size(130, 24);
            this.AvgTxt.TabIndex = 0;
            this.AvgTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.AvgTxt, "Average dose number for patients");
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(104)))), ((int)(((byte)(89)))));
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.MovingAvgTxt);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.VarTxt);
            this.groupBox1.Controls.Add(this.AvgTxt);
            this.groupBox1.Controls.Add(this.TotalDoseTxt);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.StdTxt);
            this.groupBox1.Controls.Add(this.TotalPatientTxt);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            this.groupBox1.Location = new System.Drawing.Point(787, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(186, 362);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vaccine Information";
            this.toolTip1.SetToolTip(this.groupBox1, "Vaccine stats based on number of vaccines administered");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            this.label6.Location = new System.Drawing.Point(26, 183);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 18);
            this.label6.TabIndex = 11;
            this.label6.Text = "7 Day Rolling Avg";
            // 
            // MovingAvgTxt
            // 
            this.MovingAvgTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            this.MovingAvgTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MovingAvgTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(85)))), ((int)(((byte)(35)))));
            this.MovingAvgTxt.Location = new System.Drawing.Point(26, 204);
            this.MovingAvgTxt.Name = "MovingAvgTxt";
            this.MovingAvgTxt.ReadOnly = true;
            this.MovingAvgTxt.Size = new System.Drawing.Size(130, 24);
            this.MovingAvgTxt.TabIndex = 10;
            this.MovingAvgTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.MovingAvgTxt, "7 day rolling average for doses administered per day");
            // 
            // toolTip1
            // 
            this.toolTip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(104)))), ((int)(((byte)(89)))));
            this.toolTip1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(228)))), ((int)(((byte)(201)))));
            this.toolTip1.IsBalloon = true;
            // 
            // LoadBtn
            // 
            this.LoadBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(85)))), ((int)(((byte)(35)))));
            this.LoadBtn.Image = ((System.Drawing.Image)(resources.GetObject("LoadBtn.Image")));
            this.LoadBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LoadBtn.Name = "LoadBtn";
            this.LoadBtn.Size = new System.Drawing.Size(62, 24);
            this.LoadBtn.Text = "Load";
            this.LoadBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.LoadBtn.Click += new System.EventHandler(this.LoadBtn_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 27);
            // 
            // ChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(228)))), ((int)(((byte)(201)))));
            this.ClientSize = new System.Drawing.Size(985, 465);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChartForm";
            this.Load += new System.EventHandler(this.ChartForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.VaxChart)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart VaxChart;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton DataBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton ExitBtn;
        private System.Windows.Forms.ToolStripMenuItem RankingBtn;
        private System.Windows.Forms.ToolStripMenuItem TopDBtn;
        private System.Windows.Forms.ToolStripMenuItem RollOutBtn;
        private System.Windows.Forms.ToolStripMenuItem SeriesBtn;
        private System.Windows.Forms.ToolStripMenuItem CityBtn;
        private System.Windows.Forms.ToolStripMenuItem CountyBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox VarTxt;
        private System.Windows.Forms.TextBox StdTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox AvgTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TotalDoseTxt;
        private System.Windows.Forms.TextBox TotalPatientTxt;
        private System.Windows.Forms.ToolStripMenuItem SexBtn;
        private System.Windows.Forms.ToolStripMenuItem RaceBtn;
        private System.Windows.Forms.ToolStripMenuItem EthnicityBtn;
        private System.Windows.Forms.ToolStripMenuItem manufacturerToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox MovingAvgTxt;
        private System.Windows.Forms.ToolStripMenuItem TopMBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripDropDownButton BarBtn1;
        private System.Windows.Forms.ToolStripMenuItem BarBtn;
        private System.Windows.Forms.ToolStripMenuItem StackedBarBtn;
        private System.Windows.Forms.ToolStripMenuItem ColumnBtn;
        private System.Windows.Forms.ToolStripMenuItem StackedColumnBtn;
        private System.Windows.Forms.ToolStripDropDownButton LineBtn1;
        private System.Windows.Forms.ToolStripMenuItem AreaBtn;
        private System.Windows.Forms.ToolStripMenuItem KagiBtn;
        private System.Windows.Forms.ToolStripMenuItem BubbleBtn;
        private System.Windows.Forms.ToolStripDropDownButton PieBtn1;
        private System.Windows.Forms.ToolStripMenuItem PieBtn;
        private System.Windows.Forms.ToolStripMenuItem FunnelBtn;
        private System.Windows.Forms.ToolStripMenuItem PyrimidBtn;
        private System.Windows.Forms.ToolStripMenuItem LineBtn;
        private System.Windows.Forms.ToolStripMenuItem StepLineBtn;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripButton LoadBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    }
}