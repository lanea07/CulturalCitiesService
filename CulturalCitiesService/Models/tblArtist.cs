namespace CulturalCitiesService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblArtist")]
    public partial class tblArtist
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblArtist()
        {
            tblPublicity = new HashSet<tblPublicity>();
            tblEvent = new HashSet<tblEvent>();
        }

        [Key]
        public int artist_id { get; set; }

        [Required]
        [StringLength(100)]
        public string stage_name { get; set; }

        [Required]
        [StringLength(100)]
        public string first_name { get; set; }

        [Required]
        [StringLength(100)]
        public string last_name { get; set; }

        public int country_of_origin { get; set; }

        [Required]
        [StringLength(100)]
        public string legal_representative { get; set; }

        [Required]
        [StringLength(100)]
        public string website { get; set; }

        [Required]
        [StringLength(50)]
        public string bussines_contact_number { get; set; }

        [Required]
        [StringLength(100)]
        public string official_mail_account { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPublicity> tblPublicity { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblEvent> tblEvent { get; set; }
    }
}
