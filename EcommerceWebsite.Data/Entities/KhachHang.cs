using EcommerceWebsite.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
    public class KhachHang : EntityBase
    {
        public KhachHang()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
        public string HoTen { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Sdt { get; set; }
        public string LoginString { get; set; }
        public bool GioiTinh { get; set; }
        public string HinhAnh { get; set; }
        public Status Status { get; set; }
        //Khoa ngoai

        public List<DiaChiKhachHang> DiaChiKhachHangs { get; set; }
        public List<BinhLuan> BinhLuans { get; set; }
        public List<HoaDon> HoaDons { get; set; }
    }
}
