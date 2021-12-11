using EcommerceWebsite.Api.Interface;
using EcommerceWebsite.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.Admin.Controllers
{
    public class DonHangController : Controller
    {
        private readonly IGioHangApiServices _gioHangApiServices;
        public DonHangController(IGioHangApiServices gioHangApiServices)
        {
            _gioHangApiServices = gioHangApiServices;

        }
        public async Task<IActionResult> DuyetDonHang()
        {
            try
            {
                var data = await _gioHangApiServices.LayDonHangDangDuyet();
                return View("/Views/DonHang/DuyetDonHang.cshtml", data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IActionResult> TienHanhDuyetDonHang(string id)
        {
            try
            {

             
                    var them =  _gioHangApiServices.DuyetDonHang(id);
                 
                    if (them.Result)// duyet thành công
                    {
                        return Json(new
                        {
                            status = true
                        });
                    }
                    else//Đã thêm
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
        public async Task<IActionResult> DaDuyetDonHang()
        {
            try
            {
                var data = await _gioHangApiServices.LayDonHangDaDuyet();
                return View("/Views/DonHang/DaDuyetDonHang.cshtml", data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
