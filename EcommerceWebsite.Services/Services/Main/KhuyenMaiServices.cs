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
    public class KhuyenMaiServices : IKhuyenMaiServices
    {
        private readonly EcomWebDbContext _context;

        public KhuyenMaiServices(EcomWebDbContext context)
        {
            _context = context;
        }

        public async Task<List<KhuyenMai>> layKhuyenMai()
        {
            try
            {
                return await _context.KhuyenMais.Where(dm => !dm.DaXoa).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
