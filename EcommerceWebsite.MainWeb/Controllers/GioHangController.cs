using EcommerceWebsite.Api.Interface;
using EcommerceWebsite.Data.EF;
using EcommerceWebsite.MainWeb.Models;
using EcommerceWebsite.Services.Interfaces.ExtraServices;
using EcommerceWebsite.Utilities.Output.Main;
using EcommerceWebsite.Utilities.ViewModel;
using Microsoft.AspNetCore.Mvc;
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
            return View("/Views/GioHang/Index.cshtml", dSGioHang);
        }
       
        public List<GioHang> dSGioHang
        {
            get {

                var data = HttpContext.Session.Get<List<GioHang>>("GioHang");
                if(data == null)
                {
                    data = new List<GioHang>();
                }   
                return data;
            }
        }
        //public IActionResult AddGioHang(string id, int soLuong, string type = "Normal")
        //{
        //    var myCart = dSGioHang;
        //    var item = myCart.SingleOrDefault(p => p.MaSanPham == id);

        //    if (item == null)//chưa có
        //    {
        //        var data =  _sanPhamApiServices.laySanPhamTheoMa(id);////lấy sản phaair dưới data
        //        SanPhamVM sp = data;
        //        item = new GioHang
        //        {
        //            MaSanPham = id,
        //            tenSanPham = sp.TenSanPham,
        //            giaSanPham = 120000,
        //            soLuong = soLuong,
        //            hinhAnh = sp.HinhAnh
        //        };
        //        myCart.Add(item);
        //    }
        //    else
        //    {
        //        item.soLuong += soLuong;
        //    }
        //    HttpContext.Session.Set("GioHang", myCart);

        //    if (type == "ajax")
        //    {
        //        return Json(new
        //        {
        //            SoLuong = dSGioHang.Sum(c => c.soLuong)
        //        });
        //    }
        //    return RedirectToAction("Index", "GioHang");
        //}
    }
}
