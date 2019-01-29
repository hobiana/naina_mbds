using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MauritiusGuideWS.Models.Views
{
    public class PlaceModel
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 1)]
        public string PlaceName { get; set; }

        [Key]
        [Column(Order = 2)]
        public double Latitude { get; set; }

        [Key]
        [Column(Order = 3)]
        public double Longitude { get; set; }

        [Key]
        [Column(Order = 4)]
        public bool IsIndoor { get; set; }

        [Key]
        [Column(Order = 5)]
        public bool IsOutdoor { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AverageRating { get; set; }
    }
}