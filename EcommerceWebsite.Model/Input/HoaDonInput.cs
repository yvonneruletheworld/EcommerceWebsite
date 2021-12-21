using EcommerceWebsite.Application.Constants;
using EcommerceWebsite.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EcommerceWebsite.Utilities.Input
{
    public class HoaDonInput :EntityBase
    {
        public int Type { get; set; }
        public string MaDiaChi { get; set; }
        public string MaKhuyenMai { get; set; }
        public string PhuongThucThanhToan { get; set; } 
        public decimal TongTien { get; set; }
        public decimal ThanhTien { get; set; }
        public decimal Ship { get; set; }
        public DiaChiKhachHangInput DiaChiMoi { get; set; }
        public List<string> ListCheckoutNormalCart { get; set; }
        public List<string> ListCheckoutHUICart { get; set; }
        public bool GhiNhoDangNhap { get; set; }
    }


}
