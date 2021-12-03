using EcommerceWebsite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.Api.Interface
{
  public interface IYeuThichSanPhamApiServices
    {
        Task<bool> ThemYeuThichSanPham(SanPhamYeuThich input);
    }
}
