using EcommerceWebsite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebsite.Services.Interfaces.Main
{
  public  interface IHoaDonServices
    {
        Task<List<ChiTietHoaDon>> DanhSachHoaDonTheoKhachHang(string maKH);
        Task<int> LaySoLuongBan(string maSanPham, DateTime ngayNhap);
    }
}
