using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MauritiusGuideWS.Models
{
    public class User : BaseModel
    {
        public int LanguagesID { get; set; }
        public Languages Languages { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreateDate { get; set; }

        public int RoleID { get; set; }
        public Role Role { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Pwd { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public bool Active { get; set; }

    }
}