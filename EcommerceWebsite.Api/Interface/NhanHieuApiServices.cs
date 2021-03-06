using EcommerceWebsite.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EcommerceWebsite.Api.Interface
{
    public class NhanHieuApiServices : BaseApiService, INhanHieuApiServices
    {
        public NhanHieuApiServices(IHttpClientFactory httpClietnFactory, IConfiguration config, IHttpContextAccessor httpContextAccessor)
           : base(httpClietnFactory, config, httpContextAccessor)
        {
        }

        public async Task<List<NhanHieu>> layNhanHieus()
        {
            return await GetListAsync<NhanHieu>("/api/NhanHieu/lay-nhanhieu");
        }
    }
}
