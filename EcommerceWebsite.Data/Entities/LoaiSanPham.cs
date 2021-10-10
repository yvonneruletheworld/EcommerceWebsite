using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
   public class LoaiSanPham
    {
        public string MaLoai { get; set; }
        public string TenLoai { get; set; }
        //Foreign Key
        public List<SanPham> sanPhams { get; set; }
    }
}
