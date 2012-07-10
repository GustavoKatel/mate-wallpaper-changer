using System;
using System.IO;
using System.Collections;
using Gdk;

namespace matewallpaper
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class startPage : Gtk.Bin
	{
		public startPage ()
		{
			this.Build ();
			this.image1.File = "images/wallpaper.png";
			loadInfo();
		}
		
		private void loadInfo()
		{
			StreamReader objReader = new StreamReader("info.txt");	
			string sLine="";
			while (sLine != null)
			{
				sLine = objReader.ReadLine();
				if (sLine != null)
					this.textview1.Buffer.Text = this.textview1.Buffer.Text+sLine.ToString();
			}
			objReader.Close();
		}
			
	}
}

