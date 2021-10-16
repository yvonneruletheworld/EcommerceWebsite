using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
   public class GiaoHang : EntityBase
    {
        public GiaoHang()
        {
            this.MaGiaoHang = Guid.NewGuid().ToString();
        }
        public string MaGiaoHang { get; set; }
        public string MaHoaDon { get; set; }
        public string TrangThaiHienTai { get; set; }
        public DateTime NgayTiepNhan { get; set; }
        public DateTime NgayDuKienGiao { get; set; }

        public HoaDon HoaDon { get; set; }

        public List<TinhTrangGiaoHang> TinhTrangGiaoHangs { get; set; }
    }
}
