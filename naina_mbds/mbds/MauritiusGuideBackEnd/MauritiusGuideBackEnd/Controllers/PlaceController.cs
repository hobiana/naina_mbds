using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MauritiusGuideWS.Models;
using System.Data.Entity;
using System.Web.Routing;
using MauritiusGuideBackEnd.ViewModel;
using MauritiusGuideBackEnd.Models;

namespace MauritiusGuideBackEnd.Controllers
{
    public class PlaceController : BaseController
    {
        public GuideContext _context { get; set; }
        public GuideViewContext _vcontext { get; set; }

        public PlaceController()
        {
            _context = new GuideContext();
            _vcontext = new GuideViewContext();
        }

        // GET: Place
        public ActionResult Index()
        {
            var profile = this.GetProfileSession() as LoginProfileSession;
            if (profile.Role.Equals("admin"))
            {
                return View("Index");
            }
            return View("ModerateurPlace");
        }

        // GET: Places/Create
        [ActionFilterRole]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Places/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PlaceName,Latitude,Longitude,IsIndoor,IsOutdoor")] Place place)
        {
            if (ModelState.IsValid)
            {
                if (place.IsIndoor == true)
                {
                    place.IsOutdoor = !place.IsIndoor;
                }
                else
                {
                    place.IsOutdoor = !place.IsIndoor;
                }
                _context.Places.Add(place);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(place);
        }

        
        public ActionResult Edit(int ID)
        {
            Place place = _context.Places.Find(ID);
            return View(place);
        }

        [HttpPost]
        public ActionResult Update(Place place)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", place);
            }
            else
            {
                _context.Entry(place).State = EntityState.Modified;
                
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [ActionFilterRole]
        public ActionResult PlaceUser(int ID)
        {
            var place = new Place()
            {
                ID = ID
            };
            var PlaceUsers = _vcontext.PlaceUsers
                .Where(m => m.PlaceId == ID)
                .Where(m => m.RoleName != "admin");

            PlaceViewModel view = new PlaceViewModel()
            {
                PlaceUsers = PlaceUsers,
                Place = place
            };
            return View(view);
        }

        [ActionFilterRole]
        public ActionResult NewUser(int ID)
        {
            var users = from u in _context.Users
                        .Include(t=>t.Role)
                        .Include(t=>t.Languages)
                        .Where(t=>t.Active==true)
                        where !(from up in _context.User_Places
                                where up.PlaceId == ID
                                select up.UserId).Contains(u.ID)
                        where u.Role.RoleName != "admin"
                        select u;

            var place = _context.Places.SingleOrDefault(m => m.ID == ID);

            PlaceViewModel view = new PlaceViewModel()
            {
                Users = users,
                Place = place
            };
            return View(view);
        }


        [HttpPost]
        public ActionResult AddUsers(IEnumerable<int> UserIdsToAdd, int PlaceId)
        {
            List<User_Place> UsersToAdd = new List<User_Place>();
            foreach (var id in UserIdsToAdd)
            {
                UsersToAdd.Add(new User_Place()
                {
                    PlaceId = PlaceId,
                    UserId = id
                });
            }
            _context.User_Places.AddRange(UsersToAdd);
            _context.SaveChanges();
            return RedirectToAction("PlaceUser", "Place", new { id = PlaceId });
        }


    }
}