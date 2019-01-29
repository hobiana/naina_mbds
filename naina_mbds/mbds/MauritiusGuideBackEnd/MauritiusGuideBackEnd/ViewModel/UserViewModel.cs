using MauritiusGuideWS.Models;
using MauritiusGuideWS.Models.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MauritiusGuideBackEnd.ViewModel
{
    public class UserViewModel
    {
        public User User { get; set; }
        public IEnumerable<Role> Roles { get; set; }
        public IEnumerable<Languages> Languages { get; set; }
        public UserModel UserModel { get; set; }
        public IEnumerable<PlaceModel> PlaceModel { get; set; }
        public IEnumerable<Place> Places { get; set; }
        public User_Place User_Place { get; set; }

    }
}