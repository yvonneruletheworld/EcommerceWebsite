using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Utilities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.Api.Interface
{
  public interface IYeuThichSanPhamApiServices
    {
        Task<bool> ThemYeuThichSanPham(SanPhamYeuThich input);
        Task<List<SanPhamVM>> laySanPhamYeuThich(string MaKH);
    }
}
