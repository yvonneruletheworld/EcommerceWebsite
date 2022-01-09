using EcommerceWebsite.Api.Interface;
using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Utilities.Output.Main;
using EcommerceWebsite.Utilities.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.Admin.Controllers
{
    public class HUIDetailController : Controller
    {
        private readonly IHUIApiServices _huiServices;

        public HUIDetailController(IHUIApiServices huiServices)
        {
            _huiServices = huiServices;
        }

        public async Task<IActionResult> IndexAsync(string comboCode, DateTime ngayTao, DateTime ngayNhapKe)
        {
            var vm = await _huiServices.GetHuiDetail(comboCode, ngayTao,ngayNhapKe);
            //vm.
            var giaVon = vm.ListSanPhamHUIs.Sum(sp => sp.DonGiaNhap);
            ViewBag.GiaVon = giaVon;
            ViewBag.NgayTao = ngayTao;
            // tính tổng tiền của combo dựa vào HUI của itemset 
            var tongGiaAuto = ((double)giaVon + ((double)giaVon * (double)(vm.Utility * 0.01)));
            vm.TongGiaAuto = tongGiaAuto;

            //set up gia mặc định cho từng sản phẩm
            return View(vm);
        }
        
        [HttpPost("update-gia")]
        public async Task<IActionResult> UpdateGia(string comboCode , string ngayTao , [FromBody]List<DoanhThuOutput> inputs)
        {
            var error = 0;
            foreach(var gm in inputs)
            {
                var rs = await _huiServices.SuaGiaHui(gm.MaSanPham, gm.GiaHUI, comboCode, ngayTao);
                error = rs ? error : error++;
            }
            return error == 0? Json(new { code = 200 }) : Json(new { code = 500 });
        }
    }
}
