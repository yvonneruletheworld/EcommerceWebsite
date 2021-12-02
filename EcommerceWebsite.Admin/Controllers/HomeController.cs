using EcommerceWebsite.Admin.Models;
using EcommerceWebsite.Api.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IKhachHangApiServices _khachHangService;
        private readonly ISanPhamApiServices _sanPhamService;


        public HomeController(ILogger<HomeController> logger, IKhachHangApiServices khachHangService, ISanPhamApiServices sanPhamService)
        {
            _logger = logger;
            _khachHangService = khachHangService;
            _sanPhamService = sanPhamService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            //var rs = await _khachHangService.GetKhachHangTheoMa("KH01");
            var rs = await _sanPhamService.laySanPham2();
            return View();
        }

    }
}
