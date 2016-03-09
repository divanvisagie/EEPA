using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;

namespace EEPA.Api.Modules
{
    public class IndexModule : NancyModule
    {
        public IndexModule() : base("/api")
        {
            Get["/"] = Index;
        }

        private dynamic Index(dynamic o)
        {
            return "Api is running";
        }
    }
}
