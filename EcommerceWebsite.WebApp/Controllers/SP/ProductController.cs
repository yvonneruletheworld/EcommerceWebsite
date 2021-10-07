using EcommerceWebsite.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.WebApp.Controllers.SP
{
    public class ProductController : Controller
    {
        private readonly IProductServices productServices;

        public ProductController(IProductServices productServices)
        {
            this.productServices = productServices;
        }

        public IActionResult Index()
        {
            var lst = productServices.GetListProduct();
            bool? kt = productServices.KiemTra("j");
            return View();
        }
    }
}
