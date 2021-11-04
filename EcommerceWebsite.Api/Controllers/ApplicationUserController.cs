using EcommerceWebsite.Application.Constants;
using EcommerceWebsite.Data.Identity;
using EcommerceWebsite.Services.Interfaces.ExtraServices;
using EcommerceWebsite.Services.Interfaces.Main;
using EcommerceWebsite.Services.Interfaces.System;
using EcommerceWebsite.Utilities.Input;
using Microsoft.AspNetCore.Authorization;
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
    public class ApplicationUserController : ControllerBase
    {
        private readonly IKhachHangServices _khachHangServices;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _config; 
        private readonly IEmailSenderServices _emailServices;
        private readonly ISanPhamServices _spServices;

        public ApplicationUserController(IKhachHangServices khachHangServices, SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager, IEmailSenderServices emailServices, IConfiguration config, ISanPhamServices spServices)
        {
            _khachHangServices = khachHangServices;
            _signInManager = signInManager;
            _userManager = userManager;
            _emailServices = emailServices;
            _config = config;
            _spServices = spServices;
        }

        [AllowAnonymous]
        [HttpPost("auth/login")]
        public async Task<IActionResult> Login(ThongTinKhachHangInput model)
        {
            var g = _spServices.LayChiTietSanPham("SP01", true);
            var getByUserName = await _userManager.FindByNameAsync(model.TenDangNhap);
            getByUserName ??= await _khachHangServices.GetKhachHangTheoUsername(model.TenDangNhap);

            if (getByUserName == null)
            {
                return BadRequest(Messages.KhachHang_NguoiDungKhongTonTai);
            }
            if (getByUserName.Status == Data.Enum.Status.InActive)
            {
                return BadRequest(Messages.KhachHang_NguoiDungKhongHoatDong);
            }
            if (!await _khachHangServices.KiemTraDangNhapKhachHang(getByUserName, model.MatKhau))
            {
                return BadRequest( Messages.KhachHang_MatKhauKhongDung);
            }
            var result = await _signInManager.PasswordSignInAsync(getByUserName, model.MatKhau, model.GhiNhoDangNhap, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                //get current user id
                //var currentUser = _khachHangService.GetUserEmail(User);
                var currentUser = getByUserName.Email;
                var roles = await _userManager.GetRolesAsync(getByUserName);

                var claims = new[]
                {
                    new Claim(ClaimTypes.Email, getByUserName.Email),
                    new Claim(ClaimTypes.GivenName, getByUserName.UserName),
                    new Claim(ClaimTypes.Role, string.Join(";", roles))
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var issuer = _config["JwtToken:Issuer"];
                var audience = _config["JwtToken:Audience"];
                var jwtValidity = DateTime.Now.AddMinutes(Convert.ToDouble(_config["JwtToken:TokenExpiry"]));

                var token = new JwtSecurityToken(issuer,
                  audience,
                  expires: jwtValidity,
                  signingCredentials: creds);

                return Ok( new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }

            return BadRequest("Could not create token");
        }
    }
}
