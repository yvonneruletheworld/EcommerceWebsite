using EcommerceWebsite.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Utilities.Input
{
    public class DiaChiKhachHangInput
    {
        public string Hoten { get; set; }
        public string Tinh { get; set; }
        public string ThanhPho { get; set; }
        public string QuanHuyen { get; set; }
        public string PhuongXa { get; set; }
        public LoaiDiaChiEnum LoaiDiaChi { get; set; }
        public string SDT { get; set; }
    }
}
