using EcommerceWebsite.Data.EF;
using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Data.Enum;
using EcommerceWebsite.Services.Interfaces.Main;
using EcommerceWebsite.Utilities.Output.Main;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
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
        
        public async Task<List<DoanhThuOutput>> GetListImportProduct(string maSanPham)
        {
            try
            {
                var data = await (from pn in _context.PhieuNhaps
                                  join ctn in _context.ChiTietNhapSanPhams on pn.MaPhieuNhap equals ctn.MaNhap into pn_ctn_group
                                  from pn_ctn in pn_ctn_group.DefaultIfEmpty()
                                  //join cthd in _context.ChiTietHoaDons on pn_ctn.MaSanPham equals cthd.ProductId into cthd_ctn_group
                                  //from cthd_ctn in cthd_ctn_group.DefaultIfEmpty()
                                  //join hd in _context.HoaDons on cthd_ctn.HoaDonId equals hd.MaHoaDon into cthd_hd_group
                                  //from cthd_hd in cthd_hd_group.DefaultIfEmpty()
                                  where  !pn.DaXoa && pn_ctn.MaSanPham == maSanPham
                                  select new DoanhThuOutput()
                                  {
                                      MaSanPham = pn_ctn.MaSanPham,
                                      SoLuongNhap = pn_ctn.SoLuong,
                                      DonGiaNhap = pn_ctn.DonGia,
                                      TongTienNhap = pn_ctn.ThanhTien,
                                      NgayNhap = pn.NgayTao,
                                  }).OrderByDescending(lsg => lsg.NgayNhap.Date)
                                    .ThenByDescending(d => d.NgayNhap.TimeOfDay).ToListAsync();
                if(data != null && data.Count() > 0)
                {
                    var listHoaDonCuaSanPham = await (from hd in _context.HoaDons
                                                      join cthd in _context.ChiTietHoaDons on hd.MaHoaDon equals cthd.HoaDonId
                                                      where cthd.ProductId == maSanPham
                                                      select new ChiTietHoaDon()
                                                      {
                                                          HoaDons = hd,
                                                          GiaBan = cthd.GiaBan,
                                                          MaHUI = cthd.MaHUI,
                                                          HoaDonId = hd.MaHoaDon,
                                                          ProductId = cthd.ProductId,
                                                          SoLuong = cthd.SoLuong
                                                      }).ToListAsync();
                    //set up receipt

                    var currentDate = DateTime.Now;
                    if(data.Count() == 1)
                    {
                        // nhap lan dau
                        var listDonHang = listHoaDonCuaSanPham
                            .Where(cthd => DateTime.Compare(cthd.HoaDons.NgayTao, currentDate) >= 0)
                            .ToList();
                        var daBan = listDonHang.Sum(ldh => ldh.SoLuong);
                        data[0].DaBan = daBan;
                        data[0].DonGiaBan = listDonHang.Count() == 0 ? 0 : (decimal)(listDonHang[0].GiaBan);
                        data[0].TongTienBan = listDonHang.Sum(ldh => ldh.SoLuong * ldh.GiaBan);
                    }
                    else
                    {
                        for(int i = 0; i < data.Count(); i++)
                        {
                            
                            var curDate = data[i].NgayNhap;
                            var nextDate = i == 0 ? currentDate : data[i-1].NgayNhap;
                            
                            var listDonHang = listHoaDonCuaSanPham
                                            .Where(cthd => DateTime.Compare(cthd.HoaDons.NgayTao, nextDate) <= 0
                                            && DateTime.Compare(cthd.HoaDons.NgayTao, curDate) >= 0)
                                            .ToList();
                            var daBan = listDonHang.Sum(ldh => ldh.SoLuong);
                            var tienBan = listDonHang.Sum(ldh => ldh.SoLuong * ldh.GiaBan);
                            data[i].DaBan = daBan;
                            data[i].DonGiaBan = listDonHang.Count() == 0 ? 0: (decimal)(listDonHang[0].GiaBan) ;
                            data[i].TongTienBan = tienBan;
                        }    
                    }    
                }

                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<decimal> GetRecentlyPrice(string maSanPham)
        {
            try
            {
                var data = await (from pn in _context.PhieuNhaps
                                  join ctn in _context.ChiTietNhapSanPhams on pn.MaPhieuNhap equals ctn.MaNhap into pn_ctn_group
                                  from pn_ctn in pn_ctn_group.DefaultIfEmpty()
                                  join sp in _context.SanPhams on pn_ctn.MaSanPham equals sp.MaSanPham into pn_sp_group
                                  from sp_ctn in pn_sp_group.DefaultIfEmpty()
                                  where !sp_ctn.DaXoa && sp_ctn.MaSanPham == maSanPham
                                  select new ChiTietNhapSanPham()
                                  {
                                      DonGia = pn_ctn.DonGia,
                                      PhieuNhapEntity = pn 
                                  }).ToListAsync();

                return data.OrderByDescending(ctn => ctn.PhieuNhapEntity.NgayTao.Date)
                    .FirstOrDefault().DonGia;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
