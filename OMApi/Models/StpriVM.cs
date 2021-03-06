﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMApi.Models
{
    public class StpriVM
    {
        public int Id { get; set; }

        // รหัส
        public string PriceCode { get; set; }

        // รายละเอียด
        public string Description { get; set; }

        // ใช้ราคาขายที่
        public int TabPr { get; set; }

        // ส่วนลดตามเป้า
        public decimal? Disc1 { get; set; }

        public bool? DiscPerc1 { get; set; }

        // ส่วนลดตัวแทนต่างจังหวัด
        public decimal? Disc2 { get; set; }

        public bool? DiscPerc2 { get; set; }

        // เพิ่มโดย
        public int CreBy { get; set; }

        // เพิ่มเมือ
        public System.DateTime CreDate { get; set; }

        // แก้ไขล่าสุดโดย
        public int? ChgBy { get; set; }

        // แก้ไขล่าสุดเมื่อ
        public DateTime? ChgDate { get; set; }
    }
}