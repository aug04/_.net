using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SomeeMVC_4
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.LowercaseUrls = true;

            var dataTokens = new RouteValueDictionary();
            var ns = new string[] { "SomeeMVC_4.Controllers" };
            dataTokens["Namespaces"] = ns;

            routes.Add(new Route("{controller}/{action}/{id}",
                          new RouteValueDictionary(
                             new { controller = "Home", action = "Index", id = "" }),
                             null,
                             dataTokens,
                             new HyphenatedRouteHandler()));
            
            routes.Add(new Route("{year}/{month}/{controller}/{action}/{id}",
                          new RouteValueDictionary(
                             new { controller = "Home", action = "Index", id = "" }),
                             new HyphenatedRouteHandler()));

        }
    }
}