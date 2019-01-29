using MauritiusGuideWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MauritiusGuideBackEnd.ViewModel
{
    public class CheckPointViewModel
    {
        public IEnumerable<Place> Places { get; set; }
        public Place Place { get; set; }
        public CheckPoint CheckPoint { get; set; }
       
    }
}