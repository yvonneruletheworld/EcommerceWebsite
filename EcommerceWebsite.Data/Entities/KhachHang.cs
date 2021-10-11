using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
   public class KhachHang 
    {
        public string MaKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public string SDT { get; set; }
        public string Mail { get; set; }
        public DateTime NgaySinh { get; set; }
        public string HinhAnh { get; set; }
        public string MatKhau { get; set; }
        public List<DiaChiKH> diaChiKHs { get; set; }
        public List<NhanXetSP> nhanXetSPs { get; set; }
        public List<HoaDon> hoaDons { get; set; }

    }
}
