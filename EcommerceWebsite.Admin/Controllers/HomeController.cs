using EcommerceWebsite.Admin.Models;
using EcommerceWebsite.Api.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EcommerceWebsite.Admin.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IKhachHangApiServices _khachHangApiService;
        private readonly ISanPhamApiServices _sanPhamService;
        private readonly IYeuThichSanPhamApiServices _yeuThichSanPhamService;


        public HomeController(ILogger<HomeController> logger, IKhachHangApiServices khachHangService, ISanPhamApiServices sanPhamService, IYeuThichSanPhamApiServices yeuThichSanPhamService)
        {
            _logger = logger;
            _khachHangApiService = khachHangService;
            _sanPhamService = sanPhamService;
            _yeuThichSanPhamService = yeuThichSanPhamService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            if (User.Claims != null && User.Claims.Count() > 1)
            {
                var userId = User.Claims.Where(claim => claim.Type == ClaimTypes.Sid)
                    .FirstOrDefault().Value;
                var duLieu = await _khachHangApiService.LayThongTinKhachHang(userId);
                HttpContext.Session.SetString("HoTenAdmin", duLieu.HoTen);
            }
            var data = await _yeuThichSanPhamService.LoadTrangChu();
            ViewBag.TongKhachHang = data[0];
            ViewBag.TongSanPham = data[1];
            ViewBag.DaBan = data[3];
            ViewBag.TongTienNhap = data[4];
            ViewBag.TongTienBan = data[2];
            ViewBag.LoiNhuan = ((data[2] - data[4])/ data[4]) * 100;
            //var rs = await _sanPhamService.laySanPham2();
            return View();
        }

        public async Task<IActionResult> LayThongTinKhachHang()
        {
            try
            {
                if (User.Claims != null && User.Claims.Count() > 1)
                {
                    var userId = User.Claims.Where(claim => claim.Type == ClaimTypes.Sid)
                        .FirstOrDefault().Value;
                    var duLieu = await _khachHangApiService.LayThongTinKhachHang(userId);
                    return View("/Views/KhachHang/LayThongTinKhachHang.cshtml", duLieu);
                }
                return RedirectToAction("Index", "KhachHang");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
