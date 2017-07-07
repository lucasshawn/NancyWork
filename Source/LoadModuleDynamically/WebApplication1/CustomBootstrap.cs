using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using System.Reflection;
using System.IO;
using Nancy.Diagnostics;
using Nancy.Configuration;

namespace WebApplication1
{
    public class CustomBootstrap : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Nancy2Core.dll");
            Console.WriteLine($"Loading module[{path}]...");
            var assembly = Assembly.LoadFile(path);     
            Console.WriteLine($"Successfully loaded module[{assembly.FullName}].");
            var nancy2Modtype = assembly.GetType("Nancy2Core.Nancy2");
            Console.WriteLine($"Found module type[{nancy2Modtype.Name}] and registering with TinyIoContainer.");
            TinyIoCContainer.RegisterOptions options = container.Register(nancy2Modtype);
            base.ApplicationStartup(container, pipelines);
        }

        public override void Configure(INancyEnvironment environment)
        {
            environment.Diagnostics(true, "password");
            base.Configure(environment);
        }
        
    }
}
