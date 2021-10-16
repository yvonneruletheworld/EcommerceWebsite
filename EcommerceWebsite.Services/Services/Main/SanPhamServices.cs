using EcommerceWebsite.Application.Pagination;
using EcommerceWebsite.Data.EF;
using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Data.Identity;
using EcommerceWebsite.Services.Interfaces.Main;
using EcommerceWebsite.Utilities.Main;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebsite.Services.Services.Main
{
    public class SanPhamServices : ISanPhamServices
    {
        private readonly EcomWebDbContext _context;

        public SanPhamServices(EcomWebDbContext context)
        {
            this._context = context;
        }

        public List<SanPham> GetListProduct()
        {
            return null;
        }

        public PageResponse<List<ProductOutput>> GetListProductByPage(string key, int pageIndex, int pageSize)
        {

        }

        public bool? KiemTra(string value)
        {
            return value?.Contains("j");
        }
    }
}
