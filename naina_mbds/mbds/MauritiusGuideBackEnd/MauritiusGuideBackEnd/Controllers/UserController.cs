using MauritiusGuideBackEnd.utilitaire;
using MauritiusGuideBackEnd.ViewModel;
using MauritiusGuideWS.Models;
using MauritiusGuideWS.Models.Views;
using MauritiusGuideWS.Utilitaire;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MauritiusGuideBackEnd.Controllers
{
    public class UserController : BaseController
    {
        private GuideContext _context;
        private GuideViewContext _vcontext;

        public UserController()
        {
            _context = new GuideContext();
            _vcontext = new GuideViewContext();
        }
        [ActionFilterRole]
        public ActionResult Index()
        {
            return View();
        }

        [ActionFilterRole]
        public ActionResult List()
        {
            return View();
        }

        [ActionFilterRole]
        public ActionResult New()
        {
            var roleList = _context.Roles.ToList();
            var langueList = _context.Languages.ToList();
            var data = new UserViewModel()
            {
                Languages = langueList,
                Roles = roleList
            };
            return View(data);
        }

        public ActionResult Create(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                
                var user = new User()
                {
                    Name = userModel.Name,
                    LanguagesID = userModel.LanguagesID,
                    RoleID = userModel.RoleID,
                    Email = userModel.Email,
                    PhoneNumber = userModel.PhoneNumber,
                    Pwd = Utilitaire.Sha256(userModel.Pwd),
                    Active = userModel.Active,
                    CreateDate = DateTime.Now
                };
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("List", "User");
            }

            return View("New", userModel);
        }

        [ActionFilterRole]
        public ActionResult Edit(int ID)
        {
            var roleList = _context.Roles.ToList();
            var langueList = _context.Languages.ToList();
            var user = _context.Users.Find(ID);
            var userModel = new UserModel()
            {
                ID = user.ID,
                Name = user.Name,
                LanguagesID = user.LanguagesID,
                RoleID = user.RoleID,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Pwd = Utilitaire.Sha256(user.Pwd),
                Active = user.Active,
                CreateDate = user.CreateDate
            };
            var data = new UserViewModel()
            {
                Languages = langueList,
                Roles = roleList,
                UserModel = userModel
            };
            return View(data);
        }

        public ActionResult Update(UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", userModel);
            }
            else
            {
                var user = _context.Users.SingleOrDefault(m => m.ID == userModel.ID);
                user.ID = userModel.ID;
                user.Name = userModel.Name;
                user.LanguagesID = userModel.LanguagesID;
                user.RoleID = userModel.RoleID;
                user.Email = userModel.Email;
                user.PhoneNumber = userModel.PhoneNumber;
                user.Pwd = userModel.Pwd;
                user.Active = userModel.Active;
                user.CreateDate = userModel.CreateDate;
                _context.SaveChanges();
            }
            return RedirectToAction("List", "User");
        }


        [ActionFilterRole]
        public ActionResult Places(int id)
        {
            var user = _context.Users.Include(m => m.Role).SingleOrDefault(m => m.ID==id);

            IQueryable<PlaceModel> UserPlaces;
            if (user.Role.RoleName.Equals("admin"))
            {
                UserPlaces = _vcontext.ListPlaces;
            }
            else
            {
                UserPlaces = _vcontext.UserPlaces.Where(m => m.UserId == id);
            }
            UserViewModel view = new UserViewModel()
            {
                PlaceModel = UserPlaces,
                User = user
            };
            return View(view);
        }


        [HttpPost]
        public ActionResult AddPlaces(IEnumerable<int> placeIdsToAdd, int userId)
        {
            List<User_Place> PlacesToAdd = new List<User_Place>();
            foreach (var id in placeIdsToAdd)
            {
                PlacesToAdd.Add(new User_Place()
                {
                    PlaceId = id,
                    UserId = userId
                });
            }
            _context.User_Places.AddRange(PlacesToAdd);
            _context.SaveChanges();
            return RedirectToAction("Places", "User", new { id = userId });
        }

        [ActionFilterRole]
        public ActionResult NewPlace(int id)
        {
            var places = from p in _context.Places
                         where !(from up in _context.User_Places
                                 where up.UserId == id
                                 select up.PlaceId).Contains(p.ID)
                         select p;
            var user = _context.Users.SingleOrDefault(m => m.ID == id);
            UserViewModel view = new UserViewModel()
            {
                Places = places,
                User = user
            };
            return View(view);
        }


      
    }
}