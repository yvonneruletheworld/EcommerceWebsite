﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
   public class MauSanPham
    {
        public string MaSanPham { get; set; }
        public string TenMau { get; set; }
        public string HinhAnh { get; set; }
        public SanPham sanPhams { get; set; }
    }
}
