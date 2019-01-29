using MauritiusGuideWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using System.Data.Entity;
using System.Web.Http.Cors;
using MauritiusGuideWS.Models.Views;

namespace MauritiusGuideWS.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-Custom-Header")]
    public class UserController : ApiController
    {
        private GuideContext db ;
        private GuideViewContext _vdb;

        public UserController()
        {
            db = new GuideContext();
            _vdb = new GuideViewContext();
        }

        [ResponseType(typeof(User))]
        public IHttpActionResult Postuser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Users.Add(user);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = user.ID }, user);
        }

        public IQueryable<User> GetUsers()
        {
            var dbval = db.Users.Include(m=>m.Role).Include(m=>m.Languages).Where(m=>m.Active==true);
            return dbval;
        }

        [ResponseType(typeof(User))]
        public IHttpActionResult GetUsers(int id)
        {
            User users = db.Users.Find(id);
            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }


        [ResponseType(typeof(Place))]
        public IHttpActionResult DeleteUsers(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            user.Active = false;
            
            db.SaveChanges();

            return Ok(user);
        }

        // Get List of Places of that an user is allowed to modify
        public IHttpActionResult GetPlaces(int id)
        {
            var User = db.Users.Include(m => m.Role).SingleOrDefault(m => m.ID == id);
            if (User.Role.RoleName.Equals("admin"))
            {
                var places = _vdb.ListPlaces;
                return Ok(places);
            }
            else
            {
                var places = _vdb.UserPlaces.Where(m => m.UserId == id);
                if (places == null)
                {
                    return NotFound();
                }

                return Ok(places);
            }
            
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.ID == id) > 0;
        }
    }

   
}