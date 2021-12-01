using EcommerceWebsite.Application.Pagination;
using EcommerceWebsite.Utilities.Input;
using EcommerceWebsite.Utilities.Output.Main;
using EcommerceWebsite.Utilities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.Api.Interface
{
   public interface ISanPhamApiServices
    {
        Task<PageResponse<List<SanPhamOutput>>> laySanPham(PaginationFilter pagination);

        Task<List<SanPhamOutput>> laySanPham2();

        Task<bool> ThemSanPham(SanPhamOutput input);
        Task<bool> Modify(bool laXoa, SanPhamOutput input);
        Task<SanPhamVM> LayViewSanPham(string prdId);
        Task<List<SanPhamVM>> GetViewWithMultipleIds(string[] prdIds);
        Task<SanPhamOutput> LayChiTietSanPham(string prdId);
    }
}
