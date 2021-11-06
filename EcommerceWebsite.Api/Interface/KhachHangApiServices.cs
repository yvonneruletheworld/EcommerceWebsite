using EcommerceWebsite.Application.Constants;
using EcommerceWebsite.Utilities.Input;
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
    public class KhachHangApiServices : IKhachHangServices
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public KhachHangApiServices(IHttpClientFactory httpClientFactory, IConfiguration config, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _config = config;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiResult<string>> GetLoginToken(ThongTinKhachHangInput input)
        {
            //pass data into json
            var json = JsonConvert.SerializeObject(input);

            //create httpContext
            var httpContext = new StringContent(json, Encoding.UTF8, "application/json");

            //create client
            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsync("/api/KhachHang/user-login", httpContext);

            if(response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ApiSuccessResult<string>>(await response.Content.ReadAsStringAsync());
            }

            return JsonConvert.DeserializeObject<ApiErrorResult<string>>(await response.Content.ReadAsStringAsync());
        }
    }
}
