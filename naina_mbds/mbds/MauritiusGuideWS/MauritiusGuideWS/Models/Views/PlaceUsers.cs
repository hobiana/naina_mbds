namespace MauritiusGuideWS.Models.Views
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PlaceUsers
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 1)]
        public string Name { get; set; }

        [Key]
        [Column(Order = 2)]
        public string PhoneNumber { get; set; }

        [Key]
        [Column(Order = 3)]
        public string Email { get; set; }

        [Key]
        [Column(Order = 4)]
        public string RoleName { get; set; }

        [Key]
        [Column(Order = 5)]
        public string Nom { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PlaceId { get; set; }
    }
}
