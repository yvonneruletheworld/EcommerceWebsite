using EcommerceWebsite.Application.Constants;
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
        Task<ApiResult<string>> GetLoginToken(ThongTinKhachHangInput input);
        Task<KhachHangOutput> GetKhachHangTheoMa(string maKhachHang);
    }
}
