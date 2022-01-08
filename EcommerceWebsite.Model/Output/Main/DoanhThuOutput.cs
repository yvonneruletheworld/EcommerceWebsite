using EcommerceWebsite.Data.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Utilities.Output.Main
{
    public class DoanhThuOutput
    {
        public DateTime NgayNhap { get; set; }
        public DateTime NgayBan { get; set; }
        public int SoLuongNhap { get; set; }
        public decimal DonGiaNhap { get; set; }
        public decimal TongTienNhap { get; set; }
        public int SoLuongTon { get; set; }
        public int SoLuongTonKyTruoc { get; set; }
        public int DaBan { get; set; }
        public bool DaXoa { get; set; }
        public decimal DonGiaBan { get; set; }
        public decimal TongTienBan { get; set; }
        public float LoiNhuan { get; set; }
        [JsonProperty("maSanPham")]
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        [JsonProperty("giaHUI")]
        public decimal GiaHUI { get; set; }
        public List<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    }
}
