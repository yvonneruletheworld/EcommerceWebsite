﻿using AutoMapper;
using EcommerceWebsite.Application.Constants;
using EcommerceWebsite.Application.Pagination;
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

        [HttpPut("sua-san-pham/{laXoa}")]
        public async Task<IActionResult> SuaHoacXoaSanPham (SanPhamInput input, bool laXoa)
        {
            if(ModelState.IsValid)
            {
                var obj = _mapper.Map<SanPham>(input);
                if (obj != null)
                {
                    var rs = await _sanPhamServices.SuaHoacXoaSanPham(obj, laXoa, input.NguoiTao);
                    if (rs)
                        return Ok(Messages.API_Success);
                    return BadRequest(Messages.API_EmptyResult);
                }
                return BadRequest(Messages.API_EmptyInput);
            }
            return BadRequest(Messages.API_Failed);
        }

        [HttpPatch("{productId}/{editor}/{newPrice}")]
        public async Task<IActionResult> ModifyPrice (string productId, string editor, decimal newPrice)
        {
            if (string.IsNullOrEmpty(productId) || newPrice < 0)
                return BadRequest(Messages.API_EmptyInput);

            var obj = new LichSuGia()
            {
                MaSanPham = productId,
                GiaMoi = newPrice,
                NguoiTao = editor
            };
            var prdExist = await _sanPhamServices.GetSanPhamTheoMa(productId, null);
            if (prdExist == null)
                return BadRequest(Messages.API_EmptyInput);
            var rs = await _bangGiaServices.ModifyPrice(obj);
            if (rs)
                return Ok(Messages.API_Success);
            return BadRequest(Messages.API_Failed);
        }
    }
}
