using EcommerceWebsite.Application.Constants;
using EcommerceWebsite.Data.Entities;
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
    public class DanhMucController : ControllerBase
    {
        private readonly IDanhMucServices _danhMucServices;

        public DanhMucController(IDanhMucServices danhMucServices)
        {
            _danhMucServices = danhMucServices;
        }

        [HttpGet("lay-danhmuc")]
        public async Task<IActionResult> layDanhMucs()
        {
            try
            {
                var result = await _danhMucServices.layDanhMucs();
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
