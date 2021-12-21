using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
  public class KhuyenMai : EntityBase
    {
        public KhuyenMai()
        {
            this.MaKhuyenMai = Guid.NewGuid().ToString();
        }

        public string MaKhuyenMai { get; set; }
        public string TenKhuyenMai { get; set; }
        public float PhanTram { get; set; }
        public string HinhAnh { get; set; }
        public decimal DieuKienKM { get; set; }
        public List<HoaDon> HoaDons { get; set; }
    }
}
