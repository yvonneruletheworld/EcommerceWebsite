using AutoMapper;
using EcommerceWebsite.Application.Constants;
using EcommerceWebsite.Application.Pagination;
using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Data.Enum;
using EcommerceWebsite.Services.Interfaces.Main;
using EcommerceWebsite.Utilities.Input;
using EcommerceWebsite.Utilities.Output.Main;
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
        private readonly IDinhLuongServices _dinhLuongServices;
        private readonly IBinhLuanServices _binhLuanServices;
        public SanPhamController(ISanPhamServices sanPhamServices, IMapper mapper, IBangGiaServices bangGiaServices, IDinhLuongServices dinhLuongServices, IBinhLuanServices binhLuanServices)
        {
            _sanPhamServices = sanPhamServices;
            _mapper = mapper;
            _bangGiaServices = bangGiaServices;
            _dinhLuongServices = dinhLuongServices;
            _binhLuanServices = binhLuanServices;
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
        public async Task<IActionResult> ThemSanPham (SanPhamOutput input)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var existObj = _sanPhamServices.GetSanPhamTheoMa(input.MaSanPham, input.TenSanPham);
                    if (existObj != null)
                        return BadRequest(Messages.API_Exist);
                    var obj = _mapper.Map<SanPham>(input);

                    //add
                    var result = await _sanPhamServices.ThemSanPham(obj);
                    if (result)
                    {
                        //dinh luong
                        var listDinhLuong = input.ListThongSo
                            .Select(item => new DinhLuong () { 
                                DonVi = item.DonVi,
                                GiaTri = item.GiaTri,
                                MaSanPham = obj.MaSanPham,
                                MaThuocTinh = item.MaThuocTinh,
                        }).ToList();

                        if (listDinhLuong != null && listDinhLuong.Count > 0)
                        {
                            var rsDl = await _dinhLuongServices.AddRangeAsync(listDinhLuong);
                            if (rsDl)
                            {
                                //gia ban
                                var listGiaBan = input.BangGia
                                .Select(item => new LichSuGia
                                {
                                    MaDinhLuong = item.MaDinhLuong,
                                    GiaMoi = item.GiaBan,
                                    DaXoa = false,
                                    NgayTao = DateTime.Now,
                                }).ToList();

                                if (listGiaBan != null && listGiaBan.Count > 0)
                                {
                                    var rdGB = await _bangGiaServices.ThemBangGia(listGiaBan);
                                    if(rdGB)
                                        return Ok(Messages.API_Success);
                                }
                            }
                        }
                    }
                }
                return BadRequest(Messages.API_Failed);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("sua-san-pham/{laXoa}")]
        public async Task<IActionResult> SuaHoacXoaSanPham (SanPhamOutput input, bool laXoa)
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
                //MaSanPham = productId,
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

        [HttpGet("ChiTiet/{productId}")]
        public async Task<IActionResult> LayChiTietSanPham (string productId)
        {
            if (String.IsNullOrEmpty(productId))
                return BadRequest(Messages.API_EmptyInput);
            else
            {
                // lay san pham
                var obj = await _sanPhamServices.LayChiTietSanPham(productId);
                if (obj == null)
                    return BadRequest(Messages.API_EmptyResult);
                // list Hinh anh, Thong so, Gia, Danh gia
                var listThongSo = await _dinhLuongServices.LayThongSoTheoSanPham(productId) ?? null;
                obj.ListHinhAnh = listThongSo.Where(ts => ts.MaThuocTinh == (nameof(ProductPorpertyCode.TT014))).ToList();
                obj.ListThongSo = listThongSo.Where(ts => ts.MaThuocTinh != (nameof(ProductPorpertyCode.TT014))
                || ts.MaThuocTinh != (nameof(ProductPorpertyCode.TT07))).ToList();
                obj.BangGia = await _bangGiaServices.LayBangGiaSanPham(productId);
                obj.ListBinhLuan = await _binhLuanServices.LayBinhLuanTheoSanPham(productId);
                return Ok(obj); 
            }    
        }
        
        [HttpGet("Views/{productId}")]
        public async Task<IActionResult> GetViewProduct (string productId)
        {
            if (String.IsNullOrEmpty(productId))
                return BadRequest(Messages.API_EmptyInput);
            else
            {
                // lay san pham
                var listObj = await _sanPhamServices.LaySanPhamTheoLoai(1, null, productId);
                if (listObj == null )
                    return BadRequest(Messages.API_EmptyResult);
                return Ok(listObj.FirstOrDefault()); 
            }    
        }
        
        [HttpGet("get-mulpitple-id")]
        public async Task<IActionResult> GetProductWithMultipleId ([FromQuery] string[] productIds)
        {
            if (productIds == null || productIds.Length == 0)
                return BadRequest(Messages.API_EmptyInput);
            else
            {
                // lay san pham
                var listObj = await _sanPhamServices.GetProductWithMultipleId(productIds);
                if (listObj == null )
                    return BadRequest(Messages.API_EmptyResult);
                return Ok(listObj); 
            }    
        }
    }
}
