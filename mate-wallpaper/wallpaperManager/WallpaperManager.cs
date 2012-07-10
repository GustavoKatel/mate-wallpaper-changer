using System;
using System.Collections.Generic;
using wallpaperChanger;
using wallpaperService;
using pluginManager;
using WallpaperServiceView;

namespace matewallpaper
{
	public class WallpaperManager
	{
		private List<WallpaperService> services;
		
		private int serviceIndex=0;
		
		public WallpaperManager ()
		{
			this.services = new List<WallpaperService>();
			PluginManager pm = new PluginManager();
			this.services.AddRange(pm.GetPlugins<WallpaperService>("plugins"));
			initAll();
		}
		
		private void initAll()
		{
			foreach(WallpaperService service in this.services)
				service.open();
		}
		
		public List<WallpaperService> getAllServices()
		{
			return this.services;
		}
		
		public void saveAllServices()
		{
			foreach(WallpaperService service in this.services)
			{
				service.save();
			}
		}
		
		public String getNextWallpaper()
		{
			if(services.Count==0)
				return "";
			if(serviceIndex>=services.Count)
				serviceIndex=0;
			Console.WriteLine("get image from: "+services[serviceIndex].getName());
			serviceIndex++;
			for(int i=serviceIndex;i<services.Count;i++)
			{
				Wallpaper wp = this.services[i].getNextWallpaper();
				if(wp!=null && !wp.ImageUrl.Equals(""))
					return wp.ImageUrl;	
			}
			//
			for(int i=0;i<serviceIndex;i++)
			{
				Wallpaper wp = this.services[i].getNextWallpaper();
				if(wp!=null && !wp.ImageUrl.Equals(""))
					return wp.ImageUrl;	
			}
			return "";
		}
		
		public String getRandomWallpaper()
		{
			if(services.Count<=0)
				return "";
			Random rnd = new Random (DateTime.Now.Millisecond);
			int index = rnd.Next(0,services.Count);	
			//
			for(int i=index;i<services.Count;i++)
			{
				Wallpaper wp = this.services[i].getRandomWallpaper();
				if(wp!=null && !wp.ImageUrl.Equals(""))
					return wp.ImageUrl;	
			}
			//
			for(int i=0;i<index;i++)
			{
				Wallpaper wp = this.services[i].getRandomWallpaper();
				if(wp!=null && !wp.ImageUrl.Equals(""))
					return wp.ImageUrl;	
			}
			
			return "";
		}
			
	}
}

