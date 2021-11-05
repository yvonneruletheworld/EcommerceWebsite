using EcommerceWebsite.Utilities.Output.System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EcommerceWebsite.Api.Interface
{
    public class HUIApiServices : BaseApiService, IHUIApiServices
    {
        public HUIApiServices(IHttpClientFactory httpClietnFactory, IConfiguration config, IHttpContextAccessor httpContextAccessor) 
            : base(httpClietnFactory, config, httpContextAccessor)
        {
        }

        public async Task<List<HUI>> GetListHUIFromOutput(string url)
        {
            return await GetListAsync<HUI>(url);
        }
    }
}
