using EcommerceWebsite.Data.EF;
using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Services.Interfaces.Main;
using EcommerceWebsite.Utilities.Output.Main;
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
        private readonly IPhieuNhapServices _phieuNhapServices;
        private readonly ISanPhamServices _sanPhamServices;

        public HoaDonServices(EcomWebDbContext context, IPhieuNhapServices phieuNhapServices, ISanPhamServices sanPhamServices)
        {
            _context = context;
            _phieuNhapServices = phieuNhapServices;
            _sanPhamServices = sanPhamServices;
        }

        public async Task<bool> CapNhatLoiNhuanChoSanPham()
        {
            try
            {
                var listSanPham = await _context.SanPhams.ToListAsync();

                foreach (var sp in listSanPham)
                {
                    var result = await _phieuNhapServices.GetListImportProduct2(sp.MaSanPham);
                    if (result != null && result.Count() > 0)
                    {
                        var listLoiNhuan = new List<DoanhThuOutput>();

                        foreach (var date in result.Keys)
                        {
                            listLoiNhuan.AddRange(result[date]);
                        }
                        var tongloiNhuan = listLoiNhuan.Sum(ln => ln.LoiNhuan);
                        var loiNhuan = tongloiNhuan / listLoiNhuan.Count();
                        sp.Utility = (decimal)loiNhuan;
                        var resultUpdate = await _sanPhamServices.SuaHoacXoaSanPham(sp, false);
                        if (!resultUpdate) continue;
                    }
                    else
                    {
                        continue;
                    }
                    //var tongNhap = dicChiTietNhap.ElementAt(0).Value
                    //    .Where(ctn => ctn.MaSanPham == sp.MaSanPham)
                    //    .ToList().Sum(ctn => ctn.SoLuong * ctn.DonGia);

                    //var tongBan = dicChiTietHoaDon.ElementAt(0).Value
                    //    .Where(cthd => cthd.ProductId == sp.MaSanPham)
                    //    .ToList().Sum(cthd => cthd.SoLuong * cthd.GiaBan);

                    //var ln = ((tongBan - tongNhap) / tongNhap) * 100;
                    //sp.Utility = ln;

                    //var resultUpdate = await _sanPhamServices.SuaHoacXoaSanPham(sp, false);
                    //if (!resultUpdate) continue;
                }
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        public async Task<List<ChiTietHoaDon>> DanhSachHoaDonComboCode(string comboCode, DateTime ngayTao, DateTime ngayNhapKe)
        {
            var data = await (from ct in _context.ChiTietHoaDons 
                              join hd in _context.HoaDons on ct.HoaDonId equals hd.MaHoaDon
                              where ct.MaHUI == comboCode
                              && DateTime.Compare(ngayTao.Date, ct.HoaDons.NgayTao.Date) <= 0
                            && DateTime.Compare(ngayNhapKe.Date, ct.HoaDons.NgayTao.Date) >= 0
                            select new ChiTietHoaDon()
                            {
                                HoaDonId = ct.HoaDonId,
                                HoaDons = hd
                            }).ToListAsync();
            return data;
        }

        public async Task<List<ChiTietHoaDon>> DanhSachHoaDonExport(string firstDate, string secondDate)
        {
           
            try
            {
                var rsf = (await _context.HUICosts.OrderByDescending(hc => hc.NgayTao.Date)
                                                   .ThenByDescending(hc => hc.NgayTao.TimeOfDay)
                                                   .FirstOrDefaultAsync()).NgayTao;
                var rss = firstDate == "add" ?
                    (await _context.HUICosts.OrderByDescending(hc => hc.NgayTao.Date)
                                                   .ThenByDescending(hc => hc.NgayTao.TimeOfDay)
                                                   .FirstOrDefaultAsync()).NgaySuaCuoi
                   : DateTime.Now;
                var data1 = await (from hd in _context.HoaDons
                                  join cthd in _context.ChiTietHoaDons on hd.MaHoaDon equals cthd.HoaDonId
                                  join sp in _context.SanPhams on cthd.ProductId equals sp.MaSanPham 
                                  where DateTime.Compare(hd.NgayTao, (DateTime)rsf) >= 0 && DateTime.Compare(hd.NgayTao, (DateTime)rss) <= 0
                                   select new ChiTietHoaDon
                                  {
                                      HoaDons = hd,
                                      SanPhams = sp,
                                      ProductId = cthd.ProductId,
                                      HoaDonId = hd.MaHoaDon,
                                      GiaBan = cthd.GiaBan,
                                      SoLuong = cthd.SoLuong
                                  }).ToListAsync();
                
                return data1;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            
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
