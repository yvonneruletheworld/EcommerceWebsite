using EcommerceWebsite.Utilities.Output.Main;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Utilities.Input
{
    public class PhieuNhapInput
    {
        [JsonProperty("creatorId")] 
        public string CreatorId { get; set; }
        [JsonProperty("totalvalue")]
        public string Totalvalue { get; set; }
        [JsonProperty("investor")]
        public string Investor { get; set; }
        [JsonProperty("listSanPhamInput")]
        public List<SanPhamOutput> ListSanPhamInput  { get; set; }

    }
}
