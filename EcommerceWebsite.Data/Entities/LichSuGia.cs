using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
   public class LichSuGia : EntityBase
    {
        public decimal GiaMoi { get; set; }
        public string MaSanPham { get; set; }
        public SanPham SanPham { get; set; }
    }
}
