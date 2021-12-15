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
        public async Task<List<HoaDon>> layHoaDonTheoKhachHang(string maKH)
        {
            try
            {
                //var data = await (from sp in _context.SanPhams
                //                  from sp_dl in _context.DinhLuongs
                //                                         .Where(dl => dl.MaSanPham.Equals(sp.MaSanPham)
                //                                         && (dl.MaThuocTinh == (nameof(ProductPorpertyCode.TT07))
                //                                         || dl.MaThuocTinh == (nameof(ProductPorpertyCode.TT014)))).Take(1)
                //                      //join lsg in _context.LichSuGias on sp_dl.MaDinhLuong equals lsg.MaDinhLuong into dl_lsg_group
                //                  from dl_lsg in _context.LichSuGias.Where(lsg => lsg.MaDinhLuong.Equals(sp_dl.MaDinhLuong))
                //                                                .OrderByDescending(lsg => lsg.NgayTao.Date).Take(1)

                //                  where !sp.DaXoa
                 //                select new SanPhamVM
                //                  {
                //                      MaSanPham = sp.MaSanPham,
                //                      TenSanPham = sp.TenSanPham,
                //                      SoLuongTon = sp.SoLuongTon,
                //                      HinhAnh = sp.HinhAnh,
                //                      NhanHieu = nhanHieu.TenHang,
                //                      LoaiSanPham = loaiSanPham.TenDanhMuc,
                //                      GiaBan = dl_lsg.GiaMoi,
                //                      MaLoai = loaiSanPham.MaDanhMuc,

                //                      TrangThaiYeuThich = false
                //                  }).ToListAsync();
                var duLieu = await _context.HoaDons.Where(x => x.MaKhachHang == maKH ).ToListAsync();
                return duLieu;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
