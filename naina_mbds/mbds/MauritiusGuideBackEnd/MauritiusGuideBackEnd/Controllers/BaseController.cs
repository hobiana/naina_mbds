using MauritiusGuideBackEnd.Models;
using MauritiusGuideWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MauritiusGuideBackEnd.Controllers
{
    [RedirectLogin]
    public class BaseController : Controller
    {
        private GuideContext _context;
        public BaseController()
        {
            ViewData["profile"] = GetProfileSession();
            _context = new GuideContext();
        }

        public void SetProfileSession(LoginProfileSession profile)
        {
            System.Web.HttpContext.Current.Session["UserProfile"] = profile;
        }

        public bool CheckUserSession()
        {
            var session = (LoginProfileSession)System.Web.HttpContext.Current.Session["UserProfile"];
            if (session!= null)
            {
                return true;
            }
            return false;
        }

        public LoginProfileSession GetProfileSession()
        {
            if(System.Web.HttpContext.Current.Session["UserProfile"]!=null)
            {
                return (LoginProfileSession)System.Web.HttpContext.Current.Session["UserProfile"];
            }
            return null;
           
        }

        public ActionResult RedirectToLogin()
        {
            return RedirectToAction("Login","Account");
        }
    }
}