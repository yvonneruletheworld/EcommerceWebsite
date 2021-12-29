using AutoMapper;
using EcommerceWebsite.Application.Constants;
using EcommerceWebsite.Data.EF;
using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Services.Interfaces.Main;
using EcommerceWebsite.Services.Interfaces.System;
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
        private readonly IKhachHangServices _khachHangServices;
        private readonly ISanPhamServices _sanPhamServices;
        private readonly IHoaDonServices _hoaDonServices;
        private readonly IPhieuNhapServices _phieuNhapServices;

        public YeuThichSanPhamController(IYeuThichSanPhamServices yeuThichSanPhamServices, IKhachHangServices khachHangServices, ISanPhamServices sanPhamServices, IHoaDonServices hoaDonServices, IPhieuNhapServices phieuNhapServices)
        {
            _yeuThichSanPhamServices = yeuThichSanPhamServices;
            _khachHangServices = khachHangServices;
            _sanPhamServices = sanPhamServices;
            _hoaDonServices = hoaDonServices;
            _phieuNhapServices = phieuNhapServices;
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
        [HttpGet("load-trang-chu")]
        public async Task<IActionResult> LoadTrangChu()
        {
            try
            {
                var result = new List<decimal>();
                var tkh = await _khachHangServices.CountKhachHang() + 0.0m;
                var tsp = await _sanPhamServices.CountSanPham() + 0.0m;
                var listHd = await _hoaDonServices.LayTongBan();
                var dicHd = listHd.GroupBy(ct => ct.HoaDonId).ToDictionary(ct => ct.Key, ct => ct.ToList());
                var tban = listHd.Sum(ct => ct.SoLuong * ct.GiaBan);
                var slb = dicHd.Keys.Count() + 0.0m;
                var tnhap = await _phieuNhapServices.LayTongNhap() + 0.0m;
                result.AddRange(new decimal[] { tkh, tsp, tban, slb, tnhap });
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
