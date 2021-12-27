using EcommerceWebsite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebsite.Services.Interfaces.Main
{
  public  interface IHoaDonServices
    {
        Task<bool> CapNhatLoiNhuanChoSanPham();
        Task<List<ChiTietHoaDon>> DanhSachHoaDonTheoKhachHang(string maKH);
        Task<List<ChiTietHoaDon>> DanhSachHoaDonExport(string firstDate, string secondDate);
        Task<List<ChiTietHoaDon>> DanhSachHoaDonComboCode(string comboCode, DateTime ngayTao, DateTime ngayNhapKe);
        Task<int> LaySoLuongBan(string maSanPham, DateTime ngayNhap);
    }
}
