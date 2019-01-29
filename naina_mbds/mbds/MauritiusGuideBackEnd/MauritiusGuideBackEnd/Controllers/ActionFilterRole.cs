using MauritiusGuideBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MauritiusGuideBackEnd.Controllers
{
    public class ActionFilterRole : System.Web.Mvc.ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            var profile = (LoginProfileSession)System.Web.HttpContext.Current.Session["UserProfile"];

            if (profile.Role !="admin" )
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Home",
                    action = "Index"
                }));
            }
            

        }
    }
}