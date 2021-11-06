using EcommerceWebsite.Application.Constants;
using EcommerceWebsite.Utilities.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.Api.Interface
{
    public interface IKhachHangServices
    {
        Task<ApiResult<string>> GetLoginToken(ThongTinKhachHangInput input);
    }
}
