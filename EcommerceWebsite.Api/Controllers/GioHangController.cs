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
    public class GioHangController : ControllerBase
    {
        private readonly IGioHangServices _gioHangServices;
        private readonly IKhuyenMaiServices khuyenMai;
        public GioHangController(IGioHangServices gioHangServices, IKhuyenMaiServices khuye)
        {
            _gioHangServices = gioHangServices;
            khuyenMai = khuye;
        }
        [HttpPost("them-hoadon/{maHD}/{maKH}/{maKM}/{maDC}/{pthucThanhToan}/{tongCong}/{thanhTien}/{phiShip}")]
        public async Task<IActionResult> ThemHoaDon(string maHD,string maKH, string maKM, string maDC, string pthucThanhToan, decimal tongCong, decimal thanhTien, decimal phiShip)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var obj = new HoaDon()
                    {
                        MaHoaDon = maHD,
                        MaKhachHang = maKH,
                        TongCong = tongCong,
                        MaKhuyenMai = maKM,
                        MaDiaChi = maDC,
                        ThanhTien = thanhTien,
                        TinhTrang = "Đang xử lý",
                        PhiGiaoHang = phiShip,
                        PhuongThucThanhToan = pthucThanhToan,
                        DaXoa = false,
                        NgayTao = DateTime.UtcNow,

                    };
                    var result = await _gioHangServices.ThemHoaDon(obj);
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
        [HttpPost("them-hoadonkkm/{maHD}/{maKH}/{maDC}/{pthucThanhToan}/{tongCong}/{thanhTien}/{phiShip}")]
        public async Task<IActionResult> ThemHoaDonKhongKM(string maHD, string maKH, string maDC, string pthucThanhToan, decimal tongCong, decimal thanhTien, decimal phiShip)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var obj = new HoaDon()
                    {
                        MaHoaDon = maHD,
                        MaKhachHang = maKH,
                        TongCong = tongCong,
                        MaDiaChi = maDC,
                        ThanhTien = thanhTien,
                        TinhTrang = "Đang xử lý",
                        PhiGiaoHang = phiShip,
                        PhuongThucThanhToan = pthucThanhToan,
                        DaXoa = false,
                        NgayTao = DateTime.UtcNow,

                    };
                    var result = await _gioHangServices.ThemHoaDon(obj);
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
        [HttpPost("them-cthoadon/{maHD}/{maSP}/{soLuong}/{giaBan}")]
        public async Task<IActionResult> ThemCTHoaDon(string maHD, string maSP, int soLuong, decimal giaBan)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var obj = new ChiTietHoaDon()
                    {
                        HoaDonId = maHD,
                        ProductId = maSP,
                        SoLuong = soLuong,
                        GiaBan = giaBan,

                    };
                    var result = await _gioHangServices.ThemChiTietHoaDon(obj);
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
        [HttpGet("lay-donhangdaduyet")]
        public async Task<IActionResult> layDonHangDaDuyet()
        {
            try
            {
                var result = await _gioHangServices.LayDonHangDaDuyet();
                if (result == null)
                    return BadRequest(Messages.API_EmptyResult);
                else return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.API_Exception + ex);
            }
        }
        [HttpGet("lay-sanPhamduyetdon")]
        public async Task<IActionResult> LayDonHangDangDuyet()
        {
            try
            {
                var result = await _gioHangServices.LayDonHangDangDuyet();
                if (result == null)
                    return BadRequest(Messages.API_EmptyResult);
                else return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.API_Exception + ex);
            }
        }
        [HttpGet("duyetdonhang/{MaDH}")]
        public async Task<IActionResult> DuyetDonHang(string MaDH)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _gioHangServices.DuyetDonHang(MaDH);
                    if (result)
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
