using EcommerceWebsite.Utilities.Input;
using EcommerceWebsite.WebApp.Funcs.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.WebApp.Funcs.Service
{
    public class UserApi : IUserApi
    {
        //private readonly IHttpClientFactory
        public Task<string> Authenticate(ThongTinKhachHangInput request)
        {
            throw new NotImplementedException();
        }
    }
}
