using EcommerceWebsite.Data.EF;
using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Services.Interfaces.System;
using EcommerceWebsite.Utilities.Output.System;
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

        public HUIServices(EcomWebDbContext context)
        {
            _context = context;
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

        //    public async Task<Dictionary<DateTime,List<HUI>>> GetHUICosts()
        //    {
        //        var listHui = await _context.HUICosts.OrderByDescending(bl => bl.NgayTao.Date)
        //                        .ThenByDescending(bl => bl.NgayTao.TimeOfDay)
        //                        .ToListAsync(); 

        //        var rs = new Dictionary<DateTime, List<HUI>>();
        //        var dicHui = listHui.GroupBy(hc => hc.NgayTao)
        //            .ToDictionary(hc=> hc.Key, hc => hc.ToList());
        //        for(int i = 0; i< dicHui.Keys.Count(); i++)
        //        {
        //            //loc xong ngay
        //            var value = new List<HUI>();
        //            var key = dicHui.Keys.ElementAt(i);
        //            var nextKey = i==0? DateTime.Now : dicHui.Keys.ElementAt(i - 1);
        //            foreach(var hui in dicHui[key])
        //            {

        //                var listHoaDon = await (from cthd in _context.ChiTietHoaDons
        //                                        join hd in _context.HoaDons on cthd.HoaDonId equals hd.MaHoaDon
        //                                        join sp in _context.SanPhams on hui.MaSanPham equals sp.MaSanPham
        //                                        where cthd.MaHUI == hui.ComboCode && cthd.ProductId == hui.MaSanPham
        //                                        && DateTime.Compare(hui.NgayTao, hd.NgayTao) <= 0
        //                                        && DateTime.Compare(nextKey,hd.NgayTao) >= 0
        //                                        select new ChiTietHoaDon()
        //                                        {
        //                                            SanPhams = sp,
        //                                            SoLuong = cthd.SoLuong,
        //                                            GiaBan = cthd.GiaBan
        //                                        }).ToListAsync(); 

        //                var tmp = await (from sp in _context.SanPhams
        //                                 join cthd in _context.ChiTietHoaDons on sp.MaSanPham equals cthd.ProductId 
        //                                 join hd in _context.HoaDons on cthd.HoaDonId equals hd.MaHoaDon
        //                                        join sp in _context.SanPhams on hui.MaSanPham equals sp.MaSanPham
        //                                        where cthd.MaHUI == hui.ComboCode && cthd.ProductId == hui.MaSanPham
        //                                        && DateTime.Compare(hui.NgayTao, hd.NgayTao) <= 0
        //                                        && DateTime.Compare(nextKey,hd.NgayTao) >= 0
        //                                        select new ChiTietHoaDon()
        //                                        {
        //                                            SanPhams = sp,
        //                                            SoLuong = cthd.SoLuong,
        //                                            GiaBan = cthd.GiaBan
        //                                        }).ToListAsync();
        //                var item = new HUI()
        //                {
        //                    Id = hui.ComboCode,
        //                    TongGia = hui.Cost,
        //                    DaBan = listHoaDon.Sum(ct => ct.SoLuong),
        //                    ThucBan = listHoaDon.Sum(ct => ct.SoLuong * ct.GiaBan),
        //                    SanPhams = listHoaDon
        //                };
        //                value.Add(item);
        //            }
        //            rs.Add(key,value);
        //        }
        //        return rs;
        //    }
        //}

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
    }
}
