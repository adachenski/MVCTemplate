﻿namespace MVCTemplate.Web
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Get questions by tag",
                url: "questions/tagged/{tag}",
                defaults: new { controller = "Questions", action = "GetByTag" });

            routes.MapRoute(
                name: "Display question",
                url: "questions/{id}/{url}",
                defaults: new { controller = "Questions", action = "Display" });

            routes.MapRoute(
                name: "JokePage",
                url: "Joke/{id}",
                defaults: new { controller = "Jokes", action = "ById" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}
