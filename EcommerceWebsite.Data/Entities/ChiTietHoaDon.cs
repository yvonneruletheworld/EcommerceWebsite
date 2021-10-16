using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
    public class ChiTietHoaDon 
    {
        public string HoaDonId { get; set; }
        public string ProductId { get; set; }

        public int SoLuong { get; set; }
        public decimal GiaBan { get; set; }

        public HoaDon HoaDons { get; set; }
        public SanPham SanPhams { get; set; }
    }
}
