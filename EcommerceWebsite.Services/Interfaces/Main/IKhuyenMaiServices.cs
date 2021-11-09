using EcommerceWebsite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebsite.Services.Interfaces.Main
{
   public interface IKhuyenMaiServices
    {
        Task<List<KhuyenMai>> layKhuyenMai();
    }
}
