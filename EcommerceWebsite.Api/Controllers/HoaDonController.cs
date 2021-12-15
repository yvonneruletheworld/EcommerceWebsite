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
        [HttpGet("lay-hoaDonTheoKH/{maKH}")]
        public async Task<IActionResult> layHoaDon(string maKH)
        {
            try
            {
                var result = await _hoaDonServices.layHoaDonTheoKhachHang(maKH);
                if (result == null)
                    return BadRequest(Messages.API_EmptyResult);
                else return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.API_Exception + ex);
            }
        }
    }
}
