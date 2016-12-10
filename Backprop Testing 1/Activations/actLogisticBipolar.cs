using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace BackpropNet
{
	[Serializable]
	public class actLogisticBipolar : Activation
	{
		public actLogisticBipolar() { }
		public override string funcName { get { return "Bipolar"; } }
		public override double value(double x)
		{
			return 2.0 / (1.0 + Math.Exp(-x)) - 1.0;
		}

		public override double derivative(double x)
		{
			return 0.5 * (1.0 + x) * (1.0 - x);
		}
	}
}
