using AutoMapper;
using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Utilities.Input;
using EcommerceWebsite.Utilities.Output.Main;
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
            CreateMap<SanPhamInput, SanPham>()
                .ForMember(sp => sp.MaLoaiSanPham, sp => sp.MapFrom(spi => spi.LoaiSanPham));
        }
    }
}
