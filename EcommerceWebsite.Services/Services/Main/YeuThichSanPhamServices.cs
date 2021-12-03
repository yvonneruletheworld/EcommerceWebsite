using AutoMapper;
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
    public class YeuThichSanPhamServices : IYeuThichSanPhamServices
    {
        private readonly EcomWebDbContext _context;
        private readonly IMapper _mapper;

        public YeuThichSanPhamServices(EcomWebDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SanPhamYeuThich> LaySPYeuThich(string MaSanPham, string maKhachHang)
        {
            return await _context.SanPhamYeuThiches
                .Where(x => !x.trangThai
                && x.MaSanPham == MaSanPham && x.MaKhachHang == maKhachHang)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> ThemYeuThich(SanPhamYeuThich input)
        {
            //begin transaction
            await _context.Database.BeginTransactionAsync();

            //add
            await _context.SanPhamYeuThiches.AddAsync(input);
            var result = await _context.SaveChangesAsync();

            await _context.Database.CommitTransactionAsync();

            return result > 0;
        }
    }
}
