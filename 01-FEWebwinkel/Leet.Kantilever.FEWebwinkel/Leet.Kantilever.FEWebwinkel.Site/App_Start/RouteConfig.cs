using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Leet.Kantilever.FEWebwinkel.Site
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Login", "Login",
                new { controller = "Authentication", action = "Login" }
            );

            routes.MapRoute("Logout", "Logout",
                new { controller = "Authentication", action = "Logout" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Catalogus", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
