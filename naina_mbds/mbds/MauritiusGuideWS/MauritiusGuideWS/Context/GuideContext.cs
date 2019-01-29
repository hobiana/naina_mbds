using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace MauritiusGuideWS.Models
{
    public class GuideContext : DbContext
    {
        public GuideContext() 
            : base("name=ConString")
           
        {
            this.Configuration.LazyLoadingEnabled = false;


        }
        public DbSet<Photo_CheckPoint> Photo_CheckPoints { get; set; }
        public DbSet<CheckPoint> Beacons { get; set; }
        public DbSet<Place> Places{ get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Languages> Languages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Place_Comment> Place_Comments { get; set; }
        public DbSet<User_Place> User_Places { get; set; }

    }
}