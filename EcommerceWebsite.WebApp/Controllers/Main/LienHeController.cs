using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.WebApp.Controllers.Main
{
    public class LienHeController : Controller
    {
        public IActionResult lienHeVoiChungToi()
        {
            return View();
        }
    }
}
