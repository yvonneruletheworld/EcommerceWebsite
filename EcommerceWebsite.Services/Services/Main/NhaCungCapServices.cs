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
    public class NhaCungCapServices : INhaCungCapServices
    {
        private readonly EcomWebDbContext _context;

        public NhaCungCapServices(EcomWebDbContext context)
        {
            _context = context;
        }
        public async Task<List<NhaCungCap>> layNhaCungCap()
        {
            try
            {
                return await _context.NhaCungCaps.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
