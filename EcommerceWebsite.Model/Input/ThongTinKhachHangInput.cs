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
        public int Type { get; set; }
        [StringLength(20, ErrorMessage = Messages.KhachHang_LoiDoDaiTenDangNhap)]
        public string TenDangNhap { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được trống")]
        public string MatKhau { get; set; } 
        [Required(ErrorMessage = "Xác nhận mật khẩu không được trống")]
        public string XacNhanMatKhau { get; set; }
        [Required(ErrorMessage = "Họ Tên không được trống")]
        [StringLength(50, ErrorMessage = Messages.KhachHang_HoTenKhongHopLe)]
        public string HoTen { get; set; }
        [Required(ErrorMessage = "Tên đăng nhập hoặc email không được trống")]
        [StringLength(30, ErrorMessage = Messages.KhachHang_LoiDoDaiTenDangNhap)]
        public string Email { get; set; }
        public string Ip { get; set; }
        //[Required]
        //[StringLength(12, ErrorMessage =  "Số điện thoại không hợp lệ")]
        public string SDT { get; set; }
        public string ChuoiDangNhap { get; set; }
        public bool GioiTinh { get; set; }
        public string HinhAnh { get; set; }

        public DiaChiKhachHangInput DiaChi { get; set; }
        public bool GhiNhoDangNhap { get; set; }
    }
}
