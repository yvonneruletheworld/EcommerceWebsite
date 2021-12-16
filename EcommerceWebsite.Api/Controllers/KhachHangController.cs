using EcommerceWebsite.Application.Constants;
using EcommerceWebsite.Data.Identity;
using EcommerceWebsite.Services.Interfaces.ExtraServices;
using EcommerceWebsite.Services.Interfaces.System;
using EcommerceWebsite.Utilities.Email;
using EcommerceWebsite.Utilities.Input;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebsite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        private readonly IKhachHangServices _khachHangServices;
        private readonly IEmailSenderServices _emailServices;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _config;

        public KhachHangController(IKhachHangServices khachHangServices, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration config, IEmailSenderServices emailServices)
        {
            _khachHangServices = khachHangServices;
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
            _emailServices = emailServices;
        }

        [HttpPost("user-login")]
        public async Task<IActionResult> UserLogin(ThongTinKhachHangInput input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(er => er.Errors));
            }
            else
            {
                var result = await _khachHangServices.LoginAsync(input.Email, input.MatKhau);

                if (result.ContainsKey("NotRegister"))
                {
                    return BadRequest(new { message = Messages.KhachHang_NguoiDungKhongTonTai });
                }
                if (result.ContainsKey("PasswordIncorrect"))
                {
                    return BadRequest(new { message = Messages.KhachHang_MatKhauKhongDung });
                }
                if (result.ContainsKey("UserInactive"))
                {
                    return BadRequest(new { message = Messages.KhachHang_NguoiDungKhongHoatDong });
                }
                if (result.ContainsKey("Success"))
                {
                    var user = result["Success"];
                    var testPass = await _signInManager.PasswordSignInAsync(user, input.MatKhau, input.GhiNhoDangNhap, lockoutOnFailure: false);

                    if (testPass.Succeeded)
                    {
                        //Claim
                        //var roles = await _userManager.GetRolesAsync(user);
                        var currentUser = await _userManager.FindByEmailAsync(user.Email);
                        var claims = new[]
                        {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.GivenName, user.UserName),
                    //new Claim(ClaimTypes.Role, string.Join(";", roles)),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Sid, currentUser.Id),
                };

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
                        key.KeyId = _config["Tokens:Key"];
                        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                        var issuer = _config["Tokens:Issuer"];
                        //var audience = _config["Tokens:Audience"];
                        var jwtValidity = DateTime.Now.AddMinutes(Convert.ToDouble(_config["Tokens:TokenExpiry"]));

                        var token = new JwtSecurityToken(issuer,
                          issuer,
                          claims,
                          expires: jwtValidity,
                          signingCredentials: creds);

                        return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
                    }
                    return BadRequest(new { message = Messages.KhachHang_MatKhauKhongDung });
                }
            }

            return BadRequest(new { message = "Đã xảy ra lỗi." });
        }

        [HttpPost("user-resigter")]
        public async Task<IActionResult> UserRegister(ThongTinKhachHangInput input)
        {
            if (ModelState.IsValid)
            {
                if (await _khachHangServices.SubmitUser(input))
                {
                    return Ok(Messages.API_Success);
                }
                return Ok(Messages.API_Failed);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("get-khach-hang/{maKhachHang}")]
        public async Task<IActionResult> GetKhachHang(string maKhachHang)
        {
            if (string.IsNullOrEmpty(maKhachHang))
                return BadRequest(Messages.API_EmptyInput);
            var data = await _khachHangServices.GetKhachHangTheoMa(maKhachHang);
            if (data == null)
                return BadRequest(Messages.API_EmptyResult);
            return Ok(data);
        }

        [HttpGet("lay-diachiKhachHang/{maKH}")]
        public async Task<IActionResult> layDiaChiKhachHang(string maKH)
        {
            try
            {
                var result = await _khachHangServices.layDiaChiKhachHang(maKH);
                if (result == null)
                    return BadRequest(Messages.API_EmptyResult);
                else return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.API_Exception + ex);
            }
        }
        
        [HttpGet("update-otp/{maKhachHang}/{otpCode}")]
        public async Task<IActionResult> UpdateOtp(string maKhachHang, string otpCode)
        {
            try
            {
                var result = await _khachHangServices.UpdateOTPCode(maKhachHang,otpCode);
                if (result)
                    return Ok(result);
                return BadRequest(Messages.OTP_Invalid);
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.API_Exception + ex);
            }
        }

        [HttpGet("send-mail/{mailAddress}/{otpCode}")]
        public async Task<IActionResult> SendMail(string mailAddress, string otpCode)
        {
            try
            {
                var recvs = new List<string>() { mailAddress };
                var title = EmailTemplate.OTPLogin.Title;
                var content = EmailTemplate.OTPLogin.Content.Replace("{email}", mailAddress)
                                                            .Replace("{OTPCode}", otpCode);
                var email = new EmailMessageSender(recvs, title, content);
                if (_emailServices.SendMail(email))
                    return Ok( Messages.OTP_SentSuccess);
                else
                    return BadRequest( Messages.OTP_SentFailed);
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.API_Exception + ex);
            }
        }

        [HttpGet("LayThongTinKhachHang/{maKH}")]
        public async Task<IActionResult> LayThongTinKhachHang(string maKH)
        {
            try
            {
                var result = await _khachHangServices.LayThongTinKhachHang(maKH);
                if (result == null)
                    return BadRequest(Messages.API_EmptyResult);
                else
                    return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(Messages.API_Exception + ex);
            }
        }
    }
}
