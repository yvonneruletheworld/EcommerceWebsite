using EcommerceWebsite.Application.Constants;
using EcommerceWebsite.Data.Identity;
using EcommerceWebsite.Services.Interfaces.ExtraServices;
using EcommerceWebsite.Services.Interfaces.System;
using EcommerceWebsite.Utilities.Email;
using EcommerceWebsite.Utilities.Input;
using EcommerceWebsite.WebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.WebApp.Controllers.SP
{
    public class GioHangController : Controller
    {
        private readonly ILogger<GioHangController> _logger;
        private readonly IKhachHangServices _khachHangService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSenderServices _emailServices;


        public GioHangController(ILogger<GioHangController> logger, IKhachHangServices applicationUserService, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IEmailSenderServices emailServices)
        {
            _logger = logger;
            _khachHangService = applicationUserService;
            _signInManager = signInManager;
            _userManager = userManager;
            _emailServices = emailServices;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                await _signInManager.SignOutAsync();
                return View("/Views/GioHang/Index.cshtml");
            }

            return View("/Views/GioHang/Index.cshtml", currentUser);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(ThongTinKhachHangInput model)
        {
            var msg = Messages.Form_Invalid;
            if (ModelState.IsValid)
            {
                var getByUserName = await _khachHangService.GetKhachHangTheoUsername(model.TenDangNhap);
                getByUserName ??= await _userManager.FindByNameAsync(model.TenDangNhap);

                if (getByUserName == null)
                {
                    ModelState.AddModelError(string.Empty, Messages.KhachHang_NguoiDungKhongTonTai);
                    return View("/Views/GioHang/Index.cshtml",model);
                }
                if (getByUserName.Status == Data.Enum.Status.InActive)
                {
                    ModelState.AddModelError(string.Empty, Messages.KhachHang_NguoiDungKhongHoatDong);
                    return View("/Views/GioHang/Index.cshtml",model);
                }
                if (!await _khachHangService.KiemTraDangNhapKhachHang(getByUserName, model.MatKhau))
                {
                    ModelState.AddModelError(string.Empty, Messages.KhachHang_MatKhauKhongDung);
                    return View("/Views/GioHang/Index.cshtml",model);
                }
                var result = await _signInManager.PasswordSignInAsync(getByUserName, model.MatKhau, model.GhiNhoDangNhap, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    //get current user id
                    //var currentUser = _khachHangService.GetUserEmail(User);
                    var currentUser = getByUserName.Email;
                    if (currentUser == null) msg = Messages.Login_EmailNull;
                    else
                    {
                        // get computer's ip
                        var comIp = GetUserIp();
                        //gen otp
                        var otpCode = Randoms.RandomString().ToUpper();
                        var updateOtpCode = await _khachHangService.UpdateOTPCode(getByUserName.Id, otpCode ??= "OTCODENULL");
                        if (updateOtpCode)
                        {
                            var recvs = new List<string>() { currentUser };
                            var title = EmailTemplate.OTPLogin.Title;
                            var content = EmailTemplate.OTPLogin.Content.Replace("{email}", currentUser)
                                                                        .Replace("{OTPCode}", otpCode);
                            var email = new EmailMessageSender(recvs, title, content);
                            if (_emailServices.SendMail(email))
                                msg = Messages.OTP_SentSuccess;
                            else
                                msg = Messages.OTP_SentFailed;
                        }
                    }
                }
            }
            return Json(new { code = msg });
        }

        [HttpPost("verify-otp-code")]
        public async Task<IActionResult> VerifyOTPCode(string otpInput, string input)
        {
            if (string.IsNullOrEmpty(otpInput) || string.IsNullOrEmpty(input))
                return Json(new { code = Messages.OTP_Invalid });
            else
            {
                var user = await _khachHangService.GetKhachHangTheoUsername(input);
                user ??= await _khachHangService.GetKhachHangTheoEmail(input);

                if (user == null)
                    return Json(new { code = Messages.KhachHang_NguoiDungKhongTonTai });
                if (user.OTPCode.Equals(otpInput))
                {
                    //return RedirectToAction("Index", "Home");
                    return Json(new { code = Messages.OTP_VerifySuccess });
                }
                else
                    return Json(new { code = Messages.OTP_VerifyFailed });
            }
        }


        public string GetUserIp()
        {
            return Request.HttpContext.Connection.RemoteIpAddress.ToString();
        }

        [HttpGet("get-form-login")]
        public async Task<IActionResult> GetFormLoginAsync(string phoneNumber, bool isPhoneNumber)
        {
            try
            {
                if (string.IsNullOrEmpty(phoneNumber))
                    return Json(new { code = Messages.Login_PhoneNumEmpty });
                if (isPhoneNumber)
                {
                    var isExistPhoneInDb = await _khachHangService.GetKhachHangInputTheoSdt(phoneNumber);
                    if (isExistPhoneInDb == null)
                        return Json(new { code = Messages.Login_PhoneNumIsNotExist });
                    else
                    {
                        return PartialView("/Views/User/_FormThongTin.cshtml", isExistPhoneInDb);
                    }
                }
                else return Json(new { code = "" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
    }
}
