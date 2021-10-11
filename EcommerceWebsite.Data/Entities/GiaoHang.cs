using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
   public class GiaoHang
    {
        public string MaGiaoHanh { get; set; }
        public string MaHoaDon { get; set; }
        public string TrangThaiHienTai { get; set; }
        public DateTime NgayTiepNhan { get; set; }
        public DateTime NgayDuKienGiao { get; set; }
        public DateTime NgayGiao { get; set; }

        public HoaDon hoaDons { get; set; }

        public List<TinhTrangGH> tinhTrangGHs { get; set; }
    }
}
