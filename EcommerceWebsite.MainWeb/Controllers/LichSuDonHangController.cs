using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.MainWeb.Controllers
{
    public class LichSuDonHangController : Controller
    {
        public IActionResult DanhSachDonHang()
        {
            return View();
        }
    }
}
