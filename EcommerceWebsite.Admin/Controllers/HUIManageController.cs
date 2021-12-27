﻿using EcommerceWebsite.Api.Interface;
using EcommerceWebsite.Utilities.Output.Main;
using EcommerceWebsite.Utilities.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceWebsite.Services.Interfaces.ExtraServices;
using EcommerceWebsite.Utilities.Output.System;
using EcommerceWebsite.Data.Entities;

namespace EcommerceWebsite.Admin.Controllers
{
    public class HUIManageController : Controller
    {
        private readonly IHUIApiServices _huiApiServices;

        public HUIManageController(IHUIApiServices huiApiServices)
        {
            _huiApiServices = huiApiServices;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var vm = new HUIManageVM();
            vm.ListHuiVaDoanhSo = await _huiApiServices.GetListHUIFromData();
            return View("/Views/HUIManage/Index.cshtml",vm);
        }
       
        public async Task<IActionResult> NhapNewHUI()
        {
            // doc hui

            var fileName = "output1";
            var huiReadRs = await _huiApiServices.GetListHUIFromOutput(fileName);

            if(huiReadRs != null && huiReadRs.Count() > 0)
            {
                var addResult = await _huiApiServices.AddListHui(huiReadRs);
                if (addResult)
                    return await IndexAsync();
            }
            //HttpContext.Session.Set<List<HUI>>("ListImportHUI", huiReadRs);
            return await IndexAsync();
        }
        
        public async Task<IActionResult> XuatNewData()
        {
            // doc data
            var result = await _huiApiServices.GetListHUIForInput();
            if (result != null)
            {
                //prepare data 
                var lines = new string[result.Sum(r => r.ChiTietHoaDons.Count())];
                return await IndexAsync();
            }
                
            //HttpContext.Session.Set<List<HUI>>("ListImportHUI", huiReadRs);
            return await IndexAsync();
        }

        public List<DoanhThuOutput> SetUpGiaChoHUIItemset(List<DoanhThuOutput> listSanPhamHUI, int mucLoiNhuan)
        {
            //tinh tong gia nhap moi nhat
            var tongGiaNhap = listSanPhamHUI.Sum(hui => hui.DonGiaNhap);
            var tongGiaHui = tongGiaNhap * (tongGiaNhap * (mucLoiNhuan / 100));
            foreach (var hui in listSanPhamHUI)
            {
                // tinh thi phan cua moi san pham so voi tong nhanh chung
                hui.LoiNhuan = (float)(hui.DonGiaNhap / tongGiaNhap);
                hui.GiaHUI = (decimal)((float)tongGiaHui * hui.LoiNhuan);
            }
            return listSanPhamHUI;
        }

    }
}
