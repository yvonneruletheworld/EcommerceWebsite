using EcommerceWebsite.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Utilities.ViewModel
{
    public class SanPhamVM
    {
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string HinhAnh { get; set; }
        public string LoaiSanPham { get; set; }
        public string XepHang { get; set; }
        public decimal GiaBan { get; set; }
        public Status Status { get; set; }
    }
}
