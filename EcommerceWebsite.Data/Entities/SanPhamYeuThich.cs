using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
   public class SanPhamYeuThich
    {
        public string MaSanPham { get; set; }
        public string MaKhachHang { get; set; }
        public bool TrangThai { get; set; }
        public SanPham SanPham { get; set; }
        public KhachHang KhachHang { get; set; }
    }
}
