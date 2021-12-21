using EcommerceWebsite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.Api.Interface
{
  public interface IGioHangApiServices
    {
        Task<bool> ThemHoaDon(HoaDon hD);
        Task<bool> ThemCTHoaDon(ChiTietHoaDon hD);
        Task<bool> ThemHoaDonKhongKM(HoaDon hD);
        Task<List<HoaDon>> LayDonHangDangDuyet();
        Task<bool> DuyetDonHang(string MaHD);
        Task<List<HoaDon>> LayDonHangDaDuyet();
    }
}
