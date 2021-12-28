using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
   public class PhieuNhap : EntityBase
    {
        public PhieuNhap()
        {
            this.MaPhieuNhap = Guid.NewGuid().ToString();
        }

        public string MaPhieuNhap { get; set; }
        public string MaNhanVien { get; set; }
        public string MaNhaCungCap { get; set; }
        public decimal TongTien { get; set; }

        public NhanVien NhanVien { get; set; }
        public NhaCungCap NhaCungCapE { get; set; }
        public List<ChiTietNhapSanPham> ChiTietNhapSanPhams { get; set; }
    }
}
