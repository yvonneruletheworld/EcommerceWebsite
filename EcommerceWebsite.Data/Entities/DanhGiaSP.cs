using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
  public class DanhGiaSP
    {
        public string MaDG { get; set; }
        public string NoiDung { get; set; }
        public string HinhAnhDG { get; set; }
        public string MaSP { get; set; }
        public SanPham sanPhams { get; set; }
    }
}
