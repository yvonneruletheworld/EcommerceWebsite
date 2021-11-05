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
    public class DanhMucApiServices : BaseApiService, IDanhMucApiServices
    {
        public DanhMucApiServices(IHttpClientFactory httpClietnFactory, IConfiguration config, IHttpContextAccessor httpContextAccessor)
            : base(httpClietnFactory, config, httpContextAccessor)
        {
        }

        public async Task<List<DanhMucOutput>> GetCategories(string uri)
        {
            return await GetListAsync<DanhMucOutput>(uri);
        }
    }
}
