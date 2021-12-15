using EcommerceWebsite.Application.Constants;
using EcommerceWebsite.Data.Entities;
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
    public class KhachHangApiServices : BaseApiService, IKhachHangApiServices
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public KhachHangApiServices(IHttpClientFactory httpClientFactory, IConfiguration config, IHttpContextAccessor httpContextAccessor)
             : base(httpClientFactory, config, httpContextAccessor)
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
            //convert data into json
            var json = JsonConvert.SerializeObject(input);

            //create httpContext
            var httpContext = new StringContent(json, Encoding.UTF8, "application/json");

            //create client
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_config[SystemConstant.BaseAddress]);
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", session);

            var response = await client.PostAsync("/api/KhachHang/user-login", httpContext);

            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                
                var rs = JsonConvert.DeserializeObject<ApiSuccessResult<string>>(content);
                return rs;
            }

            return JsonConvert.DeserializeObject<ApiErrorResult<string>>(content);
        }

        public async Task<List<DiaChiKhachHang>> layDiaChiKhachHang(string MaKH)
        {
            return await GetListAsync<DiaChiKhachHang>($"/api/KhachHang/lay-diachiKhachHang/{MaKH}");
        }

        public async Task<bool> Resgister(ThongTinKhachHangInput input)
        {
            var dataJson = JsonConvert.SerializeObject(input);

            var httpContext = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_config[SystemConstant.BaseAddress]);
            var response = await client.PostAsync("/api/KhachHang/user-login", httpContext);

            var content = await response.Content.ReadAsStringAsync();
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateOTP(string maKhachHang, string otp)
        {
            var session = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstant.Token);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_config[SystemConstant.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", session); 
            
            var response = await client.GetAsync($"/api/KhachHang/update-otp/{maKhachHang}/{otp}");
            return response.IsSuccessStatusCode;
        }
        
        public async Task<bool> SendMail(string mailAddress, string otpCode)
        {
            var session = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstant.Token);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_config[SystemConstant.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", session); 
            
            var response = await client.GetAsync($"/api/KhachHang/send-mail/{mailAddress}/{otpCode}");
            return response.IsSuccessStatusCode;
        }

        public async Task<KhachHang> LayThongTinKhachHang(string maKH)
        {
            return await GetAsync<KhachHang>($"api/KhachHang/LayThongTinKhachHang/{maKH}");
        }
    }
}
