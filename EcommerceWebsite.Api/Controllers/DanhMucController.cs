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
        private readonly IDanhMucThuocTinhServices _danhMucThuocTinhServices;

        public DanhMucController(IDanhMucServices danhMucServices, IDanhMucThuocTinhServices danhMucThuocTinhServices)
        {
            _danhMucServices = danhMucServices;
            _danhMucThuocTinhServices = danhMucThuocTinhServices;
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

        [HttpGet("get-danhmuc-sanpham/{count}/{maKH}")]
        public async Task<IActionResult> GetDanhMucVaSanPham (int count, string maKH)
        {
            try
            {
                var rs = await _danhMucServices.GetDanhMucVaSanPhams(count, maKH);
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
        
        [HttpGet("get-danhmuc-thuoctinh/{maDanhMuc}")]
        public async Task<IActionResult> GetThuocTinhTheoDanhMuc (string maDanhMuc)
        {
            try
            {
                var rs = await _danhMucThuocTinhServices.LayThuocTinhTheoDanhMuc(maDanhMuc);
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
