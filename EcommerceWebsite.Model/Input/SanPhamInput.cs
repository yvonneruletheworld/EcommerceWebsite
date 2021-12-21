using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Data.Enum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebsite.Utilities.Output.Main
{
    public class SanPhamInput : EntityBase
    {
        [Required]
        [JsonProperty("maSanPham")]
        public string MaSanPham { get; set; } 
        [JsonProperty("tenSanPham")]
        public string TenSanPham { get; set; }
        [JsonProperty("soLuongNhap")] 
        public int SoLuongNhap { get; set; }
        [JsonProperty("nhanHieu")]
        public string NhanHieu { get; set; }
        [JsonProperty("giaNhap")]
        public decimal GiaNhap { get; set; }
        public decimal ThanhTien { get; set; }
        [JsonProperty("maLoai")] 
        public string MaLoai { get; set; }
        [JsonProperty("tenMauMa")]
        public string TenMauMa { get; set; }
        [JsonProperty("hinhAnh")]
        public string HinhAnh { get; set; }
        [JsonProperty("maThuocTinh")]
        public string MaThuocTinh { get; set; }
        
    }
}
