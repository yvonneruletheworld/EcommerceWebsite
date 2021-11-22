using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Data.Enum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EcommerceWebsite.Utilities.Output.Main
{
    public class SanPhamOutput : EntityBase
    {
        [Required]
        [JsonProperty("maSanPham")]
        public string MaSanPham { get; set; }
        [JsonProperty("tenSanPham")]
        public string TenSanPham { get; set; }
        [JsonProperty("soLuongTon")] 
        public int SoLuongTon { get; set; }
        [JsonProperty("hinhAnh")]
        public string HinhAnh { get; set; }
        [JsonProperty("nhanHieu")]
        public string NhanHieu { get; set; }
        [JsonProperty("loaiSanPham")]
        public string LoaiSanPham { get; set; }
        [JsonProperty("xepHang")]
        public string XepHang { get; set; }
        [JsonProperty("trangThai")]
        public Status Status { get; set; }

        [JsonProperty("listHinhAnh")]
        public List<ThongSoSanPhamOutput> ListHinhAnh { get; set; }
        [JsonProperty("listThongSo")]
        public List<ThongSoSanPhamOutput> ListThongSo { get; set; }
        [JsonProperty("bangGia")]
        public List<BangGiaOutput> BangGia { get; set; }

        [JsonProperty("danhGia")]
        public DanhGiaSanPham DanhGia { get; set; }
        //Khóa ngoại
    }
}
