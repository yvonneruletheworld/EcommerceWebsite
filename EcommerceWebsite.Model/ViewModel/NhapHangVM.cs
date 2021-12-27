using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Utilities.Output.Main;
using EcommerceWebsite.Utilities.Output.System;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Utilities.ViewModel
{
    public class NhapHangVM
    {
        [JsonProperty("sanPhamInputs")]
        public IEnumerable<SanPhamInput> SanPhamInputs { get; set; }
        [JsonProperty("nhaCungCap")]
        public List<NhaCungCap> NhaCungCaps { get; set; }
        public List<PhieuNhap> phieuNhap { get; set; }
        [JsonProperty("danhMuc")]
        public List<DanhMucOutput> DanhMucs { get; set; }
       
    }
}
