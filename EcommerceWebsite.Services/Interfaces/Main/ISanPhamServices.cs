using EcommerceWebsite.Application.Pagination;
using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Data.Identity;
using EcommerceWebsite.Utilities.Output.Main;
using EcommerceWebsite.Utilities.ViewModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebsite.Services.Interfaces.Main
{
    public interface ISanPhamServices 
    {
        Task<PageResponse<List<SanPhamOutput>>> GetListProductByPage(PaginationFilter filter);

        Task<List<HUICost>> GetProductWithMultipleId(string[] idArray);
        Task<string> ThemSanPham(SanPham input);
        Task<bool> ThemSanPham(List<SanPham> input);
        Task<SanPham> GetSanPhamTheoMa(string id, string tensanpham);
        Task<bool> KiemTraGia(string value);
        Task<List<SanPhamVM>> LaySanPham();
        Task<List<SanPhamVM>> LaySanPhamTheoLoai(int take = 1, string loaiSanPham = null, string maSanPham = null, string maKH = null);
        Task<List<SanPhamVM>> GetProductWithMultipleId(string [] idArray, string comboCode);

        //Task<List<SanPhamOutput>> laySanPham();
        //Xóa sản phẩm
        Task<bool> SuaHoacXoaSanPham(SanPham input, bool laXoa, string editorMaSP = null);

        //Task<IdentityResult> Create(ApplicationUser obj);

        Task<SanPhamOutput> LayChiTietSanPham(string id);
        //Task<SanPhamOutput> LayChiTietNhapVaBan(string id);

        Task<List<SanPhamOutput>> laySanPhamTheoHang(string idHang);

        Task<List<SanPhamOutput>> laySanPhamTheoDanhMuc(string idDanhMuc, string maKH);

        Task<List<SanPhamOutput>> timKiemSanPhamTheoTen(string idTen);

        Task<SanPhamVM> laySanPhamTheoMa(string id);

        Task<List<SanPhamVM>> LaySPYeuThichKH(string maKH);

        Task<List<SanPhamVM>> LaySanPhamMoiNhat(string maKH);

        Task<List<PhieuNhap>> LayPhieuNhapSanPham(string maPN);

        Task<bool> ThemDinhLuongSanPham(DinhLuong input);

    }
}
