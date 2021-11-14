using EcommerceWebsite.Api.Interface;
using EcommerceWebsite.WebAdmin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
namespace EcommerceWebsite.WebAdmin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISanPhamApiServices _sanPhamApiServices;
        public HomeController(ILogger<HomeController> logger, ISanPhamApiServices sanPhamApiServices)
        {
            _logger = logger;
            _sanPhamApiServices = sanPhamApiServices;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult QuanLySanPham()
        {
            return View();
        }
        [HttpGet("get-data-allquanlysanpham")]
        public async Task<IActionResult> LayDanhSachSanPhamAsync()
        {
            try
            {
                var data = await _sanPhamApiServices.laySanPham2();
                return PartialView("/Views/Home/_ListQuanLySanPham.cshtml", data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
