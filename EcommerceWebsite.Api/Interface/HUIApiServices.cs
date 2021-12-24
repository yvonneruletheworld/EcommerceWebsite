using EcommerceWebsite.Application.Constants;
using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Utilities.Output.System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebsite.Api.Interface
{
    public class HUIApiServices : BaseApiService, IHUIApiServices
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public HUIApiServices(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, configuration, httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> AddListHui(List<HUICost> inputs)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstant.BaseAddress]);
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestItem = JsonConvert.SerializeObject(inputs);
            var httpContent = new StringContent(requestItem, Encoding.UTF8, "application/json");

            var response = await client
                .PostAsync($"/api/SanPham/add-list-hui", httpContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<Dictionary<DateTime, List<HUICost>>> GetListHUIFromData()
        {
            return await GetAsync<Dictionary<DateTime, List<HUICost>>>($"/api/HUI/get-all-list-hui");
        }

        public async Task<List<HUI>> GetListHUIFromOutput(string fileName)
        {
            return await GetListAsync<HUI>($"/api/HUI/get-list-hui/{fileName}");
        }
    }
}
