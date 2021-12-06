using EcommerceWebsite.Api.Interface;
using EcommerceWebsite.Data.EF;
using EcommerceWebsite.MainWeb.Models;
using EcommerceWebsite.Services.Interfaces.ExtraServices;
using EcommerceWebsite.Utilities.Output.Main;
using EcommerceWebsite.Utilities.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet("get-data-giohang")]
        public  IActionResult layHangSanPham()
        {
            try
            {
                var data =  dSGioHang;
                return PartialView("/Views/GioHang/_ListGioHang.cshtml", data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
        public IActionResult AddGioHang(string id, int soLuong, decimal giaSP, string type = "Normal")
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
                    giaSanPham = giaSP,
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
            HttpContext.Session.SetString("TongTienGH", dSGioHang.Sum(c => c.dThanhTien) + "");
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
                //cập nhật lại 
                HttpContext.Session.Set("GioHang", listGHang);
                HttpContext.Session.SetString("SoLuongGH", dSGioHang.Sum(c => c.soLuong) + "");
                HttpContext.Session.SetString("TongTienGH", dSGioHang.Sum(c => c.dThanhTien) + "");
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

        //updat giỏ hàng
        public ActionResult suaGioHang(string id, int soLuong)
        {
            //Lấy giỏ hàng
            List<GioHang> listGHang = dSGioHang;
            //Kiểm tra xem scah cần cập nhật có trong hàng không?
            GioHang sp = listGHang.Single(s => s.MaSanPham == id);
            //nếu có cập nhật
            if (sp != null)
            {

                sp.soLuong = soLuong;
                HttpContext.Session.Set("GioHang", listGHang);
                HttpContext.Session.SetString("SoLuongGH", dSGioHang.Sum(c => c.soLuong) + "");
                HttpContext.Session.SetString("TongTienGH", dSGioHang.Sum(c => c.dThanhTien) + "");
                return Json(new { code = 200, Message = "Thành công", slGH = dSGioHang.Sum(c => c.soLuong) });
            }
            else
            {
                return Json(new { code = 500, Message = "Thành công" });
            }    
        }
    }
}
