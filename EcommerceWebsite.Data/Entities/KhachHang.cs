using EcommerceWebsite.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
    public class KhachHang : EntityBase
    {
        public KhachHang()
        {
            this.MaKhachHang = Guid.NewGuid().ToString();
        }

        public string MaKhachHang { get; set; }
        public string HoTen { get; set; }
        public bool GioiTinh { get; set; }
        public string HinhAnh { get; set; }
        //Khoa ngoai

        public List<DiaChiKhachHang> DiaChiKhachHangs { get; set; }
        public List<HoaDon> HoaDons { get; set; }
        public List<SanPhamYeuThich> SanPhamYeus { get; set; }
    }
}
