using EcommerceWebsite.Application.Pagination;
using EcommerceWebsite.Utilities.Output.Main;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;


namespace EcommerceWebsite.Api.Interface
{
    public class SanPhamApiServices : BaseApiService, ISanPhamApiServices
{
        
        public SanPhamApiServices(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, configuration, httpContextAccessor)
        {

        }
        public Task<PageResponse<List<SanPhamOutput>>> laySanPham(PaginationFilter pagination)
        {
            throw new NotImplementedException();
        }

        public async Task<List<SanPhamOutput>> laySanPham2()
        {
           return await GetListAsync<SanPhamOutput>("/api/SanPham/lay-sanpham");
        }
    }
}
