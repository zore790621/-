using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DotrA
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Error",
                url: "Error/{action}",
                defaults: new { controller = "Error", action = "Error" },
                namespaces: new string[] { "DotrA.Controllers" }
                );
            routes.MapRoute(
                name: "Shop",
                url: "Shop/{page}/{pid}",
                defaults: new { controller = "Shop", action = "Index", page = UrlParameter.Optional, pid = UrlParameter.Optional },
                constraints: new { page = @"\d", pid = @"\d" },
                namespaces: new string[] { "DotrA.Controllers" }
                );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "DotrA.Controllers" }
                );
        }
    }
}
