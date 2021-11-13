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
    public class MauMaServices : IMauMaServices
    {
        private readonly EcomWebDbContext _context;
        public async Task<List<MauMaSanPham>> LayListMauMaTheoSanPham(string prdId)
        {
            return await _context.MauMaSanPhams
                .Where(mm => mm.MaSanPham.Equals(prdId))
                .ToListAsync();
        }
    }
}
