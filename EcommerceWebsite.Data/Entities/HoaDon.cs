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
        public string MaKhuyenMai { get; set; }
        public string MaDiaChi { get; set; }
        public decimal ThanhTien { get; set; }
        public Status TinhTrang { get; set; }
        public decimal PhiGiaoHang { get; set; }
        public string PhuongThucThanhToan { get; set; }

        public DiaChiKhachHang DiaChiKhachHang { get; set; }
        public KhuyenMai KhuyenMai { get; set; }
        public List<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        public KhachHang KhachHang { get; set; }
        public GiaoHang GiaoHang { get; set; }
    }
}
