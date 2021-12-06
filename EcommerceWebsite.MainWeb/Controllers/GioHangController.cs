using EcommerceWebsite.Api.Interface;
using EcommerceWebsite.Data.EF;
using EcommerceWebsite.MainWeb.Models;
using EcommerceWebsite.Services.Interfaces.ExtraServices;
using EcommerceWebsite.Utilities.Output.Main;
using EcommerceWebsite.Utilities.ViewModel;
using Microsoft.AspNetCore.Http;
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
        //Thêm
        public IActionResult AddGioHang(string id, int soLuong, string type = "Normal")
        {
            var myCart = dSGioHang;
            var item = myCart.SingleOrDefault(p => p.MaSanPham == id);

            if (item == null)//chưa có
            {
                var data = _sanPhamApiServices.laySanPhamTheoMa(id);////lấy sản phaair dưới data
                SanPhamVM sp = data.Result;
                item = new GioHang
                {
                    MaSanPham = id,
                    tenSanPham = sp.TenSanPham,
                    giaSanPham = sp.GiaBan,
                    soLuong = soLuong,
                    hinhAnh = sp.HinhAnh
                };
                myCart.Add(item);
            }
            else
            {
                item.soLuong += soLuong;
            }
           
            HttpContext.Session.Set("GioHang", myCart);
            HttpContext.Session.SetString("SoLuongGH", dSGioHang.Sum(c => c.soLuong) +"");
            if (type == "ajax")
            {
                return Json(new
                {
                    slGH = dSGioHang.Sum(c => c.soLuong)
               
            });
            }
            return RedirectToAction("Index", "GioHang");
        }


        //xóa giỏ hàng
        public ActionResult XoaGioHang(string id)
        {
            //Lấy giỏ hàng
            List<GioHang> listGHang = dSGioHang;
            //KIểm tra giỏ hàng
            GioHang sp = listGHang.Single(s => s.MaSanPham == id);
            //nếu có thì xóa nè
            if (sp != null)
            {
                listGHang.RemoveAll(s => s.MaSanPham == id);
                HttpContext.Session.Set("GioHang", listGHang);
                HttpContext.Session.SetString("SoLuongGH", dSGioHang.Sum(c => c.soLuong) + "");
                return Json(new { slGH = dSGioHang.Sum(c => c.soLuong),
                    Message = "Thành công"});
            }
            //Nếu giỏ hàng rỗng
            if (listGHang.Count == 0)
            {
                return RedirectToAction("index", "Home");
            }
            return RedirectToAction("index", "Home");
        }
    }
}
