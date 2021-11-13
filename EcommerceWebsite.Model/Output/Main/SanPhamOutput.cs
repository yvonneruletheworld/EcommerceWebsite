﻿using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Utilities.Output.Main
{
    public class SanPhamOutput : EntityBase
    {
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public int SoLuongTon { get; set; }
        public string HinhAnh { get; set; }
        public string NhanHieu { get; set; }
        public string LoaiSanPham { get; set; }
        public string MaXepHang { get; set; }
        public string GiaBan { get; set; }
        public Status Status { get; set; }

        public List<string> ListHinhAnh { get; set; }
        public List<ThongSoSanPhamOutput> ListThongSo { get; set; }
        public decimal Utility { get; set; }

        public string DanhGia { get; set; }
        //Khóa ngoại
    }
}
