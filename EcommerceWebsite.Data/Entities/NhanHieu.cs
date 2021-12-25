using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
   public class NhanHieu
    {
        public NhanHieu()
        {
            MaHang =  Guid.NewGuid().ToString();
        }
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public string HinhAnh { get; set; }
        public List<SanPham> SanPhams { get; set; }
    }
}
