using EcommerceWebsite.Api.Interface;
using EcommerceWebsite.Application.Constants;
using EcommerceWebsite.MainWeb.Models;
using EcommerceWebsite.Utilities.Output.Main;
using EcommerceWebsite.Utilities.Output.System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.WebApp.Controllers.Main
{
    public class GioHangController : Controller
    {
        private readonly ISanPhamApiServices _sanPhamApiServices;
        public GioHangController(ISanPhamApiServices sanPhamApiService)
        {
            _sanPhamApiServices = sanPhamApiService;
        }
        public IActionResult Index()
        {
            return View("/Views/GioHang/Index.cshtml");
        }
        // lấy giỏ hàng
        [HttpPost("{id}")]
        public async Task<IActionResult> AddGioHang(string id)
        {
            var sanPham = await _sanPhamApiServices.LayViewSanPham(id);
            var session = HttpContext.Session.GetString(SystemConstants.CartSession);
            List<GioHang> currentCart = new List<GioHang>();
            if (session != null)
                currentCart = JsonConvert.DeserializeObject<List<GioHang>>(session);

            int quantity = 1;
            if (currentCart.Any(x => x.MaSanPham == id))
            {
                quantity = currentCart.First(x => x.MaSanPham == id).soLuong + 1;
            }
            var cartItem = new GioHang()
            {
                MaSanPham = id,
                tenSanPham = sanPham.TenSanPham,
                hinhAnh = sanPham.HinhAnh,
                giaSanPham = sanPham.GiaBan,
                soLuong = quantity,

            };
            currentCart.Add(cartItem);

            HttpContext.Session.SetString(SystemConstants.CartSession, JsonConvert.SerializeObject(currentCart));
            return Ok(currentCart);
        }
    }
}
