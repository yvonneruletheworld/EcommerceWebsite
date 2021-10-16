using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
   public class XepHangSanPham
    {
        public XepHangSanPham()
        {
            this.MaHang = Guid.NewGuid().ToString();
        }
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public List<SanPham> SanPhams { get; set; }
    }
}
