namespace BackpropNet
{
	partial class Form1
	{
		///<summary>
		///Required designer variable.
		///</summary>
		private System.ComponentModel.IContainer components = null;

		///<summary>
		///Clean up any resources being used.
		///</summary>
		///<param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		///<summary>
		///Required method for Designer support - do not modify
		///the contents of this method with the code editor.
		///</summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.tbOutputBox = new System.Windows.Forms.TextBox();
			this.btnBaseline = new System.Windows.Forms.Button();
			this.btnStop = new System.Windows.Forms.Button();
			this.chartTrain = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.btnTrain = new System.Windows.Forms.Button();
			this.txtSchema = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtLearnRate = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtTgtRMSError = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtTgtMaxEpochs = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.lbActLayer = new System.Windows.Forms.ListBox();
			this.networkBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.lbActFunction = new System.Windows.Forms.ListBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtWeitghtDivider = new System.Windows.Forms.TextBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.readDefaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveDefaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveNetAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.openCfgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveCfgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.readTrainingFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.readRunDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.btnCreateNet = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.txtTrainNumPasses = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtTrainParamFrom = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtTrainParamTo = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtTrainParamStep = new System.Windows.Forms.TextBox();
			this.cbDispUpdate = new System.Windows.Forms.CheckBox();
			this.btnTest = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabTrain = new System.Windows.Forms.TabPage();
			this.tabTest = new System.Windows.Forms.TabPage();
			this.chartTest = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.tabNet1 = new System.Windows.Forms.TabPage();
			this.chartError = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.tabWatch = new System.Windows.Forms.TabPage();
			this.propertyGrid1 = new AdamsLair.WinForms.PropertyEditing.PropertyGrid();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.splitContainer3 = new System.Windows.Forms.SplitContainer();
			this.label14 = new System.Windows.Forms.Label();
			this.chkCaseAutoAdvance = new System.Windows.Forms.CheckBox();
			this.label13 = new System.Windows.Forms.Label();
			this.btnTrainBatch = new System.Windows.Forms.Button();
			this.label12 = new System.Windows.Forms.Label();
			this.txtNumEpochs = new System.Windows.Forms.TextBox();
			this.btnEpoch = new System.Windows.Forms.Button();
			this.label11 = new System.Windows.Forms.Label();
			this.udCaseNumber = new System.Windows.Forms.NumericUpDown();
			this.btnBwdPass = new System.Windows.Forms.Button();
			this.btnFwdPass = new System.Windows.Forms.Button();
			this.btnStep = new System.Windows.Forms.Button();
			this.btnClearText = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.chartTrain)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.networkBindingSource)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabTrain.SuspendLayout();
			this.tabTest.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chartTest)).BeginInit();
			this.tabNet1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chartError)).BeginInit();
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
			((System.ComponentModel.ISupportInitialize)(this.udCaseNumber)).BeginInit();
			this.SuspendLayout();
			// 
			// tbOutputBox
			// 
			this.tbOutputBox.Location = new System.Drawing.Point(3, 3);
			this.tbOutputBox.Multiline = true;
			this.tbOutputBox.Name = "tbOutputBox";
			this.tbOutputBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tbOutputBox.Size = new System.Drawing.Size(207, 180);
			this.tbOutputBox.TabIndex = 0;
			this.tbOutputBox.WordWrap = false;
			// 
			// btnBaseline
			// 
			this.btnBaseline.Location = new System.Drawing.Point(216, 166);
			this.btnBaseline.Name = "btnBaseline";
			this.btnBaseline.Size = new System.Drawing.Size(66, 23);
			this.btnBaseline.TabIndex = 1;
			this.btnBaseline.Text = "Train Base";
			this.btnBaseline.UseVisualStyleBackColor = true;
			this.btnBaseline.Click += new System.EventHandler(this.btnTrainBaseline_Click);
			// 
			// btnStop
			// 
			this.btnStop.Location = new System.Drawing.Point(237, 163);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new System.Drawing.Size(75, 23);
			this.btnStop.TabIndex = 2;
			this.btnStop.Text = "Stop";
			this.btnStop.UseVisualStyleBackColor = true;
			this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
			// 
			// chartTrain
			// 
			chartArea1.Name = "ChartArea1";
			this.chartTrain.ChartAreas.Add(chartArea1);
			this.chartTrain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chartTrain.Location = new System.Drawing.Point(3, 3);
			this.chartTrain.Name = "chartTrain";
			series1.ChartArea = "ChartArea1";
			series1.Color = System.Drawing.Color.LightSalmon;
			series1.Name = "AveNumEpochs";
			series2.BorderWidth = 3;
			series2.ChartArea = "ChartArea1";
			series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
			series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			series2.Name = "PercGood";
			series2.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
			this.chartTrain.Series.Add(series1);
			this.chartTrain.Series.Add(series2);
			this.chartTrain.Size = new System.Drawing.Size(442, 247);
			this.chartTrain.TabIndex = 3;
			this.chartTrain.Text = "chart1";
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
			this.pictureBox1.Location = new System.Drawing.Point(217, 3);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(65, 157);
			this.pictureBox1.TabIndex = 4;
			this.pictureBox1.TabStop = false;
			// 
			// btnTrain
			// 
			this.btnTrain.Location = new System.Drawing.Point(237, 134);
			this.btnTrain.Name = "btnTrain";
			this.btnTrain.Size = new System.Drawing.Size(75, 23);
			this.btnTrain.TabIndex = 5;
			this.btnTrain.Text = "Train";
			this.btnTrain.UseVisualStyleBackColor = true;
			this.btnTrain.Click += new System.EventHandler(this.btnTrain_Click);
			// 
			// txtSchema
			// 
			this.txtSchema.Location = new System.Drawing.Point(78, 13);
			this.txtSchema.Name = "txtSchema";
			this.txtSchema.Size = new System.Drawing.Size(70, 20);
			this.txtSchema.TabIndex = 6;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(33, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(44, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "schema";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(26, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(51, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "learn rate";
			// 
			// txtLearnRate
			// 
			this.txtLearnRate.Location = new System.Drawing.Point(78, 33);
			this.txtLearnRate.Name = "txtLearnRate";
			this.txtLearnRate.Size = new System.Drawing.Size(35, 20);
			this.txtLearnRate.TabIndex = 8;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(360, 30);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(29, 13);
			this.label3.TabIndex = 11;
			this.label3.Text = "Error";
			// 
			// txtTgtRMSError
			// 
			this.txtTgtRMSError.Location = new System.Drawing.Point(389, 23);
			this.txtTgtRMSError.Name = "txtTgtRMSError";
			this.txtTgtRMSError.Size = new System.Drawing.Size(52, 20);
			this.txtTgtRMSError.TabIndex = 10;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(346, 50);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(43, 13);
			this.label4.TabIndex = 13;
			this.label4.Text = "Epochs";
			// 
			// txtTgtMaxEpochs
			// 
			this.txtTgtMaxEpochs.Location = new System.Drawing.Point(389, 43);
			this.txtTgtMaxEpochs.Name = "txtTgtMaxEpochs";
			this.txtTgtMaxEpochs.Size = new System.Drawing.Size(52, 20);
			this.txtTgtMaxEpochs.TabIndex = 12;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(80, 86);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(50, 13);
			this.label5.TabIndex = 15;
			this.label5.Text = "Act Func";
			// 
			// lbActLayer
			// 
			this.lbActLayer.DataSource = this.networkBindingSource;
			this.lbActLayer.DisplayMember = "Idx";
			this.lbActLayer.FormattingEnabled = true;
			this.lbActLayer.Location = new System.Drawing.Point(42, 101);
			this.lbActLayer.Name = "lbActLayer";
			this.lbActLayer.Size = new System.Drawing.Size(35, 82);
			this.lbActLayer.TabIndex = 16;
			this.lbActLayer.SelectedIndexChanged += new System.EventHandler(this.lbActLayer_SelectedIndexChanged);
			// 
			// networkBindingSource
			// 
			this.networkBindingSource.DataSource = typeof(BackpropNet.Network);
			// 
			// lbActFunction
			// 
			this.lbActFunction.FormattingEnabled = true;
			this.lbActFunction.Location = new System.Drawing.Point(83, 101);
			this.lbActFunction.Name = "lbActFunction";
			this.lbActFunction.Size = new System.Drawing.Size(65, 82);
			this.lbActFunction.TabIndex = 17;
			this.lbActFunction.SelectedIndexChanged += new System.EventHandler(this.lbActFunction_SelectedIndexChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(25, 60);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(52, 13);
			this.label6.TabIndex = 19;
			this.label6.Text = "wt divider";
			// 
			// txtWeitghtDivider
			// 
			this.txtWeitghtDivider.Location = new System.Drawing.Point(78, 53);
			this.txtWeitghtDivider.Name = "txtWeitghtDivider";
			this.txtWeitghtDivider.Size = new System.Drawing.Size(35, 20);
			this.txtWeitghtDivider.TabIndex = 18;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.configToolStripMenuItem,
            this.dataToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(932, 24);
			this.menuStrip1.TabIndex = 20;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exit_Click);
			// 
			// configToolStripMenuItem
			// 
			this.configToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readDefaultToolStripMenuItem,
            this.saveDefaultToolStripMenuItem,
            this.saveNetAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.openCfgToolStripMenuItem,
            this.saveCfgToolStripMenuItem,
            this.toolStripSeparator3,
            this.testToolStripMenuItem});
			this.configToolStripMenuItem.Name = "configToolStripMenuItem";
			this.configToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
			this.configToolStripMenuItem.Text = "&Network";
			// 
			// readDefaultToolStripMenuItem
			// 
			this.readDefaultToolStripMenuItem.Name = "readDefaultToolStripMenuItem";
			this.readDefaultToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
			this.readDefaultToolStripMenuItem.Text = "&Open Network";
			this.readDefaultToolStripMenuItem.Click += new System.EventHandler(this.openNetwork_Click);
			// 
			// saveDefaultToolStripMenuItem
			// 
			this.saveDefaultToolStripMenuItem.Name = "saveDefaultToolStripMenuItem";
			this.saveDefaultToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
			this.saveDefaultToolStripMenuItem.Text = "&Save Network";
			this.saveDefaultToolStripMenuItem.Click += new System.EventHandler(this.saveNetwork_Click);
			// 
			// saveNetAsToolStripMenuItem
			// 
			this.saveNetAsToolStripMenuItem.Name = "saveNetAsToolStripMenuItem";
			this.saveNetAsToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
			this.saveNetAsToolStripMenuItem.Text = "Save Network &As";
			this.saveNetAsToolStripMenuItem.Click += new System.EventHandler(this.saveNetworkAs_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(185, 6);
			// 
			// openCfgToolStripMenuItem
			// 
			this.openCfgToolStripMenuItem.Name = "openCfgToolStripMenuItem";
			this.openCfgToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
			this.openCfgToolStripMenuItem.Text = "Open Cfg";
			this.openCfgToolStripMenuItem.Click += new System.EventHandler(this.openCfg_Click);
			// 
			// saveCfgToolStripMenuItem
			// 
			this.saveCfgToolStripMenuItem.Name = "saveCfgToolStripMenuItem";
			this.saveCfgToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
			this.saveCfgToolStripMenuItem.Text = "Save Cfg";
			this.saveCfgToolStripMenuItem.Click += new System.EventHandler(this.saveCfg_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(185, 6);
			// 
			// testToolStripMenuItem
			// 
			this.testToolStripMenuItem.Name = "testToolStripMenuItem";
			this.testToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
			this.testToolStripMenuItem.Text = "Test 1 - write Baseline";
			this.testToolStripMenuItem.Click += new System.EventHandler(this.testWriteBaseline_Click);
			// 
			// dataToolStripMenuItem
			// 
			this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readTrainingFileToolStripMenuItem,
            this.toolStripSeparator2,
            this.readRunDataToolStripMenuItem});
			this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
			this.dataToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
			this.dataToolStripMenuItem.Text = "Training";
			// 
			// readTrainingFileToolStripMenuItem
			// 
			this.readTrainingFileToolStripMenuItem.Name = "readTrainingFileToolStripMenuItem";
			this.readTrainingFileToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
			this.readTrainingFileToolStripMenuItem.Text = "Read Train Data";
			this.readTrainingFileToolStripMenuItem.Click += new System.EventHandler(this.readTrainData_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(154, 6);
			// 
			// readRunDataToolStripMenuItem
			// 
			this.readRunDataToolStripMenuItem.Name = "readRunDataToolStripMenuItem";
			this.readRunDataToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
			this.readRunDataToolStripMenuItem.Text = "Read Test Data";
			this.readRunDataToolStripMenuItem.Click += new System.EventHandler(this.readTestData_Click);
			// 
			// btnCreateNet
			// 
			this.btnCreateNet.Location = new System.Drawing.Point(42, 192);
			this.btnCreateNet.Name = "btnCreateNet";
			this.btnCreateNet.Size = new System.Drawing.Size(106, 23);
			this.btnCreateNet.TabIndex = 21;
			this.btnCreateNet.Text = "Create";
			this.btnCreateNet.UseVisualStyleBackColor = true;
			this.btnCreateNet.Click += new System.EventHandler(this.btnCreateNet_Click);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(225, 27);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(48, 13);
			this.label7.TabIndex = 23;
			this.label7.Text = "#Passes";
			// 
			// txtTrainNumPasses
			// 
			this.txtTrainNumPasses.Location = new System.Drawing.Point(276, 23);
			this.txtTrainNumPasses.Name = "txtTrainNumPasses";
			this.txtTrainNumPasses.Size = new System.Drawing.Size(36, 20);
			this.txtTrainNumPasses.TabIndex = 22;
			this.txtTrainNumPasses.TextChanged += new System.EventHandler(this.txtNumTrainPasses_TextChanged);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(243, 46);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(30, 13);
			this.label8.TabIndex = 25;
			this.label8.Text = "From";
			// 
			// txtTrainParamFrom
			// 
			this.txtTrainParamFrom.Location = new System.Drawing.Point(276, 43);
			this.txtTrainParamFrom.Name = "txtTrainParamFrom";
			this.txtTrainParamFrom.Size = new System.Drawing.Size(36, 20);
			this.txtTrainParamFrom.TabIndex = 24;
			this.txtTrainParamFrom.TextChanged += new System.EventHandler(this.txtTrainParamFrom_TextChanged);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(243, 65);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(20, 13);
			this.label9.TabIndex = 27;
			this.label9.Text = "To";
			// 
			// txtTrainParamTo
			// 
			this.txtTrainParamTo.Location = new System.Drawing.Point(276, 62);
			this.txtTrainParamTo.Name = "txtTrainParamTo";
			this.txtTrainParamTo.Size = new System.Drawing.Size(36, 20);
			this.txtTrainParamTo.TabIndex = 26;
			this.txtTrainParamTo.TextChanged += new System.EventHandler(this.txtTrainParamTo_TextChanged);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(243, 85);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(29, 13);
			this.label10.TabIndex = 29;
			this.label10.Text = "Step";
			// 
			// txtTrainParamStep
			// 
			this.txtTrainParamStep.Location = new System.Drawing.Point(276, 82);
			this.txtTrainParamStep.Name = "txtTrainParamStep";
			this.txtTrainParamStep.Size = new System.Drawing.Size(36, 20);
			this.txtTrainParamStep.TabIndex = 28;
			this.txtTrainParamStep.TextChanged += new System.EventHandler(this.txtTrainParamStep_TextChanged);
			// 
			// cbDispUpdate
			// 
			this.cbDispUpdate.AutoSize = true;
			this.cbDispUpdate.Location = new System.Drawing.Point(173, 6);
			this.cbDispUpdate.Name = "cbDispUpdate";
			this.cbDispUpdate.Size = new System.Drawing.Size(15, 14);
			this.cbDispUpdate.TabIndex = 30;
			this.cbDispUpdate.UseVisualStyleBackColor = true;
			this.cbDispUpdate.CheckedChanged += new System.EventHandler(this.cbDispUpdate_CheckedChanged);
			// 
			// btnTest
			// 
			this.btnTest.Location = new System.Drawing.Point(237, 192);
			this.btnTest.Name = "btnTest";
			this.btnTest.Size = new System.Drawing.Size(75, 23);
			this.btnTest.TabIndex = 31;
			this.btnTest.Text = "Test";
			this.btnTest.UseVisualStyleBackColor = true;
			this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabTrain);
			this.tabControl1.Controls.Add(this.tabTest);
			this.tabControl1.Controls.Add(this.tabNet1);
			this.tabControl1.Controls.Add(this.tabWatch);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(456, 279);
			this.tabControl1.TabIndex = 32;
			// 
			// tabTrain
			// 
			this.tabTrain.Controls.Add(this.chartTrain);
			this.tabTrain.Location = new System.Drawing.Point(4, 22);
			this.tabTrain.Name = "tabTrain";
			this.tabTrain.Padding = new System.Windows.Forms.Padding(3);
			this.tabTrain.Size = new System.Drawing.Size(448, 253);
			this.tabTrain.TabIndex = 0;
			this.tabTrain.Text = "Train";
			this.tabTrain.UseVisualStyleBackColor = true;
			// 
			// tabTest
			// 
			this.tabTest.Controls.Add(this.chartTest);
			this.tabTest.Location = new System.Drawing.Point(4, 22);
			this.tabTest.Name = "tabTest";
			this.tabTest.Padding = new System.Windows.Forms.Padding(3);
			this.tabTest.Size = new System.Drawing.Size(448, 253);
			this.tabTest.TabIndex = 1;
			this.tabTest.Text = "Test";
			this.tabTest.UseVisualStyleBackColor = true;
			// 
			// chartTest
			// 
			chartArea2.Name = "ChartArea1";
			this.chartTest.ChartAreas.Add(chartArea2);
			this.chartTest.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chartTest.Location = new System.Drawing.Point(3, 3);
			this.chartTest.Name = "chartTest";
			series3.ChartArea = "ChartArea1";
			series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
			series3.Color = System.Drawing.Color.LightSalmon;
			series3.Name = "trainOutputs";
			series4.BorderWidth = 2;
			series4.ChartArea = "ChartArea1";
			series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
			series4.Name = "nodeOutputs";
			series5.ChartArea = "ChartArea1";
			series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
			series5.Color = System.Drawing.Color.Red;
			series5.Name = "nodeErrors";
			series5.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
			this.chartTest.Series.Add(series3);
			this.chartTest.Series.Add(series4);
			this.chartTest.Series.Add(series5);
			this.chartTest.Size = new System.Drawing.Size(442, 247);
			this.chartTest.TabIndex = 4;
			this.chartTest.Text = "chart1";
			// 
			// tabNet1
			// 
			this.tabNet1.Controls.Add(this.chartError);
			this.tabNet1.Location = new System.Drawing.Point(4, 22);
			this.tabNet1.Name = "tabNet1";
			this.tabNet1.Padding = new System.Windows.Forms.Padding(3);
			this.tabNet1.Size = new System.Drawing.Size(448, 253);
			this.tabNet1.TabIndex = 2;
			this.tabNet1.Text = "Error";
			this.tabNet1.UseVisualStyleBackColor = true;
			// 
			// chartError
			// 
			chartArea3.Name = "ChartArea1";
			this.chartError.ChartAreas.Add(chartArea3);
			this.chartError.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chartError.Location = new System.Drawing.Point(3, 3);
			this.chartError.Name = "chartError";
			series6.ChartArea = "ChartArea1";
			series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
			series6.Color = System.Drawing.Color.LightSalmon;
			series6.Name = "trainOutputs";
			series7.BorderWidth = 2;
			series7.ChartArea = "ChartArea1";
			series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
			series7.Name = "nodeOutputs";
			series8.ChartArea = "ChartArea1";
			series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
			series8.Color = System.Drawing.Color.Red;
			series8.Name = "nodeErrors";
			series8.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
			this.chartError.Series.Add(series6);
			this.chartError.Series.Add(series7);
			this.chartError.Series.Add(series8);
			this.chartError.Size = new System.Drawing.Size(442, 247);
			this.chartError.TabIndex = 5;
			this.chartError.Text = "chart1";
			// 
			// tabWatch
			// 
			this.tabWatch.Location = new System.Drawing.Point(4, 22);
			this.tabWatch.Name = "tabWatch";
			this.tabWatch.Size = new System.Drawing.Size(448, 253);
			this.tabWatch.TabIndex = 3;
			this.tabWatch.Text = "Watch";
			this.tabWatch.UseVisualStyleBackColor = true;
			// 
			// propertyGrid1
			// 
			this.propertyGrid1.AllowDrop = true;
			this.propertyGrid1.AutoScroll = true;
			this.propertyGrid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.ReadOnly = false;
			this.propertyGrid1.ShowNonPublic = false;
			this.propertyGrid1.Size = new System.Drawing.Size(468, 279);
			this.propertyGrid1.SplitterPosition = 187;
			this.propertyGrid1.SplitterRatio = 0.4F;
			this.propertyGrid1.TabIndex = 33;
			// 
			// splitContainer1
			// 
			this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
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
			this.splitContainer1.Size = new System.Drawing.Size(932, 537);
			this.splitContainer1.SplitterDistance = 281;
			this.splitContainer1.TabIndex = 36;
			// 
			// splitContainer2
			// 
			this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.tabControl1);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.propertyGrid1);
			this.splitContainer2.Size = new System.Drawing.Size(932, 281);
			this.splitContainer2.SplitterDistance = 458;
			this.splitContainer2.TabIndex = 0;
			// 
			// splitContainer3
			// 
			this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer3.Location = new System.Drawing.Point(0, 0);
			this.splitContainer3.Name = "splitContainer3";
			// 
			// splitContainer3.Panel1
			// 
			this.splitContainer3.Panel1.Controls.Add(this.label14);
			this.splitContainer3.Panel1.Controls.Add(this.chkCaseAutoAdvance);
			this.splitContainer3.Panel1.Controls.Add(this.label13);
			this.splitContainer3.Panel1.Controls.Add(this.btnTrainBatch);
			this.splitContainer3.Panel1.Controls.Add(this.label12);
			this.splitContainer3.Panel1.Controls.Add(this.txtNumEpochs);
			this.splitContainer3.Panel1.Controls.Add(this.btnEpoch);
			this.splitContainer3.Panel1.Controls.Add(this.label11);
			this.splitContainer3.Panel1.Controls.Add(this.udCaseNumber);
			this.splitContainer3.Panel1.Controls.Add(this.btnBwdPass);
			this.splitContainer3.Panel1.Controls.Add(this.btnFwdPass);
			this.splitContainer3.Panel1.Controls.Add(this.btnStep);
			this.splitContainer3.Panel1.Controls.Add(this.txtTgtRMSError);
			this.splitContainer3.Panel1.Controls.Add(this.txtTgtMaxEpochs);
			this.splitContainer3.Panel1.Controls.Add(this.btnTest);
			this.splitContainer3.Panel1.Controls.Add(this.txtWeitghtDivider);
			this.splitContainer3.Panel1.Controls.Add(this.btnStop);
			this.splitContainer3.Panel1.Controls.Add(this.lbActFunction);
			this.splitContainer3.Panel1.Controls.Add(this.btnTrain);
			this.splitContainer3.Panel1.Controls.Add(this.label6);
			this.splitContainer3.Panel1.Controls.Add(this.label10);
			this.splitContainer3.Panel1.Controls.Add(this.lbActLayer);
			this.splitContainer3.Panel1.Controls.Add(this.txtSchema);
			this.splitContainer3.Panel1.Controls.Add(this.btnCreateNet);
			this.splitContainer3.Panel1.Controls.Add(this.txtTrainParamStep);
			this.splitContainer3.Panel1.Controls.Add(this.label5);
			this.splitContainer3.Panel1.Controls.Add(this.label1);
			this.splitContainer3.Panel1.Controls.Add(this.txtTrainNumPasses);
			this.splitContainer3.Panel1.Controls.Add(this.label9);
			this.splitContainer3.Panel1.Controls.Add(this.label4);
			this.splitContainer3.Panel1.Controls.Add(this.txtLearnRate);
			this.splitContainer3.Panel1.Controls.Add(this.label7);
			this.splitContainer3.Panel1.Controls.Add(this.txtTrainParamTo);
			this.splitContainer3.Panel1.Controls.Add(this.txtTrainParamFrom);
			this.splitContainer3.Panel1.Controls.Add(this.label2);
			this.splitContainer3.Panel1.Controls.Add(this.label3);
			this.splitContainer3.Panel1.Controls.Add(this.label8);
			// 
			// splitContainer3.Panel2
			// 
			this.splitContainer3.Panel2.Controls.Add(this.btnClearText);
			this.splitContainer3.Panel2.Controls.Add(this.cbDispUpdate);
			this.splitContainer3.Panel2.Controls.Add(this.tbOutputBox);
			this.splitContainer3.Panel2.Controls.Add(this.pictureBox1);
			this.splitContainer3.Panel2.Controls.Add(this.btnBaseline);
			this.splitContainer3.Size = new System.Drawing.Size(932, 252);
			this.splitContainer3.SplitterDistance = 494;
			this.splitContainer3.TabIndex = 0;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(457, 120);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(29, 13);
			this.label14.TabIndex = 43;
			this.label14.Text = "Auto";
			// 
			// chkCaseAutoAdvance
			// 
			this.chkCaseAutoAdvance.AutoSize = true;
			this.chkCaseAutoAdvance.Location = new System.Drawing.Point(462, 138);
			this.chkCaseAutoAdvance.Name = "chkCaseAutoAdvance";
			this.chkCaseAutoAdvance.Size = new System.Drawing.Size(15, 14);
			this.chkCaseAutoAdvance.TabIndex = 42;
			this.chkCaseAutoAdvance.UseVisualStyleBackColor = true;
			this.chkCaseAutoAdvance.CheckedChanged += new System.EventHandler(this.chkCaseAutoAdvance_CheckedChanged);
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(39, 86);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(33, 13);
			this.label13.TabIndex = 41;
			this.label13.Text = "Layer";
			// 
			// btnTrainBatch
			// 
			this.btnTrainBatch.Location = new System.Drawing.Point(366, 75);
			this.btnTrainBatch.Name = "btnTrainBatch";
			this.btnTrainBatch.Size = new System.Drawing.Size(75, 23);
			this.btnTrainBatch.TabIndex = 40;
			this.btnTrainBatch.Text = "Train Batch";
			this.btnTrainBatch.UseVisualStyleBackColor = true;
			this.btnTrainBatch.Click += new System.EventHandler(this.btnTrainBatch_Click);
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(331, 120);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(43, 13);
			this.label12.TabIndex = 39;
			this.label12.Text = "Epochs";
			// 
			// txtNumEpochs
			// 
			this.txtNumEpochs.Location = new System.Drawing.Point(334, 134);
			this.txtNumEpochs.Name = "txtNumEpochs";
			this.txtNumEpochs.Size = new System.Drawing.Size(45, 20);
			this.txtNumEpochs.TabIndex = 38;
			this.txtNumEpochs.TextChanged += new System.EventHandler(this.txtNumEpochs_TextChanged);
			// 
			// btnEpoch
			// 
			this.btnEpoch.Location = new System.Drawing.Point(334, 160);
			this.btnEpoch.Name = "btnEpoch";
			this.btnEpoch.Size = new System.Drawing.Size(55, 23);
			this.btnEpoch.TabIndex = 37;
			this.btnEpoch.Text = "Epoch";
			this.btnEpoch.UseVisualStyleBackColor = true;
			this.btnEpoch.Click += new System.EventHandler(this.btnEpoch_Click);
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(403, 120);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(31, 13);
			this.label11.TabIndex = 36;
			this.label11.Text = "Case";
			// 
			// udCaseNumber
			// 
			this.udCaseNumber.Location = new System.Drawing.Point(405, 135);
			this.udCaseNumber.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.udCaseNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
			this.udCaseNumber.Name = "udCaseNumber";
			this.udCaseNumber.Size = new System.Drawing.Size(51, 20);
			this.udCaseNumber.TabIndex = 35;
			this.udCaseNumber.ValueChanged += new System.EventHandler(this.udCaseNumber_ValueChanged);
			// 
			// btnBwdPass
			// 
			this.btnBwdPass.Location = new System.Drawing.Point(442, 190);
			this.btnBwdPass.Name = "btnBwdPass";
			this.btnBwdPass.Size = new System.Drawing.Size(38, 24);
			this.btnBwdPass.TabIndex = 34;
			this.btnBwdPass.Text = "Bwd";
			this.btnBwdPass.UseVisualStyleBackColor = true;
			this.btnBwdPass.Click += new System.EventHandler(this.btnBwdPass_Click);
			// 
			// btnFwdPass
			// 
			this.btnFwdPass.Location = new System.Drawing.Point(401, 190);
			this.btnFwdPass.Name = "btnFwdPass";
			this.btnFwdPass.Size = new System.Drawing.Size(38, 24);
			this.btnFwdPass.TabIndex = 33;
			this.btnFwdPass.Text = "Fwd";
			this.btnFwdPass.UseVisualStyleBackColor = true;
			this.btnFwdPass.Click += new System.EventHandler(this.btnFwdPass_Click);
			// 
			// btnStep
			// 
			this.btnStep.Location = new System.Drawing.Point(401, 161);
			this.btnStep.Name = "btnStep";
			this.btnStep.Size = new System.Drawing.Size(79, 23);
			this.btnStep.TabIndex = 32;
			this.btnStep.Text = "Step";
			this.btnStep.UseVisualStyleBackColor = true;
			this.btnStep.Click += new System.EventHandler(this.btnStep_Click);
			// 
			// btnClearText
			// 
			this.btnClearText.Location = new System.Drawing.Point(70, 185);
			this.btnClearText.Name = "btnClearText";
			this.btnClearText.Size = new System.Drawing.Size(66, 23);
			this.btnClearText.TabIndex = 31;
			this.btnClearText.Text = "Clear";
			this.btnClearText.UseVisualStyleBackColor = true;
			this.btnClearText.Click += new System.EventHandler(this.btnClearText_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(932, 561);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "Backprop";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.chartTrain)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.networkBindingSource)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabTrain.ResumeLayout(false);
			this.tabTest.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.chartTest)).EndInit();
			this.tabNet1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.chartError)).EndInit();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.splitContainer3.Panel1.ResumeLayout(false);
			this.splitContainer3.Panel1.PerformLayout();
			this.splitContainer3.Panel2.ResumeLayout(false);
			this.splitContainer3.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
			this.splitContainer3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.udCaseNumber)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button btnBaseline;
		private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.DataVisualization.Charting.Chart chartTrain;
		public System.Windows.Forms.TextBox tbOutputBox;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button btnTrain;
		private System.Windows.Forms.TextBox txtSchema;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtLearnRate;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtTgtRMSError;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtTgtMaxEpochs;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ListBox lbActLayer;
		private System.Windows.Forms.BindingSource networkBindingSource;
		private System.Windows.Forms.ListBox lbActFunction;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtWeitghtDivider;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem readDefaultToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveDefaultToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem readTrainingFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveNetAsToolStripMenuItem;
		private System.Windows.Forms.Button btnCreateNet;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openCfgToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveCfgToolStripMenuItem;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtTrainParamFrom;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtTrainParamTo;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtTrainParamStep;
		private System.Windows.Forms.CheckBox cbDispUpdate;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem readRunDataToolStripMenuItem;
		private System.Windows.Forms.Button btnTest;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabTrain;
		private System.Windows.Forms.TabPage tabTest;
		private System.Windows.Forms.DataVisualization.Charting.Chart chartTest;
		private System.Windows.Forms.TabPage tabNet1;
		private System.Windows.Forms.DataVisualization.Charting.Chart chartError;
		private System.Windows.Forms.TabPage tabWatch;
		private AdamsLair.WinForms.PropertyEditing.PropertyGrid propertyGrid1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.SplitContainer splitContainer3;
		private System.Windows.Forms.TextBox txtTrainNumPasses;
		private System.Windows.Forms.Button btnBwdPass;
		private System.Windows.Forms.Button btnFwdPass;
		private System.Windows.Forms.Button btnStep;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.NumericUpDown udCaseNumber;
		private System.Windows.Forms.Button btnEpoch;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txtNumEpochs;
		private System.Windows.Forms.Button btnClearText;
		private System.Windows.Forms.Button btnTrainBatch;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.CheckBox chkCaseAutoAdvance;
	}
}

