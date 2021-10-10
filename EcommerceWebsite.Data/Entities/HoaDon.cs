using EcommerceWebsite.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
    public class HoaDon : EntityBase
    {
        public HoaDon()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public string MaKhachHang { get; set; }
        public decimal TongCong { get; set; }
        public string MaHD { get; set; }
        public string MaKH { get; set; }
        public string MaKM { get; set; }
        public string MaDiaChiKH { get; set; }
        public decimal ThanhTien { get; set; }
        public Status TinhTrang { get; set; }
        public decimal PhiGH { get; set; }
        public decimal TongTien { get; set; }
        public string TrangThaiTT { get; set; }

        public KhachHang khachHang { get; set; }
        public DiaChiKH diaChiKH { get; set; }
        public KhuyenMai khuyenMai { get; set; }
        public List<CTHoaDon> cTHoaDons { get; set; }

        public KhachHang KhachHangs { get; set; }
        public GiaoHang giaoHang { get; set; }
    }
}
