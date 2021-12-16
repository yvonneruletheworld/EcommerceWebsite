using EcommerceWebsite.Api.Interface;
using EcommerceWebsite.Application.Constants;
using EcommerceWebsite.Data.Enum;
using EcommerceWebsite.Utilities.Input;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebsite.Admin.Controllers
{
    public class LoginController : Controller
    {
        public readonly IKhachHangApiServices _khachHangServices;
        public readonly IConfiguration _configuration;

        public LoginController(IKhachHangApiServices khachHangServices, IConfiguration configuration)
        {
            _khachHangServices = khachHangServices;
            _configuration = configuration;
        }

        public async Task<IActionResult> IndexAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost("client-login")]
        public async Task<IActionResult> Index(ThongTinKhachHangInput input, string previousPage = null)
        {
            input.XacNhanMatKhau = input.MatKhau;
            input.HoTen = "user";
            if (ModelState.IsValid)
            {
                var token = await _khachHangServices.GetLoginToken(input);
                if (!token.IsSuccessed)
                {
                    ModelState.AddModelError("", token.Message);
                    return View(new ThongTinKhachHangInput() { Type = ((int)LoaiTruyCap.Login) });
                }
                else
                {
                    var userPrincipal = this.ValidateToken(token.ResultObj);
                    var authProperties = new AuthenticationProperties
                    {
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                        IsPersistent = true
                    };
                    HttpContext.Session.SetString(SystemConstant.Token, token.ResultObj);
                    await HttpContext.SignInAsync(
                                CookieAuthenticationDefaults.AuthenticationScheme,
                                userPrincipal,
                                authProperties);
                    var s = User.Identity;
                    if (string.IsNullOrEmpty(previousPage))
                        return RedirectToAction("Index", "Home");
                    else
                    {
                        //get user id
                        var id = userPrincipal.Claims.Where(claim => claim.Type == ClaimTypes.Sid)
                                          .FirstOrDefault()
                                          .Value;
                        return new JsonResult(id) { StatusCode = 200 };
                    }

                }
            }
            else
            {
                //ModelState.AddModelError("", Messages.KhachHang_InputError);
                return View(new ThongTinKhachHangInput() { Type = ((int)LoaiTruyCap.Login) });
            }
        }


        private ClaimsPrincipal ValidateToken(string jwtToken)
        {
            try
            {
                IdentityModelEventSource.ShowPII = true;

                SecurityToken validatedToken;
                TokenValidationParameters validationParameters = new TokenValidationParameters();

                validationParameters.ValidateLifetime = true;

                validationParameters.ValidAudience = _configuration["Tokens:Issuer"];
                validationParameters.ValidIssuer = _configuration["Tokens:Issuer"];
                validationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));
                validationParameters.IssuerSigningKey.KeyId = _configuration["Tokens:Key"];
                ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(jwtToken, validationParameters, out validatedToken);

                return principal;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
