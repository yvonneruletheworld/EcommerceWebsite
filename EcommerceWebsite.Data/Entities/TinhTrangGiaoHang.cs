using EcommerceWebsite.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
   public class TinhTrangGiaoHang : EntityBase
    {
        public TinhTrangGiaoHang()
        {
            this.MaTinhTrangGiaoHang = Guid.NewGuid().ToString();
        }
        public string MaTinhTrangGiaoHang { get; set; }
        public string MaGiaoHang { get; set; }
        public Status TinhTrang { get; set; }
        public GiaoHang GiaoHang { get; set; }
    }
}
