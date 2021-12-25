using EcommerceWebsite.Api.Interface;
using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Utilities.ViewModel;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EcommerceWebsite.MainWeb.Controllers
{
    public class YeuThichController : Controller
    {
        private readonly ILogger<YeuThichController> _logger;
        private readonly IYeuThichSanPhamApiServices _yeuThichSanPhamApiServices;
        public const string SessionSoLuongYT = "_SoLuong";
        public YeuThichController(IYeuThichSanPhamApiServices yeuThichSanPhamApiServices, ILogger<YeuThichController> logger)
        {
            _yeuThichSanPhamApiServices = yeuThichSanPhamApiServices;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            var userId = "";
            if (User.Claims != null && User.Claims.Count() > 1)
            {
                 userId = User.Claims.Where(claim => claim.Type == ClaimTypes.Sid)
                                        .FirstOrDefault()
                                        .Value;
                var data = await _yeuThichSanPhamApiServices.laySanPhamYeuThich(userId);
                HttpContext.Session.SetString(SessionSoLuongYT, data.Count() + "");
                // create claims
                //var soLuongYeuThich = new[]
                //       {
                //    new Claim(ClaimTypes.Locality,  HttpContext.Session.GetString("_SoLuong")),
                //};
                //var claimsIdentity = new ClaimsIdentity(
                //soLuongYeuThich, CookieAuthenticationDefaults.AuthenticationScheme);

                ViewBag.soLuong = HttpContext.Session.GetString("_SoLuong");
                return View(data);
            }
            else
            {
                return RedirectToAction("Index", "KhachHang");
            }    
           
        }
        public async Task<IActionResult> ThemSanPhamYeuThich(string id)
        {
            try
            {
               
                if (User.Claims != null && User.Claims.Count() > 1)
                {
                    var userId = User.Claims.Where(claim => claim.Type == ClaimTypes.Sid)
                                          .FirstOrDefault()
                                          .Value;
                    SanPhamYeuThich spyt = new SanPhamYeuThich();
                    spyt.MaSanPham = id;
                    spyt.MaKhachHang = userId;
                    var them =  _yeuThichSanPhamApiServices.ThemYeuThichSanPham(spyt);
                   
                    if (them.Result)// thêm thành công
                    {
                        var soLuong = await _yeuThichSanPhamApiServices.laySanPhamYeuThich(userId);
                        HttpContext.Session.SetString(SessionSoLuongYT, soLuong.Count() + "");
                        return Json(new
                        {
                           sl = soLuong.Count(),
                            status = true
                        });
                    }
                    else//Đã thêm
                    {
                        var soLuong = await _yeuThichSanPhamApiServices.laySanPhamYeuThich(userId);
                        HttpContext.Session.SetString(SessionSoLuongYT, soLuong.Count() + "");
                        return Json(new
                        {
                            sl = soLuong.Count(),
                            code = 2,
                            msg = "Lỗi rồi",
                        }) ;
                    }
                   
                }
                else// chưa đăng nhập
                {
                    return Json(new
                    {
                        code = 1,
                        msg = "Lỗi rồi",
                    });
                }    
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    code = 500,
                    msg = "Lỗi rồi" + ex.Message
                });
            }
        }
    }
}
