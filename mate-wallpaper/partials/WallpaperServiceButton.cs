using System;
using Gtk;
using wallpaperService;

namespace WallpaperServiceView
{
	public class WallpaperServiceButton : Button
	{
		private WallpaperService ws;
		public WallpaperServiceButton (WallpaperService service)
		{
			this.ws = service;
			Image logo = new Image( pluginManager.PluginManager.parsePath(this.ws.getLogo()) );
			this.Add(logo);
			//
			this.Clicked+=doClick;
			this.ShowAll();
		}
		
		public void doClick(object sender, EventArgs args)
		{
			//Console.WriteLine(ws.getName());
		}
	
		public WallpaperService service
		{
			get { return ws; }	
			set { ; }
		}
		
	}
}

