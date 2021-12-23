using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Utilities.Output.Main;
using EcommerceWebsite.Utilities.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EcommerceWebsite.Api.Interface
{
    public class DanhMucApiServices : BaseApiService, IDanhMucApiServices
    {
        public DanhMucApiServices(IHttpClientFactory httpClietnFactory, IConfiguration config, IHttpContextAccessor httpContextAccessor)
            : base(httpClietnFactory, config, httpContextAccessor)
        {
        }

        public async Task<List<DanhMucOutput>> GetCategories()
        {
            return await GetListAsync<DanhMucOutput>("/api/DanhMuc/get-categories");
        }

        public async Task<List<CategorySetVM>> GetDanhMucVaSanPhams(int count, string maKH)
        {
            return await GetListAsync<CategorySetVM>($"/api/DanhMuc/get-danhmuc-sanpham/{count}/{maKH}");
        }

        public async Task<List<ThuocTinh>> GetThuocTinhTheoDanhMuc(string maDanhMuc)
        {
            return await GetListAsync<ThuocTinh>($"/api/DanhMuc/get-danhmuc-thuoctinh/{maDanhMuc}");
        }
    }
}
