using AutoMapper;
using EcommerceWebsite.Application.Constants;
using EcommerceWebsite.Data.EF;
using EcommerceWebsite.Data.Entities;
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
    public class YeuThichSanPhamController : Controller
    {
        private readonly IYeuThichSanPhamServices _yeuThichSanPhamServices;
        public YeuThichSanPhamController(IYeuThichSanPhamServices yeuThichSanPhamServices)
        {
            _yeuThichSanPhamServices = yeuThichSanPhamServices;
        }
        [HttpPost("them-san-pham-yeu-thich/{maSanPham}/{maKhachHang}")]
        public async Task<IActionResult> ThemYeuThichSanPham(string maSanPham, string maKhachHang)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var obj = new SanPhamYeuThich()
                    {
                        MaKhachHang = maKhachHang,
                        MaSanPham = maSanPham,
                        TrangThai = true
                    };
                    var result = await _yeuThichSanPhamServices.ThemYeuThich(obj);
                    if (!result)
                    {
                       return BadRequest(Messages.API_Failed);
                    }
                    else
                    {
                        return Ok(Messages.API_Success);
                    }


                }
                return BadRequest(Messages.API_Failed);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        [HttpGet("lay-sanpham-yeuthich/{MaKH}")]
        public async Task<IActionResult> laySanPhamYeuThich(string MaKH)
        {
            try
            {
              
                var result = await _yeuThichSanPhamServices.laySanPhamYeuThich(MaKH);
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
