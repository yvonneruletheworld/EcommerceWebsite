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
        public SanPhamController(ISanPhamApiServices sanPhamApiServices)
        {
            _sanPhamApiServices = sanPhamApiServices;
        }
        public async Task<IActionResult> DanhSachSanPhamAsync()
        {

            var data = await _sanPhamApiServices.laySanPham2(string.Empty);
            return View(data);
        }
    }
}
