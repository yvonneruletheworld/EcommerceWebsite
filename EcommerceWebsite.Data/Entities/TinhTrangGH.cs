using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
   public class TinhTrangGH
    {
        public string MaTinhTrangGH { get; set; }
        public string MaGiaoHang { get; set; }
        public DateTime NgayThucHien { get; set; }
        public string TinhTrang { get; set; }
        public GiaoHang giaoHangs { get; set; }
    }
}
