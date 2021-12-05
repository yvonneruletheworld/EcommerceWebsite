using AutoMapper;
using EcommerceWebsite.Data.EF;
using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Data.Enum;
using EcommerceWebsite.Services.Interfaces.Main;
using EcommerceWebsite.Utilities.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebsite.Services.Services.Main
{
    public class YeuThichSanPhamServices : IYeuThichSanPhamServices
    {
        private readonly EcomWebDbContext _context;
        private readonly IMapper _mapper;

        public YeuThichSanPhamServices(EcomWebDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<SanPhamVM>> laySanPhamYeuThich(string MaKH)
        {
            try
            {
                var data = await (from sp in _context.SanPhams.OrderByDescending(s => s.NgayTao)
                                  from yt in _context.SanPhamYeuThiches 
                                  join dm in _context.DanhMucs on sp.MaLoaiSanPham equals dm.MaDanhMuc into sp_dm_group
                                  from sp_dm in sp_dm_group.DefaultIfEmpty()
                                  join nh in _context.NhanHieus on sp.MaHang equals nh.MaHang into sp_nh_group
                                  from sp_nh in sp_nh_group.DefaultIfEmpty()

                                      //join dl in _context.DinhLuongs on sp.MaSanPham equals dl.MaSanPham into sp_dl_group
                                  from sp_dl in _context.DinhLuongs
                                                           .Where(dl => dl.MaSanPham.Equals(sp.MaSanPham)
                                                           && (dl.MaThuocTinh == (nameof(ProductPorpertyCode.TT07))
                                                           || dl.MaThuocTinh == (nameof(ProductPorpertyCode.TT014)))).Take(1)
                                      //join lsg in _context.LichSuGias on sp_dl.MaDinhLuong equals lsg.MaDinhLuong into dl_lsg_group
                                  from dl_lsg in _context.LichSuGias.Where(lsg => lsg.MaDinhLuong.Equals(sp_dl.MaDinhLuong))
                                                                .OrderByDescending(lsg => lsg.NgayTao.Date)
                                                                .ThenByDescending(d => d.NgayTao.TimeOfDay).Take(1)
                                  where !sp.DaXoa && yt.MaKhachHang == MaKH  && yt.MaSanPham == sp.MaSanPham && yt.TrangThai
                                  select new SanPhamVM()
                                  {
                                      MaSanPham = sp.MaSanPham,
                                      SoLuongTon = sp.SoLuongTon,
                                      TenSanPham = sp.TenSanPham,
                                      Status = sp.Status,
                                      HinhAnh = sp.HinhAnh,
                                      LoaiSanPham = sp_dm.TenDanhMuc,
                                      NhanHieu = sp_nh.TenHang,
                                      GiaBan = dl_lsg.GiaMoi,
                                      ngayTao = sp.NgayTao,
                                      MaLoai = sp.MaLoaiSanPham,
                                      //XepHang = sp_dl.MaDinhLuong
                                  }).ToListAsync();

                return data;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //public async Task<int> laySoLuongYeuThich(SanPhamYeuThich input)
        //{
        //    var duLieu = await _context.SanPhamYeuThiches.FirstOrDefault(x => x.MaSanPham == input.MaSanPham && x.MaKhachHang == input.MaKhachHang);
        //    if (duLieu != null)
        //    {
        //    }
        //}
        public async Task<bool> ThemYeuThich(SanPhamYeuThich input)
        {
            var duLieu = _context.SanPhamYeuThiches.FirstOrDefault(x => x.MaSanPham == input.MaSanPham && x.MaKhachHang == input.MaKhachHang);
            if(duLieu != null)
            {
                // sửa
                if(duLieu.TrangThai)
                {
                    await _context.Database.BeginTransactionAsync();
                    duLieu.TrangThai = false;
                    _context.SanPhamYeuThiches.Update(duLieu);
                    var rs = await _context.SaveChangesAsync();
                    await _context.Database.CommitTransactionAsync();
                    return false;
                }    
                else
                {
                    await _context.Database.BeginTransactionAsync();
                    duLieu.TrangThai = true;
                    _context.SanPhamYeuThiches.Update(duLieu);
                    var rs = await _context.SaveChangesAsync();
                    await _context.Database.CommitTransactionAsync();
                    return false;
                }    
              
            }
            else
            {
                //begin transaction
                await _context.Database.BeginTransactionAsync();
                //add
                await _context.SanPhamYeuThiches.AddAsync(input);
                var result = await _context.SaveChangesAsync();

                await _context.Database.CommitTransactionAsync();

                return true;
            }
        }
    }
}
