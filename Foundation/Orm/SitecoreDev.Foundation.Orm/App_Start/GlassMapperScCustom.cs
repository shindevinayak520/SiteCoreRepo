#region GlassMapperScCustom generated code
using Glass.Mapper.Configuration;
using Glass.Mapper.IoC;
using Glass.Mapper.Maps;
using Glass.Mapper.Sc.IoC;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using IDependencyResolver = Glass.Mapper.Sc.IoC.IDependencyResolver;

namespace SitecoreDev.Foundation.Orm.App_Start
{
    public static  class GlassMapperScCustom
    {
		public static IDependencyResolver CreateResolver(){
			var config = new Glass.Mapper.Sc.Config();

			var dependencyResolver = new DependencyResolver(config);
			// add any changes to the standard resolver here
			return dependencyResolver;
		}

		public static IConfigurationLoader[] GlassLoaders(){			
			
			/* USE THIS AREA TO ADD FLUENT CONFIGURATION LOADERS
             * 
             * If you are using Attribute Configuration or automapping/on-demand mapping you don't need to do anything!
             * 
             */

			return new IConfigurationLoader[]{};
		}
		public static void PostLoad(){
			
		}
		public static void AddMaps(IConfigFactory<IGlassMap> mapsConfigFactory)
        {
            string binPath = System.IO.Path.Combine(
 System.AppDomain.CurrentDomain.BaseDirectory, "bin");
            foreach (string dll in System.IO.Directory.GetFiles(
            binPath, "SitecoreDev*.dll", SearchOption.AllDirectories))
            {
                try
                {
                    Assembly loadedAssembly = Assembly.LoadFile(dll);
                    Type glassmapType = typeof(IGlassMap);
                    var maps = loadedAssembly.GetTypes().Where(x =>
                    glassmapType.IsAssignableFrom(x));
                    if (maps != null)
                    {
                        foreach (var map in maps)
                            mapsConfigFactory.Add(() =>
                            Activator.CreateInstance(map) as IGlassMap);
                    }
                }
                catch (FileLoadException loadEx)
                { } // The Assembly has already been loaded.
                catch (BadImageFormatException imgEx)
                { } // If exception is thrown, the file is not an assembly.
            }
        }
    }
}
#endregion