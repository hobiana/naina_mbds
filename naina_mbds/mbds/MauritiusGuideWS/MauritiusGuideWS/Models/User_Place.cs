using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MauritiusGuideWS.Models
{
    public class User_Place : BaseModel
    {
        public int PlaceId { get; set; }
        public Place Place { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}