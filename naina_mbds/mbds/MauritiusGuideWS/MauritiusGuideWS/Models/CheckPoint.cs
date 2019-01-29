using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MauritiusGuideWS.Models
{
    public class CheckPoint : BaseModel
    {
        public string BeaconUuid { get; set; }
        public int BeaconOrder { get; set; }
        public int MajorId { get; set; }
        public int MinorId { get; set; }
        public string BeaconName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool Active { get; set; }

        //Foreign Key
        [Display(Name ="Place")]
        public int PlaceId { get; set; }
        #region Navigation Property
            public virtual Place Places { get; set; }
        public ICollection<Photo_CheckPoint> Photoes { get; set; }

        #endregion

    }
}