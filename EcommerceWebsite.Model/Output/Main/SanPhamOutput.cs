using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Utilities.Output.Main
{
    public class SanPhamOutput : EntityBase
    {
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public int SoLuongTon { get; set; }
        public string HinhAnh { get; set; }
        public string NhanHieu { get; set; }
        public string LoaiSanPham { get; set; }
        public string XepHang { get; set; }
        public decimal GiaBan { get; set; }
        public Status Status { get; set; }

        public List<MauMaSanPham> ListHinhAnh { get; set; }
        public List<ThongSoSanPhamOutput> ListThongSo { get; set; }

        public DanhGiaSanPham DanhGia { get; set; }
        //Khóa ngoại
    }
}
