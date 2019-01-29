using MauritiusGuideWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MauritiusGuideBackEnd.ViewModel
{
    public class PhotoCheckPointViewModel
    {
        public IEnumerable<Photo_CheckPoint> Photo_CkeckPoints { get; set; }
        public Photo_CheckPoint Photo_CheckPoint { get; set; }
        public CheckPoint CheckPoint { get; set; }
        public IEnumerable<CheckPoint> CheckPoints { get; set; }

    }
}