using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MauritiusGuideWS.Models
{
    public class Languages : BaseModel
    {
        [Required]
        public string Nom { get; set; }
    }
}