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
using System.Web.Http.Cors;
using MauritiusGuideWS.Models.Views;

namespace MauritiusGuideWS.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-Custom-Header")]
    public class PlacesController : ApiController
    {
        private GuideContext db = new GuideContext();
        private GuideViewContext vdb = new GuideViewContext();

        // GET: api/Places

        public IQueryable<ListPlace> GetPlaces()
        {
            var dbval =  vdb.ListPlaces;

            return dbval;
        }
        // GET: api/Places/5
        
        [ResponseType(typeof(Place))]
        public IHttpActionResult GetPlaces(int id)
        {
            Place places = db.Places.Find(id);
            if (places == null)
            {
                return NotFound();
            }

            return Ok(places);
        }

        // PUT: api/Places/5
       
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlaces(int id, Place places)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != places.ID)
            {
                return BadRequest();
            }

            db.Entry(places).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlacesExists(id))
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

        // POST: api/Places
        
        [ResponseType(typeof(Place))]
        public IHttpActionResult PostPlaces(Place places)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Places.Add(places);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = places.ID }, places);
        }

        // DELETE: api/Places/5
        
        [ResponseType(typeof(Place))]
        public IHttpActionResult DeletePlaces(int id)
        {
            Place places = db.Places.Find(id);
            if (places == null)
            {
                return NotFound();
            }

            db.Places.Remove(places);
            db.SaveChanges();

            return Ok(places);
        }

        [ResponseType(typeof(Place_Comment))]
        public IHttpActionResult PostRating(Place_Comment place_Comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Place_Comments.Add(place_Comment);

            try
            {
                db.SaveChanges();
            }
            catch(DbUpdateException)
            {
                return BadRequest();
            }
            return Ok(place_Comment);
        }

        [ResponseType(typeof(Photo_CheckPoint))]
        public IHttpActionResult GetPhotos(int id)
        {
            var PhotosPlace = vdb.PhotosPlace.Where(m => m.PlaceId==id);
            return Ok(PhotosPlace);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlacesExists(int id)
        {
            return db.Places.Count(e => e.ID == id) > 0;
        }
    }
}