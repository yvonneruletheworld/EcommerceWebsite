using EcommerceWebsite.Application.Constants;
using EcommerceWebsite.Data.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EcommerceWebsite.Utilities.Input
{
    public class BinhLuanInput :EntityBase
    {
        [JsonProperty("matKhau")]
        [Required]
        public string MatKhau { get; set; }
       
        [JsonProperty("email")]
        [Required(ErrorMessage = "Tên đăng nhập hoặc email không được trống")]
        [StringLength(30, ErrorMessage = Messages.KhachHang_LoiDoDaiTenDangNhap)]
        public string Email { get; set; }
        
        [JsonProperty("soSao")]
        public int SoSao { get; set; }
        
        [JsonProperty("noiDung")]
        public string NoiDung { get; set; } 
        [JsonProperty("maSanPham")]
        public string MaSanPham { get; set; }
    }
}
