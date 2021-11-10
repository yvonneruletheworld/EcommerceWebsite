using EcommerceWebsite.Api.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.WebApp.Controllers.Admin
{
    public class TrangChuController : Controller
    {
        private readonly ISanPhamApiServices _sanPhamApiServices;
        public TrangChuController(ISanPhamApiServices sanPhamApiServices)
        {
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
                return PartialView("/Views/TrangChu/_ListQuanLySanPham.cshtml", data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
