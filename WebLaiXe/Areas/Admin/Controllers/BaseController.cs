using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebLaiXe.Models;

namespace WebLaiXe.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filterContext)
        {
            var session = (UserInfo)Session["Users"];
            if(session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(
                                new
                                {
                                    controller = "Home",
                                    action = "Login"
                                }));
            }
            base.OnActionExecuting(filterContext);
        }

    }
}