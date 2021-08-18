using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebLaiXe
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute(
               name:"efault",
               url:"{controller}/{action}/{id}",
               defaults: new { Controller = "Home", action = "Index", id = UrlParameter.Optional },
               new string[] { "WebLaiXe.Controllers" }
           );
        }
    }
}
