using MauritiusGuideBackEnd.Models;
using MauritiusGuideWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MauritiusGuideBackEnd.utilitaire
{
    public class UtilSession
    {
        private GuideContext _context;
        public UtilSession()
        {
            _context = new GuideContext();
        }

        private void SetProfileSession(HttpSessionStateBase session,LoginProfileSession profile)
        {
            session["UserProfile"] = profile;
        }


        private bool CheckUserSession()
        {
            var session = System.Web.HttpContext.Current.Session;
            if (session["UserProfile"] != null)
            {
                return true;
            }
            return false;
        }

        private LoginProfileSession GetProfileSession()
        {
            //return this.Session["UserProfile"] as LoginProfileSession;
            return null;
        }


        
    }
}