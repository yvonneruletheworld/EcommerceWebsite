using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
   public class ThuocTinh
    {
        public ThuocTinh()
        {
            this.MaThuocTinh = Guid.NewGuid().ToString();
        }
        public string MaThuocTinh { get; set; }
        public string TenThuocTinh { get; set; }
        public string MaDanhMuc { get; set; }
        //Khóa ngoại
        public List<DinhLuong> DinhLuongs { get; set; }
    }
}
