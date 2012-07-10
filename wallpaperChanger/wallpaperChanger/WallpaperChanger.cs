using System;

namespace wallpaperChanger
{
	public interface WallpaperChanger
	{
		String getAuthor();
		String getDescription();
		String[] getWindowManagerSearcher();
		String getPlatform();
		Boolean changeWallpaper(String imageUrl);
	}
}

