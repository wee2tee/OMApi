//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OMApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Arship
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Arship()
        {
            this.Popr = new HashSet<Popr>();
        }
    
        public int Id { get; set; }
        public string ShipTo { get; set; }
        public string Addr01 { get; set; }
        public string Addr02 { get; set; }
        public string Addr03 { get; set; }
        public string ZipCod { get; set; }
        public string Contact { get; set; }
        public string TelNum { get; set; }
        public string FaxNum { get; set; }
        public string CreBy { get; set; }
        public System.DateTime CreDate { get; set; }
        public string ChgBy { get; set; }
        public Nullable<System.DateTime> ChgDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Popr> Popr { get; set; }
        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual AspNetUsers AspNetUsers1 { get; set; }
    }
}
