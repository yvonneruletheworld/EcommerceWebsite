using EcommerceWebsite.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebsite.Utilities.ViewModel
{
    public class SanPhamVM
    {

        public string MaSanPham { get; set; }
        public string ComboCode { get; set; }
        public string TenSanPham { get; set; }
        public string HinhAnh { get; set; }
        public string LoaiSanPham { get; set; }
        public string XepHang { get; set; }
        public decimal GiaBan { get; set; }
        public decimal GiaHUI { get; set; }
        public int SoLuongTon { get; set; }
        public string NhanHieu { get; set; }
        public string MaLoai { get; set; }
        public DateTime ngayTao { get; set; }
        public Status Status { get; set; }
        public bool TrangThaiYeuThich { get; set; }
    }
}
