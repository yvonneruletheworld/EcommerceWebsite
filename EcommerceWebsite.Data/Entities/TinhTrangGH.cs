using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
   public class TinhTrangGH
    {
        public string MaTTGH { get; set; }
        public string MaGH { get; set; }
        public DateTime NgayThucHien { get; set; }
        public string TinhTrang { get; set; }
        public GiaoHang giaoHang { get; set; }
    }
}
