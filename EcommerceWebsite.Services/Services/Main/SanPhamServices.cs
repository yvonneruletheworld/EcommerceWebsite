using AutoMapper;
using EcommerceWebsite.Application.Pagination;
using EcommerceWebsite.Data.EF;
using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Data.Identity;
using EcommerceWebsite.Services.Interfaces.Main;
using EcommerceWebsite.Utilities.Main;
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
