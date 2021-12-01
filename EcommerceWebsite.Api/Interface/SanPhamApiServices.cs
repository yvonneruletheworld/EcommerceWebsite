using EcommerceWebsite.Application.Constants;
using EcommerceWebsite.Application.Pagination;
using EcommerceWebsite.Utilities.Input;
using EcommerceWebsite.Utilities.Output.Main;
using EcommerceWebsite.Utilities.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace EcommerceWebsite.Api.Interface
{
    public class SanPhamApiServices : BaseApiService, ISanPhamApiServices
{
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public SanPhamApiServices(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, configuration, httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }
        public Task<PageResponse<List<SanPhamOutput>>> laySanPham(PaginationFilter pagination)
        {
            throw new NotImplementedException();
        }

        public async Task<List<SanPhamOutput>> laySanPham2()
        {
           return await GetListAsync<SanPhamOutput>("/api/SanPham/lay-sanpham");
        }

        public async Task<bool> ThemSanPham(SanPhamOutput input)
        {
            //for auth
            // phai set truoc thi moi lay dc
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstant.Token);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstant.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestItem = JsonConvert.SerializeObject(input);
            var httpContent = new StringContent(requestItem, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"/api/SanPham/them-san-pham", httpContent );
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Modify(bool laXoa, SanPhamOutput input)
        {
            var sessions = _httpContextAccessor
                .HttpContext.Session.GetString(SystemConstant.Token);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstant.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            //convert sang json
            var request = JsonConvert.SerializeObject(input);
            var httpContent = new StringContent(request, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"/api/SanPham/them-san-pham/{laXoa}", httpContent);

            return response.IsSuccessStatusCode;
        }

        public async Task<SanPhamVM> LayViewSanPham(string prdId)
        {
            return await GetAsync<SanPhamVM>($"/api/SanPham/Views/{prdId}");
        }

        public async Task<SanPhamOutput> LayChiTietSanPham(string prdId)
        {
            return await GetAsync<SanPhamOutput>($"/api/SanPham/ChiTiet/{prdId}");
        }

        public async Task<List<SanPhamVM>> GetViewWithMultipleIds(string[] prdIds)
        {
            var url = "/api/SanPham/get-mulpitple-id/?";
            for(int i = 0; i< prdIds.Length; i++)
            {
                url +=  i == prdIds.Length - 1 ?  $"productIds={prdIds[i]}" :  $"productIds={prdIds[i]}&";
            }

            return await GetListAsync<SanPhamVM>(url);
        }
    }
}
