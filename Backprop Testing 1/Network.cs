using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.IO;
using AutoMapper;
using System.ComponentModel;

namespace BackpropNet
{
	[Serializable]
	public class Network
	{
		//serialized fields
		public int Idx { get; set; } //this net index
		[BrowsableAttribute(false)]
		public NetworkConfig cfg { get; set; } //network configuration
		public List<Layer> layers { get; set; }    //network layers l,n

		//fields re-created during construction
		//[XmlIgnore]

		#region Constructors

		public Network()
		{
		}
		public Network(int netIndex) : base()
		{
			Idx = netIndex;
			cfg = new NetworkConfig();
		}

		#endregion


		#region Creation 

		//create net from cfg
		//use when creating new network from UI fields
		public void CreateNetwork()
		{

			//network schema
			//2 - num inputs
			//2 - num nodes in 1st layer (hidden)
			//1 - num nodes in 2nd layer (output)
			//etc...


			//create network layers
			CreateLayers(cfg.schema);

			//create network weights
			//createNetWeights(schema);

			////create network outputs
			//createNetOutputs(schema);

			//////////create the neurons
			////////createNetNeurons(schema);


			////////netNeurons[0][0].weights = netWeights[0][0];
			////////netNeurons[0][1].weights = netWeights[0][1];

			////////netNeurons[1][0].inputs = netOutputs[0];
			////////netNeurons[1][0].weights = netWeights[1][0];

			//////////random weights
			////////netNeurons[0][0].randomizeWeights(0.01);
			////////netNeurons[0][1].randomizeWeights(-0.02);
			////////netNeurons[1][0].randomizeWeights(0.03);

			//use Layers neurons
			//nrn(0,0).weights = netWeights[0][0];
			//nrn(0,1).weights = netWeights[0][1];

			//nrn(1,0).inputs = netOutputs[0];
			//nrn(1, 0).inputs = netLayers[0].outputs;
			//////////////////////////////////////////////connectLayers();
			//nrn(1,0).weights = netWeights[1][0];

			////random weights
			//for (int l = 0; l < layers.Count; l++)
			//{
			//	layers[l].randomizeWeights(Form1.r);
			//}

			//default activation logistic
			////////////////////////////////////////////for (int l = 0; l < layers.Count; l++)
			////////////////////////////////////////////{
			////////////////////////////////////////////	layers[l].actFunc = new actLogistic();
			////////////////////////////////////////////}

			////random weights - same as baseline
			//nrn(0, 0).randomizeWeights(1.11);
			//nrn(0, 1).randomizeWeights(-2.23);
			//nrn(1, 0).randomizeWeights(2.34);

		}

		//finalize network references
		//use after basic network structure is created either from UI fields
		//or from file
		public void FinalizeNetwork()
		{
			ConnectLayers();
			CreateActivations();

			////random weights - same as baseline
			//nrn(0, 0).randomizeWeights(1.11);
			//nrn(0, 1).randomizeWeights(-2.23);
			//nrn(1, 0).randomizeWeights(2.34);

		}

		//default baseline network structure 2-2-1, logistic etc..
		public void CreateNetworkBaseline()
		{

			//trainData = new TrainingData();
			//trainData.makeXORData();	// XOR train data

			cfg = new NetworkConfig();
			cfg.schema = new List<int> { 2, 2, 1 };
			cfg.learnRate = 0.8;
			cfg.weightDivider = 10;

			//create network layers
			CreateLayers(cfg.schema);

			ConnectLayers();

			//default activation logistic
			for (int l = 0; l < layers.Count; l++)
			{
				layers[l].actFunc = new actLogistic();
			}

			//random weights
			nrn(0, 0).RandomizeWeights(1.11);
			nrn(0, 1).RandomizeWeights(-2.23);
			nrn(1, 0).RandomizeWeights(2.34);

		}

		private void CreateLayers(List<int> schema)
		{
			layers = new List<Layer>();
			//first value in schema is number of inputs (no layer)
			int numLayers = schema.Count - 1;
			for (int n = 0; n < numLayers; n++)
			{
				layers.Add(new Layer(this, schema, n));      //layer
			}
		}

		private void ConnectLayers()
		{
			//network-layer-neuron references 
			for (int l = 0; l < layers.Count; l++)
			{
				layers[l].net = this; // Layer.net reference
				layers[l].outputs.Clear();
				layers[l].errors.Clear();
				int numNodes = layers[l].neurons.Count;
				for (int n = 0; n < numNodes; n++)
				{
					layers[l].outputs.Add(0.0); //build outputs list
					layers[l].errors.Add(0.0);  //build errors list

					nrn(l, n).layer = layers[l]; //Neuron.layer reference
					nrn(l, n).weights = layers[l].weights[n]; // Neuron.weights reference
				}
			}

			//inter-layer references
			//neuron.inputs references
			//Layer 0 - no connections to prev output
			//		  - inputs assigned directly
			//Layer	1 - connect inputs to layer 0 outputs 
			//etc...

			for (int l = 1; l < layers.Count; l++)
			{
				int numNodes = layers[l].neurons.Count;
				for (int n = 0; n < numNodes; n++)
				{
					//reference neuron inputs to previous layer's outputs
					nrn(l, n).inputs = layers[l - 1].outputs;
				}
			}
		}

		public void CreateActivations()
		{
			foreach (Layer l in layers)
			{
				l.actFunc = Activation.getInstance(l.actFunc.funcName);
			}
		}

		public void RandomizeWeights(Random r)
		{
			for (int l = 0; l < layers.Count; l++)
			{
				layers[l].RandomizeWeights(r);
			}
		}

		#endregion


		#region Access Methods  


		public Neuron nrn(int layerIdx, int neuronIdx)
		{
			return this.layers[layerIdx].neurons[neuronIdx];
		}

		public List<double> wt(int layerIdx, int weightIdx)
		{
			return this.layers[layerIdx].weights[weightIdx];
		}

		#endregion


		#region Training

		
		//public double train(TextBox txtBox)
		//{
		//	epoch = 0;
		//	trainRMSError = 0.9999;

		//	do
		//	{
		//		epoch++;
		//		for (int i = 0; i < 4; i++)  //very important, do NOT train for only one example
		//		{
		//			//1) forward propagation (calculates output)

		//			//assign inputs to hidden nodes
		//			netNeurons[0][0].inputs = trainIn[i];
		//			netNeurons[0][1].inputs = trainIn[i];

		//			//calculate hidden layer output
		//			netOutputs[0][0] = netNeurons[0][0].calcOutput();
		//			netOutputs[0][1] = netNeurons[0][1].calcOutput();

		//			//calculate output layer output
		//			netNeurons[1][0].inputs = netOutputs[0];
		//			netNeurons[1][0].calcOutput();

		//			//2) back propagation (adjusts weights)

		//			//adjusts the weights of the output neuron, based on it's error
		//			netNeurons[1][0].error = act.derivative(netNeurons[1][0].output) * (trainOut[i] - netNeurons[1][0].output);
		//			trainErrors[i] = netNeurons[1][0].error;
		//			netNeurons[1][0].adjustWeights();

		//			//then adjusts the hidden neurons' weights, based on their errors
		//			netNeurons[0][0].error = act.derivative(netNeurons[0][0].output) * netNeurons[1][0].error * netNeurons[1][0].weights[0];
		//			netNeurons[0][1].error = act.derivative(netNeurons[0][1].output) * netNeurons[1][0].error * netNeurons[1][0].weights[1];

		//			netNeurons[0][0].adjustWeights();
		//			netNeurons[0][1].adjustWeights();
		//		}

		//		trainRMSError = 0.0;
		//		for (int i = 0; i < 4; i++)
		//		{
		//			trainRMSError += Math.Pow(trainErrors[i], 2);
		//		}
		//		trainRMSError = Math.Sqrt(trainRMSError);
		//		txtBox.AppendText(String.Format("{0:F8}\n", trainRMSError));
		//	}
		//	while (epoch < maxEpochs && trainRMSError > trainRMSErrorTarget);

		//	return trainRMSError;
		//}

		//public double train(TextBox txtBox)
		//{
		//	epoch = 0;
		//	trainRMSError = 0.9999;

		//	do
		//	{
		//		epoch++;
		//		for (int i = 0; i < trainData.Cases.Count; i++)  //very important, do NOT train for only one example
		//		{
		//			//1) forward propagation (calculates output)

		//			////assign inputs to hidden nodes
		//			//nrn(0,0).inputs = trainIn[i];
		//			//nrn(0,1).inputs = trainIn[i];
		//			//layers[0].assignInputs(trainIn[i]);
		//			layers[0].assignInputs(trainData.getCase(i).Inputs);

		//			////calculate hidden layer output
		//			//nrn(0, 0).calcOutput();
		//			//nrn(0, 1).calcOutput();
		//			////calculate output layer output
		//			//nrn(1, 0).calcOutput();
		//			for (int l = 0; l < layers.Count; l++)
		//			{
		//				layers[l].calcOutputs();
		//			}


		//			//2) back propagation (adjusts weights)

		//			//adjusts the weights of the output neuron, based on it's error

		//			//nrn(1,0).error = act.derivative(nrn(1,0).output) * (trainOut[i] - nrn(1,0).output);
		//			//nrn(1, 0).calcError(trainOut[i]);
		//			//layers[1].calcErrors(trainOut[i]);
		//			//layers[layers.Count - 1].calcErrors(trainOut[i]);
		//			//trainErrors[i] = layers[layers.Count - 1].calcErrors(trainOut[i]);
		//			trainErrors[i] = layers[layers.Count - 1].calcErrors(trainData.getCase(i).Outputs);
		//			//nrn(1, 0).adjustWeights();
		//			layers[layers.Count - 1].adjustWeights();

		//			//then adjusts the hidden neurons' weights, based on their errors

		//			//nrn(0,0).error = act.derivative(nrn(0,0).output) * nrn(1,0).error * nrn(1,0).weights[0];
		//			//nrn(0,1).error = act.derivative(nrn(0,1).output) * nrn(1,0).error * nrn(1,0).weights[1];
		//			//nrn(0, 0).calcError(layers[1].errors, layers[1].weights[0]);
		//			//nrn(0, 1).calcError(layers[1].errors, layers[1].weights[0]);
		//			//layers[0].calcErrors(layers[1]);
		//			for (int l = layers.Count - 2; l >= 0; l--)
		//			{
		//				layers[l].calcErrors(layers[l+1]);
		//				layers[l].adjustWeights();
		//			}

		//			////nrn(0, 0).adjustWeights();
		//			////nrn(0, 1).adjustWeights();
		//			//for (int l = layers.Count - 2; l >= 0; l--)
		//			//{
		//			//	layers[l].adjustWeights();
		//			//}
		//		}

		//		//network error
		//		trainRMSError = 0.0;
		//		for (int i = 0; i < trainData.Cases.Count; i++)
		//		{
		//			trainRMSError += Math.Pow(trainErrors[i], 2);
		//		}
		//		trainRMSError = Math.Sqrt(trainRMSError);

		//		if (epoch <= 11)
		//			txtBox.AppendText(String.Format("{0:F8}\n", trainRMSError));
		//	}
		//	while (epoch < cfg.maxEpochs && trainRMSError > cfg.rmsErrorTarget);
		//	txtBox.AppendText(String.Format("{0}\n", epoch));

		//	return trainRMSError;
		//}


		//public double train(Form1 form, TextBox txtBox, Boolean bDispUpdate, TrainingController trainCtrl)
		//{
		//	epoch = 0;
		//	rmsError = 0.9999;

		//	do
		//	{
		//		epoch++;
		//		for (int i = 0; (i < trainCtrl.Data.Cases.Count) && !form.bStopRequest; i++)  //very important, do NOT train for only one example
		//		{
		//			//1) forward propagation (calculates output)

		//			layers[0].assignInputs(trainCtrl.Data.Cases[i].trainInputs);
		//			for (int l = 0; l < layers.Count; l++)
		//			{
		//				layers[l].calcOutputs();
		//			}

		//			//2) back propagation (adjusts weights)

		//			//adjusts the weights of the output layer, based on it's error
		//			//trainErrors[i] = layers[layers.Count - 1].calcErrors(trainData.getCase(i).Outputs);
		//			trainCtrl.Data.Cases[i].totalError = layers[layers.Count - 1].calcErrors(trainCtrl.Data.Cases[i].trainOutputs);
		//			layers[layers.Count - 1].adjustWeights();

		//			//save output data in trainer
		//			trainCtrl.Data.Cases[i].saveNodeOutputs(layers[layers.Count - 1].outputs);
		//			trainCtrl.Data.Cases[i].saveNodeErrors(layers[layers.Count - 1].errors);
		//			trainCtrl.Data.Cases[i].calcRmsError();

		//			//then adjusts the hidden layer' weights, based on their errors
		//			for (int l = layers.Count - 2; l >= 0; l--)
		//			{
		//				layers[l].calcErrors(layers[l + 1]);
		//				layers[l].adjustWeights();
		//			}

		//			Application.DoEvents();
		//			if (form.bStopRequest) break;
		//		}

		//		//network error
		//		rmsError = 0.0;
		//		for (int i = 0; i < trainCtrl.Data.Cases.Count; i++)
		//		{
		//			//trainRMSError += Math.Pow(trainData.Cases[i].actRmsError, 2);
		//			rmsError += Math.Pow(trainCtrl.Data.Cases[i].totalError, 2);
		//		}

		//		rmsError = Math.Sqrt(rmsError) / trainCtrl.Data.Cases.Count;
		//		trainCtrl.rmsError = rmsError;

		//		//update 1st 10 rows each time
		//		if (bDispUpdate && epoch <= 11)
		//			txtBox.AppendText(String.Format("{0} {1:F8}\n", epoch, rmsError));

		//		Application.DoEvents();
		//	}
		//	while (epoch < trainCtrl.tgtEpochs && rmsError > trainCtrl.tgtRmsError && !form.bStopRequest);

		//	if (bDispUpdate)
		//		txtBox.AppendText(String.Format(">{0} {1:F8}\n", epoch, rmsError));

		//	return rmsError;
		//}

		//public double test(TextBox txtBox, Boolean bDispUpdate, TrainingController runCtrl)
		//{
		//	epoch = 0;
		//	rmsError = 0.9999;
		//	epoch++;

		//	for (int i = 0; i < runCtrl.Data.Cases.Count; i++)  //very important, do NOT train for only one example
		//	{
		//		//1) forward propagation (calculates output)

		//		layers[0].assignInputs(runCtrl.Data.Cases[i].trainInputs);
		//		for (int l = 0; l < layers.Count; l++)
		//		{
		//			layers[l].calcOutputs();
		//		}

		//		//2) back propagation (adjusts weights)

		//		//adjusts the weights of the output layer, based on it's error
		//		//trainErrors[i] = layers[layers.Count - 1].calcErrors(trainData.getCase(i).Outputs);
		//		runCtrl.Data.Cases[i].totalError = layers[layers.Count - 1].calcErrors(runCtrl.Data.Cases[i].trainOutputs);
		//		//layers[layers.Count - 1].adjustWeights();

		//		//save output data in trainer
		//		runCtrl.Data.Cases[i].saveNodeOutputs(layers[layers.Count - 1].outputs);
		//		runCtrl.Data.Cases[i].saveNodeErrors(layers[layers.Count - 1].errors);
		//		runCtrl.Data.Cases[i].calcRmsError();

		//		//then adjusts the hidden layer' weights, based on their errors
		//		for (int l = layers.Count - 2; l >= 0; l--)
		//		{
		//			layers[l].calcErrors(layers[l + 1]);
		//			//layers[l].adjustWeights();
		//		}
		//	}

		//	//network error
		//	rmsError = 0.0;
		//	for (int i = 0; i < runCtrl.Data.Cases.Count; i++)
		//	{
		//		//trainRMSError += Math.Pow(trainData.Cases[i].actRmsError, 2);
		//		rmsError += Math.Pow(runCtrl.Data.Cases[i].totalError, 2);
		//	}
		//	rmsError = Math.Sqrt(rmsError) / runCtrl.Data.Cases.Count;
		//	runCtrl.rmsError = rmsError;

		//	if (bDispUpdate)
		//		txtBox.AppendText(String.Format(">{0} {1:F8}\n", epoch, rmsError));

		//	return rmsError;
		//}

		#endregion


		#region XML persist

		public void ReadConfig(string filename)
		{
			cfg.readXML(filename);
		}

		public void WriteConfig(string filename)
		{
			cfg.writeXML(filename);
		}

		public void ReadXML(string filename)
		{
			Network net = null;
			
			using(TextReader stream = new StreamReader(filename))
			{
				XmlSerializer ser = new XmlSerializer(this.GetType());
				net = (Network)ser.Deserialize(stream);
				Copy(net, this);
			}
		}

		//write new file
		public void WriteXML(string filename)
		{
			using (TextWriter writer = new StreamWriter(filename))
			{
				XmlSerializer ser = new XmlSerializer(this.GetType());
				ser.Serialize(writer, this);
			}
		}

		private void Copy(Network src, Network dest)
		{
			//Mapper.CreateMap<Person, Person>();
			//Mapper.Map<Person, Person>(person2, person1);
			////This copies member content from person2 into the _existing_ person1 instance.

			//copy objects using AutoMapper
			//ensure all component objects' maps exists
			Mapper.CreateMap<NetworkConfig, NetworkConfig>();
			Mapper.CreateMap<Activation, Activation>();
			Mapper.CreateMap<Network, Network>();
			AutoMapper.Mapper.Map<Network, Network>(src, dest);
		}

		#endregion


	}
}
