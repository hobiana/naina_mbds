 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MauritiusGuideWS.Models
{
    public class Photo_CheckPoint : BaseModel
    {

        public string Photo_Path { get; set; }
        public string Photo_Code { get; set; }
        public string Photo_Extension { get; set; }
        public string Description { get; set; }
        public int CheckPointId { get; set; }
    }
}