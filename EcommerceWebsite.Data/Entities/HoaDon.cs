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
        public decimal ThanhTien { get; set; }
        public Status TinhTrang { get; set; }

        //Khoa ngoai
        public List<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        public KhachHang KhachHangs { get; set; }
    }
}
