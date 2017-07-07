using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nancy;

namespace Nancy3Web
{
    public class Nancy3InternalModule : NancyModule
    {
        public Nancy3InternalModule()
        {
            this.Get("/internalmod", _ => "Internal Module" );
        }
    }
}
