using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Utilities.Output.Main
{
    public class ThongSoSanPhamOutput
    {
        [JsonProperty("maThuocTinh")]
        public string MaThuocTinh { get; set; }
        [JsonProperty("maDinhLuong")]
        public string MaDinhLuong { get; set; }
        [JsonProperty("thuocTinh")]
        public string ThuocTinh { get; set; }
        [JsonProperty("donVi")]
        public string DonVi { get; set; }
        [JsonProperty("giaTri")]
        public string GiaTri { get; set; }
    }
}
