using EcommerceWebsite.Api.ApiInterfaces;
using EcommerceWebsite.Application.Constants;
using EcommerceWebsite.Application.Pagination;
using EcommerceWebsite.Data.Identity;
using EcommerceWebsite.Services.Interfaces.ExtraServices;
using EcommerceWebsite.Services.Interfaces.Main;
using EcommerceWebsite.Services.Interfaces.System;
using EcommerceWebsite.Utilities.Email;
using EcommerceWebsite.Utilities.Input;
using EcommerceWebsite.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IKhachHangServices _khachHangService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ISanPhamServices _sanPhamServices;
        private readonly IEmailSenderServices _emailServices;
        private readonly IHUIApiServices _huiApiServices;


        public HomeController(ILogger<HomeController> logger, IKhachHangServices applicationUserService, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IEmailSenderServices emailServices, ISanPhamServices sanPhamServices, IHUIApiServices huiApiServices)
        {
            _logger = logger;
            _khachHangService = applicationUserService;
            _signInManager = signInManager;
            _userManager = userManager;
            _emailServices = emailServices;
            _sanPhamServices = sanPhamServices;
            _huiApiServices = huiApiServices;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var getListApi = await _huiApiServices.GetListHuiFromApi();
            var currentUser = await _userManager.GetUserAsync(User);
            if(currentUser == null)
            {
                await _signInManager.SignOutAsync();
                return View("/Views/Home/TrangChu.cshtml");
            }
            
             return View("/Views/Home/TrangChu.cshtml", currentUser);
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
                return PartialView("/Views/Home/_ListSanPham.cshtml", data);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private string GetUserIp()
        {
            return Request.HttpContext.Connection.RemoteIpAddress.ToString();
        }


        //[HttpGet("get-client-cart")]
        //public Task<IActionResult> GetClientCart ()
        //{
        //    try
        //    {
        //        var curIp = GetUserIp();
        //        curIp ??=
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
    }
}
