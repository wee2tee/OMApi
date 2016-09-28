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
    
    public partial class Oeso
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Oeso()
        {
            this.Artrn = new HashSet<Artrn>();
            this.Oesoit = new HashSet<Oesoit>();
        }
    
        public int Id { get; set; }
        public Nullable<int> PoprId { get; set; }
        public string DealerId { get; set; }
        public string SoRecTyp { get; set; }
        public string SoNum { get; set; }
        public System.DateTime SoDat { get; set; }
        public string FlgVat { get; set; }
        public Nullable<int> Department { get; set; }
        public Nullable<int> ShipTo { get; set; }
        public int PayTrm { get; set; }
        public int DlvBy { get; set; }
        public Nullable<System.DateTime> DlvDate1 { get; set; }
        public Nullable<System.DateTime> DlvDate2 { get; set; }
        public string Remark { get; set; }
        public decimal Amount { get; set; }
        public string Disc { get; set; }
        public decimal DiscAmt { get; set; }
        public decimal Total { get; set; }
        public decimal VatRate { get; set; }
        public decimal VatAmt { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal NetAmt { get; set; }
        public decimal NetVal { get; set; }
        public string CreBy { get; set; }
        public System.DateTime CreDate { get; set; }
        public string ChgBy { get; set; }
        public Nullable<System.DateTime> ChgDate { get; set; }
        public string ConvIvBy { get; set; }
        public Nullable<System.DateTime> ConvIvDate { get; set; }
        public string CustPreName { get; set; }
        public string CustName { get; set; }
        public string CustAddr01 { get; set; }
        public string CustAddr02 { get; set; }
        public string CustAddr03 { get; set; }
        public string CustZipCod { get; set; }
        public string CustTelNum { get; set; }
        public string CustFaxNum { get; set; }
        public string CustTaxId { get; set; }
        public Nullable<System.DateTime> ExportDate { get; set; }
        public string Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Artrn> Artrn { get; set; }
        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual AspNetUsers AspNetUsers1 { get; set; }
        public virtual AspNetUsers AspNetUsers2 { get; set; }
        public virtual AspNetUsers AspNetUsers3 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Oesoit> Oesoit { get; set; }
        public virtual Popr Popr { get; set; }
    }
}
