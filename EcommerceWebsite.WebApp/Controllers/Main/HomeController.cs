using EcommerceWebsite.Api.Interface;
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

        public HomeController(IHUIApiServices huiApiServices, IDanhMucApiServices danhMucApiServices)
        {
            _huiApiServices = huiApiServices;
            _danhMucApiServices = danhMucApiServices;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var fileName = "output1";
            var listHUI = await _huiApiServices.GetListHUIFromOutput($"/api/HUI/get-list-hui/{fileName}");
            return View();
        }

        [HttpGet("list-danh-muc")]
        public async Task<IActionResult> GetListCategories ()
        {
            var rs = await _danhMucApiServices.GetCategories("/api/DanhMuc/get-categories");
            return Json (new { data = rs.Count });
        }
    }
}
