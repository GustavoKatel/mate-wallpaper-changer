using System;
using Gtk;

namespace wallpaperService
{
	public interface WallpaperService
	{	
		String getName();
		String getAuthor();
		String getDescription();
		String getLogo();
		//
		//Wallpaper getWallpaper(int pos);
		Wallpaper getNextWallpaper();
		Wallpaper getRandomWallpaper();
		//
		Widget getConfigurationView();
		//
		void open();
		void close();
		void save();
	}
}

