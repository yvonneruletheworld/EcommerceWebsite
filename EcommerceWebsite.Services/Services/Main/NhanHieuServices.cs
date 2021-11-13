using EcommerceWebsite.Data.EF;
using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Services.Interfaces.Main;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebsite.Services.Services.Main
{
    public class NhanHieuServices : INhanHieuServices
    {
        private readonly EcomWebDbContext _context;

        public NhanHieuServices(EcomWebDbContext context)
        {
            _context = context;
        }
        public async Task<List<NhanHieu>> layHangSanPham()
        {
            try
            {
                return await _context.NhanHieus.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
