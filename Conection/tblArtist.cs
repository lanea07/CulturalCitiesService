//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Conection
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblArtist
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblArtist()
        {
            this.tblPublicity = new HashSet<tblPublicity>();
            this.tblEvent = new HashSet<tblEvent>();
        }
    
        public int artist_id { get; set; }
        public string stage_name { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int country_of_origin { get; set; }
        public string legal_representative { get; set; }
        public string website { get; set; }
        public string bussines_contact_number { get; set; }
        public string official_mail_account { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPublicity> tblPublicity { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblEvent> tblEvent { get; set; }
    }
}