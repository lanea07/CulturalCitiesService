namespace CulturalCitiesService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblEventComment")]
    public partial class tblEventComment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblEventComment()
        {
            tblEventComment1 = new HashSet<tblEventComment>();
        }

        [Key]
        public int comment_id { get; set; }

        public int event_id { get; set; }

        public int customer_id { get; set; }

        [Required]
        [StringLength(500)]
        public string message_content { get; set; }

        public DateTime create_time { get; set; }

        public DateTime update_time { get; set; }

        public int in_reply_to_comment { get; set; }

        public virtual tblCustomer tblCustomer { get; set; }

        public virtual tblEvent tblEvent { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblEventComment> tblEventComment1 { get; set; }

        public virtual tblEventComment tblEventComment2 { get; set; }
    }
}
