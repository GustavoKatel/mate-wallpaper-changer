using System;
using Gtk;
using rotor;

namespace matewallpaper
{
	class MainClass
	{
		public static Rotor rotor;
		public static ChangerService changer;
		public static WallpaperManager wallpaperManager;
		
		public static void Main (string[] args)
		{
			rotor = new Rotor();
			//
			changer = new ChangerService();
			rotor.setChangerService(changer);
			//
			wallpaperManager = new WallpaperManager();
			rotor.setWallpaperManager(wallpaperManager);
			//
			rotor.start();
			//
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
			rotor.stop();
		}
	}
}
