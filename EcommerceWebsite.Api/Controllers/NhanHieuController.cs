using EcommerceWebsite.Application.Constants;
using EcommerceWebsite.Services.Interfaces.Main;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanHieuController : Controller
    {
        private readonly INhanHieuServices _nhanHieuServices;
        public NhanHieuController(INhanHieuServices nhanHieuServices)
        {
            _nhanHieuServices = nhanHieuServices;
        }
        [HttpGet("lay-nhanhieu")]
        public async Task<IActionResult> layNhanHieus()
        {
            try
            {
                var result = await _nhanHieuServices.layHangSanPham();
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
