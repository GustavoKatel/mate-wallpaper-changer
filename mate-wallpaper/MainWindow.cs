using System;
using System.IO;
using Gtk;
using System.Collections.Generic;
using wallpaperChanger;
using wallpaperService;
using pluginManager;
using WallpaperServiceView;
using matewallpaper;

public partial class MainWindow: Gtk.Window
{	
	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		//
		loadPlugins();
		loadConfigPage();
		loadStartpage();
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void onExitClicked (object sender, System.EventArgs e)
	{
		Application.Quit ();
	}
	
	private void loadPlugins()
	{
		foreach(WallpaperService service in MainClass.wallpaperManager.getAllServices())
			registerService(service);
		//
	}
	
	private void registerService(WallpaperService service)
	{
		if(service==null)
			return;
		this.newServiceBox(service);
	}
	
	private void newServiceBox(WallpaperService service)
	{
		WallpaperServiceButton but = new WallpaperServiceButton(service);
		but.Clicked+=this.serviceLogoClick;
		addBox(but);
	}
	
	private void serviceLogoClick(object sender, EventArgs e)
    {
		clearHbConfig();
        WallpaperServiceButton but = (WallpaperServiceButton)sender;
		WallpaperService service = but.service;
		loadHbConfig(service.getConfigurationView());
    }
	
	private void addBox(Widget widget)
	{
		this.m_hb_services.PackStart(widget,false,false,0);
		this.m_hb_services.ShowAll();	
	}
	
	private void clearHbConfig()
	{
		foreach(Widget w in this.m_hb_config.Children)
			this.m_hb_config.Remove(w);
	}
	
	private void loadHbConfig(Widget view)
	{
		this.m_hb_config.AddWithViewport(view);
		this.m_hb_config.ShowAll();
	}
	
	protected void onSaveClicked (object sender, System.EventArgs e)
	{
		MainClass.wallpaperManager.saveAllServices();
	}
	
	private void loadConfigPage()
	{
		Image logo = new Image("images"+System.IO.Path.DirectorySeparatorChar+"engine.png");
		//logo.SetSizeRequest(48,48);
		Button but = new Button(logo);
		but.Clicked+=this.onConfigClicked;
		addBox(but);
	}
	private void onConfigClicked(object sender, System.EventArgs e)
	{
		this.clearHbConfig();
		Widget w = new ConfigPage();
		this.loadHbConfig(w);		
	}
	//
	private void loadStartpage()
	{
		startPage w = new startPage();
	
		loadHbConfig(w);
	}
}
