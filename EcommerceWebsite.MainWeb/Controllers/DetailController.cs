using EcommerceWebsite.Api.Interface;
using EcommerceWebsite.Application.Constants;
using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Data.Identity;
using EcommerceWebsite.Utilities.Input;
using EcommerceWebsite.Utilities.Output.System;
using EcommerceWebsite.Utilities.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EcommerceWebsite.MainWeb.Controllers
{
    [Route("/ChiTiet")]
    public class DetailController : BackgroudController
    {
        private readonly ISanPhamApiServices _sanPhamServices;
        private readonly IBinhLuanApiService _binhLuanApiService;
        //private readonly IKhachHangApiServices _khachHangServices;
        private readonly IHUIApiServices _huiServices;
        //private readonly UserManager<ApplicationUser> _userManager;

        public DetailController(ISanPhamApiServices sanPhamServices,
            IKhachHangApiServices khachHangServices,
            IHUIApiServices huiServices,
            IBinhLuanApiService binhLuanApiService, IConfiguration configuration) : base(khachHangServices, configuration)
        {
            _sanPhamServices = sanPhamServices;
            //_khachHangServices = khachHangServices;
            _huiServices = huiServices;
            _binhLuanApiService = binhLuanApiService;
        }

        [HttpGet("Detail")]
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
            if (User.Claims != null && User.Claims.Count() > 1)
            {
                var user = new KhachHangOutput()
                {
                    Email = User.Claims.Where(claim => claim.Type == ClaimTypes.Email)
                                       .FirstOrDefault()
                                       .Value,
                    TenKhachHang = User.Claims.Where(claim => claim.Type == ClaimTypes.Name)
                                       .FirstOrDefault()
                                       .Value
                };
                vm.KhachHang = user;
            }
            return View("Views/Detail/Index.cshtml",vm);
        }

        [HttpPost("post-cmt")]
        public async Task<IActionResult> ThemBinhLuanAsync(BinhLuanInput input)
        {
            try
            {
                if (!string.IsNullOrEmpty(input.Email) || !string.IsNullOrEmpty(input.MatKhau))
                {
                    var obj = new ThongTinKhachHangInput
                    {
                        Email = input.Email,
                        MatKhau = input.MatKhau
                    };
                    var rs = (JsonResult)await this.Index(obj, "Detail");
                    if (!rs.Value.ToString().Contains(Messages.Login_Success))
                    {
                        return Json(new { status = false });
                    }
                    //return rs.Value.ToString().Contains(Messages.Login_Success) ?
                    //    Json(new { status = true }) : 
                }

                var userId = User.Claims.Where(claim => claim.Type == ClaimTypes.Sid)
                                          .FirstOrDefault()
                                          .Value;
                BinhLuan bt = new BinhLuan();
                bt.MaSanPham = input.MaSanPham;
                bt.NguoiTao = userId;
                bt.NoiDung = input.NoiDung;
                bt.SoSao = input.SoSao;
                var them = _binhLuanApiService.ThemBinhLuan(bt);
                return them.Result? Json(new { status = true }) 
                    :  Json(new { code = 2, msg = "Lỗi rồi" });
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
