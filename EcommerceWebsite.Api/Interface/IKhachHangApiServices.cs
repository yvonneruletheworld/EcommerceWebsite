using EcommerceWebsite.Application.Constants;
using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Utilities.Input;
using EcommerceWebsite.Utilities.Output.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.Api.Interface
{
    public interface IKhachHangApiServices
    {
        Task<bool> Resgister(ThongTinKhachHangInput input);
        Task<bool> UpdateOTP(string maKhachHang, string otp);
        Task<ApiResult<string>> GetLoginToken(ThongTinKhachHangInput input);
        Task<KhachHangOutput> GetKhachHangTheoMa(string maKhachHang);
        Task<List<DiaChiKhachHang>> layDiaChiKhachHang(string MaKH);
    }
}
