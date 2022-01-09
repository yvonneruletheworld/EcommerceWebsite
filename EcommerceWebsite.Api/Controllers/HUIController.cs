using EcommerceWebsite.Application.Constants;
using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Services.Interfaces.Main;
using EcommerceWebsite.Services.Interfaces.System;
using EcommerceWebsite.Utilities.Output.Main;
using EcommerceWebsite.Utilities.Output.System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HUIController : ControllerBase
    {
        private readonly IHUIServices _huiServices;
        private readonly ISanPhamServices _sanPhamServices;
        private readonly IHoaDonServices _hoaDonServices;
        private readonly IPhieuNhapServices _phieuNhapServices;

        public HUIController(IHUIServices huiServices, ISanPhamServices sanPhamServices, IHoaDonServices hoaDonServices, IPhieuNhapServices phieuNhapServices)
        {
            _huiServices = huiServices;
            _sanPhamServices = sanPhamServices;
            _hoaDonServices = hoaDonServices;
            _phieuNhapServices = phieuNhapServices;
        }

        [AllowAnonymous]
        [HttpGet("get-list-hui/{fileName}")]
        public  IActionResult GetListHUI (string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) return BadRequest(Messages.API_EmptyInput);

            var _path = $"D:\\Applications\\eclipse-workspace\\java.huiminer_190921\\{fileName}.txt";
            var result =  _huiServices.ReadFromTextToList(_path);
            if (result == null)
                return BadRequest(Messages.API_EmptyResult);
            else return Ok(result);
        }
        
        [AllowAnonymous]
        [HttpGet("get-all-list-hui")]
        public async Task<IActionResult> GetAllListHUIAsync (string maSanPham)
        {
            //var updateCode = await _huiServices.UpdateHUIItemsetCode();
            var update = await _hoaDonServices.CapNhatLoiNhuanChoSanPham();
            var hUICosts = await  _huiServices.GetHUICosts();
            if(hUICosts != null || hUICosts.Count() != 0)
            {
                 return Ok(hUICosts);
            }
            return BadRequest(null);
            
        }
        
        [HttpPost("add-list-hui/{ngayDau}/{ngayCuoi}")]
        public async Task<IActionResult> AddListHUI (string ngayDau, string ngayCuoi, List<HUI> inputs)
        {
            if(inputs != null || inputs.Count() != 0)
            {
                var minutil = inputs.Where(i => i.Id == "minuntil").FirstOrDefault().Utility;
                inputs = inputs.Where(i => i.Id != "minuntil").ToList();
                //var hoaDons = await _hoaDonServices.DanhSachHoaDonExport(ngayDau, ngayCuoi);
                var sanPhams = await _sanPhamServices.LayListSanPham();
                //Tinh U

                //var dicHoaDon = hoaDons.GroupBy(ct => ct.HoaDons.NgayTao)
                //   .ToDictionary(ct => ct.Key, ct => ct.ToList());
                //var lines = new List<HoaDon>();
                //foreach (var hd in dicHoaDon)
                //{
                //    var line = new List<ChiTietHoaDon>();
                    
                //    var chiTiets = hd.Value;
                //    int TU = 0;
                //    foreach (var ct in chiTiets)
                //    {
                //        TU += (int)ct.SanPhams.Utility * ct.SoLuong;
                //    }
                //    var newHd = new HoaDon() {
                //        TongCong = TU,
                //        ChiTietHoaDons = line
                //    };
                //    lines.Add(newHd);
                //}


                var datetime = DateTime.Now;
                var listHuiCostContainPrdId = new List<HUICost>();
                foreach (var input in inputs)
                {
                   var listHui = await _sanPhamServices.GetProductWithMultipleId(input.Itemsets);
                    //Count so luong ban cua cac san pham trong tat ca chi tiet
                    var averageUtil = listHui.Average(item => item.Utility);
                    foreach (var sp in listHui)
                    {
                        //countCt += sanPhams.Where(spt => spt.NguoiXoa == sp.MaSanPham).FirstOrDefault().Utility;
                        //if(listHui.IndexOf(sp) == listHui.Count() - 1)
                        //{
                            var newInput = new HUICost();
                            newInput.ComboCode = input.Id;
                            newInput.Cost = 0;
                            newInput.MaSanPham = sp.MaSanPham;
                            newInput.DaXoa = false;
                            newInput.Utility = input.Utility > 100? (int)((int)input.Utility / averageUtil) : (int)input.Utility;
                        //newInput.NgayTao = DateTime.Parse("2021-12-06 22:37:58.0019324");
                        newInput.NgayTao = datetime;
                        newInput.NguoiTao = minutil.ToString();
                        newInput.Status = true;
                            listHuiCostContainPrdId.Add(newInput);
                        //}
                    }
                }
                var rs = await _huiServices.ThemHUICosts(listHuiCostContainPrdId);
                if (rs)
                    return Ok();
                else return BadRequest();
            }
            return BadRequest();
            
        }
        [HttpGet("get-hui-detail/{comboCode}/{ngayTao}/{ngayNhapKe}")]
        public async Task<IActionResult> GetHuiDetail (string comboCode, string ngayTao, string ngayNhapKe)
        {
            var convertCreate = DateTime.Parse(ngayTao);
            var convertImport = DateTime.Parse(ngayNhapKe);
            var rs = await _huiServices.GetChiTietHUI(comboCode, convertCreate, convertImport);
            if (rs != null)
                return Ok(rs);
            else return BadRequest(Messages.API_EmptyResult);
        }
        [HttpGet("get-hui-export-list/{ngayDau}/{ngayCuoi}")]
        public async Task<IActionResult> GetHuiExport (string ngayDau, string ngayCuoi)
        {
            try
            {
                var rs = await _hoaDonServices.DanhSachHoaDonExport(ngayDau, ngayCuoi);
                if (rs != null)
                {
                    return Ok(rs);
                }
                else return BadRequest(Messages.API_Exception);
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.API_Exception + ex);
            }
        }
        [HttpGet("update-ngay-tao/{ngaySua}")]
        public async Task<IActionResult> UpdateNgayTao (string ngaysua )
        {
            try
            {
                DateTime dateConvert = DateTime.Parse(ngaysua);
                var rs = await _huiServices.UpdateHUIItemsetCode(dateConvert);
                if (rs)
                {
                    return Ok(true);
                }
                else return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(false);
            }
        }
        [HttpGet("sua-gia-hui/{maHUI}/{giaMoi}/{comboCode}/{ngayTao}")]
        public async Task<IActionResult> SuaGiaHui(string maHUI, decimal giaMoi, string comboCode, string ngayTao)
        {
            if (ModelState.IsValid)
            {
                var convertDate = DateTime.Parse(ngayTao);
                var rs = await _huiServices.SuaGiaHUI(maHUI, giaMoi, comboCode,convertDate);
                if (rs)
                {
                    return Ok(true);
                }
                return BadRequest(false);
            }
            return BadRequest(false);
        }

    }
}
