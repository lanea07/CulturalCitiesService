namespace CulturalCitiesService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblCountry")]
    public partial class tblCountry
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblCountry()
        {
            tblCity = new HashSet<tblCity>();
        }

        [Key]
        public int country_id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        public DateTime create_time { get; set; }

        public DateTime update_time { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblCity> tblCity { get; set; }
    }
}
