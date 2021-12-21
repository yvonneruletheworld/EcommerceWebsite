using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Utilities.Output.Main;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace EcommerceWebsite.Services.Interfaces.Main
{
  public interface IGioHangServices
    {
        Task<bool> ThemHoaDon(HoaDon hD);
        Task<bool> ThemChiTietHoaDon(ChiTietHoaDon hD);
        Task<List<HoaDon>> LayDonHangDangDuyet();
        Task<bool> DuyetDonHang(string MaHD);
        Task<List<HoaDon>> LayDonHangDaDuyet();
    }
}
