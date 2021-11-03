using EcommerceWebsite.Data.EF;
using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Data.Identity;
using EcommerceWebsite.Services.Interfaces.System;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using EcommerceWebsite.Utilities.Input;
using System.Security.Claims;

namespace EcommerceWebsite.Services.Services.System
{
    public class KhachHangServices : IKhachHangServices
    {
        private readonly EcomWebDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public KhachHangServices(EcomWebDbContext context, 
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<ThongTinKhachHangInput> GetKhachHangInputTheoSdt(string sdt)
        {
            return await (from au in _context.ApplicationUsers 
                          where !au.IsDeleted && au.PhoneNumber == sdt
                          select new ThongTinKhachHangInput()
                          {
                              TenDangNhap = au.UserName,
                              MatKhau = au.PasswordHash,
                              Sdt = au.PhoneNumber
                          } ).FirstOrDefaultAsync();
        }

        public Task<ApplicationUser> GetKhachHangTheoEmail(string email)
        {
            return _context.ApplicationUsers.Where(u => u.Email.Equals(email))
                                            .FirstOrDefaultAsync();
        }

        public async Task<ApplicationUser> GetKhachHangTheoId(string id)
        {
            return await _context.ApplicationUsers.FirstOrDefaultAsync(u => !u.IsDeleted && u.Id.Equals(id));
        }

        public async Task<ApplicationUser> GetKhachHangTheoUsername(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        public string GetUserEmail(ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.Email);
        }

        public string GetUserId(ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public async Task<bool> KiemTraDangNhapKhachHang(ApplicationUser obj, string pwd)
        {
            return await _userManager.CheckPasswordAsync(obj, pwd);
        }


        public async Task<bool> UpdateOTPCode(string id, string otpCode)
        {
            try
            {
                await _context.Database.BeginTransactionAsync();

                var obj = await GetKhachHangTheoId(id);
                if (obj == null) return false;

                //update OTP code
                obj.OTPCode = otpCode;
                _context.Entry(obj).State = EntityState.Modified;//sửa

                var result = await _context.SaveChangesAsync();//Lưu
                await _context.Database.CommitTransactionAsync();

                return result > 0 ;
            }
            catch (Exception exx)
            {
                throw exx;
            }
        }

        //public Task<Dictionary<string, KhachHang>> LoginAsync(string usernameOrPhone, string pass)
        //{
        //    var result = new Dictionary<string, KhachHang>();
        //    var obj = await 
        //}
    }
}
