using EcommerceWebsite.Data.EF;
using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Services.Interfaces.Main;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebsite.Services.Services.Main
{
    public class LichSuGiaServices : ILichSuGiaServices
    {
        private readonly EcomWebDbContext _context;

        public LichSuGiaServices(EcomWebDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ThemGiaMoiTheoMaSanPham(LichSuGia input)
        {
            try
            {
                await _context.Database.BeginTransactionAsync();
                //
                input.DaXoa = false;
                input.NgayTao = DateTime.UtcNow;
                //

                await _context.LichSuGias.AddAsync(input);
                var result = await _context.SaveChangesAsync();
                await _context.Database.CommitTransactionAsync();

                return result > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
