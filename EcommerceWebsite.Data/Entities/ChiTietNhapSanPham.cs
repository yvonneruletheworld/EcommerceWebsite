using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
   public class ChiTietNhapSanPham
    {
        public string MaSanPham { get; set; }
        public string MaNhap { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }
        
        public SanPham SanPham { get; set; }
        public PhieuNhap PhieuNhap { get; set; }
    }
}
