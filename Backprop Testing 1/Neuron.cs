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
	public class Neuron
	{
		//serialized fields

		public int Idx { get; set; } //this nrn number in layer
		public double biasWeight { get; set; }

		//fields re-created durign construction
		[XmlIgnore]
		public Layer layer;         //parent layer
		[XmlIgnore]
		public List<double> inputs; //ref to Layer array	
		[XmlIgnore]
		public List<double> weights;//ref to Layer array

		public Neuron()
		{
		}
		[XmlIgnore]
		public double output //ref to Layer array
		{
			get { return layer.outputs[Idx]; }
			set { layer.outputs[Idx] = value; }
		}
		[XmlIgnore]
		public double error //ref to Layer array
		{
			get { return layer.errors[Idx]; }
			set { layer.errors[Idx] = value; }
		}


		public Neuron(Layer lyr, int neuronIndex)
		{
			layer = lyr;
			Idx = neuronIndex;
		}

		public void assignInputs(List<double> trainIn)
		{
			inputs = trainIn;
		}

		public double calcOutput()
		{
			output = 0.0;
			for (int i = 0; i < inputs.Count; i++)
				output += weights[i] * inputs[i];
			output += biasWeight;
			output = layer.actFunc.value(output);
			//if (output > 0.9) output = 0.9;
			//if (output < 0.1) output = 0.1;
			return output;
		}

		//output neuron error = f'(output) * (target - output)
		public double calcError(double target)
		{
			//nrn(1, 0).error = act.derivative(nrn(1, 0).output) * (trainOut[i] - nrn(1, 0).output);
			error = layer.actFunc.derivative(output) * (target - output);
			return error;
		}

		//hidden neuron error = f'(output) * Sum(downstream error * downstream weight)
		public double calcError(List<double> errors, List<double> weights)
		{
			//nrn(0,0).error = act.derivative(nrn(0,0).output) * nrn(1,0).error * nrn(1,0).weights[0];
			double sum = 0.0;
			for (int n = 0; n < errors.Count(); n++)
				sum += errors[n] * weights[this.Idx]; //weights from n-th downstream neuron to this hidden neuron
			error = layer.actFunc.derivative(output) * sum;
			return error;
		}

		//hidden neuron proportional error
		//
		//hidden neuron error = f'(output) * Sum(downstream error * downstream weight)
		public double calcErrorProp(List<double> errors, List<double> weights)
		{
			int thisLayerIdx = Idx;
			int layerIdx = layer.Idx;

			//nrn(0,0).error = act.derivative(nrn(0,0).output) * nrn(1,0).error * nrn(1,0).weights[0];
			double sum = 0.0;
			for (int n = 0; n < errors.Count(); n++)
				sum += errors[n] * weights[this.Idx]; //weights from n-th downstream neuron to this hidden neuron
			error = layer.actFunc.derivative(output) * sum;

			error /= layerIdx;
			return error;
		}

		public void randomizeWeights(Random r)
		{
			////weights[0] = (Form1.r.NextDouble() - 0.5) / 10;
			////weights[1] = (Form1.r.NextDouble() - 0.5) / 10;
			////biasWeight = (Form1.r.NextDouble() - 0.5) / 10;

			//weights[0] = (r.NextDouble());
			//weights[1] = (r.NextDouble());
			//biasWeight = (r.NextDouble());

			//weights[0] -= 0.5;
			//weights[1] -= 0.5;
			//biasWeight -= 0.5;

			//weights[0] /= layer.net.cfg.weightDivider;
			//weights[1] /= layer.net.cfg.weightDivider;
			//biasWeight /= layer.net.cfg.weightDivider;

			for(int w =0; w<weights.Count; w++)
			{
				weights[w] = (r.NextDouble() - 0.5) / layer.net.cfg.weightDivider;
			}
			biasWeight = (r.NextDouble() - 0.5) / layer.net.cfg.weightDivider;
		}

		public void randomizeWeights(double seed)
		{
			//weights[0] = (Form1.r.NextDouble() - 0.5) / 10;
			//weights[1] = (Form1.r.NextDouble() - 0.5) / 10;
			//biasWeight = (Form1.r.NextDouble() - 0.5) / 10;

			weights[0] = (seed / 2.34);
			weights[1] = (seed / -2.45);
			biasWeight = (seed / 2.56);

			//weights[0] -= 0.5;
			//weights[1] -= 0.5;
			//biasWeight -= 0.5;

			weights[0] /= layer.net.cfg.weightDivider;
			weights[1] /= layer.net.cfg.weightDivider;
			biasWeight /= layer.net.cfg.weightDivider;
		}

		public void adjustWeights()
		{
			for (int i = 0; i < inputs.Count(); i++)
			{
				weights[i] += layer.net.cfg.learnRate * error * inputs[i];
			}
			biasWeight += layer.net.cfg.learnRate * error;
		}


		private void Copy(Neuron nrn)
		{
			//Mapper.CreateMap<Person, Person>();
			//Mapper.Map<Person, Person>(person2, person1);
			////This copies member content from person2 into the _existing_ person1 instance.

			//copy objects using AutoMapper
			//ensure all component objects' maps exists
			Mapper.CreateMap<Neuron, Neuron>();
			AutoMapper.Mapper.Map<Neuron, Neuron>(this, nrn);
		}
	}
}

