namespace MauritiusGuideWS.Migrations
{
    using MauritiusGuideWS.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MauritiusGuideWS.Models.GuideContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "MauritiusGuideWS.Models.GuideContext";
        }

        protected override void Seed(MauritiusGuideWS.Models.GuideContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            //List Of places

            #region Codes

            #region Places
         /*
            var list = new List<Place>() {

                 new Place() { ID = 1, PlaceName = "Bagatelle Mall",Latitude = -20.2237 ,Longitude = 57.4971},
                 new Place() { ID = 2, PlaceName = "Trianon Shopping Centre", Latitude = -20.2578, Longitude = 57.4912 },
                // new Places() { PlaceId = 3, PlaceName = "Ebene Commercial Centre", Latitude = -20.2433, Longitude = 57.4881 },
                 new Place() {ID=4,PlaceName="Le Rocher",Latitude=-20.019289,Longitude=57.58407199999999},
                 new Place() {ID=5,PlaceName="Super U Flacq",Latitude=-20.1841846,Longitude=57.72337500000003},
                 new Place() {ID=6,PlaceName="La Vanille Nature Park",Latitude=-20.4997037,Longitude=57.56299799999999},
                 new Place() {ID=7,PlaceName="Chamarel Waterfall",Latitude=-20.4432218,Longitude=57.385778699999946},
                 new Place() {ID=8,PlaceName="Macarena Club",Latitude=-20.103453,Longitude=57.72997856140137},
                 new Place() {ID=9,PlaceName="Queen's Club",Latitude=-20.2708697,Longitude=57.47494610000001},
                 new Place() {ID=10,PlaceName="Citadel",Latitude=-20.163731128611275,Longitude=57.51020908355713},
                 new Place(){ID=11,PlaceName="BPML Cyber Tower 1",Latitude=-20.244542267815166,Longitude=57.49177694320679}
            };
            //Seeding Places First
            foreach (var item in list)
            {
                context.Places.AddOrUpdate(item);
            }
        */
            #endregion


            #region Beacons
            /*
            //Seeding Beacons
            string UUID = ("fda5069-a4e2-4fb1-afcf-c6eb07647825");
            var Beacons = new List<CheckPoint>() {

                 new CheckPoint() { MajorId = 2,MinorId=5, BeaconName = "Vincent's Office",BeaconOrder =1 ,BeaconUuid=UUID, PlaceId=10},
                 new CheckPoint() { MajorId = 1,MinorId=16, BeaconName = "Jenny's Office",BeaconOrder = 2 ,BeaconUuid=UUID, PlaceId=10},
                 new CheckPoint() { MajorId = 1,MinorId=12, BeaconName = "Reena's Office",BeaconOrder = 3 ,BeaconUuid=UUID, PlaceId=10},
                 new CheckPoint() { MajorId = 1,MinorId=12, BeaconName = "Nowhere",BeaconOrder = 4 ,BeaconUuid=UUID, PlaceId=9},
                 new CheckPoint() { BeaconName = "Infront Of Bpml", PlaceId=10,Latitude=-20.24418,Longitude=57.49228},
                 new CheckPoint() { BeaconName = "Back Parking Lot Of Bpml", PlaceId=10,Latitude=-20.24626,Longitude=57.49137},
                 new CheckPoint() { BeaconName = "Terra", PlaceId=10,Latitude=-20.24502,Longitude=57.49187},
                 new CheckPoint() { BeaconName = "Nu Baz", PlaceId=10,Latitude=-20.2451246,Longitude=57.4918698}
                 //remove HasVisited


            };
            foreach (var item in Beacons)
            {
                context.Beacons.AddOrUpdate(item);
            }
            */
            #endregion

            #region Photo_Places
            
            var photo_places = new List<Photo_CheckPoint>()
            {
                new Photo_CheckPoint{ID = 1, Description ="Who is that man?", Photo_Path ="http://mauririusguide.blob.core.windows.net/photoes/bagarres_raciales.jpg", CheckPointId=7},
                new Photo_CheckPoint{ID = 2, Description ="Who is that man?", Photo_Path ="http://mauririusguide.blob.core.windows.net/photoes/xxx.png", CheckPointId=8}

            };
            foreach (var item in photo_places)
            {
                context.Photo_CheckPoints.AddOrUpdate(item);
            }
            
            #endregion
            
            #endregion




        }
    }
}
