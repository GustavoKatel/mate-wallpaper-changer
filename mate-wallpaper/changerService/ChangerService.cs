using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using pluginManager;
using wallpaperService;
using wallpaperChanger;

namespace matewallpaper
{
	public class ChangerService
	{
		private List<WallpaperChanger> modifiers;
		private WallpaperChanger changer = null;
		
		//
		private String platform;
		
		public ChangerService ()
		{
			//
			OperatingSystem os = Environment.OSVersion;
            this.platform = os.Platform.ToString();
			//
			this.modifiers=new List<WallpaperChanger>();
			PluginManager pm = new PluginManager();
			this.modifiers.AddRange(pm.GetPlugins<WallpaperChanger>("plugins"));
			//
			checkWindowManager();
		}
		
		public Boolean changeWallpaper(String imageUrl)
		{
			if(this.changer==null)
				return false;
			return this.changer.changeWallpaper(imageUrl);
		}
		
		private void checkWindowManager()
		{
			foreach(WallpaperChanger c in modifiers)
			{
				if(! c.getPlatform().Equals(this.getOsPlatform()))
				   break;
				if(c.getPlatform().Equals("Unix"))
					checkWMUsingUnix(c);
				if(this.changer!=null)
					break;
			}
		}
		
		private String getOsPlatform()
		{
            return platform;
		}
		
		private void checkWMUsingUnix(WallpaperChanger c)
		{
			String[] search = c.getWindowManagerSearcher();
			foreach(String s in search)
			{
				if(WMExistInUnix(s))
				{
					this.changer = c;
					return;
				}
			}	
		}
		private Boolean WMExistInUnix(String search)
		{
			Process proc = new Process();
			proc.StartInfo.FileName = "checkWM.sh";
			proc.StartInfo.Arguments=search.Replace(" ","\\ ");
			proc.StartInfo.UseShellExecute=false;
			proc.StartInfo.RedirectStandardOutput=true;
			proc.Start();
			String output = proc.StandardOutput.ReadToEnd();
			proc.WaitForExit();
			if(output=="")
			{
				return false;	
			}
			else
			{
				return true;
			}
		}
		
	}
}

