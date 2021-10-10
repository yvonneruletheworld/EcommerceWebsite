using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
  public  class NhaCungCap
    {
        public string MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }

        public List<NhapSanPham> nhapSanPhams { get; set; }
    }
}
