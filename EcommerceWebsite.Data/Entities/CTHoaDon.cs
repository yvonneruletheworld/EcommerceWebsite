using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
  public  class CTHoaDon
    {
        public string MaHoaDon { get; set; }
        public string MaSanPham { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }

        public SanPham sanPhams { get; set; }
        public HoaDon hoaDons { get; set; }
    }
}
