using EcommerceWebsite.Application.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EcommerceWebsite.Api.ApiInterfaces
{
    public class BaseApiServices
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuartion;

        public BaseApiServices(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IConfiguration configuartion)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
            _configuartion = configuartion;
        }

        protected async Task<List<T>> GetListAsync<T>(string url)
        {
            var sessions = _httpContextAccessor
                .HttpContext.Session
                .GetString(SystemConstant.Token);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5001");
            //client.DefaultRequestHeaders.Authorization

            var response = await client.GetAsync(url);
            var body = await response.Content.ReadAsStringAsync();

            if(response.IsSuccessStatusCode)
            {
                var data = (List<T>)JsonConvert.DeserializeObject(body, typeof(List<T>));
                return data;
            }
            return null;
        }
    }
}
