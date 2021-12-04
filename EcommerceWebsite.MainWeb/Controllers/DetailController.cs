using EcommerceWebsite.Api.Interface;
using EcommerceWebsite.Data.Identity;
using EcommerceWebsite.Utilities.Output.System;
using EcommerceWebsite.Utilities.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.MainWeb.Controllers
{
    public class DetailController : Controller
    {
        private readonly ISanPhamApiServices _sanPhamServices;
        private readonly IKhachHangApiServices _khachHangServices;
        private readonly IHUIApiServices _huiServices;
        //private readonly UserManager<ApplicationUser> _userManager;

        public DetailController(ISanPhamApiServices sanPhamServices, IKhachHangApiServices khachHangServices, IHUIApiServices huiServices)
        {
            _sanPhamServices = sanPhamServices;
            _khachHangServices = khachHangServices;
            _huiServices = huiServices;
        }

        public async Task<IActionResult> IndexAsync(string prdId,string prdMaDanhMuc)
        {
            var vm = new DetailVM();
            vm.SanPham = await _sanPhamServices.LayChiTietSanPham(prdId);
            //if (User != null)
            //{
            //    string id = _userManager.GetUserId(User);
            //    vm.KhachHang = await _khachHangServices.GetKhachHangTheoMa(id);
            //}
            var lstHUI = HUIConfiguration.ListHUI.Where(hui => hui.Itemsets.Length > 1)
                    .OrderByDescending(hui => hui.Utility).ToList();
            lstHUI??= await _huiServices.GetListHUIFromOutput("output1");

            foreach(var hui in lstHUI)
            {
                var itemSet = hui.Itemsets;
                if (itemSet.Contains(prdId))
                {
                    itemSet = itemSet.Where(i => i != prdId).ToArray();
                    vm.HUIItems = await _sanPhamServices.GetViewWithMultipleIds(itemSet);
                    break;
                }
            }
            vm.SanPhamOutPut = await _sanPhamServices.laySanPhamTheoDanhMuc(prdMaDanhMuc);
            return View("Views/Detail/Index.cshtml",vm);
        }
    }
}
