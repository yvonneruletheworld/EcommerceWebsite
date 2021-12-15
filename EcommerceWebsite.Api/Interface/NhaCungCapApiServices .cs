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
    public class NhaCungCapApiServices : BaseApiService, INhaCungCapApiServices
    {
        public NhaCungCapApiServices(IHttpClientFactory httpClietnFactory, IConfiguration config, IHttpContextAccessor httpContextAccessor)
           : base(httpClietnFactory, config, httpContextAccessor)
        {
        }

        public async Task<List<NhaCungCap>> layNhaCungCap()
        {
            return await GetListAsync<NhaCungCap>("/api/NhaCungCap/lay-nhacungcap");
        }
    }
}
