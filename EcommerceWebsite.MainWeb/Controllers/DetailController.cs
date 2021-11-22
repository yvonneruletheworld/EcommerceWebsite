using EcommerceWebsite.Api.Interface;
using EcommerceWebsite.Utilities.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.MainWeb.Controllers
{
    public class DetailController : Controller
    {
        private readonly ISanPhamApiServices _sanPhamServices;

        public DetailController(ISanPhamApiServices sanPhamServices)
        {
            _sanPhamServices = sanPhamServices;
        }

        public async Task<IActionResult> IndexAsync(string prdId)
        {
            var vm = new DetailVM();
            vm.SanPham = await _sanPhamServices.LayChiTietSanPham(prdId);

            return View("Views/Detail/Index.cshtml",vm);
        }
    }
}
