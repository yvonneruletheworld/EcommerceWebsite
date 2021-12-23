using EcommerceWebsite.Api.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWebsite.Admin.Controllers
{
    public class SanPhamController : Controller
    {
        private readonly ISanPhamApiServices _sanPhamApiServices;
        private readonly IDanhMucApiServices _danhMucApiServices;
        private readonly INhanHieuApiServices _nhanHieuApiServices;
        public SanPhamController(ISanPhamApiServices sanPhamApiServices, IDanhMucApiServices danhMucApiServices, INhanHieuApiServices nhanHieuApiServices)
        {
            _sanPhamApiServices = sanPhamApiServices;
            _danhMucApiServices = danhMucApiServices;
            _nhanHieuApiServices = nhanHieuApiServices;
        }
        public async Task<IActionResult> DanhSachSanPhamAsync()
        {
            var data = await _sanPhamApiServices.laySanPham2();
            return View(data);
        }
        public async Task<IActionResult> QuanLyDanhMuc()
        {
            var data = await _danhMucApiServices.GetCategories();
            return View(data);
        }
        public async Task<IActionResult> QuanLyNhanHieu()
        {
            var data = await _nhanHieuApiServices.layNhanHieus();
            return View(data);
        }


    }
}
