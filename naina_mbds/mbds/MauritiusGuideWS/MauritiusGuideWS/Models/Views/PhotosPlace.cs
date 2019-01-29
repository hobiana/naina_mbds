namespace MauritiusGuideWS.Models.Views
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhotosPlace")]
    public partial class PhotosPlace
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PhotoId { get; set; }

        public int? CheckPointId { get; set; }

        public int? PlaceId { get; set; }

        public string Photo_Path { get; set; }

        public string Description { get; set; }

        public string Photo_Code { get; set; }

        public string Photo_Extension { get; set; }
    }
}
