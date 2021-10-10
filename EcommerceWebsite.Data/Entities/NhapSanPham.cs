using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
   public class NhapSanPham
    {
        public string MaNhap { get; set; }
        public string MaNV { get; set; }
        public string MaNCC { get; set; }
        public DateTime NgayNhap { get; set; }
        public decimal TongTien { get; set; }

        public NhanVien nhanVien { get; set; }
        public NhaCungCap nhaCungCap { get; set; }
        public List<CTNhapSP> cTNhapSPs { get; set; }
    }
}
