using EcommerceWebsite.Application.Constants;
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
        private readonly ISanPhamServices _sanPhamServices;

        public HUIServices(EcomWebDbContext context, IHoaDonServices hoaDonServices, ISanPhamServices sanPhamServices)
        {
            _context = context;
            _hoaDonServices = hoaDonServices;
            _sanPhamServices = sanPhamServices;
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
                if (!line.Contains(":"))
                {
                    HUI hui = new HUI()
                    {
                        Id = "minuntil",
                        Utility = double.Parse(line.Trim()),
                    };
                    yield return hui;
                    
                }else
                {
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
                                 join sp in _context.SanPhams on hui.MaSanPham equals sp.NguoiXoa
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

                var listHoaDon = await (from cthd in _context.ChiTietHoaDons
                                        join hd in _context.HoaDons on cthd.HoaDonId equals hd.MaHoaDon
                                        where cthd.MaHUI == hui.ComboCode 
                                        && DateTime.Compare(hui.NgayTao.Date, hd.NgayTao.Date) <= 0
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
                .Where(hc => hc.ComboCode == comboCode && hc.NgayTao.Date == ngayTao.Date )
                .Select(item => new HUIDetailVM()
                {
                    ComboCode = item.ComboCode,
                    Utility = item.Utility,
                    MinUtility = item.NguoiTao
                }).FirstOrDefaultAsync();
               
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
                              join sp in _context.SanPhams on hui.MaSanPham equals sp.NguoiXoa into hui_sp_group
                              from hui_sp in hui_sp_group.DefaultIfEmpty()
                              join ctn in _context.ChiTietNhapSanPhams on hui_sp.MaSanPham equals ctn.MaSanPham into sp_ct_group
                              from sp_ct in sp_ct_group.DefaultIfEmpty()
                              join pn in _context.PhieuNhaps.Where(p => (DateTime.Compare(p.NgayTao.Date, ngayTao.Date) == 0 ?
                                                                TimeSpan.Compare(p.NgayTao.TimeOfDay, ngayTao.TimeOfDay) <= 0
                                                                : DateTime.Compare(p.NgayTao.Date, ngayTao.Date) <= 0))
                                                              .OrderByDescending(d => d.NgayTao.Date)
                                                              .ThenByDescending(d => d.NgayTao.TimeOfDay).Take(1) on sp_ct.MaNhap equals pn.MaPhieuNhap
                              where hui.NgayTao.Date == ngayTao.Date && hui.ComboCode == comboCode && !hui_sp.DaXoa
                              select new DoanhThuOutput()
                              {
                                  MaSanPham = hui_sp.NguoiXoa,
                                  TenSanPham = hui_sp.TenSanPham,
                                  DonGiaNhap = sp_ct.DonGia,
                                  DaXoa =  hui.DaXoa,
                                  //LoiNhuan = (float)hui_sp.Utility,
                                  GiaHUI = hui.Cost
                              }).ToListAsync();
            
            var tmp = await (from hui in _context.HUICosts
                              join sp in _context.SanPhams on hui.MaSanPham equals sp.NguoiXoa into hui_sp_group
                              from hui_sp in hui_sp_group.DefaultIfEmpty()
                              join ctn in _context.ChiTietNhapSanPhams on hui_sp.MaSanPham equals ctn.MaSanPham into sp_ct_group
                              from sp_ct in sp_ct_group.DefaultIfEmpty()
                              where hui.NgayTao.Date == ngayTao.Date && hui.ComboCode == comboCode && !hui_sp.DaXoa
                              select new DoanhThuOutput()
                              {
                                  MaSanPham = hui_sp.NguoiXoa,
                                  TenSanPham = hui_sp.TenSanPham,
                                  DonGiaNhap = sp_ct.DonGia,
                                  NgayNhap = sp_ct.PhieuNhapEntity.NgayTao,
                                  //LoiNhuan = (float)hui_sp.Utility,
                                  DaXoa = hui.DaXoa,
                                  GiaHUI = hui.Cost
                              }).ToListAsync();

            var tmp2 = tmp.Where(p => (DateTime.Compare(p.NgayNhap.Date, ngayTao.Date) == 0 ?
                                                                TimeSpan.Compare(p.NgayNhap.TimeOfDay, ngayTao.TimeOfDay) <= 0
                                                                : DateTime.Compare(p.NgayNhap.Date, ngayTao.Date) <= 0))
                                                              .OrderByDescending(d => d.NgayNhap.Date)
                                                              .ThenByDescending(d => d.NgayNhap.TimeOfDay)
                                                              .ToList();
            return data.Count() == 0 ? tmp2 : data;
        }

        public async Task<bool> UpdateHUIItemsetCode()
        {
            var listSanPham = await _context.SanPhams.ToListAsync();
            if(listSanPham != null)
            {
                foreach(var sp in listSanPham)
                {
                    var code = Randoms.RandomString().ToUpper();
                    sp.NguoiXoa = code;
                    var rs = await _sanPhamServices.SuaHoacXoaSanPham(sp, false);
                    if (!rs) return false;
                }
                return true;
            }
            return false;
        }

        public async Task<bool> SuaGiaHUI(string maHUI, decimal giaTien, string comboCode, DateTime ngayTao)
        {
            try
            {
                await _context.Database.BeginTransactionAsync();
                var obj = await _context.HUICosts
                    .SingleOrDefaultAsync(sp => sp.MaSanPham == maHUI && sp.ComboCode == comboCode && sp.NgayTao.Date == ngayTao.Date);
                if (obj == null) return false;

                obj.Cost = giaTien;
                // 
                _context.Entry<HUICost>(obj).State = EntityState.Detached;
                _context.HUICosts.Update(obj);

                var rs = await _context.SaveChangesAsync();
                await _context.Database.CommitTransactionAsync();

                return rs > 0;
            }
            catch (Exception ex)
            {
                await _context.Database.RollbackTransactionAsync();
                throw ex;
            }
        }

        public async Task<bool> UpdateHUIItemsetCode(DateTime ngaySua)
        {
            var ngayTao = (await _context.HUICosts.OrderByDescending(hc => hc.NgayTao.Date)
                                                   .ThenByDescending(hc => hc.NgayTao.TimeOfDay)
                                                   .FirstOrDefaultAsync()).NgayTao;

            var listSanPham = await _context.HUICosts.Where(hc => hc.NgayTao == ngayTao).ToListAsync();
            if (listSanPham != null)
            {
                var err = 0;
                foreach(var hc in listSanPham)
                {
                    hc.NgaySuaCuoi = ngaySua;
                    try
                    {
                        await _context.Database.BeginTransactionAsync();
                        _context.Entry<HUICost>(hc).State = EntityState.Detached;
                        _context.HUICosts.Update(hc);

                        var rs = await _context.SaveChangesAsync();
                        await _context.Database.CommitTransactionAsync();
                        err += rs > 0 ? 0 : 1;
                        
                    }
                    catch (Exception ex)
                    {
                        continue;
                        throw ex;
                    }
                }
                return err == 0;
            }
            return false;
        }
    }
}
