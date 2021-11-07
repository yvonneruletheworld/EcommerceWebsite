using EcommerceWebsite.Api.Interface;
using EcommerceWebsite.Application.Pagination;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.WebApp.Controllers.Main
{
    public class HomeController : Controller
    {
        private readonly IHUIApiServices _huiApiServices;
        private readonly IDanhMucApiServices _danhMucApiServices;
        private readonly ISanPhamApiServices _sanPhamApiServices;

        public HomeController(IHUIApiServices huiApiServices, IDanhMucApiServices danhMucApiServices, ISanPhamApiServices sanPhamApiServices)
        {
            _huiApiServices = huiApiServices;
            _danhMucApiServices = danhMucApiServices;
            _sanPhamApiServices = sanPhamApiServices;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var fileName = "output1";
            var listHUI = await _huiApiServices.GetListHUIFromOutput(fileName);
            return View();
        }

        [HttpGet("list-danh-muc")]
        public async Task<IActionResult> layDanhMucSanPham ()
        {
            try
            {
                var data = await _danhMucApiServices.layDanhMuc();
                return PartialView("/Views/Home/_ListDanhMucSanPham.cshtml", data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("get-data-sanpham")]
        public async Task<IActionResult> LayDanhSachSanPhamAsync()
        {
            try
            {
                var data = await _sanPhamApiServices.laySanPham2();
                return PartialView("/Views/Home/_ListSanPham.cshtml", data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
