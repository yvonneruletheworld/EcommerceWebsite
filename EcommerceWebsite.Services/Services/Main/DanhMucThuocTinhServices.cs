using EcommerceWebsite.Data.EF;
using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Utilities.Output.Main;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebsite.Services.Interfaces.Main
{
   public class DanhMucThuocTinhServices : IDanhMucThuocTinhServices
    {
        private readonly EcomWebDbContext _context;

        public DanhMucThuocTinhServices(EcomWebDbContext context)
        {
            _context = context;
        }

        public async Task<List<ThuocTinh>> LayThuocTinhTheoDanhMuc(string maDanhMuc)
        {
            return await (from dmtt in _context.DanhMucThuocTinhs 
                          join tt in _context.ThuocTinhs on dmtt.MaThuocTinh equals tt.MaThuocTinh
                          where dmtt.MaDanhMuc == maDanhMuc
                          select new ThuocTinh()
                          {
                              MaThuocTinh = dmtt.MaThuocTinh,
                              TenThuocTinh = tt.TenThuocTinh
                          }).ToListAsync();
        }
    }
}
