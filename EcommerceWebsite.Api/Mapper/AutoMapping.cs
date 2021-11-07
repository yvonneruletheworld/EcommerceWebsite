using AutoMapper;
using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Utilities.Output.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.Api.Mapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<SanPham, SanPhamOutput>();
        }
    }
}
