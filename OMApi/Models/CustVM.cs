using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMApi.Models
{
    public class CustVM
    {
        public string PreName { get; set; }
        public string Name { get; set; }
        public string Addr01 { get; set; }
        public string Addr02 { get; set; }
        public string Addr03 { get; set; }
        public string ZipCod { get; set; }
        public string TelNum { get; set; }
        public string FaxNum { get; set; }
        public string TaxId { get; set; }
    }
}