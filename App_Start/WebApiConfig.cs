using BigSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BigSchool
{
    public static class WebApiConfig
    {
        [HttpPost]
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
        
        
    }
}
