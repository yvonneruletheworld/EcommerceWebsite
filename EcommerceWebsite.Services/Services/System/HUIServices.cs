using EcommerceWebsite.Data.EF;
using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Services.Interfaces.Main;
using EcommerceWebsite.Services.Interfaces.System;
using EcommerceWebsite.Utilities.Output.Main;
using EcommerceWebsite.Utilities.Output.System;
using EcommerceWebsite.Utilities.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebsite.Services.Services.System
{
    public class HUIServices : IHUIServices
    {
        private readonly EcomWebDbContext _context;
        private readonly IHoaDonServices _hoaDonServices;

        public HUIServices(EcomWebDbContext context, IHoaDonServices hoaDonServices)
        {
            _context = context;
            _hoaDonServices = hoaDonServices;
        }

        public Task<Dictionary<string, List<string>>> ModifyListOutput(List<HUI> inputList)
        {
            // sort asc
            inputList = inputList.OrderByDescending(hui => hui.Utility).ToList();

            //get item
            var listItem = new List<string>();
            foreach (var hui in inputList)
            {
                listItem = ReadListHUI(hui.Itemsets, listItem).ToList();
            }
            return null;
        }

        private IEnumerable<string> ReadListHUI(string[] itemSet, List<string> listItem)
        {
            foreach (var ip in itemSet)
            {
                if (!listItem.Contains(ip))
                {
                    yield return ip;
                }
            }
        }
        public async IAsyncEnumerable<HUI> ReadFromTextToList(string fileName)
        {
            using StreamReader reader = File.OpenText(fileName);
            var stt = 0;
            while (!reader.EndOfStream)
            {
                var line = await reader.ReadLineAsync();
                HUI hui = new HUI()
                {
                    Id = "hui-" + stt++,
                    Utility = double.Parse(line.Trim().Split(":")[1]),
                    Itemsets = line.Trim()
                                   .Split(":")[0].Split(",")
                                   .Select(it => it.Trim()).ToArray()
                };

                yield return hui;
            }
        }

        public async Task<bool> ThemHUICosts(List<HUICost> inputs)
        {
            //begin transaction
            await _context.Database.BeginTransactionAsync();

            //add

            await _context.HUICosts.AddRangeAsync(inputs);
            var result = await _context.SaveChangesAsync();

            await _context.Database.CommitTransactionAsync();
            return result > 0;
        }

        public async Task<Dictionary<DateTime, List<HUICost>>> GetHUICosts()
        {
            var listHui = await (from hui in _context.HUICosts
                                 join sp in _context.SanPhams on hui.MaSanPham equals sp.MaSanPham
                                 select new HUICost()
                                 {
                                     ComboCode = hui.ComboCode,
                                     Cost = hui.Cost,
                                     SanPhams = sp,
                                     DaXoa = hui.DaXoa,
                                     NgayTao = hui.NgayTao,
                                     Status = hui.Status
                                 }).OrderByDescending(bl => bl.NgayTao.Date)
                            .ThenByDescending(bl => bl.NgayTao.TimeOfDay)
                            .ToListAsync();

            foreach (var hui in listHui)
            {
                var i = listHui.IndexOf(hui);
                //var key = dicHui.Keys.ElementAt(i);
                var nextDate = i == 0 ? DateTime.Now : 
                    (listHui.ElementAt(i - 1).NgayTao == hui.NgayTao)? DateTime.Now : listHui.ElementAt(i - 1).NgayTao;

                var temp = await (from cthd in _context.ChiTietHoaDons
                                  join hd in _context.HoaDons on cthd.HoaDonId equals hd.MaHoaDon
                                  where cthd.MaHUI == hui.ComboCode
                                  select new ChiTietHoaDon()
                                  {
                                      HoaDons = hd,
                                      SoLuong = cthd.SoLuong,
                                      GiaBan = cthd.GiaBan
                                  }).ToListAsync();
                var listHoaDon = await (from cthd in _context.ChiTietHoaDons
                                        join hd in _context.HoaDons on cthd.HoaDonId equals hd.MaHoaDon
                                        where cthd.MaHUI == hui.ComboCode 
                                        && DateTime.Compare(hui.NgayTao, hd.NgayTao) <= 0
                                        && DateTime.Compare(nextDate, hd.NgayTao) >= 0
                                        select new ChiTietHoaDon()
                                        {
                                            ProductId = cthd.ProductId,
                                            SoLuong = cthd.SoLuong,
                                            GiaBan = cthd.GiaBan
                                        }).ToListAsync();
                var listHoaDonSanPham = listHoaDon.Where(cthd => cthd.ProductId == hui.SanPhams.MaSanPham).ToList();
                hui.DaBan = listHoaDonSanPham.Sum(ct => ct.SoLuong);
                hui.ThucBan = listHoaDonSanPham.Sum(ct => ct.SoLuong * ct.GiaBan);
                hui.SanPhams.ChiTietHoaDons = listHoaDonSanPham;
                hui.LuotTruyCap = listHoaDon.Count();
            }
            var rs = listHui.GroupBy(hc => hc.NgayTao)
                    .ToDictionary(hc=> hc.Key, hc => hc.ToList());
            return rs;
        }

        public Task<bool> SetUpGiaChoHUIItemset()
        {
            throw new NotImplementedException();
        }

        public async Task<HUIDetailVM> GetChiTietHUI(string comboCode, DateTime ngayTao, DateTime ngayNhapKe)
        {
            try
            {
                var result = await _context.HUICosts
                .Where(hc => hc.ComboCode == comboCode && hc.NgayTao == ngayTao)
                .Select(item => new HUIDetailVM()
                {
                    ComboCode = item.ComboCode,
                    Utility = item.Utility,
                }).FirstOrDefaultAsync();
                //get List product
                if (result != null)
                {
                    var listProduct = await GetListchiTietSanPhamHUI(result.ComboCode, ngayTao);
                    var listHoaDon = await _hoaDonServices.DanhSachHoaDonComboCode(comboCode, ngayTao, ngayNhapKe);
                    result.ListSanPhamHUIs = listProduct;
                    result.ListHoaDon = listHoaDon;
                    result.TongGiaSetUp = listProduct.Sum(sp => sp.GiaHUI);
                    result.DaBan = listHoaDon.Count();
                }
                return result;
            }
            catch (Exception es)
            {

                throw es;
            }
            //var result = new HUIDetailVM();
            //get huicost
            
        }

        private async Task<List<DoanhThuOutput>> GetListchiTietSanPhamHUI(string comboCode, DateTime ngayTao)
        {
            var data = await (from hui in _context.HUICosts
                              join sp in _context.SanPhams on hui.MaSanPham equals sp.MaSanPham into hui_sp_group
                              from hui_sp in hui_sp_group.DefaultIfEmpty()
                              join ctn in _context.ChiTietNhapSanPhams on hui_sp.MaSanPham equals ctn.MaSanPham into sp_ct_group
                              from sp_ct in sp_ct_group.DefaultIfEmpty()
                              join pn in _context.PhieuNhaps.Where(p => DateTime.Compare(p.NgayTao, ngayTao) <= 0)
                                                              .OrderByDescending(d => d.NgayTao.Date)
                                                              .ThenByDescending(d => d.NgayTao.TimeOfDay).Take(1) on sp_ct.MaNhap equals pn.MaPhieuNhap
                              where hui.NgayTao == ngayTao && hui.ComboCode == comboCode && !hui_sp.DaXoa
                              select new DoanhThuOutput()
                              {
                                  MaSanPham = hui_sp.NguoiXoa,
                                  TenSanPham = hui_sp.TenSanPham,
                                  DonGiaNhap = sp_ct.DonGia,
                                  //LoiNhuan = (float)hui_sp.Utility,
                                  GiaHUI = hui_sp.GiaHUI
                              }).ToListAsync();
            return data;
        }
    }
}
