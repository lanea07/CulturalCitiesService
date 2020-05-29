namespace CulturalCitiesService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblCustomerEvent")]
    public partial class tblCustomerEvent
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int customer_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int event_id { get; set; }

        public bool suscribed_to_alerts { get; set; }

        public DateTime create_time { get; set; }

        public DateTime update_time { get; set; }

        public virtual tblCustomer tblCustomer { get; set; }

        public virtual tblEvent tblEvent { get; set; }
    }
}
