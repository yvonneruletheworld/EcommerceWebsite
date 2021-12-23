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

        public DoanhThuController(ISanPhamApiServices sanPhamApiServices, IDanhMucApiServices danhMucApiServices)
        {
            _sanPhamApiServices = sanPhamApiServices;
            _danhMucApiServices = danhMucApiServices;
        }

        public async Task<IActionResult> IndexAsync(string maSanPham)
        {
            // lay so luong ban va nhap 
            var vm = new DoanhThuVM();
           // vm.ListSanPhamNhapVaBan = await _sanPhamApiServices.LaySoLuongNhapVaBan(maSanPham);
          //  vm.ListDinhLuong = await _sanPhamApiServices.layDinhluong();
            vm.ListDanhMuc = await _danhMucApiServices.GetCategories();
            return View(vm);
        }

    }
}
