using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace wallpaperServiceConfig
{
	[Serializable()]
	public class DataPack
	{	
		private Data data;
		private int version=1;
		
		public DataPack ()
		{
		}
		
		public DataPack(SerializationInfo info, StreamingContext ctxt)
		{
			this.data = (Data)info.GetValue("data", typeof(Data));
			Console.WriteLine("Data: "+data);
			this.version = (int)info.GetValue("version",typeof(int));
		}
		
		public Data OData
		{
			get { return data; }	
			set { data = value; }
		}
		
		public int Version
		{
		
			get { return version; }
			set { version = value; }
			
		}
		
		public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
   		{
      		info.AddValue("data", this.data);
			info.AddValue("version",this.version);
		}
		
	}
}

