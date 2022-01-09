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
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

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
        public const string SessionSoLuongYT = "_SoLuong";
        private readonly IYeuThichSanPhamApiServices _yeuThichSanPhamApiServices;

        public HomeController(ILogger<HomeController> logger, IDanhMucApiServices danhMucServices, IKhuyenMaiApiServices khuyenMaiServices, IHUIApiServices huiServices,
            ISanPhamApiServices sanPhamServices, IMapper mapper, IYeuThichSanPhamApiServices yeuThichSanPhamApiServices)
        {
            _logger = logger;
            _danhMucServices = danhMucServices;
            _khuyenMaiServices = khuyenMaiServices;
            _huiServices = huiServices;
            _sanPhamServices = sanPhamServices;
            _mapper = mapper;
            _yeuThichSanPhamApiServices = yeuThichSanPhamApiServices;
            GioHangOutput.HUICart??= new Dictionary<string, List<GioHang>>();
            GioHangOutput.NormalCart??= new List<GioHang>();
        }

        public async Task<IActionResult> Index()
        {
            //get HUI
            var vm = new HomeVM();
            var danhMucHienThi = await _danhMucServices.GetCategories();
            vm.DanhMucOutputs = danhMucHienThi.Where(dm =>dm.HienThiTrangHome == true).ToList() ;
            vm.BannerOutputs = await _khuyenMaiServices.LaykhuyenMais();
            var userId = "null";
            if (User.Claims != null && User.Claims.Count() > 1)
            {
                 userId = User.Claims.Where(claim => claim.Type == ClaimTypes.Sid)
                                         .FirstOrDefault()
                                         .Value;
                var data = await _yeuThichSanPhamApiServices.laySanPhamYeuThich(userId);
                HttpContext.Session.SetString(SessionSoLuongYT, data.Count() + "");
            }
            else
            {
                HttpContext.Session.SetString(SessionSoLuongYT, 0 + "");
            }    
          
            vm.LoaiVaSanPham = await _danhMucServices.GetDanhMucVaSanPhams(5, userId);
            if (HUIConfiguration.ListHUI == null)
            {
                var fileName = "output1";
                var result = await _huiServices.GetListHUIFromOutput(fileName);
                HUIConfiguration.ListHUI = result.Where(h => h.Id != "minuntil").ToList();
                //save constant
                //HUIConfiguration.ListHUI = listHUI.Where(hui => hui.Itemsets.Length > 1)
                //    .OrderByDescending(hui => hui.Utility).ToList();
            }
            var lstHuiDon = (HUIConfiguration.ListHUI.Where(h => h.Itemsets.Count() == 1).ToList());
            vm.SanPhamHUIDons = await GetSanPhamTheoHUIDonAsync(lstHuiDon);
            return View("~/Views/Home/Index.cshtml", vm);
        }


        public Task<Dictionary<string, List<string>>> ModifyListOutput(List<HUI> inputList)
        {
            // sort asc
            inputList = inputList.OrderByDescending(hui => hui.Utility).ToList();

            //get item
            var listItem = new List<string>();
            foreach (var hui in inputList)
            {
                listItem = ReadListHUI(hui.Itemsets, listItem).ToList();
            }
            return null;
        }

        private IEnumerable<string> ReadListHUI(string[] itemSet, List<string> listItem)
        {
            foreach (var ip in itemSet)
            {
                if (!listItem.Contains(ip))
                {
                    yield return ip;
                }
            }
        }
        private async Task<List<SanPhamVM>> GetSanPhamTheoHUIDonAsync(List<HUI> lstHuiDon)
        {
            var rs = new List<SanPhamVM>();
            foreach(var hui in lstHuiDon)
            {
                var userId = "null";
                if (User.Claims != null && User.Claims.Count() > 1)
                {
                    userId = User.Claims.Where(claim => claim.Type == ClaimTypes.Sid)
                                            .FirstOrDefault()
                                            .Value;
                }
                 var data = await _sanPhamServices.LayViewSanPham(hui.Itemsets[0].Trim(), userId, hui.Id);
                var prd = _mapper.Map<SanPhamVM>(data);
                rs.Add(prd);
            }
            return rs;
        }

        [HttpGet]
        public async Task<IActionResult> layDanhMuc()
        {
            try
            {
                List<DanhMucOutput> data = new List<DanhMucOutput>();
                 data = await _danhMucServices.GetCategories();
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IActionResult> TimKiemSanPham(string keyword)
        {
            try
            {
                if(string.IsNullOrEmpty(keyword))
                {
                    keyword = "";
                }
                    ViewBag.timKiem = keyword;
                    var data = await _sanPhamServices.timKiemSanPhamTheoTen(keyword);
                    return View("~/Views/Home/TimKiem.cshtml", data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        
        }
    }
}
