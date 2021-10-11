using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
   public class ThuocTinh
    {
        public string MaThuocTinh { get; set; }
        public string TenThuocTinh { get; set; }
        //Khóa ngoại
        public List<DinhLuong> dinhLuongs { get; set; }
    }
}
