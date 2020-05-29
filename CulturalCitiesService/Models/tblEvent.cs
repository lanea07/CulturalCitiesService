namespace CulturalCitiesService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblEvent")]
    public partial class tblEvent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblEvent()
        {
            tblCustomerEvent = new HashSet<tblCustomerEvent>();
            tblEventComment = new HashSet<tblEventComment>();
            tblPublicity = new HashSet<tblPublicity>();
            tblArtist = new HashSet<tblArtist>();
            tblGenre = new HashSet<tblGenre>();
        }

        [Key]
        public int event_id { get; set; }

        [Required]
        [StringLength(200)]
        public string name { get; set; }

        [Required]
        [StringLength(50)]
        public string geographical_location { get; set; }

        public int city_id { get; set; }

        public DateTime event_date { get; set; }

        public int create_by { get; set; }

        public DateTime create_time { get; set; }

        public DateTime update_time { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string event_source_site_page { get; set; }

        public int culturaljob_task_id { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string tags { get; set; }

        public bool requested_by_artist { get; set; }

        [Required]
        [StringLength(2000)]
        public string EventImagePath { get; set; }

        public virtual tblCity tblCity { get; set; }

        public virtual tblCulturalJobTasks tblCulturalJobTasks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblCustomerEvent> tblCustomerEvent { get; set; }

        public virtual tblUser tblUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblEventComment> tblEventComment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPublicity> tblPublicity { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblArtist> tblArtist { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblGenre> tblGenre { get; set; }
    }
}
