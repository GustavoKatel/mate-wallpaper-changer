using System;
using wallpaperService;
using wallpaperServiceConfig;
using Gtk;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace localfiles
{
	public class LocalFiles : WallpaperService
	{
		public static List<String> filenames;
		private int index=0;
		
		public LocalFiles ()
		{
			filenames = new List<String>();
		}
		
		public String getName()
		{
			return "Local Files Module";	
		}
		public String getAuthor()
		{
			return "GustavoKatel";
		}
		public String getDescription()
		{
			return "Local files manager.";
		}
		public String getLogo()
		{
			return "%images%LocalFiles.png";
		}
		//
		private Wallpaper getWallpaper(int pos)
		{
			Wallpaper wp = null;
			if(pos>=filenames.Count)
				return wp;
			wp = new Wallpaper(filenames[pos]);
			return wp;
		}
		public Wallpaper getNextWallpaper()
		{
			if(filenames.Count==0)
				return null;
			if(index>=filenames.Count)
				index=0;
			return new Wallpaper(filenames[index++]);
		}
		public Wallpaper getRandomWallpaper()
		{
			if(filenames.Count<=0)
				return null;
			Random rnd = new Random(DateTime.Now.Millisecond);
			int p = rnd.Next(0,filenames.Count);
			return new Wallpaper(filenames[p]);
		}
		//
		public Widget getConfigurationView()
		{
			Widget widget = new View();
			
			return widget;
		}
		
		public void open()
		{
			WallpaperServiceConfig config = new WallpaperServiceConfig();
			config.load("%plugins%LocalFiles.conf");
			object getValue = config.getValue("items");
			if(getValue!=null)
				filenames = (List<String>)getValue;
			else
				filenames = new List<string>();
			getValue = config.getValue("index");
			if(getValue!=null)
				index = (int)getValue;
			else
				index = 0;
		}
		
		public void close()
		{
			this.save();
		}
		
		public void save()
		{
			WallpaperServiceConfig config = new WallpaperServiceConfig();
			config.addValue("items",filenames);
			config.addValue("index",index);
			config.save("%plugins%LocalFiles.conf");

		}
		
		public static void addItems(String[] list)
		{
			foreach(String item in list)
			{
				if(!filenames.Contains(item))
					filenames.Add(item);
			}
		}
		
	}
}

