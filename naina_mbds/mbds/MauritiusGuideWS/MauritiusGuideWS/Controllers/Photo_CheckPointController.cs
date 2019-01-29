using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MauritiusGuideWS.Models;
using System.IO;
using System.Web.Http.Cors;

namespace MauritiusGuideWS.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-Custom-Header")]
    public class Photo_CheckPointController : ApiController
    {
        private GuideContext db = new GuideContext();

        // GET: api/Photo_Place
        public IQueryable<Photo_CheckPoint> GetPhoto_CheckPoint()
        {
            return db.Photo_CheckPoints;
        }
        // GET: api/Photo_Place/GetPhotoByPlace/5
        public IQueryable<Photo_CheckPoint> GetPhotoByCheckPoint(int Id)
        {
            var res = db.Photo_CheckPoints.Where(x => x.CheckPointId == Id);
            return res;
        }
        // GET: api/Photo_Place/5
        [ResponseType(typeof(Photo_CheckPoint))]
        public IHttpActionResult GetPhoto_Place(int id)
        {
            Photo_CheckPoint photo_Place = db.Photo_CheckPoints.Find(id);
            if (photo_Place == null)
            {
                return NotFound();
            }

            return Ok(photo_Place);
        }

        // PUT: api/Photo_Place/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPhoto_Place(int id, Photo_CheckPoint photo_Place)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != photo_Place.ID)
            {
                return BadRequest();
            }

            db.Entry(photo_Place).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Photo_PlaceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Photo_Place
        [ResponseType(typeof(Photo_CheckPoint))]
        public IHttpActionResult PostPhoto_Place(Photo_CheckPoint photo_Place)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Photo_CheckPoints.Add(photo_Place);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = photo_Place.ID }, photo_Place);
        }

        // DELETE: api/Photo_Place/5
        [ResponseType(typeof(Photo_CheckPoint))]
        public IHttpActionResult DeletePhoto_Place(int id)
        {
            Photo_CheckPoint photo_Place = db.Photo_CheckPoints.Find(id);
            if (photo_Place == null)
            {
                return NotFound();
            }

            db.Photo_CheckPoints.Remove(photo_Place);
            db.SaveChanges();

            return Ok(photo_Place);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Photo_PlaceExists(int id)
        {
            return db.Photo_CheckPoints.Count(e => e.ID == id) > 0;
        }

        public void InsertPhoto()
        {
            Byte[] bytes = File.ReadAllBytes("path");
            String file = Convert.ToBase64String(bytes);
            
        }

    }
}