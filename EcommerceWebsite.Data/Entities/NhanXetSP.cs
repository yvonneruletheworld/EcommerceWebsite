using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
   public class NhanXetSP
    {
        public string MaSanPham { get; set; }
        public string MaKhachHang { get; set; }
        public string NoiDung { get; set; }
        public int soSao { get; set; }
        public SanPham sanPhams { get; set; }
        public KhachHang KhachHangs { get; set; }

    }
}
