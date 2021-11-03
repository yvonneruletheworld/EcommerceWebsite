using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Utilities.Output.Main
{
    public class ChiTietSanPhamOutput 
    {
         public string TenSanPham { get; set; }
         public string MaSanPham { get; set; }
         public string TinhTrang { get; set; }
         public int SoLuongTon { get; set; }
         public string DonGia { get; set; }
         public string GiaBan { get; set; }
         public List<string> HinhAnhs { get; set; }

        public List<Tuple<string, double, string>> ThuocTinhs;
    }
}
