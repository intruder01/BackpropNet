using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using AutoMapper;

namespace BackpropNet
{
	[Serializable]
	public class NetworkConfig
	{
		//serialized properties
		public List<int> schema { get; set; }
		public double learnRate { get; set; }    //learning rate
		public int weightDivider { get; set; }   //divide rnd (0-1) / x


		public NetworkConfig()
		{
			//default values
			schema = new List<int>();
			learnRate = 0.8;
			weightDivider = 10;
		}

		#region XML persist

		//read file and return new element
		public void readXML(string filename)
		{
			NetworkConfig nc = null;

			using (FileStream stream = new FileStream(filename, FileMode.Open))
			{
				XmlSerializer ser = new XmlSerializer(typeof(NetworkConfig));
				nc = (NetworkConfig)ser.Deserialize(stream);
				Copy(nc, this);
			}
	
		}

		//write new file
		public void writeXML(string filename)
		{
			
			using(StreamWriter writer = new StreamWriter(filename))
			{
				XmlSerializer ser = new XmlSerializer(this.GetType());
				ser.Serialize(writer, this);
			}
		}
		//write to open stream

		private void Copy(NetworkConfig src, NetworkConfig dest)
		{
			//Mapper.CreateMap<Person, Person>();
			//Mapper.Map<Person, Person>(person2, person1);
			////This copies member content from person2 into the _existing_ person1 instance.

			//copy objects using AutoMapper
			//ensure all component objects' maps exists
			Mapper.CreateMap<NetworkConfig, NetworkConfig>();
			AutoMapper.Mapper.Map<NetworkConfig, NetworkConfig>(src, dest);
		}

		#endregion

	}

}
