using AutoMapper;
using EcommerceWebsite.Application.Pagination;
using EcommerceWebsite.Data.EF;
using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Data.Identity;
using EcommerceWebsite.Services.Interfaces.Main;
using EcommerceWebsite.Utilities.Main;
using EcommerceWebsite.Utilities.Output.Main;
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

        public SanPhamServices(EcomWebDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

        public bool? KiemTra(string value)
        {
            return value?.Contains("j");
        }

        public async Task<ChiTietSanPhamOutput> LayChiTietSanPham(string id, bool coGiamGia)
        {
            try
            {
                var pageQuery =  (from sp in _context.SanPhams
                                       join bg in _context.LichSuGias on (sp == null ? string.Empty : sp.MaSanPham) equals bg.MaSanPham into sp_bg_group
                                       from sp_g in sp_bg_group.DefaultIfEmpty()
                                       //join dl in _context.DinhLuongs on sp_g.MaSanPham equals dl.MaSanPham into sp_dl_group
                                       //from sp_dl in sp_dl_group.DefaultIfEmpty()
                                       //join tt in _context.ThuocTinhs on sp_dl.MaThuocTinh equals tt.MaThuocTinh into dl_tt_group
                                       //from dl_tt in dl_tt_group.DefaultIfEmpty()
                                       where !sp.DaXoa && sp.MaSanPham == id
                                       select new ChiTietSanPhamOutput()
                                       {
                                           MaSanPham = sp.MaSanPham,
                                           //DonGia = sp_bg_group.FirstOrDefault().GiaMoi.ToString(), // 2
                                           //GiaBan = sp_bg_group.Skip(1).FirstOrDefault().GiaMoi.ToString(), //1
                                           //SoLuongTon = sp.SoLuongTon,
                                           //TenSanPham = sp.TenSanPham,
                                           //TinhTrang = nameof(sp.Status)
                                       }).FirstOrDefault();

                ChiTietSanPhamOutput de = new ChiTietSanPhamOutput();
                de.HinhAnhs = await _context.MauMaSanPhams.Where(x => x.MaSanPham.Equals(id))
                                                          .Select(mm => mm.HinhAnh)
                                                          .ToListAsync();


                return pageQuery;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<DanhMuc>> LayDanhMucSanPham()
        {
            try
            {
                return await _context.DanhMucs.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<List<NhanHieu>> LayNhanHieuSanPham()
        {
            try
            {
                return await _context.NhanHieus.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
