using MauritiusGuideBackEnd.ViewModel;
using MauritiusGuideWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MauritiusGuideBackEnd.Models;
using MauritiusGuideWS.Utilitaire;

namespace MauritiusGuideBackEnd.Controllers
{
    public class AccountController : Controller
    {
        private GuideContext _context;
        public AccountController()
        {
            _context = new GuideContext();
        }

        public ActionResult Login()
        {
            AccountViewModel view = new AccountViewModel();
            return View(view);
        }

        [HttpPost]
        public ActionResult Login(Models.Account account)
        {
            if (!ModelState.IsValid)
            {
                AccountViewModel viewmodel = new AccountViewModel();
                return View("Login", viewmodel);
            }
            LoginProfileSession profile = CheckUser(account.Email, account.Password);
            if (profile==null)
            {

                AccountViewModel viewmodel = new AccountViewModel();
                return View("Login", viewmodel);
            }
            else
            {
                System.Web.HttpContext.Current.Session["UserProfile"] = profile;
            }            
            
            return RedirectToAction("Index","Home");
        }

        private LoginProfileSession CheckUser(string email, string pwd)
        {
            var mdp = Utilitaire.Sha256(pwd);
            var users = _context.Users
                .Include(m => m.Role)
                .Include(m => m.Languages)
                .Where(m => m.Email.Equals(email))
                .Where(m => m.Pwd.Equals(mdp))
                .Where(m => m.Active==true)
                .ToList();
            if (users.Count() > 0)
            {
                var profile = new LoginProfileSession()
                {
                    ID = users[0].ID,
                    Name = users[0].Name,
                    Role = users[0].Role.RoleName,
                    Email = users[0].Email
                };
                return profile;
            }
            return null;
        }

        public ActionResult LogOut()
        {
            System.Web.HttpContext.Current.Session["UserProfile"] = null;
            return RedirectToAction("Login","Account");
        }
    }
}