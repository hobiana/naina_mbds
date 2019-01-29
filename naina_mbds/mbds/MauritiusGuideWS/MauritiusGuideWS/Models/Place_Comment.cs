using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MauritiusGuideWS.Models
{
    public class Place_Comment : BaseModel
    {
        public int UserID { get; set; }
        public User User { get; set; }

        public int PlaceID { get; set; }
        public Place Place { get; set; }

        public string Commentaire { get; set; }

        [Required]
        public int Notation { get; set; }
    }
}