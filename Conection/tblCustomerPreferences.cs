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
    
    public partial class tblCustomerPreferences
    {
        public int customer_id { get; set; }
        public int preference_id { get; set; }
        public string preference_value { get; set; }
        public System.DateTime update_time { get; set; }
    
        public virtual tblCustomer tblCustomer { get; set; }
        public virtual tblPreferenceValue tblPreferenceValue { get; set; }
    }
}
