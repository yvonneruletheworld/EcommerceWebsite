using EcommerceWebsite.Services.Interfaces.Main;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.WebApp.Controllers.SP
{
    public class ProductController : Controller
    {
        private readonly ISanPhamServices sanPhamServices;

        public ProductController(ISanPhamServices sanPhamServices)
        {
            this.sanPhamServices = sanPhamServices;
        }

        public IActionResult Index()
        {
            bool? kt = productServices.KiemTra("j");
            return View();
        }
    }
}
