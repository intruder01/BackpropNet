using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackpropNet
{

	public partial class Form1 : Form
	{
		public Network net;
		private TrainingController trainCtrl;
		private TrainingController testCtrl;
		public static Random r = new Random();
		public bool bStopRequest = false;

		public string filesLocation;//location of training files
		public string cfgFilename;	//last open config file
		public string netFilename;	//last open net file
		public string trainFilename;//last open train data file
		public bool bDispEnabled;   //display updates are enabled
		public string testFilename; //last open run data file

		private int winSizeWidth, winSizeHeight;
		private int splitContainer1Pos;
		private int splitContainer2Pos;
		private int splitContainer3Pos;
		

		public Form1()
		{
			InitializeComponent();

			readSettings();	//get registry settings

			net = new Network(0);
			trainCtrl = new TrainingController();
			testCtrl = new TrainingController();

			//activation list boxes
			this.lbActLayer.SelectedIndexChanged -= new System.EventHandler(this.lbActLayer_SelectedIndexChanged);
			this.lbActFunction.SelectedIndexChanged -= new System.EventHandler(this.lbActFunction_SelectedIndexChanged);

			lbActLayer.DataSource = net.layers;
			lbActLayer.DisplayMember = "Idx";
			lbActLayer.ValueMember = "Idx";

			lbActFunction.Items.Add(new actLogistic());
			lbActFunction.Items.Add(new actLogisticBipolar());
			lbActFunction.Items.Add(new actTanH());
			lbActFunction.Items.Add(new actLinear());
			lbActFunction.DisplayMember = "funcName";

			this.lbActLayer.SelectedIndexChanged += new System.EventHandler(this.lbActLayer_SelectedIndexChanged);
			this.lbActFunction.SelectedIndexChanged += new System.EventHandler(this.lbActFunction_SelectedIndexChanged);

			//UI fields
			cbDispUpdate.Checked = bDispEnabled;

			this.Width = winSizeWidth;
			this.Height = winSizeHeight;
			splitContainer1.SplitterDistance = splitContainer1Pos;
			splitContainer2.SplitterDistance = splitContainer2Pos;
			splitContainer3.SplitterDistance = splitContainer3Pos;

			//load last set of files
			net.ReadXML(netFilename);
			net.FinalizeNetwork();
			propertyGrid1.SelectObject(net, false, 200);
			ConfigToUI();
			trainCtrl.ReadConfig(filesLocation + "trainCtrlrConfig.xml");  //train parameters
			trainCtrl.ReadData(trainFilename);       //train data
			TrainCtrlrToUI();
			testCtrl.ReadConfig(filesLocation + "testCtrlrConfig.xml");	//test parameters
			testCtrl.ReadData(testFilename);         //test data
			UpdateTitle();

		}


		//private double train()
		//{
		//	//the input values
		//	double[,] inputs =
		//	{
		//		{ 0, 0},
		//		{ 0, 1},
		//		{ 1, 0},
		//		{ 1, 1}
		//	};

		//	//desired results
		//	double[] results = { 0, 1, 1, 0 };
		//	double[] errors = new double[4];
		//	double rmsError = 0.9999;

		//	//creating the neurons
		//	Neuron hiddenNeuron1 = new Neuron();
		//	Neuron hiddenNeuron2 = new Neuron();
		//	Neuron outputNeuron = new Neuron();

		//	//random weights
		//	hiddenNeuron1.randomizeWeights();
		//	hiddenNeuron2.randomizeWeights();
		//	outputNeuron.randomizeWeights();

		//	int epoch = 0;

		//	do
		//	{
		//		epoch++;
		//		for (int i = 0; i < 4; i++)  //very important, do NOT train for only one example
		//		{
		//			//1) forward propagation (calculates output)
		//			hiddenNeuron1.inputs = new double[] { inputs[i, 0], inputs[i, 1] };
		//			hiddenNeuron2.inputs = new double[] { inputs[i, 0], inputs[i, 1] };

		//			outputNeuron.inputs = new double[] { hiddenNeuron1.output, hiddenNeuron2.output };

		//			//txtBox1.AppendText(String.Format("epoch {0}   {1} xor {2} = {3:F8}   rmsErr= {4:F8}", epoch, inputs[i, 0], inputs[i, 1], outputNeuron.output, rmsError));

		//			//2) back propagation (adjusts weights)

		//			//adjusts the weight of the output neuron, based on it's error
		//			outputNeuron.error = Sigmoid.derivative(outputNeuron.output) * (results[i] - outputNeuron.output);
		//			errors[i] = outputNeuron.error;
		//			outputNeuron.adjustWeights();

		//			//then adjusts the hidden neurons' weights, based on their errors
		//			hiddenNeuron1.error = Sigmoid.derivative(hiddenNeuron1.output) * outputNeuron.error * outputNeuron.weights[0];
		//			hiddenNeuron2.error = Sigmoid.derivative(hiddenNeuron2.output) * outputNeuron.error * outputNeuron.weights[1];

		//			hiddenNeuron1.adjustWeights();
		//			hiddenNeuron2.adjustWeights();
		//		}

		//		rmsError = 0.0;
		//		for (int i = 0; i < 4; i++)
		//		{
		//			rmsError += Math.Pow(errors[i], 2);
		//		}
		//		rmsError = Math.Sqrt(rmsError);
		//	}
		//	while (epoch < 10000 && rmsError > 0.001);

		//	//txtBox1.AppendText(String.Format("Train epochs {0}  final rmsErr= {1:F8} ", epoch, rmsError));
		//	//if(rmsError > 0.001)
		//	//	txtBox1.AppendText("  FAILED\n");
		//	//else
		//	//	txtBox1.AppendText("\n");

		//	return rmsError;
		//}

		//private void btnTrain_Click_org(object sender, EventArgs e)
		//{
		//	int numPasses = 0;
		//	int numGood = 0;
		//	int aveEpochs = 0;

		//	btnStop.Focus();
		//	btnStop.Refresh();
		//	bStopRequest = false;
		//	txtBox1.Text = "";

		//	chartTrain.ChartAreas["ChartArea1"].AxisY.Maximum = 0;
		//	chartTrain.Series["PercGood"].Points.Clear();
		//	chartTrain.Series["AveNumEpochs"].Points.Clear();

		//	net.finalizeNetStructure();

		//	for (double param = trainParamFrom; param <= trainParamTo; param += trainParamStep)
		//	{
		//		numPasses = 0;
		//		numGood = 0;
		//		aveEpochs = 0;

		//		//net.cfg.learnRate = param;
		//		ConfigToUI(net.cfg);

		//		for (int pass = 0; pass < trainPasses; pass++)
		//		{
		//			numPasses++;

		//			//if doing parameter run - randomize each pass
		//			if (trainParamFrom != trainParamTo)
		//				net.randomizeWeights(r);

		//			if (net.train(this, txtBox1, bDispUpdate, trainCtrl) < net.cfg.rmsErrorTarget)
		//				numGood++;

		//			aveEpochs += net.epoch;

		//			if (bStopRequest)
		//				break;
		//			//txtBox1.AppendText(String.Format("Attempt  {0}   Good {1}    Good% {2:F2}\n", i, numGood, (double)numGood/(double)numAttempts * 100.0));
		//			Application.DoEvents();
		//		}

		//		double percGood = (double)numGood / (double)numPasses * 100.0;
		//		aveEpochs /= numPasses;

		//		chartTrain.ChartAreas["ChartArea1"].AxisX.Minimum = 0;
		//		chartTrain.ChartAreas["ChartArea1"].AxisY.Minimum = 0;
		//		if (aveEpochs > chartTrain.ChartAreas["ChartArea1"].AxisY.Maximum)
		//			chartTrain.ChartAreas["ChartArea1"].AxisY.Maximum = aveEpochs;
		//		chartTrain.ChartAreas["ChartArea1"].AxisY2.Minimum = 0;
		//		chartTrain.ChartAreas["ChartArea1"].AxisY2.Maximum = 100;

		//		chartTrain.Series["PercGood"].Points.AddXY(param, percGood);
		//		chartTrain.Series["AveNumEpochs"].Points.AddXY(param, aveEpochs);
		//		//txtBox1.AppendText(String.Format("Param: {0:F2}  Passes: {1}  Good: {2}  %: {3:F2}  AveEpochs {4}\n", param, numPasses, numGood, percGood, aveEpochs));

		//		if (bStopRequest)
		//		{
		//			txtBox1.AppendText("   STOPPED\n");
		//			break;
		//		}
		//	}
		//}

		private void btnTrainBatch_Click(object sender, EventArgs e)
		{
			btnStop.Focus();
			btnStop.Refresh();
			bStopRequest = false;
			tbOutputBox.Text = "";

			chartTrain.Series["PercGood"].Points.Clear();
			chartTrain.Series["AveNumEpochs"].Points.Clear();
			chartTrain.ChartAreas["ChartArea1"].AxisY.Maximum = trainCtrl.Cfg.tgtEpochs;
			
			//update parameters from UI
			ConfigFromUI();
			net.FinalizeNetwork();
			TrainCtrlrFromUI();
			
			for (double par = trainCtrl.Cfg.trainParamFrom; par <= trainCtrl.Cfg.trainParamTo; par += trainCtrl.Cfg.trainParamStep)
			{
				trainCtrl.NumPasses = 0;
				trainCtrl.NumGood = 0;
				trainCtrl.AveNumEpochs = 0;

				//transfer parameter to network
				//net.cfg.learnRate = par;

				ConfigToUI();
				TrainCtrlrToUI();

				for (int pass = 0; pass < trainCtrl.Cfg.trainPasses; pass++)
				{
					trainCtrl.NumPasses++;

					//if doing parameter run - randomize each pass
					//if (trainCtrl.cfg.trainParamFrom != trainCtrl.cfg.trainParamTo)
						net.RandomizeWeights(r);

					if (trainCtrl.Train(net, this, tbOutputBox, bDispEnabled))
						trainCtrl.NumGood++;

					trainCtrl.AveNumEpochs += trainCtrl.NumEpochsRan;

					if (bStopRequest)
						break;
					//txtBox1.AppendText(String.Format("Attempt  {0}   Good {1}    Good% {2:F2}\n", i, numGood, (double)numGood/(double)numAttempts * 100.0));
					Application.DoEvents();
				}

				double percGood = (double)trainCtrl.NumGood / (double)trainCtrl.NumPasses * 100.0;
				trainCtrl.AveNumEpochs /= trainCtrl.NumPasses;

				chartTrain.ChartAreas["ChartArea1"].AxisX.Minimum = 0;
				chartTrain.ChartAreas["ChartArea1"].AxisY.Minimum = 0;
				if (trainCtrl.AveNumEpochs > chartTrain.ChartAreas["ChartArea1"].AxisY.Maximum)
					chartTrain.ChartAreas["ChartArea1"].AxisY.Maximum = trainCtrl.AveNumEpochs;
				chartTrain.ChartAreas["ChartArea1"].AxisY2.Minimum = 0;
				chartTrain.ChartAreas["ChartArea1"].AxisY2.Maximum = 100;

				chartTrain.Series["PercGood"].Points.AddXY(par, percGood);
				chartTrain.Series["AveNumEpochs"].Points.AddXY(par, trainCtrl.AveNumEpochs);
				//txtBox1.AppendText(String.Format("Param: {0:F2}  Passes: {1}  Good: {2}  %: {3:F2}  AveEpochs {4}\n", param, numPasses, numGood, percGood, aveEpochs));

				if (bStopRequest)
				{
					tbOutputBox.AppendText("   STOPPED\n");
					break;
				}
			}
		}

		private void btnTrain_Click(object sender, EventArgs e)
		{
			btnStop.Focus();
			btnStop.Refresh();
			bStopRequest = false;
			tbOutputBox.Text = "";

			chartTrain.Series["PercGood"].Points.Clear();
			chartTrain.Series["AveNumEpochs"].Points.Clear();
			chartTrain.ChartAreas["ChartArea1"].AxisY.Maximum = trainCtrl.Cfg.tgtEpochs;

			net.FinalizeNetwork();
			TrainCtrlrFromUI();

			trainCtrl.NumPasses = 0;
			trainCtrl.NumGood = 0;
			trainCtrl.AveNumEpochs = 0;

			ConfigToUI();
			TrainCtrlrToUI();

			trainCtrl.NumPasses++;

			//if doing parameter run - randomize each pass
			//if (trainCtrl.cfg.trainParamFrom != trainCtrl.cfg.trainParamTo)
				net.RandomizeWeights(r);

			if (trainCtrl.Train(net, this, tbOutputBox, bDispEnabled))
				trainCtrl.NumGood++;

			trainCtrl.AveNumEpochs += trainCtrl.NumEpochsRan;
			trainCtrl.PercGood = (double)trainCtrl.NumGood / (double)trainCtrl.NumPasses * 100.0;
			trainCtrl.AveNumEpochs /= trainCtrl.NumPasses;

			chartTrain.ChartAreas["ChartArea1"].AxisX.Minimum = 0;
			chartTrain.ChartAreas["ChartArea1"].AxisY.Minimum = 0;
			if (trainCtrl.AveNumEpochs > chartTrain.ChartAreas["ChartArea1"].AxisY.Maximum)
				chartTrain.ChartAreas["ChartArea1"].AxisY.Maximum = trainCtrl.AveNumEpochs;
			chartTrain.ChartAreas["ChartArea1"].AxisY2.Minimum = 0;
			chartTrain.ChartAreas["ChartArea1"].AxisY2.Maximum = 100;

			chartTrain.Series["PercGood"].Points.AddXY(0, trainCtrl.PercGood);
			chartTrain.Series["AveNumEpochs"].Points.AddXY(0, trainCtrl.AveNumEpochs);
			//txtBox1.AppendText(String.Format("Param: {0:F2}  Passes: {1}  Good: {2}  %: {3:F2}  AveEpochs {4}\n", param, numPasses, numGood, percGood, aveEpochs));

		}

		private void btnTest_Click(object sender, EventArgs e)
		{
			btnStop.Focus();
			btnStop.Refresh();
			bStopRequest = false;
			tbOutputBox.Text = "";

			//tabControl1.SelectTab("tabTest");
			chartTest.Series["trainOutputs"].Points.Clear();
			chartTest.Series["nodeOutputs"].Points.Clear();
			chartTest.Series["nodeErrors"].Points.Clear();
			chartTest.ChartAreas["ChartArea1"].AxisY.Maximum = 0;
			chartTest.ChartAreas["ChartArea1"].AxisX.Minimum = 0;
			chartTest.ChartAreas["ChartArea1"].AxisY.Minimum = 0;
			chartTest.ChartAreas["ChartArea1"].AxisY2.Minimum = 0;
			chartTest.ChartAreas["ChartArea1"].AxisY2.Maximum = 0;

			ConfigToUI();
			TrainCtrlrFromUI();

			net.FinalizeNetwork();


			//net.test(txtBox1, bDispUpdate, testCtrl);
			testCtrl.Test(net, this, tbOutputBox, bDispEnabled);
			Application.DoEvents();


			//double percGood = (double)numGood / (double)numPasses * 100.0;
			//aveEpochs /= numPasses;


			for (int i=0; i< testCtrl.Data.Cases.Count;i++)
			{
				TrainingCase cas = testCtrl.Data.Cases[i];
				//scale trainOutputs Y
				if (cas.trainOutputs[0] > chartTest.ChartAreas["ChartArea1"].AxisY.Maximum)
					chartTest.ChartAreas["ChartArea1"].AxisY.Maximum = cas.trainOutputs[0];
				//scale nodeOutputs Y
				if (cas.nodeOutputs[0] > chartTest.ChartAreas["ChartArea1"].AxisY.Maximum)
					chartTest.ChartAreas["ChartArea1"].AxisY.Maximum = cas.nodeOutputs[0];
				//scale nodeErrors Y2
				if (cas.nodeErrors[0] > chartTest.ChartAreas["ChartArea1"].AxisY2.Maximum)
					chartTest.ChartAreas["ChartArea1"].AxisY2.Maximum = cas.nodeErrors[0];
				if (cas.nodeErrors[0] < chartTest.ChartAreas["ChartArea1"].AxisY2.Minimum)
					chartTest.ChartAreas["ChartArea1"].AxisY2.Minimum = cas.nodeErrors[0];

				chartTest.Series["trainOutputs"].Points.AddXY(i, cas.trainOutputs[0]);
				chartTest.Series["nodeOutputs"].Points.AddXY(i, cas.nodeOutputs[0]);
				chartTest.Series["nodeErrors"].Points.AddXY(i, cas.nodeErrors[0]);
			}
		}

		private void btnTrainBaseline_Click(object sender, EventArgs e)
		{
			btnStop.Focus();
			btnStop.Refresh();
			bStopRequest = false;

			chartTrain.ChartAreas["ChartArea1"].AxisY.Maximum = 0;
			chartTrain.Series["PercGood"].Points.Clear();
			chartTrain.Series["AveNumEpochs"].Points.Clear();

			//network schema
			//2 - num inputs
			//2 - num nodes in 1st layer (hidden)
			//1 - num nodes in 2nd layer (output)
			//etc...
			//int[] schema = new int[] { 2, 2, 1 };

			net.cfg.learnRate = 0.8;
			net.cfg.weightDivider = 10;
			net.CreateNetworkBaseline();

			trainCtrl.Data.makeXORData();
			trainCtrl.Cfg.tgtRmsError = 0.001;
			trainCtrl.Cfg.tgtEpochs = 5000;

			trainCtrl.NumPasses = 1;
			trainCtrl.NumGood = 0;
			trainCtrl.AveNumEpochs = 0;


			if (trainCtrl.Train(net, this, tbOutputBox, bDispEnabled))
				trainCtrl.NumGood++;

			trainCtrl.AveNumEpochs += trainCtrl.NumEpochsRan;

			//txtBox1.AppendText(String.Format("Attempt  {0}   Good {1}    Good% {2:F2}\n", i, numGood, (double)numGood/(double)numAttempts * 100.0));
			Application.DoEvents();
			
			double percGood = (double)trainCtrl.NumGood / (double)trainCtrl.NumPasses * 100.0;
			trainCtrl.AveNumEpochs /= trainCtrl.NumPasses;

			chartTrain.ChartAreas["ChartArea1"].AxisX.Minimum = 0;
			chartTrain.ChartAreas["ChartArea1"].AxisY.Minimum = 0;
			if (trainCtrl.AveNumEpochs > chartTrain.ChartAreas["ChartArea1"].AxisY.Maximum)
				chartTrain.ChartAreas["ChartArea1"].AxisY.Maximum = trainCtrl.AveNumEpochs;
			chartTrain.ChartAreas["ChartArea1"].AxisY2.Minimum = 0;
			chartTrain.ChartAreas["ChartArea1"].AxisY2.Maximum = 100;

			chartTrain.Series["PercGood"].Points.AddXY(1, percGood);
			chartTrain.Series["AveNumEpochs"].Points.AddXY(1, trainCtrl.AveNumEpochs);
			//txtBox1.AppendText(String.Format("Param: {0:F2}  Passes: {1}  Good: {2}  %: {3:F2}  AveEpochs {4}\n", param, numPasses, numGood, percGood, aveEpochs));

		}

		private void btnStop_Click(object sender, EventArgs e)
		{
			bStopRequest = true;
			tbOutputBox.AppendText("   STOP\n"); 
			Application.DoEvents();
		}

		private void btnEpoch_Click(object sender, EventArgs e)
		{
			trainCtrl.Epoch(net, this, tbOutputBox, bDispEnabled);
		}
		private void btnStep_Click(object sender, EventArgs e)
		{
			trainCtrl.Step(net, this, tbOutputBox, bDispEnabled);
		}
		private void btnFwdPass_Click(object sender, EventArgs e)
		{
			trainCtrl.ForwardPass(net, this, tbOutputBox, bDispEnabled);
		}
		private void btnBwdPass_Click(object sender, EventArgs e)
		{
			trainCtrl.BackwardPass(net, this, tbOutputBox, bDispEnabled);
		}

		private void lbActLayer_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbActLayer.SelectedItem != null)
			{
				//Layer selLayer = (Layer)lbActLayer.SelectedItem;
				int lrIdx = lbActLayer.SelectedIndex;
				Layer selLayer = net.layers[lrIdx];
				int index = lbActFunction.FindString(selLayer.actFunc.funcName);
				lbActFunction.SetSelected(index, true);
			}
		}

		private void lbActFunction_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbActFunction.SelectedItem != null)
			{
				if (lbActLayer.SelectedItem != null)
				{
					//Layer selLayer = (Layer)lbActLayer.SelectedItem;
					int lrIdx = lbActLayer.SelectedIndex;
					Layer selLayer = net.layers[lrIdx];
					Activation selActFunction = (Activation)lbActFunction.SelectedItem;
					selLayer.actFunc = selActFunction;
				}
			}
		}

		//read schema string
		private List<int> stringToSchema(string text)
		{
			List<int> res = new List<int>();
			string[] split = text.Split(new char[] { ',', ';', '.' });
			foreach (string s in split)
			{
				int i = Convert.ToInt32(s);
				res.Add(i);
			}
			return res;
		}

		private string schemaToString(List<int> schema)
		{
			string res = "";
			string result = "";
			if(schema != null && schema.Count > 0)
			{
				foreach(int i in schema)
				{
					res += i.ToString() + ",";
				}
			}
			if (res.Length > 0)
				result = res.Substring(0, res.Length - 1);
			return result;
		}

		public NetworkConfig ConfigFromUI()
		{
			NetworkConfig cfg = new NetworkConfig();
			cfg.schema = stringToSchema(txtSchema.Text);
			cfg.learnRate = Convert.ToDouble(txtLearnRate.Text); //0.8
			cfg.weightDivider = Convert.ToInt32(txtWeitghtDivider.Text); //10;
			return cfg;
		}
		public void ConfigToUI()
		{
			//fill network config fields
			txtSchema.Text = schemaToString(net.cfg.schema);
			txtLearnRate.Text = net.cfg.learnRate.ToString();
			txtWeitghtDivider.Text = net.cfg.weightDivider.ToString();
			lbActLayer.DataSource = net.layers;
		}

		public void TrainCtrlrFromUI()
		{
			trainCtrl.Cfg.tgtRmsError = Convert.ToDouble(txtTgtRMSError.Text);//0.001;
			trainCtrl.Cfg.tgtEpochs = Convert.ToInt32(txtTgtMaxEpochs.Text); //5000;
			trainCtrl.Cfg.trainPasses = Convert.ToInt32(txtTrainNumPasses.Text);
			trainCtrl.Cfg.trainParamFrom = Convert.ToDouble(txtTrainParamFrom.Text);
			trainCtrl.Cfg.trainParamTo = Convert.ToDouble(txtTrainParamTo.Text);
			trainCtrl.Cfg.trainParamStep = Convert.ToDouble(txtTrainParamStep.Text);
			trainCtrl.Cfg.trainEpochs = Convert.ToInt32(txtNumEpochs.Text);
			trainCtrl.CurrCase = Convert.ToInt32(udCaseNumber.Value);//case number up/dn
			trainCtrl.Cfg.bStepAutoAdvance = Convert.ToBoolean(chkCaseAutoAdvance.Checked);
		}
		public void TrainCtrlrToUI()
		{
			txtTgtRMSError.Text = trainCtrl.Cfg.tgtRmsError.ToString();//0.001;
			txtTgtMaxEpochs.Text = trainCtrl.Cfg.tgtEpochs.ToString();//5000;
			txtTrainNumPasses.Text = trainCtrl.Cfg.trainPasses.ToString();
			txtTrainParamFrom.Text = trainCtrl.Cfg.trainParamFrom.ToString();
			txtTrainParamTo.Text = trainCtrl.Cfg.trainParamTo.ToString();
			txtTrainParamStep.Text = trainCtrl.Cfg.trainParamStep.ToString();
			txtNumEpochs.Text = trainCtrl.NumEpochsRan.ToString();
			udCaseNumber.Value = trainCtrl.CurrCase;    //case number up/dn
			udCaseNumber.Minimum = -1; //allow wrap around
			udCaseNumber.Maximum = trainCtrl.Data.Cases.Count; //allow wrap around
			chkCaseAutoAdvance.Checked = trainCtrl.Cfg.bStepAutoAdvance;

		}

		private void UpdateTitle()
		{
			string title = "Backprop";
			if(netFilename.Length >0)
				title += String.Format(" Net: {0}", Path.GetFileName(netFilename));
			if (trainFilename.Length > 0)
				title += String.Format(" Train: {0}", Path.GetFileName(trainFilename));
			if (testFilename.Length > 0)
				title += String.Format(" Test: {0}", Path.GetFileName(testFilename));

			this.Text = title;
		}

		private void exit_Click(object sender, EventArgs e)
		{
			saveSettings();
			Close();
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			trainCtrl.WriteConfig(filesLocation + "trainCtrlrConfig.xml");
			testCtrl.WriteConfig(filesLocation + "testCtrlrConfig.xml");
			saveSettings();
		}

		private void openCfg_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.InitialDirectory = filesLocation;
			dlg.Filter = "XML Files|*.xml|All Files|*.*";
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				filesLocation = Path.GetDirectoryName(dlg.FileName) + "\\";
				netFilename = Path.GetFullPath(dlg.FileName);
				saveSettings();
				net.ReadConfig(dlg.FileName);
				net.CreateNetwork();
				net.FinalizeNetwork();
				ConfigToUI();
			}
			UpdateTitle();
		}

		private void saveCfg_Click(object sender, EventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.InitialDirectory = filesLocation;
			dlg.Filter = "XML Files|*.xml|All Files|*.*";
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				filesLocation = Path.GetDirectoryName(dlg.FileName) + "\\";
				cfgFilename = Path.GetFullPath(dlg.FileName);
				saveSettings();
				net.WriteConfig(dlg.FileName);
			}
		}

		private void openNetwork_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.InitialDirectory = filesLocation;
			dlg.FileName = netFilename;
			dlg.Filter = "XML Files|*.xml|All Files|*.*";
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				filesLocation = Path.GetDirectoryName(dlg.FileName) + "\\";
				netFilename = Path.GetFullPath(dlg.FileName);
				saveSettings();
				net.ReadXML(dlg.FileName);
				net.FinalizeNetwork();
				ConfigToUI();
				propertyGrid1.SelectObject(net, false, 200);
			}
			UpdateTitle();
		}

		private void saveNetwork_Click(object sender, EventArgs e)
		{
			if(MessageBox.Show(@"Save current network ?" + Environment.NewLine + netFilename, "Save Network", MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				net.WriteXML(filesLocation + netFilename);
			}
		}

		private void saveNetworkAs_Click(object sender, EventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.InitialDirectory = filesLocation;
			dlg.FileName = netFilename;
			dlg.Filter = "XML Files|*.xml|All Files|*.*";
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				filesLocation = Path.GetDirectoryName(dlg.FileName) + "\\";
				netFilename = Path.GetFullPath(dlg.FileName);
				saveSettings();
				//net.cfg = readConfigUI();   //update from fields
				//net.writeConfig(dlg.FileName);
				net.WriteXML(dlg.FileName);
			}
		}
		private void readTrainData_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.InitialDirectory = filesLocation;
			dlg.FileName = trainFilename;
			dlg.Filter = "CSV Files|*.csv|All Files|*.*";
			if(dlg.ShowDialog() == DialogResult.OK)
			{
				filesLocation = Path.GetDirectoryName(dlg.FileName) + "\\";
				trainFilename = Path.GetFullPath(dlg.FileName);
				saveSettings();
				trainCtrl.Data.ReadCSV(dlg.FileName);
			}
			UpdateTitle();
		}

		private void readTestData_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.InitialDirectory = filesLocation;
			dlg.FileName = testFilename;
			dlg.Filter = "CSV Files|*.csv|All Files|*.*";
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				filesLocation = Path.GetDirectoryName(dlg.FileName) + "\\";
				testFilename = Path.GetFullPath(dlg.FileName);
				saveSettings();
				testCtrl.Data.ReadCSV(dlg.FileName);
			}
			UpdateTitle();
		}


		private void saveSettings()
		{
			RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Backprop");
			key.SetValue("filesLocation", filesLocation, RegistryValueKind.String);
			key.SetValue("cfgFilename", cfgFilename, RegistryValueKind.String);
			key.SetValue("netFilename", netFilename, RegistryValueKind.String);
			key.SetValue("trainFilename", trainFilename, RegistryValueKind.String);
			key.SetValue("runFilename", testFilename, RegistryValueKind.String);
			key.SetValue("bDispUpdate", cbDispUpdate.Checked.ToString(), RegistryValueKind.String);
			key.SetValue("winSizeWidth", this.Size.Width.ToString(), RegistryValueKind.String);
			key.SetValue("winSizeHeight", this.Size.Height.ToString(), RegistryValueKind.String);
			key.SetValue("splitContainer1Pos", splitContainer1.SplitterDistance.ToString(), RegistryValueKind.String);
			key.SetValue("splitContainer2Pos", splitContainer2.SplitterDistance.ToString(), RegistryValueKind.String);
			key.SetValue("splitContainer3Pos", splitContainer3.SplitterDistance.ToString(), RegistryValueKind.String);

		}
		private void readSettings()
		{
			RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Backprop");
			filesLocation = (String)key.GetValue("filesLocation", "");
			cfgFilename = (String)key.GetValue("cfgFilename", "");
			netFilename = (String)key.GetValue("netFilename", "");
			trainFilename = (String)key.GetValue("trainFilename", "");
			testFilename = (String)key.GetValue("runFilename", "");
			bDispEnabled = Convert.ToBoolean(key.GetValue("bDispUpdate", "true"));
			winSizeWidth = Convert.ToInt32(key.GetValue("winSizeWidth", "800"));
			winSizeHeight = Convert.ToInt32(key.GetValue("winSizeHeight", "700"));
			splitContainer1Pos = Convert.ToInt32(key.GetValue("splitContainer1Pos", "400"));
			splitContainer2Pos = Convert.ToInt32(key.GetValue("splitContainer2Pos", "400"));
			splitContainer3Pos = Convert.ToInt32(key.GetValue("splitContainer3Pos", "400"));
		}
		private void btnCreateNet_Click(object sender, EventArgs e)
		{
			//read UI fields
			net.cfg = ConfigFromUI();
			net.CreateNetwork();
			net.FinalizeNetwork();
			net.RandomizeWeights(r);
			ConfigToUI();
			propertyGrid1.SelectObject(net, false, 200);
		}
		private void testWriteBaseline_Click(object sender, EventArgs e)
		{
			//create net
			net.CreateNetworkBaseline();

			//write net
			net.WriteXML("C:\\Users\\jsadowski.GFPDIV\\Documents\\Projects\\BrainNet Project\\Backprop\\Backprop Test 1\\Backprop Testing 1\\files\\XOR 2-2-1 TEST.xml");
		}
		private void txtNumTrainPasses_TextChanged(object sender, EventArgs e)
		{
			int i;
			if (Int32.TryParse(txtTrainNumPasses.Text, out i))
				trainCtrl.Cfg.trainPasses = i;
			else
				trainCtrl.Cfg.trainPasses = 1;
		}
		private void txtTrainParamFrom_TextChanged(object sender, EventArgs e)
		{
			double d;
			if (Double.TryParse(txtTrainParamFrom.Text, out d))
				trainCtrl.Cfg.trainParamFrom = d;
			else
				trainCtrl.Cfg.trainParamFrom = 0.1;
		}
		private void txtTrainParamTo_TextChanged(object sender, EventArgs e)
		{
			double d;
			if (Double.TryParse(txtTrainParamTo.Text, out d))
				trainCtrl.Cfg.trainParamTo = d;
			else
				trainCtrl.Cfg.trainParamTo = 0.1;
		}

		private void udCaseNumber_ValueChanged(object sender, EventArgs e)
		{
			trainCtrl.CurrCase = (int)udCaseNumber.Value;
			if (trainCtrl.CurrCase >= trainCtrl.Data.Cases.Count)
				trainCtrl.CurrCase = 0;
			if (trainCtrl.CurrCase < 0)
				trainCtrl.CurrCase = trainCtrl.Data.Cases.Count - 1;
			udCaseNumber.Value = trainCtrl.CurrCase;
		}

		private void txtNumEpochs_TextChanged(object sender, EventArgs e)
		{
			int i;
			if (Int32.TryParse(txtNumEpochs.Text, out i))
				trainCtrl.Cfg.trainEpochs = i;
			else
				trainCtrl.Cfg.trainEpochs = 1;
		}

		private void btnClearText_Click(object sender, EventArgs e)
		{
			tbOutputBox.Clear();
		}

		private void txtTrainParamStep_TextChanged(object sender, EventArgs e)
		{
			double d;
			if (Double.TryParse(txtTrainParamStep.Text, out d))
				trainCtrl.Cfg.trainParamStep = d;
			else
				trainCtrl.Cfg.trainParamStep = 0.1;
		}

		private void chkCaseAutoAdvance_CheckedChanged(object sender, EventArgs e)
		{
			trainCtrl.Cfg.bStepAutoAdvance = chkCaseAutoAdvance.Checked;
		}

		private void cbDispUpdate_CheckedChanged(object sender, EventArgs e)
		{
			bDispEnabled = cbDispUpdate.Checked;
		}

	}
}
