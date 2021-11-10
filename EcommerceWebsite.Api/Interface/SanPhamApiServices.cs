﻿using EcommerceWebsite.Application.Constants;
using EcommerceWebsite.Application.Pagination;
using EcommerceWebsite.Utilities.Input;
using EcommerceWebsite.Utilities.Output.Main;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
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

        public async Task<bool> ThemSanPham(SanPhamInput input)
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

            var requestItem = new MultipartFormDataContent();



            var response = await client.PostAsync($"/api/products/", requestItem);
            return response.IsSuccessStatusCode;

        }
    }
}
