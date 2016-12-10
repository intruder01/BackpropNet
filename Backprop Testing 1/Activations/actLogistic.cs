using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BackpropNet
{
	[Serializable]
	public class actLogistic : Activation
	{
		public actLogistic() { }
		public override string funcName { get { return "Logistic"; } }
		public override double value(double x)
		{
			return 1.0 / (1.0 + Math.Exp(-x));
		}
		public override double derivative(double x)
		{
			return x * (1 - x);
		}
	}
}
