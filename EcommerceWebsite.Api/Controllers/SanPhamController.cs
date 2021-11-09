using AutoMapper;
using EcommerceWebsite.Application.Constants;
using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Services.Interfaces.Main;
using EcommerceWebsite.Utilities.Input;
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
    public class SanPhamController : ControllerBase
    {
        private readonly ISanPhamServices _sanPhamServices;
        private readonly IMapper _mapper;
        private readonly IBangGiaServices _bangGiaServices;
        public SanPhamController(ISanPhamServices sanPhamServices, IMapper mapper)
        {
            _sanPhamServices = sanPhamServices;
            _mapper = mapper;
        }
        [HttpGet("lay-sanpham")]
        public async Task<IActionResult> LaySanPhams()
        {
            try
            {
                var result = await _sanPhamServices.LaySanPham();
                if (result == null)
                    return BadRequest(Messages.API_EmptyResult);
                else return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.API_Exception + ex);
            }
        }

        [HttpPost("them-san-pham")]
        public async Task<IActionResult> ThemSanPham (SanPhamInput input)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var existObj = _sanPhamServices.GetSanPhamTheoMa(input.MaSanPham, input.TenSanPham);
                    if (existObj == null)
                        return BadRequest(Messages.API_Exist);
                    var obj = _mapper.Map<SanPham>(input);

                    //add
                    var result = await _sanPhamServices.ThemSanPham(obj);
                    if (result)
                    {
                        //them gia 
                        var newGia = new LichSuGia()
                        {
                            DaXoa = false,
                            NgayTao =  DateTime.UtcNow,
                            GiaMoi = input.GiaBan,
                            MaSanPham = input.MaSanPham,
                            NguoiTao = input.NguoiTao
                        };
                        var resultGia = await _bangGiaServices.ThemGia(newGia);
                        if(resultGia)
                        {
                            return Ok(Messages.API_Success);
                        }    
                        else return BadRequest(Messages.API_Failed);
                    }
                    else return BadRequest(Messages.API_Failed);
                }
                else return BadRequest(Messages.API_Failed);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
