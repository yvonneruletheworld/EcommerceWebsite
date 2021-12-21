using EcommerceWebsite.Api.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EcommerceWebsite.MainWeb.Controllers
{
    public class LichSuDonHangController : Controller
    {
        private readonly IHoaDonApiSerivce _hoaDonApiSerivce;
      
        public LichSuDonHangController(IHoaDonApiSerivce hoaDonApiSerivce )
        {
            _hoaDonApiSerivce = hoaDonApiSerivce;
        }
        public async  Task<IActionResult> DanhSachDonHang()
        {
            try
            {
                if (User.Claims != null && User.Claims.Count() > 1)
                {
                    var userId = User.Claims.Where(claim => claim.Type == ClaimTypes.Sid)
                                             .FirstOrDefault()
                                             .Value;
                    var duLieu = await _hoaDonApiSerivce.LayHoaDonTheoKhachHangs(userId);
                    return View("/Views/LichSuDonHang/DanhSachDonHang.cshtml", duLieu);
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
