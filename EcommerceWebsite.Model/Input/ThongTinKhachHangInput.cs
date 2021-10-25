using EcommerceWebsite.Application.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EcommerceWebsite.Utilities.Input
{
    public class ThongTinKhachHangInput 
    {
        [Required]
        [StringLength(12, ErrorMessage = Messages.KhachHang_LoiDoDaiTenDangNhap)]
        public string TenDangNhap { get; set; }

        [Required]
        public string MatKhau { get; set; }

        public string Sdt { get; set; }
        public bool GhiNhoDangNhap { get; set; }
    }
}
