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
    public class HoaDonApiSerivce : BaseApiService, IHoaDonApiSerivce
    {

        public HoaDonApiSerivce(IHttpClientFactory httpClietnFactory, IConfiguration config, IHttpContextAccessor httpContextAccessor)
         : base(httpClietnFactory, config, httpContextAccessor)
        {
        }
        public async Task<List<HoaDon>> LayHoaDonTheoKhachHangs(string maKH)
        {
            return await GetListAsync<HoaDon>($"/api/HoaDon/lay-hoaDonTheoKH/{maKH}");
        }

      
    }
}
