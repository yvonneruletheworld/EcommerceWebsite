using EcommerceWebsite.Utilities.Output.Main;
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
    }
}
