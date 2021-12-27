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
        private readonly IPhieuNhapServices _phieuNhapServices;
        private readonly IHoaDonServices _hoaDonServices;
        public SanPhamController(ISanPhamServices sanPhamServices, IMapper mapper, IBangGiaServices bangGiaServices, IDinhLuongServices dinhLuongServices, IBinhLuanServices binhLuanServices, IPhieuNhapServices phieuNhapServices, IHoaDonServices hoaDonServices)
        {
            _sanPhamServices = sanPhamServices;
            _mapper = mapper;
            _bangGiaServices = bangGiaServices;
            _dinhLuongServices = dinhLuongServices;
            _binhLuanServices = binhLuanServices;
            _phieuNhapServices = phieuNhapServices;
            _hoaDonServices = hoaDonServices;
        }
        [HttpGet("lay-sanpham")]
        public async Task<IActionResult> LaySanPhams()
        {
            try
            {
                var update = await _hoaDonServices.CapNhatLoiNhuanChoSanPham();
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
        [HttpGet("lay-sanphamyt/{maKH}")]
        public async Task<IActionResult> LaySanPhamYTKH(string maKH)
        {
            try
            {
                var result = await _sanPhamServices.LaySPYeuThichKH(maKH);
                if (result == null)
                    return BadRequest(Messages.API_EmptyResult);
                else return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.API_Exception + ex);
            }
        }
        [HttpGet("lay-PhieuNhap")]
        public async Task<IActionResult> layPhieuNhapSanPham()
        {
            try
            {
                var result = await _sanPhamServices.LayPhieuNhapSanPham();
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
        public async Task<string> ThemSanPham(SanPhamOutput input, string creatorId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //var existObj = _sanPhamServices.GetSanPhamTheoMa(input.MaSanPham, input.TenSanPham);
                    //if (existObj != null)
                    //    return BadRequest(Messages.API_Exist);
                    var obj = _mapper.Map<SanPham>(input);
                    //obj.MaSanPham = Guid.NewGuid().ToString();
                    obj.NguoiTao = creatorId;
                    //add
                    var result = await _sanPhamServices.ThemSanPham(obj);
                    if (result != null)
                    {
                        //dinh luong
                        var listDinhLuong = input.ListThongSo
                            .Select(item => new DinhLuong (item.MaDinhLuong) { 
                                DonVi = item.DonVi,
                                GiaTri = item.GiaTri?? "https://i.ibb.co/jzN4xyb/Blue-with-Gold-Laurel-Education-Logo-9-1-removebg-preview.png",
                                MaSanPham = result,
                                MaThuocTinh = item.MaThuocTinh,
                        }).ToList();

                        if (listDinhLuong != null && listDinhLuong.Count > 0)
                        {
                            var rsDl = await _dinhLuongServices.AddRangeAsync(listDinhLuong);
                            if (rsDl != null && rsDl.Count() > 0)
                            {
                                //gia ban
                                var listGiaBan = input.BangGia
                                .Select(item => new BangGiaSanPham
                                {
                                    MaDinhLuong = rsDl[0],
                                    GiaMoi = item.GiaBan,
                                    DaXoa = false,
                                    NgayTao = DateTime.Now,
                                    NguoiTao = creatorId
                                }).ToList();

                                if (listGiaBan != null && listGiaBan.Count > 0)
                                {
                                    var rdGB = await _bangGiaServices.ThemBangGia(listGiaBan);
                                    if(rdGB)
                                        return result;
                                }
                            }
                        }
                    }
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("them-phieu-nhap")]
        public async Task<IActionResult> ThemPhieuNhap(PhieuNhapInput input)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int isError = 0;
                    var listProduct = input.ListSanPhamInput;
                    //them phieu nhap
                    //prepare data 
                    var newInventory = new PhieuNhap()
                    {
                        MaNhanVien = input.CreatorId,
                        TongTien = decimal.Parse(input.Totalvalue),
                        MaNhaCungCap = input.Investor,
                    };
                    //them pn
                    var rsInputInventory = await _phieuNhapServices
                        .CreateNewInventoryVoucher(newInventory);
                    if(rsInputInventory)
                    {
                       
                        //them sp
                        foreach (var sp in listProduct)
                        {
                            var rsExec = await ThemSanPham(sp, input.CreatorId);
                            if (string.IsNullOrEmpty(rsExec))
                            {
                                isError++;
                                continue;
                            }else
                            {
                                //them chi tiet nhap
                                var ctpn = _mapper.Map<ChiTietNhapSanPham>(sp);
                                ctpn.DonGia = sp.BangGia[0].GiaBan;
                                ctpn.MaNhap = newInventory.MaPhieuNhap;
                                ctpn.MaSanPham = rsExec;
                                var rsCtn = await _phieuNhapServices.CreateNewInventoryVoucherDetail(ctpn);
                                isError = rsCtn ? isError : isError++;
                            }    
                        }
                    }    
                    if (isError > 0)
                        return BadRequest(Messages.API_CointainError);
                    else
                        return Ok();
                }
                return BadRequest(Messages.API_EmptyInput);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        [HttpPut("sua-san-pham/{laXoa}")]
        public async Task<IActionResult> SuaHoacXoaSanPham(SanPhamOutput input, bool laXoa)
        {
            if (ModelState.IsValid)
            {
                var ErrorList = new List<string>();
                var obj = _mapper.Map<SanPham>(input);
                if (obj != null)
                {
                    var rs = await _sanPhamServices.SuaHoacXoaSanPham(obj, laXoa, input.NguoiTao);
                    if (rs)
                    {
                        // sua dinh luong
                        var newListObj = input.ListThongSo;
                        foreach (var dl in newListObj)
                        {
                            var newDl = new DinhLuong(dl.MaDinhLuong)
                            {
                                MaThuocTinh = dl.MaThuocTinh,
                                DonVi = dl.DonVi,
                                GiaTri = dl.GiaTri,
                                MaSanPham = input.MaSanPham
                            };
                            var rsDl = await _dinhLuongServices.UpdateAsync(newDl);
                            if (!rsDl)
                            {
                                ErrorList.Add("Lỗi chỉnh sửa thông số " + dl.ThuocTinh);
                            }    
                        }
                        return Ok(ErrorList);
                    }
                    else ErrorList.Add("Lỗi chỉnh sửa sản phẩm "+ input.MaSanPham);
                }
                return BadRequest(ErrorList);
            }
            return BadRequest(Messages.API_Failed);
        }
        
       
        [HttpGet("{maDinhLuong}/{editor}/{newPrice}")]
        public async Task<IActionResult> ModifyPrice(string maDinhLuong, string editor, decimal newPrice)
        {
            if (string.IsNullOrEmpty(maDinhLuong) || newPrice < 0)
                return BadRequest(Messages.API_EmptyInput);

            var dl = await _dinhLuongServices.LayDinhLuongTheoSanPham(maDinhLuong);
            if(dl != null)
            {
                var obj = new BangGiaSanPham()
                {
                    //MaSanPham = productId,
                    MaDinhLuong = dl.MaDinhLuong,
                    GiaMoi = newPrice,
                    NguoiTao = editor,
                    NgayTao = DateTime.Now
                };
                var prdExist = await _bangGiaServices.ThemGia(obj);
                if (prdExist)
                    return Ok(Messages.API_Success);
                return BadRequest(Messages.API_Failed);
            }
            return BadRequest(Messages.API_Failed);
        }

        [HttpGet("ChiTiet/{productId}")]
        public async Task<IActionResult> LayChiTietSanPham(string productId)
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
                //lay so Luong Ton 
                var soLuongTon = (await _phieuNhapServices.GetListImportProduct(productId)).LastOrDefault();
                obj.SoLuongTon = soLuongTon.SoLuongTon;
                var listThongSo = await _dinhLuongServices.LayThongSoTheoSanPham(productId) ?? null;
                obj.ListHinhAnh = listThongSo.Where(ts => ts.MaThuocTinh == (nameof(ProductPorpertyCode.TT014))).ToList();
                obj.ListThongSo = listThongSo.Where(ts => ts.MaThuocTinh != (nameof(ProductPorpertyCode.TT014))
                || ts.MaThuocTinh != (nameof(ProductPorpertyCode.TT07))).ToList();
                obj.BangGia = await _bangGiaServices.LayBangGiaSanPham(productId);
                obj.ListBinhLuan = await _binhLuanServices.LayBinhLuanTheoSanPham(productId);
                return Ok(obj);
            }
        }

        [HttpGet("Views/{productId}/{maKH}")]
        public async Task<IActionResult> GetViewProduct(string productId, string maKH)
        {
            if (String.IsNullOrEmpty(productId))
                return BadRequest(Messages.API_EmptyInput);
            else
            {
                // lay san pham
                var listObj = await _sanPhamServices.LaySanPhamTheoLoai(1, null, productId, maKH);
                if (listObj == null)
                    return BadRequest(Messages.API_EmptyResult);
                return Ok(listObj.FirstOrDefault());
            }
        }
        [HttpGet("lay-sanpham-theohang/{prdId}")]
        public async Task<IActionResult> LaySanPhamTheoHang(string prdId)
        {
            try
            {
                var result = await _sanPhamServices.laySanPhamTheoHang(prdId);
                if (result == null)
                    return BadRequest(Messages.API_EmptyResult);
                else return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.API_Exception + ex);
            }
        }
        [HttpGet("lay-sanpham-theodanhmuc/{prdId}/{maKH}")]
        public async Task<IActionResult> laySanPhamTheoDanhMuc(string prdId, string maKH)
        {
            try
            {
                var result = await _sanPhamServices.laySanPhamTheoDanhMuc(prdId, maKH);
                if (result == null)
                    return BadRequest(Messages.API_EmptyResult);
                else return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.API_Exception + ex);
            }
        }
        [HttpGet("lay-sanpham-theoten/{keyword}")]
        public async Task<IActionResult> timKiemSanPhamTheoTen(string keyword)
        {
            try
            {
                var result = await _sanPhamServices.timKiemSanPhamTheoTen(keyword);
                if (result == null)
                    return BadRequest(Messages.API_EmptyResult);
                else return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.API_Exception + ex);
            }
        }
        [HttpGet("lay-sanpham-Ma/{keyword}")]
        public async Task<IActionResult> LaySanPhamTheoMa(string keyword)
        {
            try
            {
                var result = await _sanPhamServices.LayChiTietSanPham(keyword);
                if (result == null)
                    return null;
                else return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.API_Exception + ex);
            }
        }

        [HttpGet("get-mulpitple-id")]
        public async Task<IActionResult> GetProductWithMultipleId(string comboCode, [FromQuery] string[] productIds)
        {
            if (productIds == null || productIds.Length == 0)
                return BadRequest(Messages.API_EmptyInput);
            else
            {
                // lay san pham
                var listObj = await _sanPhamServices.GetProductWithMultipleId(productIds, comboCode);
                if (listObj == null)
                    return BadRequest(Messages.API_EmptyResult);
                return Ok(listObj);
            }
        }
        [HttpGet("lay-sanphammoinhat/{maKH}")]
        public async Task<IActionResult> LaySanPhamMoiNhat(string maKH)
        {
            try
            {
                var result = await _sanPhamServices.LaySanPhamMoiNhat(maKH);
                if (result == null)
                    return BadRequest(Messages.API_EmptyResult);
                else return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.API_Exception + ex);
            }
        }
        [HttpGet("lay-soluongnhap-va-ban/{maSanPham}")]
        public async Task<IActionResult> LaySoLuongNhapVaBan(string maSanPham)
        {
            try
            {
                var danhSachNhap = await _phieuNhapServices.GetListImportProduct(maSanPham);
                if(danhSachNhap != null && danhSachNhap.Count() > 0)
                {
                    return Ok(danhSachNhap);
                }
                else return BadRequest(Messages.API_EmptyResult);
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.API_Exception + ex);
            }
        }
        [HttpGet("lay-theodinhluong")]
        public async Task<IActionResult> LayThongSo()
        {
            try
            {
                var result = await _dinhLuongServices.LayThongSo();
                if (result == null)
                    return BadRequest(Messages.API_EmptyResult);
                else return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.API_Exception + ex);
            }
        }
        [HttpPost("them-thuocTinh")]
        public async Task<IActionResult> ThemVaSuaHang(NhanHieu thuocTinh)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    
                    var result = await _dinhLuongServices.ThemVaSuaHang(thuocTinh);
                    if (!result)
                    {
                        return BadRequest(Messages.API_Failed);
                    }
                    else
                    {
                        return Ok(Messages.API_Success);
                    }


                }
                return BadRequest(Messages.API_Failed);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("xoa-hang/{maHang}")]
        public async Task<IActionResult> XoaHang(string maHang)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var result = await _dinhLuongServices.XoaHang(maHang);
                    if (!result)
                    {
                        return BadRequest(Messages.API_Failed);
                    }
                    else
                    {
                        return Ok(Messages.API_Success);
                    }


                }
                return BadRequest(Messages.API_Failed);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("them-dinhluongsanpham")]
        public async Task<IActionResult> ThemDinhLuongSanPham(DinhLuong input)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   
                    var result = await _sanPhamServices.ThemDinhLuongSanPham(input);
                    if (!result)
                    {
                        return BadRequest(Messages.API_Failed);
                    }
                    else
                    {
                        return Ok(Messages.API_Success);
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
