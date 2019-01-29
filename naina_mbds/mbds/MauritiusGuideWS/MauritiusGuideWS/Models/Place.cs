using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MauritiusGuideWS.Models
{
    public class Place : BaseModel
    {
        public string PlaceName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool IsIndoor { get; set; }
        public bool IsOutdoor { get; set; }

        #region Navigation Property
   
        public ICollection<CheckPoint> Beacons { get; set; }
        #endregion
    }
}