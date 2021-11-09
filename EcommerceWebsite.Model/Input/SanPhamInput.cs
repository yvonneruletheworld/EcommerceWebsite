using EcommerceWebsite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Utilities.Input
{
    public class SanPhamInput : EntityBase
    {
       public string MaSanPham { get; set; }
       public string TenSanPham { get; set; }
       public string HinhAnh { get; set; }
       public string NhanHieu { get; set; }
       public decimal DonGia { get; set; }
       public decimal GiaBan { get; set; }
       public string DanhMuc { get; set; }
       public string LoaiSanPham { get; set; }
       public string Utility { get; set; }
       public string SoLuong { get; set; }
    }
}
