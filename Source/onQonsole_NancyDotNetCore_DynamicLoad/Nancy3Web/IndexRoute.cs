using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;

namespace NancyModuleExample
{
    public class IndexRoute : NancyModule
    {

        public IndexRoute() : base("/")
        {
            Get("/", parameters =>
            {
                return @"Visit http://localhost:8888/moduleexample access the module.";
            });
        }


    }
}
