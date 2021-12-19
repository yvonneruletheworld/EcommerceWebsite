using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Utilities.Output.Main
{
    public class BangGiaOutput
    {
        [JsonProperty("maDinhLuong")]
        public  string MaDinhLuong { get; set; }
        [JsonProperty("tenDinhLuong")]
        public string TenDinhLuong { get; set; }
        [JsonProperty("giaBan")]
        public decimal GiaBan { get; set; }
        [JsonProperty("maThuocTinh")]
        public string MaThuocTinh { get; set; }
    }
}
