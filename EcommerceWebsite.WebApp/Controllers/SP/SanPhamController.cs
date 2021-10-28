using EcommerceWebsite.Application.Pagination;
using EcommerceWebsite.Services.Interfaces.Main;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.WebApp.Controllers.SP
{
    public class SanPhamController : Controller
    {
        private readonly ISanPhamServices _sanPhamServices;
        private readonly IBoPhanServices _boPhanServices;

        public SanPhamController(ISanPhamServices sanPhamServices, IBoPhanServices boPhanServices)
        {
            this._sanPhamServices = sanPhamServices;
            _boPhanServices = boPhanServices;
        }

        public IActionResult Index()
        {
            return View("/Views/SanPham/Index.cshtml");
        }
        
        [HttpGet("get-data-sanpham")]
        public async Task<IActionResult> LayDanhSachSanPhamAsync(int pageIndex)
        {
            try
            {
                PaginationFilter filter = new PaginationFilter();
                filter.PageSize = 10;
                filter.PageNumber = pageIndex;

                var data = await _sanPhamServices.GetListProductByPage(filter);
                return PartialView("/Views/SanPham/_ListDS.cshtml", data);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpGet("get-data-bophan")]
        public async Task<IActionResult> LoadBoPhan()
        {
            try
            {
                var data = await _boPhanServices.LayDanhSachBoPhan();
                var kq = data.Count();
                return Json(new { code = kq });

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
