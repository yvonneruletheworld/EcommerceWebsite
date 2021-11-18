using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
  public  class DinhLuong
    {
        public string DonVi { get; set; }
        public string GiaTri { get; set; }
        public string MaSanPham { get; set; }
        public string MaThuocTinh { get; set; }
        //Khóa ngoại
        public ThuocTinh ThuocTinh { get; set; }
        public SanPham SanPham { get; set; }

    }
}
