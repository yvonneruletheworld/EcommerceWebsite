using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Utilities.Output.Main
{
    public class DoanhThuOutput
    {
        public DateTime NgayNhap { get; set; }
        public int SoLuongNhap { get; set; }
        public decimal DonGiaNhap { get; set; }
        public decimal TongTienNhap { get; set; }
        public int SoLuongTon { get; set; }
        public int DaBan { get; set; }
        public decimal DonGiaBan { get; set; }
        public decimal TongTienBan { get; set; }
        public float LoiNhuan { get; set; }
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public decimal GiaHUI { get; set; }
    }
}
