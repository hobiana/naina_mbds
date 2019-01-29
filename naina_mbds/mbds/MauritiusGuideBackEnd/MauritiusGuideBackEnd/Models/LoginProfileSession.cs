﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MauritiusGuideBackEnd.Models
{
    [Serializable]
    public class LoginProfileSession
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
    }
}