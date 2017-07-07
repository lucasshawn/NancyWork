using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using Nancy.TinyIoc;
using Nancy3Shared;

namespace NancyModuleExample
{
    public static class ModuleManager
    {
        private static Dictionary<IModule, string> Modules = new Dictionary<IModule, string>();
        public static void Load(string dir)
        {
            foreach (var Module in Directory.GetFiles(dir, "*.dll"))
            {

                Assembly ModuleAssembly = Assembly.LoadFrom(Module);

                string name = Path.GetFileNameWithoutExtension(Module);
                foreach (Type t in ModuleAssembly.GetExportedTypes())
                {
                    if (t.GetInterfaces().Contains(typeof(IModule)) && t.GetConstructor(Type.EmptyTypes) != null)
                    {
                        // Create a instance of the module
                        IModule instance = Activator.CreateInstance(t) as IModule;
                        // Add it to the modules list
                        Modules.Add(instance, name);
                    }
                }
            }
        }

        public static void Enable(TinyIoCContainer container)
        {

            foreach (var module in Modules)
            {
                // Register it so we can find it anywhere in the nancy framework
                container.Register<IModule>((c, p) => module.Key, module.Value);
            }
        }
    }
}
