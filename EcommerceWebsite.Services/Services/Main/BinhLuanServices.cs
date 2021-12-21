using AutoMapper;
using EcommerceWebsite.Data.EF;
using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Data.Enum;
using EcommerceWebsite.Services.Interfaces.Main;
using EcommerceWebsite.Utilities.Output.Main;
using EcommerceWebsite.Utilities.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebsite.Services.Services.Main
{
    public class BinhLuanServices : IBinhLuanServices
    {
        private readonly EcomWebDbContext _context;
        private readonly IMapper _mapper;
        public BinhLuanServices(EcomWebDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<BinhLuanOutput>> LayBinhLuanTheoSanPham(string maSanPham)
        {
            return await (from bl in _context.BinhLuans 
                          join kh in _context.KhachHangs on (bl == null ? string.Empty : bl.NguoiTao) equals kh.MaKhachHang
                          where bl.MaSanPham == maSanPham && !bl.DaXoa
                          select new BinhLuanOutput ()
                          {
                              GioiTinh = kh.GioiTinh,
                              NgayTao = bl.NgayTao,
                              NguoiTao = kh.HoTen,
                              NoiDung = bl.NoiDung,
                              SoSao = bl.SoSao
                          }).OrderByDescending(bl => bl.NgayTao.Date)
                            .ThenByDescending(bl => bl.NgayTao.TimeOfDay)
                            .ToListAsync();
        }

        public async Task<bool> ThemBinhLuan(BinhLuan input)
        {
            try
            {
                var duLieu = _context.BinhLuans.FirstOrDefault(x => x.MaSanPham == input.MaSanPham && x.NguoiTao == input.NguoiTao && x.NgayTao == input.NgayTao);
                if (duLieu != null)
                {
                    return false;
                }
                else
                {
                    await _context.Database.BeginTransactionAsync();
                    await _context.BinhLuans.AddAsync(input);// này chạy ok 
                    await _context.SaveChangesAsync(); // Chạy tới dòng này bị bung 

                    await _context.Database.CommitTransactionAsync();

                    return true;
                }    
                  
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
