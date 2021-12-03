using EcommerceWebsite.Utilities.Output.Main;
using EcommerceWebsite.Utilities.Output.System;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Utilities.ViewModel
{
    public class DetailVM
    {
        [JsonProperty("sanPham")]
        public SanPhamOutput SanPham { get; set; }
        public KhachHangOutput KhachHang { get; set; }
        public List<SanPhamVM> HUIItems { get; set; }
        public List<SanPhamOutput> SanPhamOutPut { get; set; }
    }
}
