using EcommerceWebsite.Api.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.Admin.Controllers
{
    public class NhapSanPhamController : Controller
    {
        private readonly INhaCungCapApiServices _nhaCungCapApiServices;
        public NhapSanPhamController(INhaCungCapApiServices nhaCungCapApiServices)
        {
            _nhaCungCapApiServices = nhaCungCapApiServices;

        }
        public async Task<IActionResult> NhapHang()
        {
            try
            {
                var data = await _nhaCungCapApiServices.layNhaCungCap();
                return View("/Views/NhapSanPham/NhapHang.cshtml", data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
          
        }
    }
}
