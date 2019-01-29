using MauritiusGuideWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace MauritiusGuideWS.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-Custom-Header")]
    public class BeaconsController : ApiController
    {
        private GuideContext db = new GuideContext();
        public List<CheckPoint> Beacons { get; set; }
        public BeaconsController()
        {
            string UUID = ("fda5069-a4e2-4fb1-afcf-c6eb07647825");
            Beacons = new List<CheckPoint>() {

                 new CheckPoint() { MajorId = 2,MinorId=5, BeaconName = "Vincent's Office",BeaconOrder =1 ,BeaconUuid=UUID, PlaceId=11},
                 new CheckPoint() { MajorId = 1,MinorId=16, BeaconName = "Jenny's Office",BeaconOrder = 2 ,BeaconUuid=UUID, PlaceId=11},
                 new CheckPoint() { MajorId = 1,MinorId=12, BeaconName = "Reena's Office",BeaconOrder = 3 ,BeaconUuid=UUID, PlaceId=11},
                 new CheckPoint() { MajorId = 1,MinorId=12, BeaconName = "Nowhere",BeaconOrder = 4 ,BeaconUuid=UUID, PlaceId=10},
                 new CheckPoint() { BeaconUuid="", BeaconName = "Infront Of Bpml", PlaceId=11,Latitude=-20.24418,Longitude=57.49228},
                 new CheckPoint() { BeaconUuid="", BeaconName = "Back Parking Lot Of Bpml", PlaceId=11,Latitude=-20.24626,Longitude=57.49137}
                 //remove HasVisited


            };
        }

        public IQueryable<CheckPoint> GetBeacons()
        {
            var res = db.Beacons;
            
            return res;

        }
        //[ResponseType(typeof(Beacon))]
        public IQueryable<CheckPoint> GetBeaconByPlace(int Id)
        {
            var res = db.Beacons.Where(x => x.PlaceId == Id);
            return res;
        }

        // POST: api/Checkpoint
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
    }
}
