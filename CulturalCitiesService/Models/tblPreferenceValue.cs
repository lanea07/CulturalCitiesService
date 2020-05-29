namespace CulturalCitiesService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblPreferenceValue")]
    public partial class tblPreferenceValue
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblPreferenceValue()
        {
            tblCustomerPreferences = new HashSet<tblCustomerPreferences>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int preference_id { get; set; }

        [Required]
        [StringLength(50)]
        public string preference_name { get; set; }

        public DateTime create_time { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblCustomerPreferences> tblCustomerPreferences { get; set; }
    }
}
