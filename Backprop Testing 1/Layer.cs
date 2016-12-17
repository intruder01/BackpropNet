using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using AutoMapper;

namespace BackpropNet
{
	[Serializable]
	public class Layer
	{
		//serialized fields
		public int Idx { get; set; } //this layer number in network
		public List<Neuron> neurons { get; set; } //layer neurons
		public List<List<double>> weights { get; set; } //neuron weights [n][w]	
		public Activation actFunc;   //activation function

		//fields re-created durign construction
		[XmlIgnore]
		public List<double> outputs { get; set; }  //neuron outputs [n]
		[XmlIgnore]
		public List<double> errors { get; set; }  //neuron errors [n]
		[XmlIgnore]
		public Network net { get; set; } //owner network


		#region Constructors
		public Layer()
		{
			neurons = new List<Neuron>();
			outputs = new List<double>();
			errors = new List<double>();
			weights = new List<List<double>>();
		}
		public Layer(Network n, List<int> Schema, int layerIndex) : this()
		{
			net = n;
			Idx = layerIndex;

			//create nodes per schema
			//first value in schema is number of inputs
			createNeurons(Schema[Idx + 1]);
			createErrors(Schema[Idx + 1]);
			createWeights(Schema[Idx]);    //wts to previous layer
			createOutputs(Schema[Idx + 1]);
			actFunc = new actLogistic();	//default activation
		}

#endregion


		#region Creation
		private void createNeurons(int numNeurons)
		{
			//neurons = new List<Neuron>();
			neurons.Clear();
			for (int n = 0; n < numNeurons; n++)
			{
				neurons.Add(new Neuron(this, n));	//node
			}
		}

		private void createOutputs(int numNodes)
		{
			//outputs = new List<double>();
			outputs.Clear();
			for (int n = 0; n < numNodes; n++)
			{
				outputs.Add(0.0);      //node output
			}
		}

		private void createErrors(int numNeurons)
		{
			//errors = new List<double>();
			errors.Clear();
			for (int n = 0; n < numNeurons; n++)
			{
				errors.Add(0.0);   //error
			}
		}

		private void createWeights(int numWeights)
		{
			//weights = new List<List<double>>();
			weights.Clear();
			for (int n = 0; n < neurons.Count; n++) //for each neuron
			{
				weights.Add(new List<double>());	//node
				for (int w = 0; w < numWeights; w++)
				{
					weights[n].Add(0.0);			//weight
				}
				//assign neuron's weights pointer to Layer weights array
				neurons[n].weights = weights[n];
			}
		}

		public void RandomizeWeights(Random r)
		{
			for (int n = 0; n < neurons.Count; n++) //for each neuron
			{
				neurons[n].RandomizeWeights(r);
			}
		}

		#endregion


		#region Training

		public void CalcOutputs()
		{
			for (int n = 0; n < neurons.Count; n++) //for each neuron
			{
				neurons[n].CalcOutput();
			}
		}

		//ouput layer error = f'(output) * (target - output)
		public double CalcErrors(List<double> target)
		{
			double sumError = 0.0;
			for (int n = 0; n < neurons.Count; n++) //for each neuron
			{
				sumError += neurons[n].CalcError(target[n]);
			}
			return sumError;
		}

		//hidden layer error = f'(output) * Sum(downstream error * downstream weight)
		public void CalcErrors(Layer layer)
		{
			for (int n = 0; n < neurons.Count; n++) //for each neuron
			{
				for (int dn = 0; dn < layer.neurons.Count; dn++)
				{
					neurons[n].CalcError(layer.errors, layer.weights[dn]);
				}
			}
		}

		public void AssignInputs(List<double> trainIn)
		{
			for (int n = 0; n < neurons.Count; n++) //for each neuron
			{
				neurons[n].AssignInputs(trainIn);
			}
		}

		public void AdjustWeights()
		{
			for (int n = 0; n < neurons.Count; n++) //for each neuron
			{
				neurons[n].AdjustWeights();
			}
		}

		#endregion


		//private void Copy(Layer lr)
		//{
		//	//Mapper.CreateMap<Person, Person>();
		//	//Mapper.Map<Person, Person>(person2, person1);
		//	////This copies member content from person2 into the _existing_ person1 instance.

		//	//copy objects using AutoMapper
		//	//ensure all component objects' maps exists
		//	Mapper.CreateMap<Activation, Activation>();
		//	Mapper.CreateMap<Layer, Layer>();
		//	AutoMapper.Mapper.Map<Layer, Layer>(this, lr);
		//}

	}
}
