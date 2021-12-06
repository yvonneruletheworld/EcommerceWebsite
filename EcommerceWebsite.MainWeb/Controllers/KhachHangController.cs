﻿using EcommerceWebsite.Api.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebsite.MainWeb.Controllers
{
    [Route("/KhachHang")]
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class KhachHangController : BackgroudController
    {
        public KhachHangController(IKhachHangApiServices khachHangServices, IConfiguration configuration) : base(khachHangServices, configuration)
        {
        }

        //private readonly IKhachHangApiServices _khachHangServices;
        //private readonly IConfiguration _configuration;

        //public KhachHangController(IKhachHangApiServices khachHangServices, IConfiguration configuration)
        //{
        //    _khachHangServices = khachHangServices;
        //    _configuration = configuration;
        //}


        //get
        [HttpGet("client-login")]
        public async Task<IActionResult> Index()
        {   
            //await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View();
        }

        //[HttpPost("client-login")]
        //public async Task<IActionResult> Index(ThongTinKhachHangInput input, string previousPage = null)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var token = await _khachHangServices.GetLoginToken(input);
        //        if (!token.IsSuccessed)
        //        {
        //            ModelState.AddModelError("", token.Message);
        //            return View();
        //        }
        //        else
        //        {
        //            var userPrincipal = this.ValidateToken(token.ResultObj);
        //            var authProperties = new AuthenticationProperties
        //            {
        //                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
        //                IsPersistent = false
        //            };
        //            HttpContext.Session.SetString(SystemConstant.Token, token.ResultObj);
        //            await HttpContext.SignInAsync(
        //                        CookieAuthenticationDefaults.AuthenticationScheme,
        //                        userPrincipal,
        //                        authProperties);
        //            if (string.IsNullOrEmpty(previousPage))
        //                return RedirectToAction("Index", "Home");
        //            else
        //                return Json(new { code = 200, msg = Messages.Login_Success });
        //        }
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", Messages.KhachHang_InputError);
        //        return View();
        //    }
        //}

        //private ClaimsPrincipal ValidateToken(string jwtToken)
        //{
        //    try
        //    {
        //        IdentityModelEventSource.ShowPII = true;

        //        SecurityToken validatedToken;
        //        TokenValidationParameters validationParameters = new TokenValidationParameters();

        //        validationParameters.ValidateLifetime = true;

        //        validationParameters.ValidAudience = _configuration["Tokens:Issuer"];
        //        validationParameters.ValidIssuer = _configuration["Tokens:Issuer"];
        //        validationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));
        //        validationParameters.IssuerSigningKey.KeyId = _configuration["Tokens:Key"];
        //        ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(jwtToken, validationParameters, out validatedToken);

        //        return principal;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
            
        //}
    }
}
