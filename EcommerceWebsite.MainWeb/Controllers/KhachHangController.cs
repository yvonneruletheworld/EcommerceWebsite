using EcommerceWebsite.Api.Interface;
using EcommerceWebsite.Application.Constants;
using EcommerceWebsite.Data.Enum;
using EcommerceWebsite.Utilities.Input;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
            var vm = new ThongTinKhachHangInput();
            vm.Type = (int)LoaiTruyCap.Login;
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View(vm);
        }
        [HttpGet("client-register")]
        public async Task<IActionResult> Register()
        {
            var vm = new ThongTinKhachHangInput();
            vm.Type = (int)LoaiTruyCap.Register;
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View("/Views/KhachHang/Index.cshtml", vm);
        }

        [HttpPost("post-client-register")]
        public async Task<IActionResult> Register(ThongTinKhachHangInput input)
        {
            if(ModelState.IsValid)
            {
                var rs = await _khachHangServices.Resgister(input);
                return rs ? await this.Index(input) : Json(Messages.Login_Fail);
            }
            ModelState.AddModelError("", Messages.KhachHang_InputError);
            return View("/Views/KhachHang/Index.cshtml", input);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> LayThongTinKhachHang()
        {
            try
            {
                if(User.Claims != null && User.Claims.Count() > 1)
                {
                    var userId = User.Claims.Where(claim => claim.Type == ClaimTypes.Sid)
                        .FirstOrDefault().Value;
                    var duLieu = await _khachHangServices.LayThongTinKhachHang(userId);
                    return View("/Views/KhachHang/LayThongTinKhachHang.cshtml", duLieu);
                }
                return RedirectToAction("Index", "KhachHang");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}