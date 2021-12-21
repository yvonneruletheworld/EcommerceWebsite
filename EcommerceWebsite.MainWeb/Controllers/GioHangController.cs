using EcommerceWebsite.Api.Interface;
using EcommerceWebsite.Application.Constants;
using EcommerceWebsite.Data.EF;
using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.MainWeb.Models;
using EcommerceWebsite.Services.Interfaces.ExtraServices;
using EcommerceWebsite.Utilities.Email;
using EcommerceWebsite.Utilities.Input;
using EcommerceWebsite.Utilities.Output.Main;
using EcommerceWebsite.Utilities.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EcommerceWebsite.WebApp.Controllers.Main
{
    public class GioHangController : Controller
    {
        private readonly ISanPhamApiServices _sanPhamApiServices;
        private readonly IGioHangApiServices _gioHangApiServices;
        private readonly IKhachHangApiServices _khachHangApiServices;
        private readonly IKhuyenMaiApiServices _khuyenMaiApiServices;

        public GioHangController(ISanPhamApiServices sanPhamApiService, IKhachHangApiServices khachHangApiServices, IGioHangApiServices gioHangApiServices, IKhuyenMaiApiServices khuyenMaiApiServices)
        {
            _sanPhamApiServices = sanPhamApiService;
            _khachHangApiServices = khachHangApiServices;
            _gioHangApiServices = gioHangApiServices;
            _khuyenMaiApiServices = khuyenMaiApiServices;
        }

        
        public IActionResult Index()
        {
            if (User.Claims != null && User.Claims.Count() > 1)
            {
                var userEmail = User.Claims.Where(claim => claim.Type == ClaimTypes.Email)
                                         .FirstOrDefault()
                                         .Value;
                ViewBag.Email = userEmail;
            }
            return View("/Views/GioHang/Index.cshtml");
        }
        [HttpGet("get-data-giohang")]
        public IActionResult layGioHang()
        {
            try
            {
                var data = GioHangOutput.CountCart();
                if(data == 0)
                {
                    return Json(new
                    {
                        code = 500,
                        Message = "Giỏ hàng trống"
                    });
                }    
                return PartialView("/Views/GioHang/_ListGioHang.cshtml");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("get-data-minigiohang")]
        public IActionResult MinigioHang()
        {
            try
            {
                var data = GioHangOutput.CountCart();
                if (data == 0)
                {
                    return Json(new
                    {
                        code = 500,
                        Message = "Giỏ hàng trống"
                    });
                }
                return PartialView("/Views/Home/_MiniCart.cshtml", data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("get-data-diachikhachhang")]
        public async Task<IActionResult> layDiaChiKhachHang()
        {
            try
            {
                if (User.Claims != null && User.Claims.Count() > 1)
                {
                    var userId = User.Claims.Where(claim => claim.Type == ClaimTypes.Sid)
                                             .FirstOrDefault()
                                             .Value;
                    var data = await _khachHangApiServices.layDiaChiKhachHang(userId);
                    return PartialView("/Views/GioHang/_ListDiaChiKhachHang.cshtml", data);
                }
                else
                {
                    return Json(new
                    {
                        code = 500,
                        Message = "Vui lòng đăng nhập"
                    });
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("get-data-khuyenmaigiohang")]
        public async Task<IActionResult> layKhuyenMai()
        {
            try
            {
                var data = await _khuyenMaiApiServices.layKhuyenMai();
                return PartialView("/Views/GioHang/_ListKhuyenMai.cshtml", data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("get-data-chitietkhuyenmai/{maKM}")]
        public async Task<IActionResult> layChiTietKhuyenMai(string maKM)
        {
            try
            {
                var data = await _khuyenMaiApiServices.layChiTietKhuyenMai(maKM);
                return PartialView("/Views/GioHang/_ListChiTietKhuyenMai.cshtml", data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("get-data-thanhtoan")]
        public async Task<IActionResult> ThanhToanGioHangAsync()
        {
            try
            {
                if (User.Claims != null && User.Claims.Count() > 1)
                {
                    var userId = User.Claims.Where(claim => claim.Type == ClaimTypes.Sid)
                                             .FirstOrDefault()
                                             .Value;
                    var data = GioHangOutput.NormalCart;
                    var KH = await _khachHangApiServices.layDiaChiKhachHang(userId);
                    if (KH.Count != 0)
                    {
                        HttpContext.Session.SetString("HotenKH", KH[0].Hoten);
                        HttpContext.Session.SetString("SDTKH", KH[0].SDT);
                        HttpContext.Session.SetString("DiaChiKH", KH[0].DiaChi);
                        HttpContext.Session.SetString("MaDiaChiKH", KH[0].MaDiaChi);

                    }
                    return PartialView("/Views/GioHang/_ListThanhToan.cshtml", data);
                }
                else
                {
                    return Json(new
                    {
                        code = 500,
                        Message = "Vui lòng đăng nhập"
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        //Thêm
        public IActionResult AddGioHang(string id, int soLuong, decimal giaSP, string type = "Normal")
        {
            var item = GioHangOutput.NormalCart.SingleOrDefault(p => p.MaSanPham == id);

            if (item == null)//chưa có
            {
                var data = _sanPhamApiServices.laySanPhamTheoMa(id);////lấy sản phaair dưới data
                SanPhamVM sp = data.Result;
                item = new GioHang
                {
                    MaSanPham = id,
                    tenSanPham = sp.TenSanPham,
                    giaSanPham = sp.GiaBan,
                    soLuong = soLuong,
                    hinhAnh = sp.HinhAnh,
                    giaBan = giaSP
                };
                GioHangOutput.AddNormal(item);
            }
            else
            {
                item.soLuong += soLuong;
            }

            if (type == "ajax")
            {
                return Json(new
                {
                    slGH = GioHangOutput.CountCart(),
                    slTien = GioHangOutput.Cash()

                });
            }
            return RedirectToAction("Index", "GioHang");
        }


        //xóa giỏ hàng
        public ActionResult XoaGioHang(string id, string comboCode = null)
        {
            if (GioHangOutput.CountCart() == 0)
                return RedirectToAction("index", "Home");
            else
            {
                GioHangOutput.XoaGioHang(id, comboCode);
                return Json(new
                {
                    slGH = GioHangOutput.CountCart(),
                    Message = "Thành công"
                });
            }    
        }

        //updat giỏ hàng
        public ActionResult suaGioHang(string id,string comboCode = null, bool isAdd = true)
        {
            if (GioHangOutput.CountCart() == 0)
                return RedirectToAction("index", "Home");
            else if(isAdd)
            {
               return GioHangOutput.ThemMot(id, comboCode)?
                Json(new { code = 200, Message = "Thành công", slGH = GioHangOutput.CountCart() })
                : Json(new { code = 500, Message = "Lỗi", slGH = GioHangOutput.CountCart() });
            }else
            {
                return GioHangOutput.XoaMot(id, comboCode) ?
                                Json(new { code = 200, Message = "Thành công", slGH = GioHangOutput.CountCart() })
                                : Json(new { code = 500, Message = "Lỗi", slGH = GioHangOutput.CountCart() });
            }
        }

        [HttpGet("send-otp")]
        public async Task<JsonResult> SendOTPAsync()
        {
            var userId = User.Claims.Where(claim => claim.Type == ClaimTypes.Sid)
                                             .FirstOrDefault()
                                             .Value;
            //gen otp
            var otpCode = Randoms.RandomString().ToUpper();
            //TempData["OTPCode"] = otpCode;
            var updateOtpCode = await _khachHangApiServices.UpdateOTP(userId, otpCode ??= "OTCODENULL");
            if (updateOtpCode)
            {
                var mailAddress = User.Claims.Where(claim => claim.Type == ClaimTypes.Email)
                                             .FirstOrDefault()
                                             .Value;
                var sendMailResult = await _khachHangApiServices.SendMail(mailAddress, otpCode);
                return sendMailResult ? Json(otpCode) : Json(Messages.OTP_SentFailed);
            }
            return Json(Messages.OTP_Invalid);
        }
       
        public IActionResult ThemDiaChiKhachHang(string sDT, string hoTen, string diachi)
        {
            try
            {

                if (User.Claims != null && User.Claims.Count() > 1)
                {
                    var userId = User.Claims.Where(claim => claim.Type == ClaimTypes.Sid)
                                          .FirstOrDefault()
                                          .Value;
                    DiaChiKhachHang hd = new DiaChiKhachHang();
                    hd.MaKhachHang = userId;
                    hd.SDT = sDT;
                    hd.Hoten = hoTen;
                    hd.DiaChi = diachi;
                    var them = _khachHangApiServices.ThemDiaChiKhachHang(hd);
                    if (them.Result)// thêm thành công
                    {

                        return Json(new
                        {
                            status = true
                        });
                    }
                    else
                    {
                        return Json(new
                        {

                            code = 2,
                            msg = "Lỗi rồi",
                        });
                    }

                }
                else// chưa đăng nhập
                {
                    return Json(new
                    {
                        code = 1,
                        msg = "Lỗi rồi",
                    });
                }
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
        /// <summary>
        /// Ý tưởng chung: Nhận vào HoaDonInput có chứa danh sách những mặt hàng bthuong và  hang HUI muốn thanh toán. 
        /// Tìm trong GioHangOutPut lọc ra những mặt hàng có mã giống rồi tạo hóa đơn
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //Tiến hành thanh toán
        [HttpPost("thanh-toan")]
        public async Task<IActionResult> ThanhToanAsync(HoaDonInput input)
        {
            try
            {
                if (User.Claims != null && User.Claims.Count() > 1)
                {
                    var userId = User.Claims.Where(claim => claim.Type == ClaimTypes.Sid)
                                          .FirstOrDefault()
                                          .Value;
                    HoaDon hd = new HoaDon();
                    hd.MaKhachHang = userId;
                    hd.MaDiaChi = input.MaDiaChi;
                    hd.PhuongThucThanhToan = input.PhuongThucThanhToan;
                    hd.TongCong = input.TongTien;
                    hd.ThanhTien = input.ThanhTien;
                    hd.PhiGiaoHang = input.Ship;
                    hd.MaKhuyenMai = input.MaKhuyenMai;
                    var them = string.IsNullOrEmpty(input.MaKhuyenMai)?
                        await _gioHangApiServices.ThemHoaDon(hd)
                        : await _gioHangApiServices.ThemHoaDonKhongKM(hd); ;
                    string maHoaDon = hd.MaHoaDon;
                    if (them)// thêm thành công
                    {
                        //Kiem tra gio hang binh thuong va gio hang HUI
                        if(input.ListCheckoutHUICart != null && input.ListCheckoutNormalCart != null
                            && (input.ListCheckoutHUICart.Count() != 0 || input.ListCheckoutNormalCart.Count() != 0))
                        {
                            //loc giỏ hàng bình thường 
                            if(input.ListCheckoutNormalCart.Count() != 0 && input.ListCheckoutNormalCart[0] != null)
                            {
                                var listCheckoutNormalCart = input.ListCheckoutNormalCart[0].Split(",");
                                foreach (var cartId in listCheckoutNormalCart)
                                {
                                    var checkOutItem = GioHangOutput.Find(cartId);
                                    if (checkOutItem != null)
                                    {
                                        ChiTietHoaDon ct = new ChiTietHoaDon();
                                        ct.HoaDonId = maHoaDon;
                                        ct.ProductId = checkOutItem.MaSanPham;
                                        ct.SoLuong = checkOutItem.soLuong;
                                        ct.GiaBan = (decimal)checkOutItem.giaBan;
                                        ct.MaHUI = "n";
                                        var rs = await _gioHangApiServices.ThemCTHoaDon(ct);
                                        //cap nhat gio hang
                                        if (rs) GioHangOutput.XoaGioHang(cartId);
                                    }

                                }
                            }

                            //lọc giỏ hàng HUI
                            if (input.ListCheckoutHUICart.Count() != 0 && input.ListCheckoutHUICart[0] != null)
                            {
                                var listCheckoutHUICart = input.ListCheckoutHUICart[0].Split(",");
                                foreach (var idAndCode in listCheckoutHUICart)
                                {
                                    var cartId = idAndCode.Split('_')[0];
                                    var code = idAndCode.Split('_')[1];
                                    var checkOutItem = GioHangOutput.Find(cartId,code);
                                    if (checkOutItem != null)
                                    {
                                        ChiTietHoaDon ct = new ChiTietHoaDon();
                                        ct.HoaDonId = maHoaDon;
                                        ct.ProductId = checkOutItem.MaSanPham;
                                        ct.MaHUI = code;
                                        ct.SoLuong = checkOutItem.soLuong;
                                        ct.GiaBan = (decimal)checkOutItem.giaBan;
                                        var rs = await _gioHangApiServices.ThemCTHoaDon(ct);
                                        //cap nhat gio hang
                                        if (rs) GioHangOutput.XoaGioHang(cartId,code);
                                    }

                                }
                            }
                            return Json(new{ status = true});
                        }else //Gio hang trong
                            return Json(new{ status = false});
                    }
                    else return Json(new{code = 2,msg = "Lỗi rồi",});
                }
                else// chưa đăng nhập
                {
                    return Json(new
                    {
                        code = 1,
                        msg = "Lỗi rồi",
                    });
                }
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

        //private GioHang GetCheckoutItems(string cartId)
        //{
        //    if(this.CurrentGioHang != null && this.CurrentGioHang.HUICart.Count() > 0 
        //        && this.CurrentGioHang.NormalCart.Count() > 0)
        //    {

        //    }    
        //}
    }
}
