using AutoMapper;
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
    public class GioHangServices : IGioHangServices
    {
        private readonly EcomWebDbContext _context;
        private readonly IMapper _mapper;

        public GioHangServices(EcomWebDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> DuyetDonHang(string MaHD)
        {

            var duLieu = _context.HoaDons.FirstOrDefault(x => x.MaHoaDon == MaHD);
            if (duLieu != null)
            {
               
                    await _context.Database.BeginTransactionAsync();
                    duLieu.TinhTrang = "Đã duyệt";
                    _context.HoaDons.Update(duLieu);
                //Thêm giao hàng:

                    GiaoHang gh = new GiaoHang()
                    {
                        MaHoaDon = MaHD,
                        TrangThaiHienTai = "Chờ lấy hàng",
                        NgayTiepNhan = DateTime.Now,
                        NgayDuKienGiao = DateTime.Now,
                        NgayTao = DateTime.Now,
                        DaXoa = false,
                    };
                    _context.GiaoHangs.Add(gh);
                var rs = await _context.SaveChangesAsync();
               
                    await _context.Database.CommitTransactionAsync();
                    return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<HoaDon>> LayDonHangDaDuyet()
        {
            try
            {
                var data = await _context.HoaDons.Where(s => s.TinhTrang == "Đã duyệt").ToListAsync();
                return data;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<HoaDon>> LayDonHangDangDuyet()
        {
            try
            {
                var data = await _context.HoaDons.Where(s => s.TinhTrang == "Đang xử lý").ToListAsync();
                return data;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> ThemChiTietHoaDon(ChiTietHoaDon ct)
        {
            try
            {
                await _context.Database.BeginTransactionAsync();
                //add
                await _context.ChiTietHoaDons.AddAsync(ct);
                var result = await _context.SaveChangesAsync();

                await _context.Database.CommitTransactionAsync();

                return true;
            }
            catch (Exception )
            {
                return false;
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
