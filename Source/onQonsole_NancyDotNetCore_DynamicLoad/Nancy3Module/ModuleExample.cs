using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy3Shared;

namespace ModuleExample
{
    public class ModuleExample : IModule
    {
        public void Test()
        {
            Console.WriteLine("This is called from the module");
        }
    }
}
