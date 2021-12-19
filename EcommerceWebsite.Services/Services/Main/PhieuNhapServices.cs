using EcommerceWebsite.Data.EF;
using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Services.Interfaces.Main;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebsite.Services.Services.Main
{
    public class PhieuNhapServices : IPhieuNhapServices
    {
        private readonly EcomWebDbContext _context;

        public PhieuNhapServices(EcomWebDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateNewInventoryVoucher(PhieuNhap input)
        {
            //begin transaction
            await _context.Database.BeginTransactionAsync();

            //setup obj
            input.NgayTao = DateTime.UtcNow;
            input.DaXoa = false;
            //add

            await _context.PhieuNhaps.AddAsync(input);
            var result = await _context.SaveChangesAsync();

            await _context.Database.CommitTransactionAsync();

            if (result > 0)
            {
                var rsDetail = await CreateNewInventoryVoucherDetail(input.ChiTietNhapSanPhams);
                return rsDetail;
            }
            return false;
        }

        private async Task<bool> CreateNewInventoryVoucherDetail(List<ChiTietNhapSanPham> inputs)
        {
            //begin transaction
            await _context.Database.BeginTransactionAsync();


            await _context.ChiTietNhapSanPhams.AddRangeAsync(inputs);
            var result = await _context.SaveChangesAsync();

            await _context.Database.CommitTransactionAsync();

            return result > 0;
        }

        public async Task<List<PhieuNhap>> GetAllInventoryVoucher()
        {
            return await _context.PhieuNhaps.ToListAsync();
        }

        public async Task<List<ChiTietNhapSanPham>> GetAllInventoryVoucherDetail(string maPhieuNhap)
        {
            return await _context.ChiTietNhapSanPhams
                .Where(ct => ct.MaNhap == maPhieuNhap).ToListAsync();
        }
    }
}
