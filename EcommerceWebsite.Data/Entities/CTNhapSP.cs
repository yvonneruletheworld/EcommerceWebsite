using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
   public class CTNhapSP
    {
        public string MaSP { get; set; }
        public string MaNhap { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }
        
        public SanPham sanPham { get; set; }
        public NhapSanPham nhapSanPham { get; set; }
    }
}
