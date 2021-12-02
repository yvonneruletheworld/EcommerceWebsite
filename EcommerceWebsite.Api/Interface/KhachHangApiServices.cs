using EcommerceWebsite.Application.Constants;
using EcommerceWebsite.Utilities.Input;
using EcommerceWebsite.Utilities.Output.System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebsite.Api.Interface
{
    public class KhachHangApiServices : IKhachHangApiServices
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

        public async Task<KhachHangOutput> GetKhachHangTheoMa(string maKhachHang)
        {
            try
            {
                var session = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstant.Token);

                var client = _httpClientFactory.CreateClient();
                client.BaseAddress = new Uri(_config[SystemConstant.BaseAddress]);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", session);

                var response = await client.GetAsync($"api/KhachHang/get-khach-hang/{maKhachHang}");
                var body = await response.Content.ReadAsStringAsync();

                return response.IsSuccessStatusCode ?
                 (KhachHangOutput)JsonConvert.DeserializeObject(body, typeof(KhachHangOutput))
                 : JsonConvert.DeserializeObject<KhachHangOutput>(body);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<ApiResult<string>> GetLoginToken(ThongTinKhachHangInput input)
        {
            //pass data into json
            var json = JsonConvert.SerializeObject(input);

            //create httpContext
            var httpContext = new StringContent(json, Encoding.UTF8, "application/json");

            //create client
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_config[SystemConstant.BaseAddress]);
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", session);

            var response = await client.PostAsync("/api/KhachHang/user-login", httpContext);

            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var rs = JsonConvert.DeserializeObject<ApiSuccessResult<string>>(content);
                return rs;
            }

            return JsonConvert.DeserializeObject<ApiErrorResult<string>>(await response.Content.ReadAsStringAsync());
        }
    }
}
