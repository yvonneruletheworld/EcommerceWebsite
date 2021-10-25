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

        public SanPhamController(ISanPhamServices sanPhamServices)
        {
            this._sanPhamServices = sanPhamServices;
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
                filter.PageSize = 20;
                filter.PageNumber = pageIndex;

                var data = await _sanPhamServices.GetListProductByPage(filter);
                return PartialView("/Views/SanPham/_List.cshtml", data);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
