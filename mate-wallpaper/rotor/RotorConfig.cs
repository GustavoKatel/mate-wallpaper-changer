using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace rotor
{
	public class RotorConfig
	{
		//
		private const String KEY_AUTOSTART="autoStart";
		private const String KEY_DELAY="delay";
		private const String KEY_DELAY_MULTI="delayMulti";
		private const String KEY_MODE="mode";
		//
		private static RotorConfig instace=null;
		//
		private Boolean autoStart=false;
		private int delay=60;
		private DelayMulti delayMulti=DelayMulti.SECS;
		private ChangeMode mode = ChangeMode.LINEAR;
		
		private Dictionary<String,Object> dic;
		
		private RotorConfig ()
		{
			dic = new Dictionary<string, object>();
			this.load();
		}
		
		public static RotorConfig getInstace()
		{
			if(instace==null)
				instace = new RotorConfig();
			return instace;
		}
		
		public Boolean Autostart
		{
			get { return autoStart; }	
			set 
			{ 
				autoStart = value; 
				this.dic[KEY_AUTOSTART]=value;
			}
		}
		
		public int Delay
		{
			get { return delay; }	
			set 
			{ 
				delay = value; 
				this.dic[KEY_DELAY]=value;
			}
		}
		
		public DelayMulti DelayMultiplier
		{
			get { return delayMulti; }	
			set 
			{
				this.delayMulti = value;
				this.dic[KEY_DELAY_MULTI]=value;
			}
		}
		
		public ChangeMode Mode
		{
			get { return mode; }	
			set 
			{ 
				mode = value;
				this.dic[KEY_MODE]=value;
			}
		}
		
		public int getDelayInSecs()
		{
			int secs = this.Delay;
			if(this.DelayMultiplier==DelayMulti.HOURS)
				secs = secs*3600;
			else if(this.DelayMultiplier==DelayMulti.MINUTES)
				secs = secs*60;
			return secs;
		}
		
		public void save()
		{
			//
			String path = "conf";
		    FileStream s = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
		    BinaryFormatter B = new BinaryFormatter();
		    B.Serialize(s, dic);
		    s.Close();
		}
		
		public void load()
		{
			String path = "conf";
			if(!File.Exists(path))
				return;
			FileStream Fs = new FileStream(path, FileMode.Open, FileAccess.Read);
		    BinaryFormatter F = new BinaryFormatter();
		    Object d = F.Deserialize(Fs);
		    Fs.Close();
			if(d!=null)
				this.dic = (Dictionary<String,Object>)d;
			//
			if(dic.ContainsKey(KEY_AUTOSTART))
				this.autoStart = (Boolean)dic[KEY_AUTOSTART];
			//
			if(dic.ContainsKey(KEY_DELAY))
			{
				this.delay = (int)dic[KEY_DELAY];
			}
			//
			if(dic.ContainsKey(KEY_DELAY_MULTI))
				this.delayMulti = (DelayMulti)dic[KEY_DELAY_MULTI];
			if(dic.ContainsKey(KEY_MODE))
				this.mode = (ChangeMode)dic[KEY_MODE];
		}
		
	}
	
	public enum ChangeMode { RANDOM,LINEAR };
	public enum DelayMulti { HOURS,MINUTES,SECS };
	
}

