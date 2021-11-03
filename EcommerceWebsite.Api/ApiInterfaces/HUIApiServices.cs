using EcommerceWebsite.Utilities.System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EcommerceWebsite.Api.ApiInterfaces
{
    public class HUIApiServices : BaseApiServices, IHUIApiServices
    {
        public HUIApiServices(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IConfiguration configuartion) 
            : base(httpClientFactory, httpContextAccessor, configuartion)
        {
        }

        public async Task<List<HUI>> GetListHuiFromApi()
        {
            return await GetListAsync<HUI>("/api/HUI/read-hui");
        }
    }
}
