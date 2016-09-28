using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OMApi.Models;
using OMApi.MiscClass;

namespace OMApi.Models
{
    public class DealerVM
    {
        public string Id { get; set; }

        // รหัสตัวแทน
        public string DealerCode { get; set; }
        // ประเภท
        public int? DealerType { get; set; }
        // รหัสผู้ใช้
        public string UserName { get; set; }
        // S/N
        public string SerNum { get; set; }
        // คำนำหน้าชื่อ
        public string PreName { get; set; }
        // ชื่อ
        public string FullName { get; set; }
        // เลขประจำตัวผู้เสียภาษี
        public string TaxId { get; set; }
        // ที่อยู่ 1
        public string Addr01 { get; set; }
        // ที่อยู่ 2
        public string Addr02 { get; set; }
        // ที่อยู่ 3
        public string Addr03 { get; set; }
        // รหัสไปรษณีย์
        public string ZipCod { get; set; }
        // โทรศัพท์
        public string TelNum { get; set; }
        // โทรสาร
        public string FaxNum { get; set; }
        // ตารางราคา
        public string PriceCode { get; set; }
        // กลุ่มวิธีการจัดส่ง
        public int? DlvProfile { get; set; }
        // ส่วนลด 1
        public decimal? Disc { get; set; }
        public bool? DiscPerc { get; set; }
        // ส่วนลด 2
        public decimal? Disc2 { get; set; }
        public bool? DiscPerc2 { get; set; }
        // สถานะ
        public string Status { get; set; }
        // แก้ไขล่าสุดโดย
        public string ChgBy { get; set; }
        // แก้ไขล่าสุดเมื่อ
        public DateTime? ChgDate { get; set; }

        //// ชื่อ
        //public string Name
        //{
        //    get
        //    {
        //        return (this.PreName != null && this.PreName.Trim().Length > 0 ? this.PreName + " " + this.FullName : this.FullName);
        //    }
        //}

        //// ที่อยู่
        //public string Addr {
        //    get {
        //        return this.Addr01 + " " + this.Addr02 + " " + this.Addr03 + " " + this.ZipCod;
        //    }
        //}

        //public string _Disc { get; set; }
        //public string _Disc2 { get; set; }
    }
}