using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Utilities.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebsite.Services.Interfaces.Main
{
   public interface IYeuThichSanPhamServices
    {
        Task<bool> ThemYeuThich(SanPhamYeuThich input);
        //Task<int> laySoLuongYeuThich(SanPhamYeuThich input);
        Task<List<SanPhamVM>> laySanPhamYeuThich(string MaKH);

    }
}
