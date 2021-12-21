using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Utilities.Output.Main
{
    public class SanPhamNhapOutput
    {
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public int SoLuongNhap { get; set; }
        public decimal DonGiaNhap { get; set; }
        public decimal ThanhTien { get; set; }
        public decimal GiaBan { get; set; }
        public decimal GiaHUI { get; set; }
        public int SoLuongBan { get; set; }
        public DateTime NgayNhap { get; set; }
    }
}
