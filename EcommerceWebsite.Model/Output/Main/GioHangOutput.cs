using EcommerceWebsite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Utilities.Output.Main
{
    public class GioHangOutput
    {
        public SanPham sanPham { get; set; }
        public int soLuong { get; set; }
        public decimal giaSanPham { get; set; }
        public decimal? dThanhTien
        {
            get { return soLuong * giaSanPham; }
        }
    }
}
