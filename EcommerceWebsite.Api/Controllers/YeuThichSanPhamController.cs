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
        [HttpPost("them-san-pham-yeu-thich/{maSanPham}/{maKhachHang}")]
        public async Task<IActionResult> ThemYeuThichSanPham(string maSanPham, string maKhachHang)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var existObj = _yeuThichSanPhamServices.LaySPYeuThich(maSanPham, maKhachHang);
                    if (existObj != null)
                        return BadRequest(Messages.API_Exist);
                    var obj = new SanPhamYeuThich()
                    {
                        MaKhachHang = maKhachHang,
                        MaSanPham = maSanPham,
                        TrangThai = true
                    };
                    var result = await _yeuThichSanPhamServices.ThemYeuThich(obj);
                    if(result)
                        return Ok(Messages.API_Success);
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
