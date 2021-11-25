using EcommerceWebsite.Api.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
                var data = await _sanPhamApiServices.laySanPham2();
                return PartialView("/Views/CuaHang/_ListAllSanPham.cshtml", data);
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
                var data = await _sanPhamApiServices.laySanPhamTheoHang("MH01");
                return PartialView("/Views/CuaHang/_ListSanPhamTheoHang.cshtml", data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
