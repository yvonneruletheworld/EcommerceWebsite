using EcommerceWebsite.Data.EF;
using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Services.Interfaces.Main;
using EcommerceWebsite.Utilities.Output.Main;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebsite.Services.Services.Main
{
    public class BinhLuanServices : IBinhLuanServices
    {
        private readonly EcomWebDbContext _context;

        public BinhLuanServices(EcomWebDbContext context)
        {
            _context = context;
        }

        public async Task<List<BinhLuanOutput>> LayBinhLuanTheoSanPham(string maSanPham)
        {
            return await (from bl in _context.BinhLuans 
                          join kh in _context.KhachHangs on (bl == null ? string.Empty : bl.NguoiTao) equals kh.MaKhachHang
                          where bl.MaSanPham == maSanPham && !bl.DaXoa
                          select new BinhLuanOutput ()
                          {
                              GioiTinh = kh.GioiTinh,
                              NgayTao = bl.NgayTao,
                              NguoiTao = kh.HoTen,
                              NoiDung = bl.NoiDung,
                              SoSao = bl.SoSao
                          }).OrderByDescending(bl => bl.NgayTao.Date)
                            .ThenByDescending(bl => bl.NgayTao.TimeOfDay)
                            .ToListAsync();
        }
    }
}
