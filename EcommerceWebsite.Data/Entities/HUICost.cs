using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
    public class HUICost : EntityBase
    {
        public string MaSanPham { get; set; }
        public string ComboCode { get; set; }
        public decimal Cost { get; set; }
        public bool Status { get; set; }
        public SanPham SanPhams { get; set; }
        public int DaBan { get; set; }
        public int LuotTruyCap { get; set; }
        public decimal TongGia { get; set; }
        public decimal ThucBan { get; set; }
    }
}
