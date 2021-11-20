using EcommerceWebsite.Utilities.Output.Main;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.WebApp.Controllers.Main
{
    public class GioHangController : Controller
    {
        public IActionResult Index()
        {
            return View("/Views/GioHang/Index.cshtml");
        }
        ////lấy giỏ hàng
        //public List<GioHangOutput> LayGioHang()
        //{

        //    List<GioHangOutput> listGHang = Session["cart"] as List<GioHangOutput>;
        //    if (listGHang == null)
        //    {
        //        //Nếu gỏi k tồn tại thì khởi tạo
        //        listGHang = new List<GioHangOutput>();
        //        Session["cart"] = listGHang;
        //    }
        //    return listGHang;
        //}
    }
}
