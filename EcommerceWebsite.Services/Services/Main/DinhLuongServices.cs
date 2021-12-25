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
    public class DinhLuongServices : IDinhLuongServices
    {
        private readonly EcomWebDbContext _context;

        public DinhLuongServices(EcomWebDbContext context)
        {
            _context = context;
        }

        public async Task<List<string>> AddRangeAsync(List<DinhLuong> input)
        {
            try
            {
                await _context.Database.BeginTransactionAsync();

                await _context.DinhLuongs.AddRangeAsync(input);
                var rs = await _context.SaveChangesAsync();

                await _context.Database.CommitTransactionAsync();

                if (rs > 0)
                {
                    var rsList = new List<string>();
                    foreach(var dl in input)
                    {
                        var maSanPham = dl.MaSanPham;
                        var maThuocTinh = dl.MaSanPham;
                        var giaTri = dl.GiaTri;
                        var getDl = await _context.DinhLuongs
                            .Where(dl => dl.GiaTri == giaTri && dl.MaThuocTinh == maThuocTinh && dl.MaSanPham == maSanPham)
                            .FirstOrDefaultAsync();
                        if (getDl != null)
                            rsList.Add(getDl.MaDinhLuong);
                    }
                    return rsList;
                }
                else return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<ThuocTinh>> LayThongSo()
        {
            try
            {
                return await _context.ThuocTinhs.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ThongSoSanPhamOutput>> LayThongSoTheoSanPham(string maSanPham)
        {
            try
            {
                var data = await (from dl in _context.DinhLuongs
                            join tt in _context.ThuocTinhs on (dl == null ? string.Empty : dl.MaThuocTinh) equals tt.MaThuocTinh into dl_tt_group
                            from dl_tt in dl_tt_group.DefaultIfEmpty()
                            where dl.MaSanPham == maSanPham
                            select new ThongSoSanPhamOutput
                            {
                                MaDinhLuong = dl.MaDinhLuong,
                                MaThuocTinh = dl.MaThuocTinh,
                                ThuocTinh = dl_tt.TenThuocTinh,
                                DonVi = dl.DonVi,
                                GiaTri = dl.GiaTri
                            }).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ThemVaSuaHang(NhanHieu input)
        {
            var duLieu = _context.NhanHieus.FirstOrDefault(x => x.MaHang == input.MaHang);
            if (duLieu != null)
            {
               
                    await _context.Database.BeginTransactionAsync();
                    duLieu.TenHang = input.TenHang;
                    _context.NhanHieus.Update(duLieu);
                    var rs = await _context.SaveChangesAsync();
                    await _context.Database.CommitTransactionAsync();
                    return false;

            }
            else
            {
                //begin transaction
                await _context.Database.BeginTransactionAsync();
                //add
                await _context.NhanHieus.AddAsync(input);
                var result = await _context.SaveChangesAsync();

                await _context.Database.CommitTransactionAsync();

                return true;
            }
        }
        public async Task<bool> XoaHang(string input)
        {
           
            var duLieu = _context.NhanHieus.FirstOrDefault(x => x.MaHang == input);
            if (duLieu != null)
            {
                await _context.Database.BeginTransactionAsync();
                _context.NhanHieus.Remove(duLieu);
                var rs = await _context.SaveChangesAsync();
                await _context.Database.CommitTransactionAsync();
                return true;

            }
            else
            {
                return true;
            }
        }
    }
}
