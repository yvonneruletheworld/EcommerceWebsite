using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
   public class MauSanPham
    {
        public string MaSP { get; set; }
        public string TenMau { get; set; }
        public string HinhAnh { get; set; }
        public SanPham sanPham { get; set; }
    }
}
