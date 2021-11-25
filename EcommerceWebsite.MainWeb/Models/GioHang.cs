using EcommerceWebsite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.MainWeb.Models
{
    public class GioHang
    {
        public string MaSanPham { get; set; }
        public int soLuong { get; set; }
        public string tenSanPham { get; set; }
        public string hinhAnh { get; set; }
        public decimal giaSanPham { get; set; }
        public decimal? dThanhTien
        {
            get { return soLuong * giaSanPham; }
        }
    }
}
