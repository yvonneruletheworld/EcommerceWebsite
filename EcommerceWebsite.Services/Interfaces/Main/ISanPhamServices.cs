using EcommerceWebsite.Application.Pagination;
using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Data.Identity;
using EcommerceWebsite.Utilities.Output.Main;
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
        bool? KiemTra(string value);

        //Task<IdentityResult> Create(ApplicationUser obj);
    }
}
