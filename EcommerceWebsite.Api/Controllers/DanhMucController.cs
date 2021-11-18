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

        [HttpGet("get-categories")]
        public async Task<IActionResult> GetListCategories ()
        {
            try
            {
                var result = await _danhMucServices.GetDanhMucs();
                if (result == null)
                    return BadRequest(Messages.API_EmptyResult);
                else return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.API_Exception + ex);
            } 
        }

        [HttpGet("get-danhmuc-sanpham/{count}")]
        public async Task<IActionResult> GetDanhMucVaSanPham (int count)
        {
            try
            {
                var rs = await _danhMucServices.GetDanhMucVaSanPhams(count);
                if (rs == null)
                    return BadRequest(Messages.API_EmptyResult);
                else
                    return Ok(rs);
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.API_Exception + ex);
            }
        }
    }
}
