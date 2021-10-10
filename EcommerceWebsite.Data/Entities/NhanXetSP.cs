using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
   public class NhanXetSP
    {
        public string MaSP { get; set; }
        public string MaKH { get; set; }
        public string NoiDung { get; set; }
        public int soSao { get; set; }
        public SanPham sanPham { get; set; }
        public KhachHang KhachHang { get; set; }

    }
}
