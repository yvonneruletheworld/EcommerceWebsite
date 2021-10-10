using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
   public class GiaoHang
    {
        public string MaGH { get; set; }
        public string MaHD { get; set; }
        public string TrangThaiHienTai { get; set; }
        public DateTime NgayTiepNhan { get; set; }
        public DateTime NgayDuKienGiao { get; set; }
        public DateTime NgayGiao { get; set; }

        public HoaDon hoaDon { get; set; }

        public List<TinhTrangGH> tinhTrangGHs { get; set; }
    }
}
