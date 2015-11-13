using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.Owin;
using Newtonsoft.Json;
using Owin;

[assembly: OwinStartup(typeof(Adressekartotek.Startup))]

namespace Adressekartotek
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            
        }
    }
}
