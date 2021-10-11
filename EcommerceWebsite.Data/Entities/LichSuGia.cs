using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
   public class LichSuGia
    {
        public DateTime NgayBD { get; set; }
        public decimal Gia { get; set; }
        public string MaSanPham { get; set; }
        public SanPham sanPhams { get; set; }
    }
}
