using EcommerceWebsite.Utilities.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.WebApp.Funcs.Interface
{
    public interface IUserApi
    {
        Task<string> Authenticate(ThongTinKhachHangInput request);
    }
}
