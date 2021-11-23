using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
  public class DanhGiaSanPham
    {
        public string MaDanhGia { get; set; }
        public string NoiDung { get; set; }
        public string HinhAnhDanhGia { get; set; }
        public string MaSanPham { get; set; }
        public string TieuDe { get; set; }
        public SanPham SanPham { get; set; }
    }
}
