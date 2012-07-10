using System;
using System.Diagnostics;
using wallpaperChanger;

namespace mate_changer
{
	public class MyClass : WallpaperChanger
	{
		private const String cmd = "mateconftool-2";
		private const String args = "-t string -s /desktop/mate/background/picture_filename {0}";
		
		public MyClass ()
		{
		}
		
		public String getAuthor()
		{
			return "GustavoKatel";	
		}
		
		public String getDescription()
		{
			return "Wallpaper changer plugin for Mate Desktop";
		}
		
		public String[] getWindowManagerSearcher()
		{
			return new String[]{"mate"};
		}
		
		public String getPlatform()
		{
			return "Unix";	
		}
		
		public Boolean changeWallpaper(String imageUrl)
		{
			if(imageUrl==null || imageUrl.Equals(""))
				return false;
			Process proc = new Process();
			proc.StartInfo.FileName= cmd;
			String a = String.Format(args,imageUrl.Replace(" ","\\ "));
			a = a.Replace("!","\\!");
			a = a.Replace("?","\\?");
			//Console.WriteLine(a);
			proc.StartInfo.Arguments = a;
			proc.Start();
			proc.WaitForExit();
			proc.Close();
			return true;	
		}
		
	}
}

