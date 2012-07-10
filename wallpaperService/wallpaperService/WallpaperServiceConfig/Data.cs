using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace wallpaperServiceConfig
{
	[Serializable()]
	public class Data : Dictionary<String,Object>,ISerializable
	{	
		
		public Data()
		{
			
		}		
		
		public Data(SerializationInfo info,StreamingContext context)
		{
			
		}
		
	}
}

