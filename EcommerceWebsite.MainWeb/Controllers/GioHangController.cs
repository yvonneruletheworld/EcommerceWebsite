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
        public  IActionResult layGioHang()
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
                    if(KH.Count != 0)
                    {
                        HttpContext.Session.SetString("HotenKH", KH[0].Hoten );
                        HttpContext.Session.SetString("SDTKH", KH[0].SDT );
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
                    slGH = GioHangOutput.CountCart()

                });
            }
            return RedirectToAction("Index", "GioHang");
        }


        //xóa giỏ hàng
        public ActionResult XoaGioHang(string id, string comboCode = null)
        {
            //Normal Cart 
            if(string.IsNullOrEmpty(comboCode))
            {
                //Lấy giỏ hàng
                List<GioHang> listGHang = GioHangOutput.NormalCart;
                //KIểm tra giỏ hàng
                GioHang sp = listGHang.Single(s => s.MaSanPham == id);
                //nếu có thì xóa nè
                if (sp != null)
                {
                    listGHang.RemoveAll(s => s.MaSanPham == id);
                    //cập nhật lại 
                    GioHangOutput.NormalCart = listGHang;
                }
            } 
            //HUI cart
            else
            {
                var huiCart = GioHangOutput.HUICart.Where(hc => hc.Key == comboCode)
                    .FirstOrDefault().Value;
                huiCart.RemoveAll(ci => ci.MaSanPham == id);
                GioHangOutput.HUICart[comboCode] = huiCart;
            }
            //HttpContext.Session.Set("GioHang", CurrentGioHang);
            //HttpContext.Session.SetString("SoLuongGH", CurrentGioHang.CountCart() + "");
            //HttpContext.Session.SetString("TongTienGH", CurrentGioHang.Cash() + "");
            if (GioHangOutput.CountCart() == 0)
                return RedirectToAction("index", "Home");
           else
            return Json(new
            {
                slGH = GioHangOutput.CountCart(),
                Message = "Thành công"
            });
        }

        //updat giỏ hàng
        public ActionResult suaGioHang(string id, int soLuong, string comboCode = null)
        {
            //Normal Cart 
            if (string.IsNullOrEmpty(comboCode))
            {
                //Lấy giỏ hàng
                List<GioHang> listGHang = GioHangOutput.NormalCart;
                GioHang sp = listGHang.Single(s => s.MaSanPham == id);
                if (sp != null)
                {
                    sp.soLuong = soLuong;
                    //cập nhật lại 
                    GioHangOutput.NormalCart = listGHang;
                }
            }
            //HUI cart
            else
            {
                var huiCart = GioHangOutput.HUICart.Where(hc => hc.Key == comboCode)
                    .FirstOrDefault().Value;
                var dict = huiCart.ToDictionary(ci => ci.MaSanPham);
                GioHang updateObj;
                if (dict.TryGetValue(id, out updateObj))
                    updateObj.soLuong = soLuong;
                GioHangOutput.HUICart[comboCode] = huiCart;
            }
            //HttpContext.Session.Set("GioHang", GioHangOutput);
            //HttpContext.Session.SetString("SoLuongGH", CurrentGioHang.CountCart() + "");
            //HttpContext.Session.SetString("TongTienGH", CurrentGioHang.Cash() + "");
            if (GioHangOutput.CountCart() == 0)
                return RedirectToAction("index", "Home");
            else
                return Json(new { code = 200, Message = "Thành công", slGH = GioHangOutput.CountCart() });
        }

        [HttpGet("send-otp")]
        public async Task<JsonResult> SendOTPAsync ()
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

        //Tiến hành thanh toán
        //public IActionResult ThanhToan(HoaDonInput input)
        //{
        //    try
        //    {
        //        if (User.Claims != null && User.Claims.Count() > 1)
        //        {
        //            var userId = User.Claims.Where(claim => claim.Type == ClaimTypes.Sid)
        //                                  .FirstOrDefault()
        //                                  .Value;
        //            HoaDon hd = new HoaDon();
        //            hd.MaKhachHang = userId;
        //            hd.MaDiaChi = input.MaDiaChi;
        //            hd.PhuongThucThanhToan = input.PhuongThucThanhToan;
        //            hd.TongCong = input.TongTien;
        //            hd.ThanhTien = input.ThanhTien;
        //            hd.PhiGiaoHang = input.Ship;
        //            if (!string.IsNullOrEmpty(input.MaKhuyenMai))
        //            {
        //                hd.MaKhuyenMai = input.MaKhuyenMai;
        //                var them = _gioHangApiServices.ThemHoaDon(hd);
        //                string maHoaDon = hd.MaHoaDon;
        //                if (them.Result)// thêm thành công
        //                {
        //                    foreach (var cartId in input.ListCheckoutCart)
        //                    {
        //                        var checkOutItem = GetCheckoutItems(cartId);
        //                        if(checkOutItem != null)
        //                        {
        //                            ChiTietHoaDon ct = new ChiTietHoaDon();
        //                            ct.HoaDonId = maHoaDon;
        //                            ct.ProductId = gh;
        //                            ct.SoLuong = gh.soLuong;
        //                            ct.GiaBan = (decimal)gh.dThanhTien / gh.soLuong;
        //                            _gioHangApiServices.ThemCTHoaDon(ct);
        //                        }    
                                
        //                    }
        //                    List<GioHang> listGHang = dSGioHang;
        //                    listGHang.Clear();
        //                    HttpContext.Session.Set("GioHang", listGHang);
        //                    HttpContext.Session.SetString("SoLuongGH", 0 + "");
        //                    return Json(new
        //                    {
        //                        status = true
        //                    });
        //                }
        //                else
        //                {
        //                    return Json(new
        //                    {

        //                        code = 2,
        //                        msg = "Lỗi rồi",
        //                    });
        //                }
        //            }    
        //            else
        //            {
        //                var them = _gioHangApiServices.ThemHoaDonKhongKM(hd);
        //                string maHoaDon = hd.MaHoaDon;
        //                if (them.Result)// thêm thành công
        //                {
        //                    foreach (var gh in dSGioHang)
        //                    {
        //                        ChiTietHoaDon ct = new ChiTietHoaDon();
        //                        ct.HoaDonId = maHoaDon;
        //                        ct.ProductId = gh.MaSanPham;
        //                        ct.SoLuong = gh.soLuong;
        //                        ct.GiaBan = (decimal)gh.dThanhTien / gh.soLuong;
        //                        _gioHangApiServices.ThemCTHoaDon(ct);
        //                    }
        //                    List<GioHang> listGHang = dSGioHang;
        //                    listGHang.Clear();
        //                    HttpContext.Session.Set("GioHang", listGHang);
        //                    HttpContext.Session.SetString("SoLuongGH", 0 + "");
        //                    return Json(new
        //                    {
        //                        status = true
        //                    });
        //                }
        //                else
        //                {
        //                    return Json(new
        //                    {

        //                        code = 2,
        //                        msg = "Lỗi rồi",
        //                    });
        //                }
        //            }    
        //        }
        //        else// chưa đăng nhập
        //        {
        //            return Json(new
        //            {
        //                code = 1,
        //                msg = "Lỗi rồi",
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new
        //        {
        //            code = 500,
        //            msg = "Lỗi rồi" + ex.Message
        //        });
        //    }
        //}

        //private GioHang GetCheckoutItems(string cartId)
        //{
        //    if(this.CurrentGioHang != null && this.CurrentGioHang.HUICart.Count() > 0 
        //        && this.CurrentGioHang.NormalCart.Count() > 0)
        //    {

        //    }    
        //}
    }
}
