using EcommerceWebsite.Api.Interface;
using EcommerceWebsite.Application.Pagination;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.WebApp.Controllers.Main
{
    public class HomeController : Controller
    {
        private readonly IHUIApiServices _huiApiServices;
        private readonly IDanhMucApiServices _danhMucApiServices;
        private readonly ISanPhamApiServices _sanPhamApiServices;
        private readonly IKhuyenMaiApiServices _khuyenMaiApiServices;
        private readonly INhanHieuApiServices _nhanHieuApiServices;

        public HomeController(IHUIApiServices huiApiServices, IDanhMucApiServices danhMucApiServices,
            ISanPhamApiServices sanPhamApiServices, IKhuyenMaiApiServices khuyenMaiApiServices,
            INhanHieuApiServices nhanHieuApiServices)
        {
            _huiApiServices = huiApiServices;
            _danhMucApiServices = danhMucApiServices;
            _sanPhamApiServices = sanPhamApiServices;
            _khuyenMaiApiServices = khuyenMaiApiServices;
            _nhanHieuApiServices = nhanHieuApiServices;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var fileName = "output1";
            var listHUI = await _huiApiServices.GetListHUIFromOutput(fileName);
            var data = await _khuyenMaiApiServices.laykhuyenMais();
            return View("~/Views/Home/Index.cshtml", data);
        }
        public IActionResult CuaHangAsync()
        {
            return View();
        }
        [HttpGet("list-danh-muc")]
        public async Task<IActionResult> layDanhMucSanPham ()
        {
            try
            {
                var data = await _danhMucApiServices.layDanhMuc();
                return PartialView("/Views/Home/_ListDanhMucSanPham.cshtml", data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("get-data-sanpham")]
        public async Task<IActionResult> LayDanhSachSanPhamAsync()
        {
            try
            {
                var data = await _sanPhamApiServices.laySanPham2();
                return PartialView("/Views/Home/_ListSanPham.cshtml", data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("get-data-khuyenmai")]
        public async Task<IActionResult> layKhuyenMai()
        {
            try
            {
                var data = await _khuyenMaiApiServices.laykhuyenMais();
                //return Json(new
                //{
                //    datalist = (from a in data select new { a.MaKhuyenMai, a.TenKhuyenMai, a.PhanTram, a.HinhAnh }).ToList(),
                //    status = true
                //});
               return PartialView("/Views/Home/_ListKhuyenMai.cshtml", data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("get-data-allsanpham")]
        public async Task<IActionResult> LayAllSanPham()
        {
            try
            {
                var data = await _sanPhamApiServices.laySanPham2();
                return PartialView("/Views/Home/_ListAllSanPham.cshtml", data);
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
                return PartialView("/Views/Home/_ListNhanHieuSanPham.cshtml", data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
