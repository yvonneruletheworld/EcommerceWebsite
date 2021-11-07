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
        public string MaLoaiSanPham { get; set; }
        public string MaXepHang { get; set; }
        public decimal giaSP { get; set; }
        public Status Status { get; set; }
        public decimal Utility { get; set; }
        public DanhGiaSanPham DanhGiaSanPham { get; set; }
        public DanhMuc DanhMuc { get; set; }
        //Khóa ngoại
    }
}
