using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
  public  class DinhLuong
    {
        public string DonVi { get; set; }
        public float GiaTri { get; set; }
        public string MaSanPham { get; set; }
        public string MaThuocTinh { get; set; }
        //Khóa ngoại
        public ThuocTinh thuocTinhs { get; set; }
        public SanPham sanPhams { get; set; }

    }
}
