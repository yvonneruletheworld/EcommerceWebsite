using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
   public class BinhLuan : EntityBase
    {
        public string MaSanPham { get; set; }
        public string NoiDung { get; set; }
        public int SoSao { get; set; }
        public SanPham SanPham { get; set; }
        public KhachHang KhachHang { get; set; }

    }
}
