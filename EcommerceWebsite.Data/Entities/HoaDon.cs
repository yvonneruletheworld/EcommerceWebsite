using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
   public class HoaDon
    {
        public string MaHoaDon { get; set; }
        public string MaKhachHang { get; set; }
        public string MaKhuyenMai { get; set; }
        public string MaDiaChiKH { get; set; }
        public DateTime NgayLap { get; set; }
        public decimal ThanhTien { get; set; }
        public decimal PhiGH { get; set; }
        public decimal TongTien { get; set; }
        public string TrangThaiTT { get; set; }

        public KhachHang khachHangs { get; set; }
        public DiaChiKH diaChiKHs { get; set; }
        public KhuyenMai khuyenMais { get; set; }
        public List<CTHoaDon> cTHoaDons { get; set; }

        public GiaoHang giaoHangs { get; set; }
    }
}
