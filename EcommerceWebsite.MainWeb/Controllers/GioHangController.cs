using EcommerceWebsite.Api.Interface;
using EcommerceWebsite.Application.Constants;
using EcommerceWebsite.Data.EF;
using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.MainWeb.Models;
using EcommerceWebsite.Services.Interfaces.ExtraServices;
using EcommerceWebsite.Utilities.Email;
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
            return View("/Views/GioHang/Index.cshtml");
        }
        [HttpGet("get-data-giohang")]
        public  IActionResult layGioHang()
        {
            try
            {
                var data =  dSGioHang;
                if(data.Count == 0)
                {
                    return Json(new
                    {
                        code = 500,
                        Message = "Giỏ hàng trống"
                    });
                }    
                return PartialView("/Views/GioHang/_ListGioHang.cshtml", data);
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
                var data = dSGioHang;
                if (data.Count == 0)
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
                    var data = dSGioHang;
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
        public List<GioHang> dSGioHang
        {
            get {

                var data = HttpContext.Session.Get<List<GioHang>>("GioHang");
                if (data == null)
                {
                    data = new List<GioHang>();
                }   
                return data;
            }
        }
        //Thêm
        public IActionResult AddGioHang(string id, int soLuong, decimal giaSP, string type = "Normal")
        {
            var myCart = dSGioHang;
            var item = myCart.SingleOrDefault(p => p.MaSanPham == id);

            if (item == null)//chưa có
            {
                var data = _sanPhamApiServices.laySanPhamTheoMa(id);////lấy sản phaair dưới data
                SanPhamVM sp = data.Result;
                item = new GioHang
                {
                    MaSanPham = id,
                    tenSanPham = sp.TenSanPham,
                    giaSanPham = giaSP,
                    soLuong = soLuong,
                    hinhAnh = sp.HinhAnh
                };
                myCart.Add(item);
            }
            else
            {
                item.soLuong += soLuong;
            }
           
            HttpContext.Session.Set("GioHang", myCart);
            HttpContext.Session.SetString("SoLuongGH", dSGioHang.Sum(c => c.soLuong) +"");
            HttpContext.Session.SetString("TongTienGH", dSGioHang.Sum(c => c.dThanhTien) + "");
            if (type == "ajax")
            {
                return Json(new
                {
                    slGH = dSGioHang.Sum(c => c.soLuong)
               
            });
            }
            return RedirectToAction("Index", "GioHang");
        }


        //xóa giỏ hàng
        public ActionResult XoaGioHang(string id)
        {
            //Lấy giỏ hàng
            List<GioHang> listGHang = dSGioHang;
            //KIểm tra giỏ hàng
            GioHang sp = listGHang.Single(s => s.MaSanPham == id);
            //nếu có thì xóa nè
            if (sp != null)
            {
                listGHang.RemoveAll(s => s.MaSanPham == id);
                //cập nhật lại 
                HttpContext.Session.Set("GioHang", listGHang);
                HttpContext.Session.SetString("SoLuongGH", dSGioHang.Sum(c => c.soLuong) + "");
                HttpContext.Session.SetString("TongTienGH", dSGioHang.Sum(c => c.dThanhTien) + "");
                return Json(new { slGH = dSGioHang.Sum(c => c.soLuong),
                    Message = "Thành công"});
            }
            //Nếu giỏ hàng rỗng
            if (listGHang.Count == 0)
            {
                return RedirectToAction("index", "Home");
            }
            return RedirectToAction("index", "Home");
        }

        //updat giỏ hàng
        public ActionResult suaGioHang(string id, int soLuong)
        {
            //Lấy giỏ hàng
            List<GioHang> listGHang = dSGioHang;
            //Kiểm tra xem scah cần cập nhật có trong hàng không?
            GioHang sp = listGHang.Single(s => s.MaSanPham == id);
            //nếu có cập nhật
            if (sp != null)
            {

                sp.soLuong = soLuong;
                HttpContext.Session.Set("GioHang", listGHang);
                HttpContext.Session.SetString("SoLuongGH", dSGioHang.Sum(c => c.soLuong) + "");
                HttpContext.Session.SetString("TongTienGH", dSGioHang.Sum(c => c.dThanhTien) + "");
                return Json(new { code = 200, Message = "Thành công", slGH = dSGioHang.Sum(c => c.soLuong) });
            }
            else
            {
                return Json(new { code = 500, Message = "Thành công" });
            }    
        }

        public async Task<JsonResult> SendOTPAsync ()
        {
            var userId = User.Claims.Where(claim => claim.Type == ClaimTypes.Sid)
                                             .FirstOrDefault()
                                             .Value;
            //gen otp
            var otpCode = Randoms.RandomString().ToUpper();
            var updateOtpCode = await _khachHangApiServices.UpdateOTP(userId, otpCode ??= "OTCODENULL");
            if (updateOtpCode)
            {
                var mailAddress = User.Claims.Where(claim => claim.Type == ClaimTypes.Email)
                                             .FirstOrDefault()
                                             .Value;
                var recvs = new List<string>() { mailAddress };
                var title = EmailTemplate.OTPLogin.Title;
                var content = EmailTemplate.OTPLogin.Content.Replace("{email}", mailAddress)
                                                            .Replace("{OTPCode}", otpCode);
                var email = new EmailMessageSender(recvs, title, content);
                if (_emailServices.SendMail(email))
                    msg = Messages.OTP_SentSuccess;
                else
                    msg = Messages.OTP_SentFailed;
            }
        }

        //Tiến hành thanh toán
        public IActionResult ThanhToan(string MaKM, string MaDC, string PtThanhToan,decimal TongTien, decimal ThanhTien, decimal PhiShip, string type = "Normal")
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
                    hd.MaDiaChi = MaDC;
                    hd.PhuongThucThanhToan = PtThanhToan;
                    hd.TongCong = TongTien;
                    hd.ThanhTien = ThanhTien;
                    hd.PhiGiaoHang = PhiShip;
                    if (!string.IsNullOrEmpty(MaKM))
                    {
                        hd.MaKhuyenMai = MaKM;
                        var them = _gioHangApiServices.ThemHoaDon(hd);
                        string maHoaDon = hd.MaHoaDon;
                        if (them.Result)// thêm thành công
                        {
                            foreach (var gh in dSGioHang)
                            {
                                ChiTietHoaDon ct = new ChiTietHoaDon();
                                ct.HoaDonId = maHoaDon;
                                ct.ProductId = gh.MaSanPham;
                                ct.SoLuong = gh.soLuong;
                                ct.GiaBan = (decimal)gh.dThanhTien / gh.soLuong;
                                _gioHangApiServices.ThemCTHoaDon(ct);
                            }
                            List<GioHang> listGHang = dSGioHang;
                            listGHang.Clear();
                            HttpContext.Session.Set("GioHang", listGHang);
                            HttpContext.Session.SetString("SoLuongGH", 0 + "");
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
                    else
                    {
                        var them = _gioHangApiServices.ThemHoaDonKhongKM(hd);
                        string maHoaDon = hd.MaHoaDon;
                        if (them.Result)// thêm thành công
                        {
                            foreach (var gh in dSGioHang)
                            {
                                ChiTietHoaDon ct = new ChiTietHoaDon();
                                ct.HoaDonId = maHoaDon;
                                ct.ProductId = gh.MaSanPham;
                                ct.SoLuong = gh.soLuong;
                                ct.GiaBan = (decimal)gh.dThanhTien / gh.soLuong;
                                _gioHangApiServices.ThemCTHoaDon(ct);
                            }
                            List<GioHang> listGHang = dSGioHang;
                            listGHang.Clear();
                            HttpContext.Session.Set("GioHang", listGHang);
                            HttpContext.Session.SetString("SoLuongGH", 0 + "");
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
    }
}
