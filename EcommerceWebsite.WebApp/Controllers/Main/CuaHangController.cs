using EcommerceWebsite.Api.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.WebApp.Controllers.Main
{
    public class CuaHangController : Controller { 
        private readonly ISanPhamApiServices _sanPhamApiServices;
        private readonly INhanHieuApiServices _nhanHieuApiServices;
        public CuaHangController(ISanPhamApiServices sanPhamApiServices, INhanHieuApiServices nhanHieuApiServices)
        {
            _sanPhamApiServices = sanPhamApiServices;
            _nhanHieuApiServices = nhanHieuApiServices;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("get-data-allsanpham")]
        public async Task<IActionResult> LayAllSanPham()
        {
            try
            {
                var data = await _sanPhamApiServices.laySanPham2();
                return PartialView("/Views/Home/_ListAllSanPham.cshtml", data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("get-data-nhanhieuSP")]
        public async Task<IActionResult> layHangSanPham()
        {
            try
            {
                var data = await _nhanHieuApiServices.layNhanHieus();
                return PartialView("/Views/Home/_ListNhanHieuSanPham.cshtml", data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
