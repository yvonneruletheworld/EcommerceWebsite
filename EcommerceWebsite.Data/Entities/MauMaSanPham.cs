using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
   public class MauMaSanPham
    {
        public string MaMauMa { get; set; }
        public string TenMauMa { get; set; }
        public string HinhAnh { get; set; }
        public string MaSanPham { get; set; }
        public SanPham SanPham { get; set; }
        public List<LichSuGia>  LichSuGias { get; set; }
    }
}
