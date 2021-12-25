﻿using EcommerceWebsite.Application.Constants;
using EcommerceWebsite.Application.Pagination;
using EcommerceWebsite.Data.Entities;
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

        public async Task<List<SanPhamVM>> laySanPham2()
        {
            return await GetListAsync<SanPhamVM>($"/api/SanPham/lay-sanpham");
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

            var response = await client.PostAsync($"/api/SanPham/them-san-pham", httpContent);
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

        public async Task<List<SanPhamOutput>> laySanPhamTheoHang(string prdId)
        {
            return await GetListAsync<SanPhamOutput>($"/api/SanPham/lay-sanpham-theohang/{prdId}");
        }

        public async Task<List<SanPhamOutput>> laySanPhamTheoDanhMuc(string prdId)
        {
            return await GetListAsync<SanPhamOutput>($"/api/SanPham/lay-sanpham-theodanhmuc/{prdId}");
        }

        public async Task<List<SanPhamOutput>> timKiemSanPhamTheoTen(string keyword)
        {
            return await GetListAsync<SanPhamOutput>($"/api/SanPham/lay-sanpham-theoten/{keyword}");
        }
        public Task<SanPhamVM> laySanPhamTheoMa(string prdId)
        {
            return GetAsync<SanPhamVM>($"/api/SanPham/lay-sanpham-Ma/{prdId}");
        }
        public async Task<List<SanPhamVM>> GetViewWithMultipleIds(string[] prdIds, string comboCode)
        {
            var url = "/api/SanPham/get-mulpitple-id/?comboCode=" + comboCode;
            for (int i = 0; i < prdIds.Length; i++)
            {
                url += i == prdIds.Length - 1 ? $"productIds={prdIds[i]}" : $"productIds={prdIds[i]}&";
            }

            return await GetListAsync<SanPhamVM>(url);
        }

        public async Task<List<SanPhamVM>> LaySPYeuThichKH(string maKH)
        {
            return await GetListAsync<SanPhamVM>($"/api/SanPham/lay-sanphamyt/{maKH}");
        }

        public async Task<List<SanPhamVM>> LaySanPhamMoiNhat()
        {
            return await GetListAsync<SanPhamVM>($"/api/SanPham/lay-sanphammoinhat");
        }

        public async Task<bool> ThemPhieuNhap(PhieuNhapInput input)
        {

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstant.BaseAddress]);
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestItem = JsonConvert.SerializeObject(input);
            var httpContent = new StringContent(requestItem, Encoding.UTF8, "application/json");


            var response = await client
                .PostAsync($"/api/SanPham/them-phieu-nhap", httpContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<List<DoanhThuOutput>> LaySoLuongNhapVaBan(string maSanPham)
        {
            return await GetListAsync<DoanhThuOutput>($"/api/SanPham/lay-soluongnhap-va-ban/{maSanPham}");
        }

        public async Task<List<ThuocTinh>> layDinhluong()
        {
            return await GetListAsync<ThuocTinh>($"/api/SanPham/lay-theodinhluong");
        }

        public async Task<bool> ThemVaSuaHang(NhanHieu input)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstant.BaseAddress]);
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestItem = JsonConvert.SerializeObject(input);
            var httpContent = new StringContent(requestItem, Encoding.UTF8, "application/json");


            var response = await client
                .PostAsync($"/api/SanPham/them-thuocTinh", httpContent);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> XoaHang(string input)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstant.BaseAddress]);
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestItem = JsonConvert.SerializeObject(input);
            var httpContent = new StringContent(requestItem, Encoding.UTF8, "application/json");


            var response = await client
                .PostAsync($"/api/SanPham/xoa-hang/{input}", httpContent);
            return response.IsSuccessStatusCode;
        }
    }
}
