using AutoMapper;
using EcommerceWebsite.Api.Interface;
using EcommerceWebsite.MainWeb.Models;
using EcommerceWebsite.Utilities.Output.Main;
using EcommerceWebsite.Utilities.Output.System;
using EcommerceWebsite.Utilities.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.MainWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDanhMucApiServices _danhMucServices;
        private readonly IKhuyenMaiApiServices _khuyenMaiServices;
        private readonly IHUIApiServices _huiServices;
        private readonly ISanPhamApiServices _sanPhamServices;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IDanhMucApiServices danhMucServices, IKhuyenMaiApiServices khuyenMaiServices, IHUIApiServices huiServices, ISanPhamApiServices sanPhamServices, IMapper mapper)
        {
            _logger = logger;
            _danhMucServices = danhMucServices;
            _khuyenMaiServices = khuyenMaiServices;
            _huiServices = huiServices;
            _sanPhamServices = sanPhamServices;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            //get HUI

            var fileName = "output1";
            var listHUI = await _huiServices.GetListHUIFromOutput(fileName);
            
            var vm = new HomeVM();
            vm.DanhMucOutputs = await _danhMucServices.GetCategories();
            vm.BannerOutputs = await _khuyenMaiServices.LaykhuyenMais();
            vm.LoaiVaSanPham = await _danhMucServices.GetDanhMucVaSanPhams(5);
            var lstHuiDon = (listHUI.Where(h => h.Itemsets.Count() == 1).ToList());
            vm.SanPhamHUIDons = await GetSanPhamTheoHUIDonAsync(lstHuiDon);

            return View("~/Views/Home/Index.cshtml", vm);
        }

        private async Task<List<SanPhamVM>> GetSanPhamTheoHUIDonAsync(List<HUI> lstHuiDon)
        {
            var rs = new List<SanPhamVM>();
            foreach(var hui in lstHuiDon)
            {
                var data = await _sanPhamServices.LayViewSanPham(hui.Itemsets[0].Trim());
                var prd = _mapper.Map<SanPhamVM>(data);
                rs.Add(prd);
            }
            return rs;
        }
    }
}
