using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
  public class KhuyenMai
    {
        public string MaKM { get; set; }
        public string TenKM { get; set; }
        public DateTime NgayBD { get; set; }
        public DateTime NgayKT { get; set; }
        public float PhanTram { get; set; }
        public string HinhAnh { get; set; }
        public List<HoaDon> hoaDons { get; set; }
    }
}
