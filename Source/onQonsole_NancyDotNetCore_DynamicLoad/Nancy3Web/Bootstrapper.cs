using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using System.IO;
using System.Reflection;

namespace NancyModuleExample
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {

        public Bootstrapper()
        {
            ModuleManager.Load(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Modules"));
        }

        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);
            ModuleManager.Enable(container);
        }

    }
}
