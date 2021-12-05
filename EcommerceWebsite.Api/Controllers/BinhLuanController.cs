using EcommerceWebsite.Application.Constants;
using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Services.Interfaces.Main;
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
    public class BinhLuanController : ControllerBase
    {
        private readonly IBinhLuanServices _binhLuanServices;
        public BinhLuanController(IBinhLuanServices binhLuanServices)
        {
            _binhLuanServices = binhLuanServices;
        }
        [HttpPost("them-binhluan/{maSanPham}/{maKH}/{noiDung}/{soSao}")]
        public async Task<IActionResult> ThemBinhLuan(string maSanPham, string maKH, string noiDung, int soSao)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var obj = new BinhLuan()
                    {
                        MaSanPham = maSanPham,
                        NoiDung = noiDung,
                        SoSao = soSao,
                        NgayTao = DateTime.UtcNow,
                        NguoiTao = maKH,
                        DaXoa = false,
                    };  
                    var result = await _binhLuanServices.ThemBinhLuan(obj);
                    if (result)
                    {
                        return Ok(Messages.API_Success);
                     
                    }
                    else
                    {
                        return BadRequest(Messages.API_Failed);
                    }


                }
                return BadRequest(Messages.API_Failed);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
