using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BackpropNet
{
	[Serializable]
	public class actTanH : Activation
	{
		public actTanH() { }
		public override string funcName { get { return "TanH"; } }
		public override double value(double x)
		{
			return Math.Tanh(x);
		}

		public override double derivative(double x)
		{
			return 1 - Math.Pow(x, 2);
		}
	}
}
