using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace wallpaperServiceConfig
{
	public class WallpaperServiceConfig
	{
		private Dictionary<String, Object> dic;
		
		public WallpaperServiceConfig ()
		{
			dic = new Dictionary<string, object>();
		}
		
		public Boolean addValue(String key, Object bValue)
		{
			//this.data.Add(key,bValue);
			this.dic.Add(key,bValue);
			return true;
		}
		
		public Object getValue(String key)
		{
			if(this.dic.ContainsKey(key))
			{
				return this.dic[key];
			}
			else
			{
				return null;
			}
		}
		
		public void save(string fileName)
		{
			String path = fixPath(fileName);
		    FileStream s = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
		    BinaryFormatter B = new BinaryFormatter();
		    B.Serialize(s, dic);
		    s.Close();
		}
		
		public void load(string fileName)
		{
			String path = fixPath(fileName);
			if(!File.Exists(path))
				return;
			FileStream Fs = new FileStream(path, FileMode.Open, FileAccess.Read);
		    BinaryFormatter F = new BinaryFormatter();
		    Object d = F.Deserialize(Fs);
		    Fs.Close();
			if(d!=null)
				this.dic = (Dictionary<String,Object>)d;
			
		}
		
		private String fixPath(String fileName)
		{
			return fileName.Replace("%plugins%","plugins"+Path.DirectorySeparatorChar);	
		}
		
	}
}

