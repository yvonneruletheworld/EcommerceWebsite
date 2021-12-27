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

            return result > 0;
        }

        public async Task<bool> CreateNewInventoryVoucherDetail(ChiTietNhapSanPham inputs)
        {
            //begin transaction
            await _context.Database.BeginTransactionAsync();


            await _context.ChiTietNhapSanPhams.AddAsync(inputs);
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
                                  from ctn_pn in pn_ctn_group.DefaultIfEmpty()
                                  join sp in _context.SanPhams on ctn_pn.MaSanPham equals sp.MaSanPham into ctn_sp_group
                                  from sp_ctn in ctn_sp_group.DefaultIfEmpty()
                                  where  !pn.DaXoa && sp_ctn.MaSanPham == maSanPham
                                  select new DoanhThuOutput()
                                  {
                                      MaSanPham = ctn_pn.MaSanPham,
                                      SoLuongNhap = ctn_pn.SoLuong,
                                      DonGiaNhap = ctn_pn.DonGia,
                                      TongTienNhap = ctn_pn.SoLuong * ctn_pn.DonGia,
                                      NgayNhap = pn.NgayTao,
                                      SoLuongTon = ctn_pn.SoLuong,
                                      SoLuongTonKyTruoc = 0,
                                      LoiNhuan = 0
                                  }).OrderBy(lsg => lsg.NgayNhap.Date)
                                    .ThenBy(d => d.NgayNhap.TimeOfDay).ToListAsync();
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
                    if(listHoaDonCuaSanPham.Count >= 0)
                    {
                        var currentDate = DateTime.Now;
                        //if (data.Count() == 1)
                        //{
                        //    // nhap lan dau
                        //    var listDonHang = listHoaDonCuaSanPham
                        //        .Where(cthd => DateTime.Compare(cthd.HoaDons.NgayTao, currentDate) >= 0)
                        //        .ToList();
                        //    var daBan = listDonHang.Sum(ldh => ldh.SoLuong);
                        //    data[0].DaBan = daBan;
                        //    data[0].SoLuongTon = data[0].SoLuongNhap - daBan;
                        //    data[0].DonGiaBan = listDonHang.Count() == 0 ? 0 : (decimal)(listDonHang[0].GiaBan);
                        //    data[0].TongTienBan = listDonHang.Sum(ldh => ldh.SoLuong * ldh.GiaBan);
                        //    data[0].LoiNhuan = TinhLoiNhuan(data[0].TongTienBan, data[0].TongTienNhap);
                        //}
                        //else
                        //{
                            var soTonKiTruoc = 0;
                            for (int i = 0; i < data.Count(); i++)
                            {
                                //tu ngay nhap nho den lon
                                var curDate = data[i].NgayNhap;
                                var nextDate = i == data.Count() - 1 ? currentDate : data[i + 1].NgayNhap;
                                var previousDate = i == 0 ? curDate : data[i - 1].NgayNhap ;
                                var listDonHang = listHoaDonCuaSanPham
                                                .Where(cthd => (DateTime.Compare(cthd.HoaDons.NgayTao.Date, nextDate.Date) == 0 ?
                                                TimeSpan.Compare(cthd.HoaDons.NgayTao.TimeOfDay, nextDate.TimeOfDay) <= 0 
                                                : DateTime.Compare(cthd.HoaDons.NgayTao.Date, nextDate.Date) <= 0)
                                                && (DateTime.Compare(cthd.HoaDons.NgayTao.Date, curDate.Date) == 0 ?
                                                TimeSpan.Compare(cthd.HoaDons.NgayTao.TimeOfDay, curDate.TimeOfDay) >= 0
                                                : DateTime.Compare(cthd.HoaDons.NgayTao.Date, curDate.Date) >= 0))
                                                .ToList();
                                var daBan = listDonHang.Sum(ldh => ldh.SoLuong);
                                var daBanKiTruoc = i == 0 ? 0 : data[i - 1].DaBan;

                                var tienBan = listDonHang.Sum(ldh => ldh.SoLuong * ldh.GiaBan);
                                //var tienBanKiTruoc = listDonHangKiTruoc.Sum(ldh => ldh.SoLuong * ldh.GiaBan);

                                soTonKiTruoc += i == 0 ? 0 : data[i - 1].SoLuongNhap - daBanKiTruoc;
                                data[i].DaBan = daBan;
                                data[i].SoLuongTonKyTruoc = i == 0? 0 : soTonKiTruoc;
                                data[i].SoLuongTon = data[i].SoLuongNhap - daBan + data[i].SoLuongTonKyTruoc;
                                data[i].DonGiaBan = listDonHang.Count() == 0 ? 0 : (decimal)(listDonHang[0].GiaBan);
                                data[i].TongTienBan = tienBan;
                                data[i].LoiNhuan = TinhLoiNhuan(data[i].TongTienBan, data[i].TongTienNhap);
                            }
                        //}
                    }
                   
                }

                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private float TinhLoiNhuan(decimal tongTienBan, decimal tongTienNhap)
        {
            return (float)(((tongTienBan - tongTienNhap) / tongTienNhap) * 100);
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
