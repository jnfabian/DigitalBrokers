using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Web.DigitalBrokers
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // vehicular
            routes.MapRoute(
                "Vehicular",
                "vehicular",
                new { controller = "vehicular", action = "Index" }
            );

            //Salud
            routes.MapRoute(
                "Salud",
                "Salud",
                new { controller = "Salud", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Vehicular", action = "Index", id = UrlParameter.Optional }
            );
            
           

        }
    }
}
