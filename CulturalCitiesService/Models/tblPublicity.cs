namespace CulturalCitiesService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblPublicity")]
    public partial class tblPublicity
    {
        [Key]
        public int ad_id { get; set; }

        [Required]
        [StringLength(50)]
        public string ad_title { get; set; }

        public int create_by { get; set; }

        public DateTime create_time { get; set; }

        public int update_by { get; set; }

        public DateTime update_time { get; set; }

        public DateTime start_period { get; set; }

        public DateTime end_period { get; set; }

        public int cant_of_follows { get; set; }

        public int related_event { get; set; }

        public bool requested_by_artist { get; set; }

        public int? artist_id { get; set; }

        public virtual tblArtist tblArtist { get; set; }

        public virtual tblEvent tblEvent { get; set; }
    }
}
