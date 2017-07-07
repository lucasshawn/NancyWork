using System;
using Nancy;
[assembly: IncludeInNancyAssemblyScanning]
namespace Nancy2Core
{
    public class Nancy2 : NancyModule
    {
        public Nancy2()
        {
            Get("/Nancy2", _ => "Nancy2");
        }
    }
}
