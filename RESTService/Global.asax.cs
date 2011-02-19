using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using RESTService.Models;

namespace RESTService
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // ~/
            routes.MapRoute(
                "Default",
                "",
                new { controller = "Default", action = "Index" }
            );

            // ~/API
            routes.MapRoute(
                "Index", // Route name
                "API", // URL with parameters
                new { controller = "Monster", action = "Index" } // Parameter defaults
            );

            // ~/API/Monster (POST)
            routes.MapRoute(
                "InsertMonster", // Route name
                "API/Monster", // URL with parameters
                new { controller = "Monster", action = "InsertMonster" } // Parameter defaults
            );

            // ~/API/Monster/Jackraw
            routes.MapRoute(
                "API", // Route name
                "API/{action}/{name}", // URL with parameters
                new { controller = "Monster", action = "Monster" } // Parameter defaults
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            // Add ability to POST XML to action methods (in addition to default JSON).
            ValueProviderFactories.Factories.Add(new XmlValueProviderFactory());
        }
    }
}