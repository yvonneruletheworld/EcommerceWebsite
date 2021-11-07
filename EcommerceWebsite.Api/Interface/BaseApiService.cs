using EcommerceWebsite.Application.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EcommerceWebsite.Api.Interface
{
    public class BaseApiService
    {
        private readonly IHttpClientFactory _httpClietnFactory;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BaseApiService(IHttpClientFactory httpClietnFactory, IConfiguration config, IHttpContextAccessor httpContextAccessor)
        {
            _httpClietnFactory = httpClietnFactory;
            _config = config;
            _httpContextAccessor = httpContextAccessor;
        }

        public BaseApiService(IHttpClientFactory httpClietnFactory, AutoMapper.Configuration.IConfiguration config, IHttpContextAccessor httpContextAccessor)
        {
        }

        public async Task<List<T>> GetListAsync<T> (string url, bool requiredLogin = false)
        {
            var session = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstant.Token);

            // create client from local devices

            var client = _httpClietnFactory.CreateClient();
            client.BaseAddress = new Uri(_config[SystemConstant.BaseAddress]);
            //client.DefaultRequestHeaders.Authorization = new 

            var response = await client.GetAsync(url);
            var body = await response.Content.ReadAsStringAsync();

            return response.IsSuccessStatusCode ?
                (List<T>)JsonConvert.DeserializeObject(body, typeof(List<T>)) 
                : null;
        }
    }
}
