using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
   public class SanPham
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
        public string MaLoai { get; set; }
        public string MaHang { get; set; }

        public DanhGiaSP danhGiaSP { get; set; }

        public LoaiSanPham loaiSanPhams { get; set; }
        public HangSanPham hangSanPhams { get; set; }
        //Khóa ngoại
        public List<DinhLuong> dinhLuongs { get; set; }
        public List<MauSanPham> mauSanPhams { get; set; }
        public List<LichSuGia> lishSuGias { get; set; }
        public List<NhanXetSP> nhanXetSPs { get; set; }
        public List<CTNhapSP> cTNhapSPs { get; set; }
        public List<CTHoaDon> cTHoaDons { get; set; }

    }
}
