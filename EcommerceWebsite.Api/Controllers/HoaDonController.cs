using EcommerceWebsite.Application.Constants;
using EcommerceWebsite.Services.Interfaces.Main;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonController : ControllerBase
    {

        private readonly IHoaDonServices _hoaDonServices;
        public HoaDonController(IHoaDonServices hoaDonServices)
        {
            _hoaDonServices = hoaDonServices;
        }
        [HttpGet("DanhSachHoaDonTheoKhachHang/{maKH}")]
        public async Task<IActionResult> DanhSachHoaDonTheoKhachHang(string maKH)
        {
            try
            {
                var result = await _hoaDonServices.DanhSachHoaDonTheoKhachHang(maKH);
                var dicHoaDon = result.OrderBy(ct => ct.HoaDons.NgayTao).OrderBy(ct2 => ct2.HoaDonId);
                if (dicHoaDon == null)
                    return BadRequest(Messages.API_EmptyResult);
                else return Ok(dicHoaDon);
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.API_Exception + ex);
            }
        }
    }
}
