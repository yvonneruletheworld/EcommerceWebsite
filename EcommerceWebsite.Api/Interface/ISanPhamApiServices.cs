using EcommerceWebsite.Application.Pagination;
using EcommerceWebsite.Utilities.Input;
using EcommerceWebsite.Utilities.Output.Main;
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

        Task<bool> ThemSanPham(SanPhamInput input);
        Task<bool> Modify(bool laXoa, SanPhamInput input);
    }
}
