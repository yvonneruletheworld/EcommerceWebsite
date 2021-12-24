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
    public class BangGiaServices : IBangGiaServices
    {
        private readonly EcomWebDbContext _context;

        public BangGiaServices(EcomWebDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// De hien thi VM san pham: Get gia san pham moi nhat. Điều kiện: Mỗi sản phẩm có các thông số định lượng tương ứng sẽ có các mức giá khác nhau.
        /// Lấy giá mowist nhất bằng cách: Join định lượng và giá => Lọc bằng mã sản phẩm, Group by mã đ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BangGiaOutput> GetGiaSanPhamMoiNhat(string maDinhLuong)
        {
            try
            {
                var data = await (from dl in _context.DinhLuongs
                                  join lsg in _context.BangGiaSanPhams on dl.MaDinhLuong equals lsg.MaDinhLuong into dl_lsg_group
                                  from dl_lsg in dl_lsg_group.DefaultIfEmpty()
                                                            .OrderByDescending(lsg => lsg.NgayTao.Date)
                                                            .ThenByDescending(d => d.NgayTao.TimeOfDay)
                                  where dl.MaDinhLuong == maDinhLuong && !dl_lsg.DaXoa && dl.GiaTri != "0"
                                  select new BangGiaOutput
                                  {
                                      MaDinhLuong = dl.MaDinhLuong, // Dinh luong
                                      GiaBan = dl_lsg.GiaMoi
                                  }).FirstOrDefaultAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
         
        /// <summary>
        /// Dung de hien thi gia o trang chi tiet
        /// </summary>
        /// <param name="prdId"></param>
        /// <returns></returns>
        public async Task<List<BangGiaOutput>> LayBangGiaSanPham (string prdId)
        {
            try
            {
                var data = await (from dl in _context.DinhLuongs
                                  join lsg in _context.BangGiaSanPhams on dl.MaDinhLuong equals lsg.MaDinhLuong into dl_lsg_group
                                  from dl_lsg in dl_lsg_group.DefaultIfEmpty()
                                  where dl.MaSanPham == prdId && !dl_lsg.DaXoa && dl.GiaTri != "0"
                                  select new BangGiaOutput
                                  {
                                      MaThuocTinh = dl.MaThuocTinh,
                                      MaDinhLuong = dl.MaDinhLuong, // Dinh luong
                                      TenDinhLuong =  dl.GiaTri + " " + dl.DonVi,
                                      GiaBan = dl_lsg.GiaMoi,
                                      NgayTao = dl_lsg.NgayTao
                                  }).OrderByDescending(bg => bg.NgayTao.Date)
                                  .ThenByDescending(bg => bg.NgayTao.TimeOfDay).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ThemGia(BangGiaSanPham input)
        {
            //begin transaction
            await _context.Database.BeginTransactionAsync();

            //add

            await _context.BangGiaSanPhams.AddAsync(input);
            var result = await _context.SaveChangesAsync();

            await _context.Database.CommitTransactionAsync();
            return result > 0;
        }

        public async Task<bool> ModifyPrice(BangGiaSanPham ls)
        {
            try
            {
                if (ls == null)
                    return false;
                await _context.Database.BeginTransactionAsync();
                ls.DaXoa = false;
                ls.NgayTao = DateTime.UtcNow;
                 _context.BangGiaSanPhams.Update(ls);
                _context.Entry(ls).State = EntityState.Modified;
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

        public async Task<bool> ThemBangGia(List<BangGiaSanPham> input)
        {
            try
            {
                //begin transaction
                await _context.Database.BeginTransactionAsync();

                //add

                await _context.BangGiaSanPhams.AddRangeAsync(input);
                var result = await _context.SaveChangesAsync();

                await _context.Database.CommitTransactionAsync();
                return result > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
