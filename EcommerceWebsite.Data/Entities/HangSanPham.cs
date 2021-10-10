using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
   public class HangSanPham
    {
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public List<SanPham> sanPhams { get; set; }
    }
}
