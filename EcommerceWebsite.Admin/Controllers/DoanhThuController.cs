using EcommerceWebsite.Api.Interface;
using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Utilities.Output.Main;
using EcommerceWebsite.Utilities.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EcommerceWebsite.Admin.Controllers
{
    public class DoanhThuController : Controller
    {
        private readonly ISanPhamApiServices _sanPhamApiServices;
        private readonly IDanhMucApiServices _danhMucApiServices;
        private readonly INhanHieuApiServices _nhanHieuApiServices;

        public DoanhThuController(ISanPhamApiServices sanPhamApiServices, IDanhMucApiServices danhMucApiServices, INhanHieuApiServices nhanHieuApiServices)
        {
            _sanPhamApiServices = sanPhamApiServices;
            _danhMucApiServices = danhMucApiServices;
            _nhanHieuApiServices = nhanHieuApiServices;
        }

        public async Task<IActionResult> IndexAsync(string maSanPham)
        {
            if(!string.IsNullOrEmpty(maSanPham))
            {
                var vm = new DoanhThuVM();
                vm.SanPham = await _sanPhamApiServices.LayChiTietSanPham(maSanPham);
                vm.SanPham.giaBan = vm.SanPham.BangGia
                    .OrderByDescending(bg => bg.NgayTao.Date)
                    .ThenByDescending(bg => bg.NgayTao.TimeOfDay)
                    .FirstOrDefault().GiaBan;
                vm.ListSanPhamNhapVaBan = await _sanPhamApiServices.LaySoLuongNhapVaBan(maSanPham);
                vm.ListDinhLuong = await _sanPhamApiServices.layDinhluong();
                vm.ListDanhMuc = await _danhMucApiServices.GetCategories();
                vm.ListNhanHieu = await _nhanHieuApiServices.layNhanHieus();
                return View(vm);
            }
            // lay so luong ban va nhap 
            return   View();
        }

        
        [HttpPost("cap-nhat-san-pham")]
        public async Task<IActionResult> CapNhatSanPham(SanPhamOutput input)
        {
            if(ModelState.IsValid)
            {
                var rsUpdateGiaErr = 0;
                var userId = "";
               var rsUpdateSanPham = await _sanPhamApiServices.SuaSanPham(false, input);
                if(input.ThanhTien != 0)
                {
                    if (User.Claims != null && User.Claims.Count() > 1)
                    {
                        userId = User.Claims.Where(claim => claim.Type == ClaimTypes.Sid)
                            .FirstOrDefault().Value;
                    }
                    var rs = await _sanPhamApiServices.CapNhatGia(input.MaSanPham, userId, input.ThanhTien);
                    if (!rs) rsUpdateGiaErr++;
                }
                
                if(rsUpdateSanPham.Count() == 0 && rsUpdateGiaErr == 0)
                {
                    return RedirectToAction("Index", "DoanhThu");
                }
            }
            // lay so luong ban va nhap 
            return RedirectToAction("Index", "DoanhThu");
        }
        public async Task<IActionResult> ThemDinhLuongSanPham(string maThuocTinh, string maSanPham, string giaTri, string DonVi)
        {
            try
            {
                DinhLuong spyt = new DinhLuong(null);
                spyt.MaThuocTinh = maThuocTinh;
                spyt.MaSanPham = maSanPham;
                spyt.GiaTri = giaTri;
                spyt.DonVi = DonVi;
                var them = _sanPhamApiServices.ThemDinhLuongSanPham(spyt);
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
