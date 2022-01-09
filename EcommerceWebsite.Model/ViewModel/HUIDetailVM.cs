using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Utilities.Output.Main;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Utilities.ViewModel
{
    public class HUIDetailVM
    {
        [JsonProperty("listSanPhamHUIs")]
        public List<DoanhThuOutput> ListSanPhamHUIs { get; set; }
        public string ComboCode { get; set; }
        public int Utility { get; set; }
        public string MinUtility { get; set; }
        public double TongGiaAuto { get; set; }
        public decimal TongGiaSetUp { get; set; }
        public int DaBan { get; set; }
        public int DaBanLe { get; set; }
        public List<ChiTietHoaDon> ListHoaDon { get; set; }
    }
}
