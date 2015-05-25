using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace PensioenSysteem.Application.Deelnemer
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented; 

            // Web API routes
            config.MapHttpAttributeRoutes();
        }
    }
}
