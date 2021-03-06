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

        public async Task<bool> AddRangeAsync(List<DinhLuong> input)
        {
            try
            {
                await _context.Database.BeginTransactionAsync();

                await _context.DinhLuongs.AddRangeAsync(input);
                var rs = await _context.SaveChangesAsync();

                await _context.Database.CommitTransactionAsync();

                return rs > 0;
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
    }
}
