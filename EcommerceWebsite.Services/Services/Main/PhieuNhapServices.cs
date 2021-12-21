using EcommerceWebsite.Data.EF;
using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Data.Enum;
using EcommerceWebsite.Services.Interfaces.Main;
using EcommerceWebsite.Utilities.Output.Main;
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
            PhieuNhap obj = input;
            List<ChiTietNhapSanPham> lstObj = input.ChiTietNhapSanPhams; 
            obj.ChiTietNhapSanPhams = null;
            await _context.Database.BeginTransactionAsync();

            //setup obj
            input.NgayTao = DateTime.Now;
            input.DaXoa = false;
            //add

            await _context.PhieuNhaps.AddAsync(obj);
            var result = await _context.SaveChangesAsync();

            await _context.Database.CommitTransactionAsync();

            //return result > 0;
            if (result > 0)
            {
                var rsDetail = await CreateNewInventoryVoucherDetail(lstObj);
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
        
        public async Task<List<SanPhamNhapOutput>> GetListImportProduct(string maSanPham)
        {
            try
            {
                var data = await (from pn in _context.PhieuNhaps
                                  join ctn in _context.ChiTietNhapSanPhams on pn.MaPhieuNhap equals ctn.MaNhap into pn_ctn_group
                                  from pn_ctn in pn_ctn_group.DefaultIfEmpty()
                                  join sp in _context.SanPhams on pn_ctn.MaSanPham equals sp.MaSanPham
                                  from dl in _context.DinhLuongs
                                                            .Where(dl => dl.MaSanPham.Equals(sp.MaSanPham)
                                                            && dl.MaThuocTinh == (nameof(ProductPorpertyCode.TT014))).Take(1)
                                      //join lsg in _context.BangGiaSanPhams on sp_dl.MaDinhLuong equals lsg.MaDinhLuong into dl_lsg_group
                                  from dl_lsg in _context.BangGiaSanPhams.Where(lsg => lsg.MaDinhLuong.Equals(dl.MaDinhLuong)
                                                                && !lsg.DaXoa)
                                                                .OrderByDescending(lsg => lsg.NgayTao.Date).Take(1)
                                  where !sp.DaXoa && sp.MaSanPham == maSanPham
                                  select new SanPhamNhapOutput()
                                  {
                                      MaSanPham = sp.MaSanPham,
                                      TenSanPham = sp.TenSanPham,
                                      DonGiaNhap = pn_ctn.DonGia,
                                      GiaBan = dl_lsg.GiaMoi,
                                      SoLuongNhap = pn_ctn.SoLuong,
                                      ThanhTien = pn_ctn.ThanhTien,
                                      NgayNhap = pn.NgayTao
                                  }).ToListAsync();

                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
