using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
   public class NhapSanPham
    {
        public string MaNhap { get; set; }
        public string MaNhanVien { get; set; }
        public string MaNhaCungCap { get; set; }
        public DateTime NgayNhap { get; set; }
        public decimal TongTien { get; set; }

        public NhanVien nhanViens { get; set; }
        public NhaCungCap nhaCungCaps { get; set; }
        public List<CTNhapSP> cTNhapSPs { get; set; }
    }
}
