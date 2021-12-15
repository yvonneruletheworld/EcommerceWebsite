using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Data.Identity;
using EcommerceWebsite.Utilities.Input;
using EcommerceWebsite.Utilities.Output.System;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebsite.Services.Interfaces.System
{
    public interface IKhachHangServices
    {
        Task<Dictionary<string, ApplicationUser>> LoginAsync(string usernameOrEmail, string password);
        Task<ApplicationUser> GetKhachHangInputTheoSdt(string sdt);
        Task<ApplicationUser> GetKhachHangTheoUsername(string userName);
        Task<ApplicationUser> GetKhachHangTheoId(string id);
        Task<KhachHangOutput> GetKhachHangTheoMa(string maKhachHang);
        Task<ApplicationUser> GetKhachHangTheoEmail(string email);
        Task<bool> CheckLoginPass(ApplicationUser obj, string pwd);
        //Task<Dictionary<string, KhachHang>> LoginAsync(string usernameOrPhone, string pass);
        string GetUserId(ClaimsPrincipal user);
        string GetUserEmail(ClaimsPrincipal user);
        Task<bool> UpdateOTPCode(string id, string v);
        Task<bool> SubmitUser(ThongTinKhachHangInput input);
        Task<List<DiaChiKhachHang>> layDiaChiKhachHang(string MaKH);
        Task<KhachHang> LayThongTinKhachHang(string maKH);
    }
}
