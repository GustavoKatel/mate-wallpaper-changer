using System;
using System.Threading;

namespace rotor
{
	public class Rotor
	{
		private Thread monitor;
		private static Boolean active=false;
			
		private int count=0;
		
		private matewallpaper.ChangerService changer;
		private matewallpaper.WallpaperManager manager;
		
		public Rotor ()
		{
		}
		
		public void setChangerService(matewallpaper.ChangerService changer)
		{
			this.changer = changer;
		}
		
		public void setWallpaperManager(matewallpaper.WallpaperManager manager)
		{
			this.manager = manager;	
		}
		
		public void start()
		{
			if(RotorConfig.getInstace().Autostart)
			{
				this.rotate();
			}	
		}
		
		public void rotate()
		{
			active=true;
			monitor = new Thread(new ThreadStart(nextStep));
			monitor.Start();	
		}
		
		public void stop()
		{
			active=false;
			if(monitor!=null)
				monitor.Abort();
		}
		
		public void restart()
		{
			this.stop();
			this.start();
		}
		
		private void nextStep()
		{
			while(active)
			{
				change();
				Thread.Sleep(RotorConfig.getInstace().getDelayInSecs()*1000);
			}
		}
		
		public void change()
		{
			String imageUrl = "";
			if(RotorConfig.getInstace().Mode==ChangeMode.LINEAR)
				imageUrl = this.manager.getNextWallpaper();
			else
				imageUrl = this.manager.getRandomWallpaper();
			if(imageUrl!="")
			{
				this.changer.changeWallpaper(imageUrl);
				Console.WriteLine(imageUrl+" change at: "+count);
			}
			else
			{
				Console.WriteLine("at: "+count);
			}
			count++;
		}
		
	}
}

