using EcommerceWebsite.Application.Constants;
using EcommerceWebsite.Data.Entities;
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
    public class GioHangApiServices : BaseApiService, IGioHangApiServices
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public GioHangApiServices(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
           : base(httpClientFactory, configuration, httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> ThemCTHoaDon(ChiTietHoaDon hD)
        {
            // phai set truoc thi moi lay dc
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstant.Token);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstant.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestItem = JsonConvert.SerializeObject(hD);
            var httpContent = new StringContent(requestItem, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"/api/GioHang/them-cthoadon/{hD.HoaDonId}/{hD.ProductId}/{hD.SoLuong}/{hD.GiaBan}", httpContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> ThemHoaDon(HoaDon hD)
        {
            // phai set truoc thi moi lay dc
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstant.Token);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstant.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestItem = JsonConvert.SerializeObject(hD);
            var httpContent = new StringContent(requestItem, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"/api/GioHang/them-hoadon/{hD.MaHoaDon}/{hD.MaKhachHang}/{hD.MaKhuyenMai}/{hD.MaDiaChi}/{hD.PhuongThucThanhToan}/{hD.TongCong}/{hD.ThanhTien}/{hD.PhiGiaoHang}", httpContent);
            return response.IsSuccessStatusCode;
        }
    }
}
