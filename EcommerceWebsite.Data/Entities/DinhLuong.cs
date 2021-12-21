using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
  public  class DinhLuong
    {
        public DinhLuong(string maDinhLuong)
        {
            MaDinhLuong= maDinhLuong ?? Guid.NewGuid().ToString();
        }

        public string MaDinhLuong { get; set; }
        public string DonVi { get; set; }
        public string GiaTri { get; set; }
        public string MaSanPham { get; set; }
        public string MaThuocTinh { get; set; }
        //Khóa ngoại
        public List<BangGiaSanPham> BangGiaSanPhams { get; set; }
        public ThuocTinh ThuocTinh { get; set; }
        public SanPham SanPham { get; set; }

    }
}
