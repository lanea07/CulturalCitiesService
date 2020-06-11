namespace CulturalCitiesService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblCustomerPreferences
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int customer_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int preference_id { get; set; }

        [Required]
        [StringLength(50)]
        public string preference_value { get; set; }

        public DateTime update_time { get; set; }

        public virtual tblCustomer tblCustomer { get; set; }

        public virtual tblPreferenceValue tblPreferenceValue { get; set; }
    }
}
