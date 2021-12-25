using EcommerceWebsite.Application.Constants;
using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Services.Interfaces.System;
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

        public HUIController(IHUIServices huiServices)
        {
            _huiServices = huiServices;
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
        public async Task<IActionResult> GetAllListHUIAsync ()
        {
            var hUICosts = await  _huiServices.GetHUICosts();
            if(hUICosts != null || hUICosts.Count() != 0)
            {
                 return Ok(hUICosts);
            }
            return BadRequest(null);
            
        }
        
        [HttpGet("add-list-hui")]
        public async Task<IActionResult> AddListHUI (List<HUICost> inputs)
        {
            if(inputs != null || inputs.Count() != 0)
            {
                var rs = await _huiServices.ThemHUICosts(inputs);
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
    }
}
