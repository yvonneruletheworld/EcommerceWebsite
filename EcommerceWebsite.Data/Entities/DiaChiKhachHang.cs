using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
   public class DiaChiKhachHang : EntityBase
    {
        public DiaChiKhachHang()
        {
            this.MaDiaChi = Guid.NewGuid().ToString();
        }
        public string MaDiaChi { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string MaKhachHang { get; set; }
        public KhachHang KhachHang { get; set; }
        public List<HoaDon> HoaDons { get; set; }
    }
}
