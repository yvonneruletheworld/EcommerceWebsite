using EcommerceWebsite.Api.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebsite.MainWeb.Controllers
{
    [Route("/KhachHang")]
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class KhachHangController : BackgroudController
    {
        public KhachHangController(IKhachHangApiServices khachHangServices, IConfiguration configuration) : base(khachHangServices, configuration)
        {
        }

        //private readonly IKhachHangApiServices _khachHangServices;
        //private readonly IConfiguration _configuration;

        //public KhachHangController(IKhachHangApiServices khachHangServices, IConfiguration configuration)
        //{
        //    _khachHangServices = khachHangServices;
        //    _configuration = configuration;
        //}


        //get
        [HttpGet("client-login")]
        public async Task<IActionResult> Index()
        {   
            //await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View();
        }

    }
}
