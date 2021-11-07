﻿using EcommerceWebsite.Application.Pagination;
using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Data.Identity;
using EcommerceWebsite.Utilities.Main;
using EcommerceWebsite.Utilities.Output.Main;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebsite.Services.Interfaces.Main
{
    public interface ISanPhamServices
    {
        Task<PageResponse<List<SanPhamOutput>>> GetListProductByPage(PaginationFilter filter);

        bool? KiemTra(string value);

        Task<List<DanhMuc>> LayDanhMucSanPham();

        Task<List<NhanHieu>> LayNhanHieuSanPham();

        Task<ChiTietSanPhamOutput> LayChiTietSanPham(string id, bool coGiamGia);
        //Task<IdentityResult> Create(ApplicationUser obj);
    }
}
