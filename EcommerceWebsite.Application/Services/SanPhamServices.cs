using EcommerceWebsite.Application.Interfaces;
using EcommerceWebsite.Data.EF;
using EcommerceWebsite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebsite.Application.Services
{
    public class SanPhamServices : ISanPhamServices
    {
        private readonly EcomWebDbContext context;

        public SanPhamServices(EcomWebDbContext context)
        {
            this.context = context;
        }

        public List<SanPham> GetListProduct ()
        {
            return context.SanPhams.ToList();
        }

        public bool? KiemTra(string value)
        {
            return value?.Contains("j");
        }
    }
}
