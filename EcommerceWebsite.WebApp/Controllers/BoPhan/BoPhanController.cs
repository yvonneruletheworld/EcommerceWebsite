using EcommerceWebsite.Services.Interfaces.Main;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.WebApp.Controllers.BoPhan
{
    public class BoPhanController : Controller
    {
        private readonly IBoPhanServices boPhanServices;

        public BoPhanController(IBoPhanServices boPhanServices)
        {
            this.boPhanServices = boPhanServices;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var danhSach = await boPhanServices.LayDanhSachBoPhan();
            return View();
        }
    }
}
