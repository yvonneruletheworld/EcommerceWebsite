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
        
        [HttpPost("add-list-hui")]
        public async Task<IActionResult> AddListHUI (List<HUI> inputs)
        {
            if(inputs != null || inputs.Count() != 0)
            {
                // convert data
                var datetime = DateTime.Now;
                var listHuiCostContainPrdId = new List<HUICost>();
                foreach (var input in inputs)
                {
                   var listHui = await _sanPhamServices.GetProductWithMultipleId(input.Itemsets);
                    listHui.ForEach(h => {
                        h.ComboCode = input.Id;
                        h.Cost = 0;
                        h.DaXoa = false;
                        h.Utility = (int)input.Utility;
                        h.NgayTao = datetime;
                        h.Status = true;
                    });
                    listHuiCostContainPrdId.AddRange(listHui);
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
        [HttpGet("get-hui-export-list")]
        public async Task<IActionResult> GetHuiExport ()
        {
            try
            {
                var data = await _sanPhamServices.LayListSanPham();
                var result = new List<DoanhThuOutput>();
                foreach(var sp in data)
                {
                    var danhSachNhap = await _phieuNhapServices.GetListImportProduct(sp.MaSanPham);
                    if (danhSachNhap != null && danhSachNhap.Count() > 0)
                    {
                        danhSachNhap.LastOrDefault().MaSanPham = sp.NguoiXoa;
                        result.Add(danhSachNhap.LastOrDefault());
                    }
                    else continue;
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.API_Exception + ex);
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
