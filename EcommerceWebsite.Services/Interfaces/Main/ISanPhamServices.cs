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

        Task<bool> ThemSanPham(SanPham input);
        Task<SanPham> GetSanPhamTheoMa(string id, string tensanpham);
        Task<bool> KiemTraGia(string value);
        Task<List<SanPhamOutput>> LaySanPham();
        Task<List<SanPhamVM>> LaySanPhamTheoLoai(int take = 1, string loaiSanPham = null, string maSanPham = null);
        Task<List<SanPhamVM>> GetProductWithMultipleId(string [] idArray);

        //Task<List<SanPhamOutput>> laySanPham();
        //Xóa sản phẩm
        Task<bool> SuaHoacXoaSanPham(SanPham input, bool laXoa, string editorMaSP = null);

        //Task<IdentityResult> Create(ApplicationUser obj);

        Task<SanPhamOutput> LayChiTietSanPham(string id);


    }
}
