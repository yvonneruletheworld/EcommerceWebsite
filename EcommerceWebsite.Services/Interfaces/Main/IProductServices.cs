﻿using EcommerceWebsite.Application.Pagination;
using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Data.Identity;
using EcommerceWebsite.Utilities.Main;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebsite.Services.Interfaces.Main
{
    public interface IProductServices 
    {
        List<Product> GetListProduct();

        PageResponse<List<ProductOutput>> GetListProductByPage(string key, int pageIndex, int pageSize);

        bool? KiemTra(string value);

        Task<IdentityResult> Create(KhachHangVM obj);
    }
}