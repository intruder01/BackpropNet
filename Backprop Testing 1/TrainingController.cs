using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LumenWorks.Framework.IO.Csv;
using System.Xml.Serialization;
using AutoMapper;
using System.Reflection;
using System.Xml;

//uses csv reader library
//http://www.codeproject.com/Articles/9258/A-Fast-CSV-Reader


namespace BackpropNet
{

	public class TrainingCase
	{
		//desired
		public List<double> trainInputs;
		public List<double> trainOutputs;

		//actual training values
		public List<double> nodeOutputs;
		public List<double> nodeErrors; //output node errors
		public double totalError;       //case output error Σ(nodeErrors)
		public double rmsError;         //case rms error  1/n * √(Σ(nodeErrors^2))

		public TrainingCase()
		{
			trainInputs = new List<double>();
			trainOutputs = new List<double>();

			nodeOutputs = new List<double>();
			nodeErrors = new List<double>();
			totalError = 0.0;
		}

		public TrainingCase(List<double> inputs, List<double> outputs)
			: this()
		{
			trainInputs = inputs;
			trainOutputs = outputs;

			//allocate actual values as per Outputs
			nodeOutputs.Clear();
			nodeErrors.Clear();
			foreach(double o in trainOutputs)
			{
				nodeOutputs.Add(0.0);
				nodeErrors.Add(0.0);
			}
		}

		//save output layer outputs in case outputs
		public void saveNodeOutputs(List<double> outs)
		{
			for (int i = 0; i < outs.Count; i++)
			{
				nodeOutputs[i] = outs[i];
			}
		}

		//save output layer errors in case errors
		public void saveNodeErrors(List<double> errs)
		{
			for (int i = 0; i < errs.Count; i++)
			{
				nodeErrors[i] = errs[i];
			}
		}

		//calculate case RMS error based on individual output node errors
		//call only after nodeErrors have been updated
		public double calcRmsError()
		{
			rmsError = 0.0;
			for (int i = 0; i < nodeErrors.Count; i++)
			{
				rmsError += (nodeErrors[i] * nodeErrors[i]);
			}
			rmsError = Math.Sqrt(rmsError) / nodeErrors.Count;
			return rmsError;
		}
	}
	public class TrainingData
	{
		public List<TrainingCase> Cases;
		public List<string> Headers;
		public TrainingData()
		{
			Cases = new List<TrainingCase>();
			Headers = new List<string>();

		}

		protected void addCase(List<double> inputs, List<double> outputs)
		{
			TrainingCase Case = new TrainingCase(inputs, outputs);
			Cases.Add(Case);
		}

		public void readCSV(string filename)
		{
			Cases.Clear();

			// open the file "data.csv" which is a CSV file with headers
			using (CsvReader csv = new CsvReader(new StreamReader(filename), true))
			{
				int fieldCount = csv.FieldCount;

				Headers = csv.GetFieldHeaders().ToList();
				while (csv.ReadNextRecord())
				{
					TrainingCase trainCase = new TrainingCase();
					for (int i = 0; i < fieldCount; i++)
					{
						//Console.Write(string.Format("{0} = {1};", Headers[i], csv[i]));
						double val;
						if (Double.TryParse(csv[i], out val))
						{
							if (Headers[i].ToUpper().Contains("[IN]"))
								trainCase.trainInputs.Add(val);
							if (Headers[i].ToUpper().Contains("[OUT]"))
							{
								trainCase.trainOutputs.Add(val);
								trainCase.nodeOutputs.Add(0.0);
								trainCase.nodeErrors.Add(0.0);
							}
						}
					}
					Cases.Add(trainCase);
				}
			}
		}

		public void makeXORData()
		{
			Cases.Clear();
			Headers.Clear();

			TrainingCase cas;
			cas = new TrainingCase(new List<double> { 0, 0 }, new List<double> { 0 });
			Cases.Add(cas);
			cas = new TrainingCase(new List<double> { 0, 1 }, new List<double> { 1 });
			Cases.Add(cas);
			cas = new TrainingCase(new List<double> { 1, 0 }, new List<double> { 1 });
			Cases.Add(cas);
			cas = new TrainingCase(new List<double> { 1, 1 }, new List<double> { 0 });
			Cases.Add(cas);
		}

		private void Copy(TrainingData td)
		{
			//Mapper.CreateMap<Person, Person>();
			//Mapper.Map<Person, Person>(person2, person1);
			////This copies member content from person2 into the _existing_ person1 instance.

			//copy objects using AutoMapper
			//ensure all component objects' maps exists
			Mapper.CreateMap<TrainingCase, TrainingCase>();
			Mapper.CreateMap<TrainingData, TrainingData>();
			AutoMapper.Mapper.Map<TrainingData, TrainingData>(td, this);
		}

	}
	
	public class TrainingController
	{ 
		//target parameters - serialized
		public int tgtEpochs { get; set; }
		public double tgtRmsError { get; set; }
		public int trainPasses { get; set; }	//num of passes with parameters
		public double trainParamFrom { get; set; }  //initial param value for loop
		public double trainParamTo { get; set; }	//final param value for loop
		public double trainParamStep { get; set; }  //param step value for loop
		public int trainEpochs { get; set; }    //num of epochs to train 

		//not serialized
		[XmlIgnore]
		public TrainingData Data;
		[XmlIgnore]
		public double rmsError { get; set; }    //whole network RMS error
		[XmlIgnore]
		public int numEpochsRan { get; set; } //how many epochs have been ran
		[XmlIgnore]
		public List<double> totalErrorHistory; //totalError each epoch
		[XmlIgnore]
		public List<double> rmsErrorHistory;   //rmsError each epoch
		[XmlIgnore]
		public int currCase { get; set; } //current case being processed
		private int lastCase { get; set; }     //last case processed

		//test parameters

		public TrainingController()
		{
			Data = new TrainingData();
			totalErrorHistory = new List<double>();
			rmsErrorHistory = new List<double>();

			//set defaults
			tgtEpochs = 5000;
			tgtRmsError = 0.001;
			trainPasses = 10;
			trainParamFrom = 0.1;
			trainParamTo = 1;
			trainParamStep = 0.1;
			trainEpochs = 1;

			Reset();
		}

		public void Reset()
		{
			rmsError = 0.0;
			numEpochsRan = 0;
			totalErrorHistory.Clear();
			rmsErrorHistory.Clear();
			currCase = 0;
			lastCase = -1;
		}

		public int NextCase()
		{
			if (++currCase >= Data.Cases.Count)
				currCase = 0;
			return currCase;
		}

		public double Train_org(Network net, Form1 form, TextBox txtBox, Boolean bDispUpdate)
		{
			numEpochsRan = 0;
			rmsError = 0.9999;

			do
			{
				numEpochsRan++;
				for (int i = 0; (i < Data.Cases.Count) && !form.bStopRequest; i++)  //very important, do NOT train for only one example
				{
					//1) forward propagation (calculates output)

					net.layers[0].assignInputs(Data.Cases[i].trainInputs);
					for (int l = 0; l < net.layers.Count; l++)
					{
						net.layers[l].calcOutputs();
					}

					//2) back propagation (adjusts weights)

					//adjusts the weights of the output layer, based on it's error
					//trainErrors[i] = layers[layers.Count - 1].calcErrors(trainData.getCase(i).Outputs);
					Data.Cases[i].totalError = net.layers[net.layers.Count - 1].calcErrors(Data.Cases[i].trainOutputs);
					net.layers[net.layers.Count - 1].adjustWeights();

					//save output data in trainer
					Data.Cases[i].saveNodeOutputs(net.layers[net.layers.Count - 1].outputs);
					Data.Cases[i].saveNodeErrors(net.layers[net.layers.Count - 1].errors);
					Data.Cases[i].calcRmsError();

					//then adjusts the hidden layer' weights, based on their errors
					for (int l = net.layers.Count - 2; l >= 0; l--)
					{
						net.layers[l].calcErrors(net.layers[l + 1]);
						net.layers[l].adjustWeights();
					}

					Application.DoEvents();
					if (form.bStopRequest) break;
				}

				//network error
				rmsError = 0.0;
				for (int i = 0; i < Data.Cases.Count; i++)
				{
					//trainRMSError += Math.Pow(trainData.Cases[i].actRmsError, 2);
					rmsError += Math.Pow(Data.Cases[i].totalError, 2);
				}

				rmsError = Math.Sqrt(rmsError) / Data.Cases.Count;

				//update 1st 10 rows each time
				if (bDispUpdate && numEpochsRan <= 11)
					txtBox.AppendText(String.Format("{0} {1:F8}\n", numEpochsRan, rmsError));

				Application.DoEvents();
			}
			while (numEpochsRan < tgtEpochs && rmsError > tgtRmsError && !form.bStopRequest);

			if (bDispUpdate)
				txtBox.AppendText(String.Format(">{0} {1:F8}\n", numEpochsRan, rmsError));

			return rmsError;
		}

		public double Train(Network net, Form1 form, TextBox txtBox, Boolean bDispUpdate)
		{
			numEpochsRan = 0;
			rmsError = 0.9999;

			do
			{
				numEpochsRan++;
				for (int i = 0; (i < Data.Cases.Count) && !form.bStopRequest; i++)  //very important, do NOT train for only one example
				{
					currCase = i;
					
					//1) forward propagation (calculates output)
					net.layers[0].assignInputs(Data.Cases[currCase].trainInputs);
					for (int l = 0; l < net.layers.Count; l++)
					{
						net.layers[l].calcOutputs();
					}

					//save output data in trainer
					Data.Cases[currCase].saveNodeOutputs(net.layers[net.layers.Count - 1].outputs);

					//2) back propagation (adjusts weights)

					////////////OUTPUT LAYER
					////////////adjusts the weights of the output layer, based on it's error
					//////////Data.Cases[currCase].totalError = net.layers[net.layers.Count - 1].calcErrors(Data.Cases[currCase].trainOutputs);
					//////////net.layers[net.layers.Count - 1].adjustWeights();

					////////////save error data in trainer
					//////////Data.Cases[currCase].saveNodeErrors(net.layers[net.layers.Count - 1].errors);
					//////////Data.Cases[currCase].calcRmsError();


					//HIDDEN LAYERS
					//adjusts the hidden layer's weights, based on their errors
					////////////for (int l = net.layers.Count - 2; l >= 0; l--)
					for (int l = net.layers.Count - 1; l >= 0; l--)
					{
						if (l == net.layers.Count - 1)
						{
							Data.Cases[currCase].totalError = net.layers[net.layers.Count - 1].calcErrors(Data.Cases[currCase].trainOutputs);
							net.layers[l].adjustWeights();

							//save error data in trainer
							Data.Cases[currCase].saveNodeErrors(net.layers[net.layers.Count - 1].errors);
							Data.Cases[currCase].calcRmsError();
						}
						else
						{
							net.layers[l].calcErrors(net.layers[l + 1]);
							net.layers[l].adjustWeights();
						}
					}

					//for (int l = net.layers.Count - 1; l >= 0; l--)
					//{
					//	net.layers[l].adjustWeights();
					//}

					lastCase = currCase;

					Application.DoEvents();
					if (form.bStopRequest) break;
				}

				//network error
				rmsError = 0.0;
				for (int i = 0; i < Data.Cases.Count; i++)
				{
					//trainRMSError += Math.Pow(trainData.Cases[i].actRmsError, 2);
					rmsError += Math.Pow(Data.Cases[i].totalError, 2);
				}
				rmsError = Math.Sqrt(rmsError) / Data.Cases.Count;

				//update 1st 10 rows each time
				if (bDispUpdate && numEpochsRan <= 11)
					txtBox.AppendText(String.Format("{0} {1:F8}\n", numEpochsRan, rmsError));

				Application.DoEvents();
			}
			while (numEpochsRan < tgtEpochs && rmsError > tgtRmsError && !form.bStopRequest);

			if (bDispUpdate)
				txtBox.AppendText(String.Format(">{0} {1:F8}\n", numEpochsRan, rmsError));

			return rmsError;
		}

		public double Test(Network net, Form1 form, TextBox txtBox, Boolean bDispUpdate)
		{
			numEpochsRan = 0;
			rmsError = 0.9999;
			numEpochsRan++;

			for (int i = 0; i < Data.Cases.Count; i++)  //very important, do NOT train for only one example
			{
				//1) forward propagation (calculates output)

				net.layers[0].assignInputs(Data.Cases[i].trainInputs);
				for (int l = 0; l < net.layers.Count; l++)
				{
					net.layers[l].calcOutputs();
				}

				//save output data in trainer
				Data.Cases[i].saveNodeOutputs(net.layers[net.layers.Count - 1].outputs);

				//2) back propagation (adjusts weights)

				//OUTPUT LAYER
				//adjusts the weights of the output layer, based on it's error
				//trainErrors[i] = layers[layers.Count - 1].calcErrors(trainData.getCase(i).Outputs);
				Data.Cases[i].totalError = net.layers[net.layers.Count - 1].calcErrors(Data.Cases[i].trainOutputs);
				//layers[layers.Count - 1].adjustWeights();

				//save error data in trainer
				Data.Cases[i].saveNodeErrors(net.layers[net.layers.Count - 1].errors);
				Data.Cases[i].calcRmsError();

				//HIDDEN LAYERS
				//then adjusts the hidden layer' weights, based on their errors
				for (int l = net.layers.Count - 2; l >= 0; l--)
				{
					net.layers[l].calcErrors(net.layers[l + 1]);
					//layers[l].adjustWeights();
				}
			}

			//network error
			rmsError = 0.0;
			for (int i = 0; i < Data.Cases.Count; i++)
			{
				//trainRMSError += Math.Pow(trainData.Cases[i].actRmsError, 2);
				rmsError += Math.Pow(Data.Cases[i].totalError, 2);
			}
			rmsError = Math.Sqrt(rmsError) / Data.Cases.Count;

			if (bDispUpdate)
				txtBox.AppendText(String.Format("TST: {0} {1:F8}\n", numEpochsRan, rmsError));

			return rmsError;
		}

		public void ForwardPass(Network net, Form1 form, TextBox txtBox, Boolean bDispUpdate)
		{
			if (currCase == lastCase)
			{
				DialogResult res;
				res = MessageBox.Show("Advance case?", "This case already processed", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Hand);
				if (res == DialogResult.Yes)
				{
					NextCase();
					form.TrainCtrlrToUI();
				}
				if (res == DialogResult.Cancel)
					return;
			}

			//1) forward propagation (calculates output)
			net.layers[0].assignInputs(Data.Cases[currCase].trainInputs);
			for (int l = 0; l < net.layers.Count; l++)
			{
				net.layers[l].calcOutputs();
			}

			//save output data in trainer
			Data.Cases[currCase].saveNodeOutputs(net.layers[net.layers.Count - 1].outputs);

			//update 1st 10 rows each time
			//if (bDispUpdate)
			//	txtBox.AppendText(String.Format("FWD: {0} {1:F8}\n", numEpochsRan, rmsError));

			Application.DoEvents();
		}

		public void BackwardPass(Network net, Form1 form, TextBox txtBox, Boolean bDispUpdate)
		{
			//2) back propagation (adjusts weights)

			//adjusts the weights of the output layer, based on it's error
			Data.Cases[currCase].totalError = net.layers[net.layers.Count - 1].calcErrors(Data.Cases[currCase].trainOutputs);
			net.layers[net.layers.Count - 1].adjustWeights();

			//save output data in trainer
			Data.Cases[currCase].saveNodeErrors(net.layers[net.layers.Count - 1].errors);
			Data.Cases[currCase].calcRmsError();

			//then adjusts the hidden layer' weights, based on their errors
			for (int l = net.layers.Count - 2; l >= 0; l--)
			{
				net.layers[l].calcErrors(net.layers[l + 1]);
				net.layers[l].adjustWeights();
			}

			//network error
			rmsError = 0.0;
			for (int i = 0; i < Data.Cases.Count; i++)
			{
				//trainRMSError += Math.Pow(trainData.Cases[i].actRmsError, 2);
				rmsError += Math.Pow(Data.Cases[i].totalError, 2);
			}

			rmsError = Math.Sqrt(rmsError) / Data.Cases.Count;

			lastCase = currCase;

			////update 1st 10 rows each time
			//if (bDispUpdate)
			//	txtBox.AppendText(String.Format("BCK: {0} {1:F8}\n", numEpochsRan, rmsError));

			Application.DoEvents();
		}

		public void Step(Network net, Form1 form, TextBox txtBox, Boolean bDispUpdate)
		{
			ForwardPass(net, form, txtBox, bDispUpdate);
			BackwardPass(net, form, txtBox, bDispUpdate);
		}

		public void Epoch(Network net, Form1 form, TextBox txtBox, Boolean bDispUpdate)
		{
			for (int epoch = 0; epoch < trainEpochs; epoch++)
			{
				numEpochsRan++;

				for (int i = 0; i < Data.Cases.Count; i++)  //very important, do NOT train for only one example
				{
					currCase = i;
					ForwardPass(net, form, txtBox, bDispUpdate);
					BackwardPass(net, form, txtBox, bDispUpdate);
				}

				//network error
				rmsError = 0.0;
				for (int i = 0; i < Data.Cases.Count; i++)
				{
					//trainRMSError += Math.Pow(trainData.Cases[i].actRmsError, 2);
					rmsError += Math.Pow(Data.Cases[i].totalError, 2);
				}
				rmsError = Math.Sqrt(rmsError) / Data.Cases.Count;
			}

			if (bDispUpdate)
				txtBox.AppendText(String.Format("EPOCH: {0} {1:F8}\n", numEpochsRan, rmsError));
		}

		#region XML persist 

		//read file and return new element
		public void readXML(string filename)
		{
			TrainingController tc = null;
			
			using(FileStream stream = new FileStream(filename, FileMode.Open))
			{
				XmlSerializer ser = new XmlSerializer(this.GetType());
				tc = (TrainingController)ser.Deserialize(stream);
				Copy(tc, this);
			}
		}

		//write new file
		public void writeXML(string filename)
		{
			using (StreamWriter writer = new StreamWriter(filename))
			{
				XmlSerializer ser = new XmlSerializer(this.GetType());
				ser.Serialize(writer, this);
			}
		}

		public void writeXML_Example_my_properties_only(string filename)
		{
			//writer settings 
			XmlWriterSettings xmlSettings = new XmlWriterSettings();
			xmlSettings.Indent = true;

			using (XmlWriter writer = XmlWriter.Create(filename, xmlSettings))
			{
				XmlSerializer ser = new XmlSerializer(this.GetType());

				//write this class members only
				
				//fields - ignore
				var props = this.GetType().GetFields();

				writer.WriteStartDocument();
				writer.WriteStartElement("TrainingController");
				writer.WriteValue("0.005");
				////properties - write
				//foreach (PropertyInfo propertyInfo in this.GetType().GetProperties())
				//{
				//	string name = propertyInfo.Name;

				//	//skip if XmlIgnore attribute applied to property
				//	bool xmlIgnore = propertyInfo.GetCustomAttributes(false).Any(a => a is XmlIgnoreAttribute);

				//	//if this class's member
				//	if (propertyInfo.DeclaringType == this.GetType() && !xmlIgnore)
				//	{
				//		object obj = propertyInfo.GetValue(this, null);

				//		if (obj != null)
				//		{
				//			string value = obj.ToString();
				//			writer.WriteStartElement(name);
				//			writer.WriteValue(value);
				//			writer.WriteEndElement();
				//		}
				//	}
				//}
				writer.WriteEndElement();
				writer.WriteEndDocument();
			}
		}

		private void Copy(TrainingController src, TrainingController dest)
		{
			//Mapper.CreateMap<Person, Person>();
			//Mapper.Map<Person, Person>(person2, person1);
			////This copies member content from person2 into the _existing_ person1 instance.

			//copy objects using AutoMapper
			//ensure all component objects' maps exists
			Mapper.CreateMap<TrainingCase, TrainingCase>();
			Mapper.CreateMap<TrainingData, TrainingData>();
			Mapper.CreateMap<TrainingController, TrainingController>();
			AutoMapper.Mapper.Map<TrainingController, TrainingController>(src, dest);
		}



		#endregion

	}

}
