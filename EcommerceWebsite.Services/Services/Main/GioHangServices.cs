using AutoMapper;
using EcommerceWebsite.Data.EF;
using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Services.Interfaces.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebsite.Services.Services.Main
{
    public class GioHangServices : IGioHangServices
    {
        private readonly EcomWebDbContext _context;
        private readonly IMapper _mapper;

        public GioHangServices(EcomWebDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> ThemChiTietHoaDon(ChiTietHoaDon ct)
        {
            var duLieu = _context.ChiTietHoaDons.FirstOrDefault(x => x.HoaDonId == ct.HoaDonId && x.ProductId == ct.ProductId);
            if (duLieu != null)
            {
                return false;

            }
            else
            {
                //begin transaction
                await _context.Database.BeginTransactionAsync();
                //add
                await _context.ChiTietHoaDons.AddAsync(ct);
                var result = await _context.SaveChangesAsync();

                await _context.Database.CommitTransactionAsync();

                return true;
            }
        }

        public async Task<bool> ThemHoaDon(HoaDon hD)
        {
            var duLieu = _context.HoaDons.FirstOrDefault(x => x.MaHoaDon == hD.MaHoaDon);
            if (duLieu != null)
            {
                return false;

            }
            else
            {
                //begin transaction
                await _context.Database.BeginTransactionAsync();
                //add
                //Hóa đơn
                await _context.HoaDons.AddAsync(hD);
                var result = await _context.SaveChangesAsync();

                await _context.Database.CommitTransactionAsync();

                return true;
            }
        }
    }
}
