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
    
    public partial class Stpri
    {
        public int Id { get; set; }
        public string PriceCode { get; set; }
        public string Description { get; set; }
        public int TabPr { get; set; }
        public Nullable<decimal> Disc1 { get; set; }
        public Nullable<bool> DiscPerc1 { get; set; }
        public Nullable<decimal> Disc2 { get; set; }
        public Nullable<bool> DiscPerc2 { get; set; }
        public int CreBy { get; set; }
        public System.DateTime CreDate { get; set; }
        public Nullable<int> ChgBy { get; set; }
        public Nullable<System.DateTime> ChgDate { get; set; }
    
        public virtual InternalUsers InternalUsers { get; set; }
        public virtual InternalUsers InternalUsers1 { get; set; }
    }
}
