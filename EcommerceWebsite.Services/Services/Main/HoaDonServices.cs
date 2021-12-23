using EcommerceWebsite.Data.EF;
using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Services.Interfaces.Main;
using EcommerceWebsite.Utilities.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebsite.Services.Services.Main
{
    public class HoaDonServices : IHoaDonServices
    {
        private readonly EcomWebDbContext _context;

        public HoaDonServices(EcomWebDbContext context)
        {
            _context = context;
        }
        public async Task<List<ChiTietHoaDon>> DanhSachHoaDonTheoKhachHang(string maKH)
        {
            var data = await (from hd in _context.HoaDons
                              join cthd in _context.ChiTietHoaDons on hd.MaHoaDon equals cthd.HoaDonId
                              where hd.MaKhachHang == maKH
                              select new ChiTietHoaDon
                              {
                                  HoaDons = hd,
                                  ProductId = cthd.ProductId,

                                  HoaDonId = hd.MaHoaDon,
                                  GiaBan = cthd.GiaBan,
                                  SoLuong = cthd.SoLuong
                              }).ToListAsync();
            return data;
        }

        public async Task<int> LaySoLuongBan(string maSanPham, DateTime ngayNhap)
        {
            try
            {
                var data = await (from hd in _context.HoaDons
                                  join cthd in _context.ChiTietHoaDons on hd.MaHoaDon equals cthd.HoaDonId into hd_cthd_group
                                  from hd_cthd in hd_cthd_group.DefaultIfEmpty()
                                  join sp in _context.SanPhams on hd_cthd.ProductId equals sp.MaSanPham
                                  where sp.MaSanPham == hd_cthd.ProductId && !sp.DaXoa && DateTime.Compare(ngayNhap,hd.NgayTao) <= 0 
                                  select new SanPham()).ToListAsync();

                return data.Count();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
