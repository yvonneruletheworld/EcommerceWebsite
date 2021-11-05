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
    public class DanhMucServices : IDanhMucServices
    {
        private readonly EcomWebDbContext _context;

        public DanhMucServices(EcomWebDbContext context)
        {
            _context = context;
        }

        public async Task<List<DanhMucOutput>> GetDanhMucs()
        {
            try
            {
                return await _context.DanhMucs
                    .Where(dm => !dm.DaXoa)
                    .Select(item => new DanhMucOutput{ 
                        MaDanhMuc = item.MaDanhMuc,
                        HinhAnh = item.HinhAnh,
                        TenDanhMuc = item.TenDanhMuc
                     })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
