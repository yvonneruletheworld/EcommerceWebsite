using AutoMapper;
using EcommerceWebsite.Application.Pagination;
using EcommerceWebsite.Data.EF;
using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Data.Enum;
using EcommerceWebsite.Data.Identity;
using EcommerceWebsite.Services.Interfaces.Main;
using EcommerceWebsite.Utilities.Input;
using EcommerceWebsite.Utilities.Output.Main;
using EcommerceWebsite.Utilities.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebsite.Services.Services.Main
{
    public class SanPhamServices : ISanPhamServices
    {
        private readonly EcomWebDbContext _context;
        private readonly IMapper _mapper;
        private readonly IBangGiaServices _bangGiaServices;

        public SanPhamServices(EcomWebDbContext context, IMapper mapper, IBangGiaServices bangGiaServices)
        {
            _context = context;
            _mapper = mapper;
            _bangGiaServices = bangGiaServices;
        }

        public async Task<PageResponse<List<SanPhamOutput>>> GetListProductByPage(PaginationFilter filter)
        {
            try
            {
                PaginationFilter validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

                var pageQuery = _context.SanPhams.Where(x => !x.DaXoa);
                var pageData = new List<SanPham>();
                Func<SanPham, object> filterSort = x => x.MaSanPham;
                
                pageData = pageQuery
                    .OrderBy(filterSort)
                    .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                    .Take(validFilter.PageSize)
                    .ToList();
              
                var result = new PageResponse<List<SanPhamOutput>>(_mapper.Map<List<SanPhamOutput>>(pageData),
                                                                   validFilter.PageNumber,
                                                                   validFilter.PageSize,
                                                                   pageData.Count());
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<SanPham> GetSanPhamTheoMa(string id, string tensanpham)
        {
            return await _context.SanPhams
                .Where(x => !x.DaXoa 
                && (x.MaSanPham == id || x.TenSanPham == tensanpham))
                .FirstOrDefaultAsync();
        }

        public async Task<bool> KiemTraGia(string prdId)
        {
            return (await _context.LichSuGias.FindAsync(prdId) == null);
        }

        public async Task<SanPhamOutput> LayChiTietSanPham(string id)
        {
            try
            {
                //lấy những thông số k phải list
                var obj = await (from sp in _context.SanPhams
                                 // Sản phẩm - Đánh giá 1 - 1
                                 //join dg in _context.DanhGiaSanPhams on (sp == null ? string.Empty : sp.MaSanPham) equals dg.MaSanPham into sp_dg_group
                                 //from sp_dg in sp_dg_group.DefaultIfEmpty()
                                 // Sản phẩm - Danh mục 1 - 1 
                                 join dm in _context.DanhMucs on (sp == null ? string.Empty : sp.MaLoaiSanPham) equals dm.MaDanhMuc into sp_dm_group
                                 from sp_dm in sp_dm_group.DefaultIfEmpty()
                                 // Sản phẩm  - Nhãn hiệu 1 - 1
                                 join nh in _context.NhanHieus on (sp == null ? string.Empty : sp.MaHang) equals nh.MaHang into sp_nh_group
                                 from sp_nh in sp_nh_group.DefaultIfEmpty()
                                 where !sp.DaXoa && sp.MaSanPham == id
                                 select new SanPhamOutput()
                                 {
                                     MaSanPham = sp.MaSanPham,
                                     SoLuongTon = sp.SoLuongTon,
                                     TenSanPham = sp.TenSanPham,
                                     Status = sp.Status,
                                     HinhAnh = sp.HinhAnh,
                                     //DanhGia = sp_dg,
                                     LoaiSanPham = sp_dm.TenDanhMuc,
                                     NhanHieu = sp_nh.TenHang,
                                     //GiaBan = gb.GiaMoi
                                 }).FirstOrDefaultAsync();
                obj.DanhGia = await _context.DanhGiaSanPhams.Where(dg => dg.MaSanPham.Equals(obj.MaSanPham)).ToListAsync();

                return obj;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<SanPhamOutput>> LaySanPham()
        {
            try
            {
                var data = await (from sp in _context.SanPhams
                                  join nhanHieu in _context.NhanHieus on sp.MaHang equals nhanHieu.MaHang
                                  join loaiSanPham in _context.DanhMucs on sp.MaLoaiSanPham equals loaiSanPham.MaDanhMuc
                                  from sp_dl in _context.DinhLuongs
                                                         .Where(dl => dl.MaSanPham.Equals(sp.MaSanPham)
                                                         && (dl.MaThuocTinh == (nameof(ProductPorpertyCode.TT07))
                                                         || dl.MaThuocTinh == (nameof(ProductPorpertyCode.TT014)))).Take(1)
                                      //join lsg in _context.LichSuGias on sp_dl.MaDinhLuong equals lsg.MaDinhLuong into dl_lsg_group
                                  from dl_lsg in _context.LichSuGias.Where(lsg => lsg.MaDinhLuong.Equals(sp_dl.MaDinhLuong))
                                                                .OrderByDescending(lsg => lsg.NgayTao.Date).Take(1)

                                  where !sp.DaXoa
                                  select new SanPhamOutput
                                  {
                                      MaSanPham = sp.MaSanPham,
                                      TenSanPham = sp.TenSanPham,
                                      SoLuongTon = sp.SoLuongTon,
                                      HinhAnh = sp.HinhAnh,
                                      NhanHieu = nhanHieu.TenHang,
                                      LoaiSanPham = loaiSanPham.TenDanhMuc,
                                      giaBan = dl_lsg.GiaMoi,
                                      MaLoai = loaiSanPham.MaDanhMuc,
                                  }).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> ThemSanPham (SanPham input)
        {
            //begin transaction
            await _context.Database.BeginTransactionAsync();

            //setup obj
            input.NgayTao = DateTime.UtcNow;
            input.DaXoa = false;
            input.Status = Data.Enum.Status.Active;

            //add

            await _context.SanPhams.AddAsync(input);
            var result = await _context.SaveChangesAsync();

            await _context.Database.CommitTransactionAsync();

            return  result > 0;
        }
        private async Task<SanPham> GetByIdAsync(string maSP)
        {
            try
            {
                var data = await _context.SanPhams.SingleOrDefaultAsync(s => s.MaSanPham == maSP);
                return data;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //Xóa sản phẩm
        public async Task<bool> SuaHoacXoaSanPham(SanPham input, bool laXoa, string editorMaSP = null)
        {
            try
            {
                await _context.Database.BeginTransactionAsync();
                var obj = await GetByIdAsync(input.MaSanPham);
                if (obj == null) return false;

                //
                if(laXoa)
                {
                    obj.DaXoa = true;
                    obj.NgayXoa = DateTime.UtcNow;
                    obj.NguoiXoa = editorMaSP;
                }
                else
                {
                    obj.NgaySuaCuoi = DateTime.UtcNow;
                    obj.NguoiSuaCuoi = editorMaSP;
                }

                // 
                _context.SanPhams.Update(obj);
                _context.Entry(obj).State = EntityState.Modified;

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

        public async Task<List<SanPhamVM>> LaySanPhamTheoLoai(int take = 1, string loaiSanPham = null,  string maSanPham = null)
        {
            try
            {
                var data = await (from sp in _context.SanPhams.OrderByDescending(s => s.NgayTao)
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
                                  where !sp.DaXoa && (string.IsNullOrEmpty(loaiSanPham) ? sp.MaSanPham == maSanPham : sp.MaLoaiSanPham == loaiSanPham)
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
                                  }).Take(take).ToListAsync();

                return data;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public async Task<List<SanPhamOutput>> laySanPhamTheoHang(string idHang)
        {
            try
            {
                var data = await(from sp in _context.SanPhams.Where(s => s.MaHang.Equals(idHang))
                                 join nhanHieu in _context.NhanHieus on sp.MaHang equals nhanHieu.MaHang
                                 join loaiSanPham in _context.DanhMucs on sp.MaLoaiSanPham equals loaiSanPham.MaDanhMuc
                                 from sp_dl in _context.DinhLuongs
                                                        .Where(dl => dl.MaSanPham.Equals(sp.MaSanPham)
                                                        && (dl.MaThuocTinh == (nameof(ProductPorpertyCode.TT07))
                                                        || dl.MaThuocTinh == (nameof(ProductPorpertyCode.TT014)))).Take(1)
                                     //join lsg in _context.LichSuGias on sp_dl.MaDinhLuong equals lsg.MaDinhLuong into dl_lsg_group
                                 from dl_lsg in _context.LichSuGias.Where(lsg => lsg.MaDinhLuong.Equals(sp_dl.MaDinhLuong))
                                                               .OrderByDescending(lsg => lsg.NgayTao.Date).Take(1)

                                 where !sp.DaXoa
                                 select new SanPhamOutput
                                 {
                                     MaSanPham = sp.MaSanPham,
                                     TenSanPham = sp.TenSanPham,
                                     SoLuongTon = sp.SoLuongTon,
                                     HinhAnh = sp.HinhAnh,
                                     NhanHieu = nhanHieu.TenHang,
                                     LoaiSanPham = loaiSanPham.TenDanhMuc,
                                     giaBan = dl_lsg.GiaMoi,
                                     MaLoai = loaiSanPham.MaDanhMuc,
                                 }).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<SanPhamOutput>> laySanPhamTheoDanhMuc(string idDanhMuc)
        {
            try
            {
                var data = await (from sp in _context.SanPhams.Where(s => s.MaLoaiSanPham.Equals(idDanhMuc))
                                  join nhanHieu in _context.NhanHieus on sp.MaHang equals nhanHieu.MaHang
                                  join loaiSanPham in _context.DanhMucs on sp.MaLoaiSanPham equals loaiSanPham.MaDanhMuc
                                  from sp_dl in _context.DinhLuongs
                                                         .Where(dl => dl.MaSanPham.Equals(sp.MaSanPham)
                                                         && (dl.MaThuocTinh == (nameof(ProductPorpertyCode.TT07))
                                                         || dl.MaThuocTinh == (nameof(ProductPorpertyCode.TT014)))).Take(1)
                                      //join lsg in _context.LichSuGias on sp_dl.MaDinhLuong equals lsg.MaDinhLuong into dl_lsg_group
                                  from dl_lsg in _context.LichSuGias.Where(lsg => lsg.MaDinhLuong.Equals(sp_dl.MaDinhLuong))
                                                                .OrderByDescending(lsg => lsg.NgayTao.Date).Take(1)

                                  where !sp.DaXoa
                                  select new SanPhamOutput
                                  {
                                      MaSanPham = sp.MaSanPham,
                                      TenSanPham = sp.TenSanPham,
                                      SoLuongTon = sp.SoLuongTon,
                                      HinhAnh = sp.HinhAnh,
                                      NhanHieu = nhanHieu.TenHang,
                                      LoaiSanPham = loaiSanPham.TenDanhMuc,
                                      giaBan = dl_lsg.GiaMoi,
                                      MaLoai = loaiSanPham.MaDanhMuc,
                                  }).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<SanPhamOutput>> timKiemSanPhamTheoTen(string idTen)
        {
            try
            {
                var data = await(from sp in _context.SanPhams.Where(s => s.TenSanPham.Contains(idTen))
                                 join nhanHieu in _context.NhanHieus on sp.MaHang equals nhanHieu.MaHang
                                 join loaiSanPham in _context.DanhMucs on sp.MaLoaiSanPham equals loaiSanPham.MaDanhMuc
                                 from sp_dl in _context.DinhLuongs
                                                        .Where(dl => dl.MaSanPham.Equals(sp.MaSanPham)
                                                        && (dl.MaThuocTinh == (nameof(ProductPorpertyCode.TT07))
                                                        || dl.MaThuocTinh == (nameof(ProductPorpertyCode.TT014)))).Take(1)
                                     //join lsg in _context.LichSuGias on sp_dl.MaDinhLuong equals lsg.MaDinhLuong into dl_lsg_group
                                 from dl_lsg in _context.LichSuGias.Where(lsg => lsg.MaDinhLuong.Equals(sp_dl.MaDinhLuong))
                                                               .OrderByDescending(lsg => lsg.NgayTao.Date).Take(1)

                                 where !sp.DaXoa
                                 select new SanPhamOutput
                                 {
                                     MaSanPham = sp.MaSanPham,
                                     TenSanPham = sp.TenSanPham,
                                     SoLuongTon = sp.SoLuongTon,
                                     HinhAnh = sp.HinhAnh,
                                     NhanHieu = nhanHieu.TenHang,
                                     LoaiSanPham = loaiSanPham.TenDanhMuc,
                                     giaBan = dl_lsg.GiaMoi,
                                     MaLoai = loaiSanPham.MaDanhMuc,
                                 }).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<SanPhamVM> laySanPhamTheoMa(string id)
        {
            try
            {
                //lấy những thông số k phải list
                SanPhamVM obj = await (from sp in _context.SanPhams
                                     // Sản phẩm - Đánh giá 1 - 1
                                     //join dg in _context.DanhGiaSanPhams on (sp == null ? string.Empty : sp.MaSanPham) equals dg.MaSanPham into sp_dg_group
                                     //from sp_dg in sp_dg_group.DefaultIfEmpty()
                                     // Sản phẩm - Danh mục 1 - 1 
                                 join dm in _context.DanhMucs on (sp == null ? string.Empty : sp.MaLoaiSanPham) equals dm.MaDanhMuc into sp_dm_group
                                 from sp_dm in sp_dm_group.DefaultIfEmpty()
                                     // Sản phẩm  - Nhãn hiệu 1 - 1
                                 join nh in _context.NhanHieus on (sp == null ? string.Empty : sp.MaHang) equals nh.MaHang into sp_nh_group
                                 from sp_nh in sp_nh_group.DefaultIfEmpty()
                                 where !sp.DaXoa && sp.MaSanPham == id
                                 select new SanPhamVM()
                                 {
                                     MaSanPham = sp.MaSanPham,
                                     SoLuongTon = sp.SoLuongTon,
                                     TenSanPham = sp.TenSanPham,
                                     Status = sp.Status,
                                     HinhAnh = sp.HinhAnh,
                                     //DanhGia = sp_dg,
                                     LoaiSanPham = sp_dm.TenDanhMuc,
                                     NhanHieu = sp_nh.TenHang,
                                     //GiaBan = gb.GiaMoi
                                 }).FirstOrDefaultAsync();

                return obj;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
