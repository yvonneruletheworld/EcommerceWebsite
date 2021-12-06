using EcommerceWebsite.Api.Interface;
using EcommerceWebsite.Application.Constants;
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

namespace EcommerceWebsite.MainWeb.Controllers
{
    public class BackgroudController : Controller
    {
        private readonly IKhachHangApiServices _khachHangServices;
        private readonly IConfiguration _configuration;

        public BackgroudController(IKhachHangApiServices khachHangServices, IConfiguration configuration)
        {
            _khachHangServices = khachHangServices;
            _configuration = configuration;
        }

        [HttpPost("client-login")]
        public async Task<IActionResult> Index(ThongTinKhachHangInput input, string previousPage = null)
        {
            if (ModelState.IsValid)
            {
                var token = await _khachHangServices.GetLoginToken(input);
                if (!token.IsSuccessed)
                {
                    ModelState.AddModelError("", token.Message);
                    return View();
                }
                else
                {
                    var userPrincipal = this.ValidateToken(token.ResultObj);
                    var authProperties = new AuthenticationProperties
                    {
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                        IsPersistent = false
                    };
                    HttpContext.Session.SetString(SystemConstant.Token, token.ResultObj);
                    await HttpContext.SignInAsync(
                                CookieAuthenticationDefaults.AuthenticationScheme,
                                userPrincipal,
                                authProperties);
                    if (string.IsNullOrEmpty(previousPage))
                        return RedirectToAction("Index", "Home");
                    else
                        return Json(Messages.Login_Success);
                }
            }
            else
            {
                ModelState.AddModelError("", Messages.KhachHang_InputError);
                return View();
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
