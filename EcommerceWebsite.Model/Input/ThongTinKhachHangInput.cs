using EcommerceWebsite.Application.Constants;
using EcommerceWebsite.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EcommerceWebsite.Utilities.Input
{
    public class ThongTinKhachHangInput :EntityBase
    {
        [Required]
        [StringLength(12, ErrorMessage = Messages.KhachHang_LoiDoDaiTenDangNhap)]
        public string TenDangNhap { get; set; }

        [Required]
        public string MatKhau { get; set; }

        public string HoTen { get; set; }
        public string Email { get; set; }
        public string Ip { get; set; }
        public string SDT { get; set; }
        public string ChuoiDangNhap { get; set; }
        public bool GioiTinh { get; set; }
        public string HinhAnh { get; set; }

        public DiaChiKhachHangInput DiaChi { get; set; }
        public bool GhiNhoDangNhap { get; set; }
    }
}
