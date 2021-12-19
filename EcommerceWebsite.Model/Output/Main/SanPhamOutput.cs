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
    public class SanPhamOutput : EntityBase 
    {
        public SanPhamOutput()
        {
            ListThongSo = new List<ThongSoSanPhamOutput>();
            BangGia = new List<BangGiaOutput>();
        }

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

        public decimal giaBan { get; set; }
        [JsonProperty("thanhTien")]
        public decimal ThanhTien { get; set; }
        [JsonProperty("maLoai")]
        public string MaLoai { get; set; }

        [JsonProperty("listHinhAnh")]
        public List<ThongSoSanPhamOutput> ListHinhAnh { get; set; }
        [JsonProperty("listThongSo")]
        public List<ThongSoSanPhamOutput> ListThongSo { get; set; }
        [JsonProperty("bangGia")]
        public List<BangGiaOutput> BangGia { get; set; }

        [JsonProperty("danhGia")]
        public List<DanhGiaSanPham> DanhGia { get; set; }
        [JsonProperty("listBinhLuan")]
        public List<BinhLuanOutput> ListBinhLuan { get; set; }

        //Khóa ngoại
    }
}
