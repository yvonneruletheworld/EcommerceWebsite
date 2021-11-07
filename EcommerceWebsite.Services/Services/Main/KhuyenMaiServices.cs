using AutoMapper;
using EcommerceWebsite.Application.Pagination;
using EcommerceWebsite.Data.EF;
using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Services.Interfaces.Main;
using EcommerceWebsite.Utilities.Main;
using EcommerceWebsite.Utilities.Output.Main;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebsite.Services.Services.Main
{
    public class KhuyenMaiServices : IKhuyenMaiServices
    {
        private readonly EcomWebDbContext _context;
        private readonly IMapper _mapper;
        public KhuyenMaiServices(EcomWebDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<KhuyenMai>> LayKhuyenMai()
        {
            try
            {
                return await _context.KhuyenMais.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
