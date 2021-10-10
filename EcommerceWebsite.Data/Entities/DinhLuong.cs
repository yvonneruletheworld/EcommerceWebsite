using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
  public  class DinhLuong
    {
        public string DonVi { get; set; }
        public float GiaTri { get; set; }
        public string MaSP { get; set; }
        public string MaTT { get; set; }
        //Khóa ngoại
        public ThuocTinh thuocTinh { get; set; }
        public SanPham sanPham { get; set; }

    }
}
