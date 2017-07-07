using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;

namespace ModuleExample
{
    public class ModuleRoute : NancyModule
    {

        public ModuleRoute() : base("/moduleexample")
        {
            Get("/", parameters =>
            {
                return "Welcome To Your Module";
            });
        }

    }
}
