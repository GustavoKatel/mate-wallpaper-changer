using System;

namespace wallpaperService
{
	public class Wallpaper
	{
		private String imgUrl;
		private String author;
		
		public Wallpaper (String imageUrl)
		{
			imgUrl = imageUrl;
		}
		
		public String ImageUrl
		{
			get { return imgUrl; }
			set { imgUrl = value; }
		}
		
		public String Author
		{
			get { return author; }
			set { author = value; }
		}
		
	}
}

