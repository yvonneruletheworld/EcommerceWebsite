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
    public class KhuyenMaiController : ControllerBase
    {
        private readonly IKhuyenMaiServices _khuyenMaiServices;
        public KhuyenMaiController(IKhuyenMaiServices khuyenMaiServices)
        {
            _khuyenMaiServices = khuyenMaiServices;
        }

        [HttpGet("lay-khuyenmai")]
        public async Task<IActionResult> laySanPhams()
        {
            try
            {
                var result = await _khuyenMaiServices.LayKhuyenMaiChoTrangChu();
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
