using MauritiusGuideWS.Models;
using MauritiusGuideWS.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MauritiusGuideBackEnd.ViewModel
{
    public class PlaceViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public User_Place User_Place { get; set; }
        public Place Place { get; set; }
        public IEnumerable<PlaceUsers> PlaceUsers { get; set; }
    }
}