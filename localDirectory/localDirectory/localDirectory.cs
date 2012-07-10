using System;
using System.IO;
using System.Collections.Generic;
using Gtk;
//
using wallpaperService;
using wallpaperServiceConfig;

namespace localDirectory
{
	public class LocalDirectory:WallpaperService
	{
		private static List<String> filenames;
		
		private static List<String> directories;
		
		private static Boolean recursiveSearch=false;
		
		private int index=0;
		
		public LocalDirectory ()
		{
			directories = new List<string>();
			filenames = new List<string>();
		}
		
		public String getName()
		{
			return "Local Directory Module";	
		}
		public String getAuthor()
		{
			return "GustavoKatel";
		}
		public String getDescription()
		{
			return "Manage pictures from a local directory";
		}
		public String getLogo()
		{
			return "%images%LocalDirectory.png";
		}
		//
		public Wallpaper getNextWallpaper()
		{
			if(filenames.Count==0)
				return null;
			if(index>=filenames.Count)
				index=0;
			return new Wallpaper(filenames[index]);	
		}
		public Wallpaper getRandomWallpaper()
		{
			if(filenames.Count==0)
				return null;
			Random rnd = new Random();
			int p = rnd.Next(0,filenames.Count);
			return new Wallpaper(filenames[p]);
		}
		//
		public Widget getConfigurationView()
		{
			return new View();
		}
		//
		public void open()
		{
			WallpaperServiceConfig config = new WallpaperServiceConfig();
			config.load("%plugins%LocalDirectories.conf");
			//items
			object getValue = config.getValue("items");
			if(getValue!=null)
				directories = (List<String>)getValue;
			else
				directories = new List<string>();
			//index
			getValue = config.getValue("index");
			if(getValue!=null)
				index = (int)getValue;
			else
				index = 0;
			//
			getValue = config.getValue("recursiveSearch");
			if(getValue!=null)
				recursiveSearch = (Boolean)getValue;
			else
				recursiveSearch = false;
			//
			loadFilenames();
		}
		public void close()
		{
			save();
		}
		public void save()
		{
			WallpaperServiceConfig config = new WallpaperServiceConfig();
			config.addValue("items",directories);
			config.addValue("index",index);
			config.addValue("recursiveSearch",recursiveSearch);
			config.save("%plugins%LocalDirectories.conf");
		}
		
		public static void removeDirectory(int pos)
		{
			if(pos>=directories.Count)
				return;
			directories.RemoveAt(pos);
			loadFilenames();
		}
		
		public static void clearDirectories()
		{
			directories = new List<string>();
			loadFilenames();
		}
		
		public static void addDirectories(List<String> dirList)
		{
			addDirectories(dirList.ToArray());
		}
		
		public static void addDirectories(String[] dirList)
		{
			directories.AddRange(dirList);	
			loadFilenames();
		}
		
		public static String getDirectory(int pos)
		{
			if(pos>=directories.Count)
				return "";
			return directories[pos];
		}
		
		public static List<String> getDirectories()
		{
			return directories;
		}
		
		public static void setRecursive(Boolean r)
		{
			recursiveSearch = r;	
			loadFilenames();
		}
		public static Boolean getRecursive()
		{
			return recursiveSearch;
		}
		
		private static void loadFilenames()
		{
			filenames = new List<string>();
			//
			List<FileInfo> files = new List<FileInfo>();
			foreach(String dir in directories)
				files.AddRange(searchInDir(dir,recursiveSearch));
			
			foreach(FileInfo file in files)
				filenames.Add(file.FullName);
			//Console.WriteLine("Total: "+filenames.Count);
		}
		
		private static List<FileInfo> searchInDir(String dir, Boolean recursive)
		{
			if(dir==null || dir.Equals(""))
				return new List<FileInfo>();
			DirectoryInfo dirInfo = new DirectoryInfo(dir);
			List<FileInfo> files = new List<FileInfo>();
			//
			SearchOption so = SearchOption.TopDirectoryOnly;
			if(recursive)
				so = SearchOption.AllDirectories;
			//
			files.AddRange(dirInfo.GetFiles("*.png",so));
			files.AddRange(dirInfo.GetFiles("*.PNG",so));
			files.AddRange(dirInfo.GetFiles("*.jpg",so));
			files.AddRange(dirInfo.GetFiles("*.JPG",so));
			files.AddRange(dirInfo.GetFiles("*.jpeg",so));
			files.AddRange(dirInfo.GetFiles("*.JPEG",so));
			
			//
			/*if(recursive)
			{
				DirectoryInfo[] subs = dirInfo.GetDirectories();
				foreach(DirectoryInfo sub in subs)
					files.AddRange(searchInDir(sub.FullName,recursive));
			}*/
			//
			return files;
		}
		
	}
}

