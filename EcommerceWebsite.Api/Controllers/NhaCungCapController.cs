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
    public class NhaCungCapController : ControllerBase
    {
        private readonly INhaCungCapServices _nhaCungCapServices;
        public NhaCungCapController(INhaCungCapServices nhaCungCapServices)
        {
            _nhaCungCapServices = nhaCungCapServices;
        }
        [HttpGet("lay-nhacungcap")]
        public async Task<IActionResult> laynhacungcap()
        {
            try
            {
                var result = await _nhaCungCapServices.layNhaCungCap();
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
