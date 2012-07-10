using System;
using System.Collections.Generic;
using rotor;


namespace matewallpaper
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class ConfigPage : Gtk.Bin
	{	
		public ConfigPage ()
		{
			this.Build ();
			loadConfig();
			loadPluginManager();
		}

		protected void OnSaveClicked (object sender, System.EventArgs e)
		{
			DelayMulti multi = DelayMulti.SECS;
			if(sbDelayMulti.Active==0)
				multi=DelayMulti.HOURS;
			else if(sbDelayMulti.Active==1)
				multi=DelayMulti.MINUTES;
			
			int delay = Convert.ToInt32(this.sbDelay.Text);
			//
			bool autostart = this.cbAutostart.Active;
			//
			ChangeMode mode = ChangeMode.LINEAR;
			if(cbMode.Active==1)
				mode = ChangeMode.RANDOM;
			//
			RotorConfig.getInstace().Delay=delay;
			RotorConfig.getInstace().DelayMultiplier=multi;
			RotorConfig.getInstace().Autostart=autostart;
			RotorConfig.getInstace().Mode=mode;
			RotorConfig.getInstace().save();
			//
			MainClass.rotor.restart();
		}
		
		private void loadConfig()
		{
			RotorConfig conf = RotorConfig.getInstace();
			this.cbAutostart.Active = conf.Autostart;
			this.sbDelay.Value = conf.Delay;
			switch(conf.DelayMultiplier)
			{
			case DelayMulti.HOURS:
				this.sbDelayMulti.Active=0;
				break;
			case DelayMulti.MINUTES:
				this.sbDelayMulti.Active=1;
				break;
			case DelayMulti.SECS:
				this.sbDelayMulti.Active=2;
				break;
			default:break;
			}
			switch(conf.Mode)
			{
			case ChangeMode.LINEAR:
				this.cbMode.Active=0;
				break;
			case ChangeMode.RANDOM:
				this.cbMode.Active=1;
				break;
			default: break;
			}
		}
		
		private void loadPluginManager()
		{
			Gtk.ListStore store = new Gtk.ListStore (
				typeof (string), typeof (string), typeof(string) );
 
			plugins.AppendColumn (
				"Title", new Gtk.CellRendererText (), "text", 0);
			plugins.AppendColumn (
				"Author", new Gtk.CellRendererText (), "text", 1);
			plugins.AppendColumn (
				"Description", new Gtk.CellRendererText (), "text", 2);
 
			WallpaperManager manager = new WallpaperManager();
			foreach(wallpaperService.WallpaperService service in manager.getAllServices())
			{
				store.AppendValues (service.getName(), service.getAuthor(),service.getDescription());
			}
					
			plugins.Model=store;
			//
			
		}
		
	}
}

