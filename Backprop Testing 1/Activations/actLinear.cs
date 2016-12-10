using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BackpropNet
{
	[Serializable]
	public class actLinear : Activation
	{
		public actLinear() { }
		public override string funcName { get { return "Linear";}}
		public override double value(double x)
		{
			return x;
		}
		public override double derivative(double x)
		{
			return 1;
		}
	}
}
