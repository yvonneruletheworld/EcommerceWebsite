using EcommerceWebsite.Api.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EcommerceWebsite.WebApp.Controllers.Main
{
    public class CuaHangController : Controller { 
        private readonly ISanPhamApiServices _sanPhamApiServices;
        private readonly INhanHieuApiServices _nhanHieuApiServices;
        private readonly IDanhMucApiServices _danhMucApiServices;
        public CuaHangController(ISanPhamApiServices sanPhamApiServices, INhanHieuApiServices nhanHieuApiServices, IDanhMucApiServices danhMucApiServices)
        {
            _sanPhamApiServices = sanPhamApiServices;
            _nhanHieuApiServices = nhanHieuApiServices;
            _danhMucApiServices = danhMucApiServices;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("get-data-allsanpham")]
        public async Task<IActionResult> LayAllSanPham()
        {
            try
            {
                if (User.Claims != null && User.Claims.Count() > 1)
                {
                    var userId = User.Claims.Where(claim => claim.Type == ClaimTypes.Sid)
                                          .FirstOrDefault()
                                          .Value;

                    var data = await _sanPhamApiServices.LaySPYeuThichKH(userId);
                    return PartialView("/Views/CuaHang/_ListAllSanPham.cshtml", data);
                }
                else
                {
                    var data = await _sanPhamApiServices.laySanPham2();
                    return PartialView("/Views/CuaHang/_ListAllSanPham.cshtml", data);
                }    
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("get-data-nhanhieuSP")]
        public async Task<IActionResult> layHangSanPham()
        {
            try
            {
                var data = await _nhanHieuApiServices.layNhanHieus();
                return PartialView("/Views/CuaHang/_ListNhanHieuSanPham.cshtml", data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("get-data-laySanPhamMoiNhat")]
        public async Task<IActionResult> laySanPhamMoiNhat()
        {
            try
            {
                var data = await _sanPhamApiServices.LaySanPhamMoiNhat();
                return PartialView("/Views/CuaHang/_ListAllSanPham.cshtml", data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("list-danh-muc-CH")]
        public async Task<IActionResult> LayDanhMucSanPham()
        {
            try
            {
                var data = await _danhMucApiServices.GetCategories();
                return PartialView("/Views/CuaHang/_ListdanhMucSP.cshtml", data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("get-data-sanpham-theohang/{prdId}")]
        public async Task<IActionResult> LaySanPhamTheoHang(string prdId)
        {
            try
            {
                var data = await _sanPhamApiServices.laySanPhamTheoHang(prdId);
                return PartialView("/Views/CuaHang/_ListSanPhamTheoHang.cshtml", data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("get-data-sanpham-loai/{prdId}")]
        public async Task<IActionResult> LaySanPhamTheoDanhMuc(string prdId)
        {
            try
            {
                var data = await _sanPhamApiServices.laySanPhamTheoDanhMuc(prdId);
                return PartialView("/Views/CuaHang/_ListSanPhamTheoHang.cshtml", data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
