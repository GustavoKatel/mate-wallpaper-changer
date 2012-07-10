using System;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;
using System.IO;

namespace pluginManager
{
	public class PluginManager
	{
		
		public static String parsePath(String path)
		{
			String res = path.Replace("%plugins%","plugins"+Path.DirectorySeparatorChar);	
			res = res.Replace("%images%","images"+Path.DirectorySeparatorChar);
			return res;
		}
		
		public PluginManager ()
		{
		}
		
		public List<T> GetPlugins<T>(string folder)

		{

		    string[] files = Directory.GetFiles(folder, "*.dll");
		
		    List<T> tList = new List<T>();
		
		    //Debug.Assert(typeof(T).IsInterface);
			//Console.WriteLine(typeof(T).IsInterface);

			foreach (string file in files) 
		
			{

				try 
	
				{
	
		            Assembly assembly = Assembly.LoadFile(file);
		
		            foreach (Type type in assembly.GetTypes()) 
	
					{
	
		                if (!type.IsClass || type.IsNotPublic) continue;
		
		                Type[] interfaces = type.GetInterfaces();
		
		                //if (((IList)interfaces).Contains(typeof(T))) 
						foreach(Type tipo in interfaces)
						{
							if(tipo==typeof(T))
							{
				                {
				
				                    object obj = Activator.CreateInstance(type);
				
				                    T t = (T)obj;
				
				                    tList.Add(t);
				
				                }
								break;
							}
						}
	
					} 
	
				}
	
				catch (Exception ex)
	
	        	{
	
	            	//LogError(ex);
					Console.WriteLine("err: "+ex.Message);
	        	}

    		}

    		return tList; 

		}
		
	}
}

