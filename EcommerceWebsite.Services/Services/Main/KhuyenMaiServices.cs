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
    public class KhuyenMaiServices : IKhuyenMaiServices
    {
        private readonly EcomWebDbContext _context;

        public KhuyenMaiServices(EcomWebDbContext context)
        {
            _context = context;
        }

        public async Task<List<BannerOutput>> LayKhuyenMaiChoTrangChu()
        {
            var data = await (from km in _context.KhuyenMais
                              from bn in _context.Banners.Where(bn => bn.TenBanner.Equals(km.MaKhuyenMai)).Take(1)
                              where !km.DaXoa
                              select new BannerOutput()
                              {
                                  Url = km.HinhAnh, // luu url redirect den trang khuyen mai
                                  HinhAnh = bn.HinhAnhBanner,
                                  Content = km.TenKhuyenMai,
                                  Value = km.PhanTram,
                                  Time = km.NgayTao.ToString()
                              }).Take(7).ToListAsync();
            return data;
        }
    }
}
