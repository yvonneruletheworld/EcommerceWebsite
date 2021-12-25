using EcommerceWebsite.Api.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EcommerceWebsite.Data.Entities;

namespace EcommerceWebsite.Admin.Controllers
{
    public class SanPhamController : Controller
    {
        private readonly ISanPhamApiServices _sanPhamApiServices;
        private readonly IDanhMucApiServices _danhMucApiServices;
        private readonly INhanHieuApiServices _nhanHieuApiServices;
        public SanPhamController(ISanPhamApiServices sanPhamApiServices, IDanhMucApiServices danhMucApiServices, INhanHieuApiServices nhanHieuApiServices)
        {
            _sanPhamApiServices = sanPhamApiServices;
            _danhMucApiServices = danhMucApiServices;
            _nhanHieuApiServices = nhanHieuApiServices;
        }
        public async Task<IActionResult> DanhSachSanPhamAsync()
        {
            var data = await _sanPhamApiServices.laySanPham2();
            return View(data);
        }
        public async Task<IActionResult> QuanLyDanhMuc()
        {
            var data = await _danhMucApiServices.GetCategories();
            return View(data);
        }
        public async Task<IActionResult> QuanLyNhanHieu()
        {
            var data = await _nhanHieuApiServices.layNhanHieus();
            return View(data);
        }
        public async Task<IActionResult> ThemVaSuaHang(string tenThuocTinh, string maHieuHang)
        {
            try
            {
                
                    NhanHieu spyt = new NhanHieu();
                    if(maHieuHang != null)
                    {
                        spyt.MaHang = maHieuHang;
                    }    
                    spyt.TenHang = tenThuocTinh;
                    var them = _sanPhamApiServices.ThemVaSuaHang(spyt);
                    if (them.Result)// thêm thành công
                    {
                        return Json(new
                        {
                            status = true
                        });
                    }
                    else//Đã thêm
                    {
                        return Json(new
                        {
                            code = 2,
                            msg = "Lỗi rồi",
                        });
                    }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    code = 500,
                    msg = "Lỗi rồi" + ex.Message
                });
            }
        }
        public async Task<IActionResult> XoaHangSanPham( string maHieuHang)
        {
            try
            {

                var them = _sanPhamApiServices.XoaHang(maHieuHang);
                if (them.Result)// thêm thành công
                {
                    return Json(new
                    {
                        status = true
                    });
                }
                else//Đã thêm
                {
                    return Json(new
                    {
                        code = 2,
                        msg = "Lỗi rồi",
                    });
                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    code = 500,
                    msg = "Lỗi rồi" + ex.Message
                });
            }
        }

    }
}
