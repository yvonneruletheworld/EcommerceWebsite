using EcommerceWebsite.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
   public class NhanVien : EntityBase
    {
        public NhanVien()
        {
            this.MaNhanVien = Guid.NewGuid().ToString();
        }

        public string MaNhanVien { get; set; }
        public string Username { get; set; }
        public string TenNhanVien { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public string Mail { get; set; }
        public Status Status { get; set; }
        public DateTime NgaySinh { get; set; }
        public string HinhAnh { get; set; }
        public string MaBoPhan { get; set; }
        public string LoginString { get; set; }
        public BoPhan BoPhan { get; set; }
        public List<PhieuNhap> PhieuNhaps { get; set; }
    }
}
