using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Utilities.Output.Main;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EcommerceWebsite.Api.Interface
{
    public class KhuyenMaiApiServices : BaseApiService, IKhuyenMaiApiServices
    {
        public KhuyenMaiApiServices(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
           : base(httpClientFactory, configuration, httpContextAccessor)
        {
        }
        public async Task<List<BannerOutput>> LaykhuyenMais()
        {
            return await GetListAsync<BannerOutput>("/api/KhuyenMai/lay-khuyenmai");
        }
    }
}
