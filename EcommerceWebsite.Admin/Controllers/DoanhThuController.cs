using EcommerceWebsite.Api.Interface;
using EcommerceWebsite.Utilities.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
               
                vm.ListSanPhamNhapVaBan = await _sanPhamApiServices.LaySoLuongNhapVaBan(maSanPham);
                ViewBag.GiaNhapGanNhat = vm.ListSanPhamNhapVaBan?[0].DonGiaNhap;
                vm.ListDinhLuong = await _sanPhamApiServices.layDinhluong();
                vm.ListDanhMuc = await _danhMucApiServices.GetCategories();
                vm.ListNhanHieu = await _nhanHieuApiServices.layNhanHieus();
                return View(vm);
            }
            // lay so luong ban va nhap 
            return   View();
        }

    }
}
