using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
   public class DiaChiKH
    {
        public string MaDiaChiKH { get; set; }
        public string DiaChiGH { get; set; }
        public string SDT { get; set; }
        public string MaKhachHang { get; set; }
        public KhachHang khachHang { get; set; }
        public List<HoaDon> hoaDons { get; set; }
    }
}
