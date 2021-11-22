using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
    public class LichSuGia : EntityBase
    {
        public decimal GiaMoi { get; set; }

        public string MaDinhLuong {get; set;}
        public DinhLuong DinhLuong {get; set;}
    }
}
