namespace MauritiusGuideWS.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using MauritiusGuideWS.Models.Views;

    public partial class GuideViewContext : DbContext
    {
        public GuideViewContext()
            : base("name=ConString")
        {
        }

        public virtual DbSet<ListPlace> ListPlaces { get; set; }
        public virtual DbSet<PhotosPlace> PhotosPlace { get; set; }

        public virtual DbSet<UserPlaces> UserPlaces { get; set; }
        public virtual DbSet<PlaceUsers> PlaceUsers { get; set; }

        public virtual DbSet<UserCheckpoints> UserCheckpoints { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
