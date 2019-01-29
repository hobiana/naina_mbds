using MauritiusGuideWS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.Mvc;

namespace MauritiusGuideWS.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-Custom-Header")]
	
    public class CheckPointController : ApiController
    {
        private GuideContext db;
        private GuideViewContext _db;
        // PUT: api/Places/5

        public CheckPointController()
        {
            db =new GuideContext();
            _db = new GuideViewContext();
        }


        public IQueryable<CheckPoint> GetCheckPoint()
        {
            var res = db.Beacons.Where(m => m.Active==true);

            return res;

        }


        [ResponseType(typeof(CheckPoint))]
        public IHttpActionResult GetCheckPoint(int id)
        {
            CheckPoint checkpoint = db.Beacons.Find(id);
            if (checkpoint == null || checkpoint.Active==false)
            {
                return NotFound();
            }

            return Ok(checkpoint);
        }


        [ResponseType(typeof(void))]
        public IHttpActionResult PutCheckPoint(int id, CheckPoint checkpoint)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != checkpoint.ID)
            {
                return BadRequest();
            }

            db.Entry(checkpoint).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CheckPointExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }


        [ResponseType(typeof(CheckPoint))]
        public IHttpActionResult DeleteCheckPoint(int id)
        {
            CheckPoint checkpoint = db.Beacons.Find(id);
            checkpoint.Active = false;
            if (checkpoint == null)
            {
                return NotFound();
            }
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CheckPointExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(checkpoint);
        }


        [ResponseType(typeof(CheckPoint))]
        public IHttpActionResult PostCheckpoint(CheckPoint beacons)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Beacons.Add(beacons);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = beacons.ID }, beacons);
        }

        public IQueryable<CheckPoint> GetCheckPointByPlace(int Id)
        {
            var res = db.Beacons
                .Where(x => x.PlaceId == Id)
                .Where(x => x.Active == true);
            return res;
        }

        public IHttpActionResult GetCheckPointByUser(int Id)
        {
            var user = db.Users.Include(m => m.Role).SingleOrDefault(m => m.ID == Id);
            if (user.Role.RoleName.Equals("admin"))
            {
                var checkpoints = db.Beacons;
                return Ok(checkpoints);
            }
            var res = _db.UserCheckpoints.Where(m => m.UserId == Id);
            return Ok(res);
        }

        private bool CheckPointExists(int id)
        {
            return db.Beacons.Count(e => e.ID == id) > 0;
        }
    }
}