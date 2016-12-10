using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BackpropNet
{
	//base class for activations
	[XmlInclude(typeof(actLogistic))]
	[XmlInclude(typeof(actLogisticBipolar))]
	[XmlInclude(typeof(actLinear))]
	[XmlInclude(typeof(actTanH))]
	public class Activation
	{
		public virtual string funcName { get; }
		public virtual double value(double x) { return 0; }
		public virtual double derivative(double x) { return 0; }

		public static Activation getInstance(string funcName)
		{
			Activation act = new Activation();
			switch (funcName)
			{
				case "Logistic":
					return new actLogistic();
				case "Bipolar":
					return new actLogisticBipolar();
				case "Linear":
					return new actLinear();
				case "TanH":
					return new actTanH();
			}
			throw new Exception("Activation function undefined, funcName=" + funcName);
		}

	}
}
