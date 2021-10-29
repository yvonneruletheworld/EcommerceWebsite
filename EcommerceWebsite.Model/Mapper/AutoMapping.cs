using AutoMapper;
using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Utilities.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.Utilities.Mapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<SanPham, SanPhamOutput>();
        }
    }
}
