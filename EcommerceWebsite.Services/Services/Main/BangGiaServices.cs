using EcommerceWebsite.Data.EF;
using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Services.Interfaces.Main;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebsite.Services.Services.Main
{
    public class BangGiaServices : IBangGiaServices
    {
        private readonly EcomWebDbContext _context;

        public BangGiaServices(EcomWebDbContext context)
        {
            _context = context;
        }

        public async Task<LichSuGia> GetGiaSanPhamMoiNhat(string id)
        {
            try
            {
                var data = await _context.LichSuGias
                    .Where(lsg => !lsg.DaXoa && lsg.MaSanPham.Equals(id))
                    .OrderBy(lsg => lsg.NgayTao.Date)
                    .ThenBy(d => d.NgayTao.TimeOfDay)
                    .FirstOrDefaultAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ThemGia(LichSuGia input)
        {
            //begin transaction
            await _context.Database.BeginTransactionAsync();

            //add

            await _context.LichSuGias.AddAsync(input);
            var result = await _context.SaveChangesAsync();

            await _context.Database.CommitTransactionAsync();
            return result > 0;
        }
    }
}
