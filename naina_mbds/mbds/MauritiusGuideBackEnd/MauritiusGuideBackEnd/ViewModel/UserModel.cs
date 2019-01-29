using MauritiusGuideWS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MauritiusGuideBackEnd.ViewModel
{
    public class UserModel : BaseModel
    {
        [Required]
        public int LanguagesID { get; set; }
       


        public DateTime CreateDate { get; set; }

        [Required]
        public int RoleID { get; set; }


        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Pwd { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public bool Active { get; set; }

        [Required]
        [Compare("Pwd", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string ConfirmPassword { get; set; }
    }
}