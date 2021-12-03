using AutoMapper;
using EcommerceWebsite.Application.Constants;
using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Services.Interfaces.Main;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.Api.Controllers
{
    public class YeuThichSanPhamController : Controller
    {
        private readonly IYeuThichSanPhamServices _yeuThichSanPhamServices;
        private readonly IMapper _mapper;
        public YeuThichSanPhamController(IYeuThichSanPhamServices yeuThichSanPhamServices, IMapper mapper)
        {
            _yeuThichSanPhamServices = yeuThichSanPhamServices;
            _mapper = mapper;
        }
        [HttpPost("them-sanphamyeuthich")]
        public async Task<IActionResult> ThemYeuThichSanPham(SanPhamYeuThich input)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var existObj = _yeuThichSanPhamServices.LaySPYeuThich(input.MaSanPham, input.MaKhachHang);
                    if (existObj != null)
                        return BadRequest(Messages.API_Exist);
                    var result = await _yeuThichSanPhamServices.ThemYeuThich(input);
                    if(result)
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
    }
}
