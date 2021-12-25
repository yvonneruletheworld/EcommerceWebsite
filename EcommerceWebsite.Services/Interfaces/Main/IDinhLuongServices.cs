using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Utilities.Output.Main;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebsite.Services.Interfaces.Main
{
    public interface IDinhLuongServices
    {
        Task<List<ThongSoSanPhamOutput>> LayThongSoTheoSanPham(string maSanPham);
        Task<DinhLuong> LayDinhLuongTheoSanPham(string maSanPham);
        Task<List<ThuocTinh>> LayThongSo();
        Task<List<string>> AddRangeAsync(List<DinhLuong> input);
        Task<bool> UpdateAsync(DinhLuong input);
        Task<bool> ThemVaSuaHang(NhanHieu input);
        Task<bool> XoaHang(string maNhanHieu);
    }
}
