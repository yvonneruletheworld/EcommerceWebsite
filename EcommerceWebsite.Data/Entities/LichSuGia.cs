using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
   public class LichSuGia : EntityBase
    {
        public string MaLichSuGia { get; set; }
        public decimal GiaMoi { get; set; }
        public string MaSanPham { get; set; }
        public string MaDinhLuong { get; set; }
        public string MaMauMa { get; set; }
        public SanPham SanPham { get; set; }
        public MauMaSanPham MauMaSanPham { get; set; }
        public DinhLuong DinhLuong { get; set; }
    }
}
