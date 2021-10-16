using EcommerceWebsite.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
   public class SanPham :EntityBase
    {
        public SanPham()
        {
            this.MaSanPham = Guid.NewGuid().ToString();
        }

        //[Key]
        //[MaxLength(100)]
        //[Required]
        public string MaSanPham { get; set; }
        //[StringLength(270,
        //              ErrorMessage = "Tên loại sản phẩm từ 8 kí tự đến 8 kí tự",
        //              MinimumLength = 8)]
        public string TenSanPham { get; set; }
        public int SoLuongTon { get; set; }
        public string HinhAnh { get; set; }
        public string NhanHieu { get; set; }
        public string MaLoaiSanPham { get; set; }
        public string MaXepHang { get; set; }
        public Status Status { get; set; }

        public DanhGiaSanPham DanhGiaSanPham { get; set; }
        public decimal Utility { get; set; }

        public DanhMuc DanhMuc { get; set; }
        public XepHangSanPham XepHangSanPham { get; set; }
        //Khóa ngoại
        public List<DinhLuong> DinhLuongs { get; set; }
        public List<MauMaSanPham> MauMaSanPhams { get; set; }
        public List<LichSuGia> LichSuGias { get; set; }
        public List<BinhLuan> BinhLuans { get; set; }
        public List<ChiTietNhapSanPham> ChiTietNhapSanPhams { get; set; }
        public List<ChiTietHoaDon> ChiTietHoaDons { get; set; }

    }
}
