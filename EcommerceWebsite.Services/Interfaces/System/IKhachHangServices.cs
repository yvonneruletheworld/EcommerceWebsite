using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Data.Identity;
using EcommerceWebsite.Utilities.Input;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebsite.Services.Interfaces.System
{
    public interface IKhachHangServices
    {
        Task<ThongTinKhachHangInput> GetKhachHangInputTheoSdt(string sdt);
        Task<ApplicationUser> GetKhachHangTheoUsername(string userName);
        Task<ApplicationUser> GetKhachHangTheoEmail(string email);
        Task<bool> KiemTraDangNhapKhachHang(ApplicationUser obj, string pwd);
        //Task<Dictionary<string, KhachHang>> LoginAsync(string usernameOrPhone, string pass);
        string GetUserId(ClaimsPrincipal user);
        string GetUserEmail(ClaimsPrincipal user);
        Task<bool> UpdateOTPCode(string id, string v);
    }
}
