using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EMA
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*x}", new { x = @".*\.asmx(/.*)?" });
            routes.IgnoreRoute("{*x}", new { x = @".*\.aspx(/.*)?" });
            routes.IgnoreRoute("{*x}", new { x = @".*\.svc(/.*)?" });
            routes.IgnoreRoute("{*x}", new { x = @".*\.ashx(/.*)?" });
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
