using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
   public class ThuocTinh
    {
        public string MaTT { get; set; }
        public string TenTT { get; set; }
        //Khóa ngoại
        public List<DinhLuong> dinhLuongs { get; set; }
    }
}
